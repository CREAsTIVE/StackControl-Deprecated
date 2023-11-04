using StackControl.SCCommands;
using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StackControl
{
    public class Compilator
    {
        Environment enivroment;
        public Compilator(Environment enivroment)
        {
            this.enivroment = enivroment;
        }

        public Compilator() : this(new Environment())
        {

        }

        static string groupedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789\"-.";
        public static string[] SepOnTokens(string source)
        {
            LinkedList<string> tokens = new();
            for (var si = 0; si < source.Length; si++)
            {
                if (groupedSymbols.Contains(source[si]))
                {
                    string newToken = "";
                    for (; si < source.Length && groupedSymbols.Contains(source[si]); si++)
                        newToken += source[si];
                    tokens.AddLast(newToken);
                    si--;
                    continue;
                }
                else if (char.IsSeparator(source[si]))
                    continue;
                tokens.AddLast($"{source[si]}");
            }
            return tokens.ToArray();
        }

        public void UnpuckAliases(string[] source)
        {
            for (var i = 0; i < source.Length; i++)
                if (enivroment.Aliases.TryGetValue(source[i], out var alias))
                    source[i] = alias;
        }

        static Regex AnyNumberRegex = new(@"^-?\d+(\.\d+)?$");
        static Regex AnyStringRegex = new(@"^(""|')(.*)\1$");

        public Command[] GenerateCommands(string[] tokens)
        {
            return ParseCommands((TokenReader<string>)tokens);
        }

        public Command ParseCommand(string token, TokenReader<string> tokenReader)
        {
            var strMatch = AnyStringRegex.Match(token.ToString());

            if (token == "#")
                return new StackPusher(new CommandContainer(ParseCommand(tokenReader.GetNext(), tokenReader)));

            else if (AnyNumberRegex.IsMatch(token))
                return new StackPusher(new Number(double.Parse(token)));

            else if (strMatch.Success)
                return new StackPusher(new BSObjects.String(strMatch.Groups[2].Value));

            else if (token == "[") // Встроенная обязательная комманда
                return new StackPusher(new ListOpener());

            else if (token == "]") // Встроенная обязательная команда
                return new ListGenerator();

            else if (enivroment.Commands.TryGetValue(token, out var namedComand))
                return namedComand;

            throw new NotImplementedException();
        }

        public Command[] ParseCommands(TokenReader<string> reader)
        {
            LinkedList<Command> result = new();
            while (reader.HasNext())
            {
                var token = reader.GetNext();
                if (token == ")") break;
                else if (token == "(")
                {
                    var methodCommands = ParseCommands(reader);
                    result.AddLast(new StackPusher(new ListOpener()));
                    foreach (Command cmd in methodCommands)
                        result.AddLast(new StackPusher(new CommandContainer(cmd)));
                    result.AddLast(new ListGenerator());
                } else
                    result.AddLast(ParseCommand(token, reader));
            }
            return result.ToArray();
        }

        /*public Command[] GenerateCommands(string[] commands)
        {
            LinkedList<Command> result = new();
            int stackPlace = 0;

            foreach (var command in commands)
            {
                bool genToken = true;
                var strMatch = AnyStringRegex.Match(command.ToString());

                if (command == "#")
                {
                    stackPlace++;
                    genToken = false;
                }
                    

                if (genToken)
                {
                    if (AnyNumberRegex.IsMatch(command))
                        result.AddLast(new StackPusher(new Number(double.Parse(command))));

                    else if (strMatch.Success)
                        result.AddLast(new StackPusher(new BSObjects.String(strMatch.Groups[2].Value)));

                    else if (command == "[") // Встроенная обязательная комманда
                        result.AddLast(new StackPusher(new ListOpener()));

                    else if (command == "]") // Встроенная обязательная команда
                        result.AddLast(new ListGenerator());

                    else if (enivroment.Commands.TryGetValue(command, out var namedComand))
                        result.AddLast(namedComand);

                    else
                        throw new("Unknow command");
                }   

                if (command != "#")
                    for (; stackPlace > 0; stackPlace--)
                        result.AddLast(new StackPusher(new CommandContainer(result.Last?.Value ?? throw new())));
            }

            return result.ToArray();
        }*/

        public static void Run(Command[] commands, RuntimeEnvironment runtimeEnvironment)
        {
            foreach (var command in commands)
                command.Call(runtimeEnvironment);
        }
    }
}
