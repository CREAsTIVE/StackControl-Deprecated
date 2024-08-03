using StackControl.SCCommands;
using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StackControl
{
    public class Compiler
    {
        public Environment environment;
        public Tokenizer tokenizer;
        public Compiler(Environment enivroment)
        {
            this.environment = enivroment;
            tokenizer = new(enivroment);
        }

        public Compiler() : this(new Environment())
        {

        }

        public IEnumerable<Command> Compile(string v) => ParseCommands(tokenizer.Parse(v).ToArray());
        

        public LinkedList<Command> ParseCommands(TokenReader<Token> tokens)
        {
            LinkedList<Command> commands = new LinkedList<Command>();

            while (tokens.HasNext)
            {
                var token = tokens.GetNext();
                if (token is Tokens.FunctionCloser)
                    break;
                else if (token is Tokens.FunctionOpener)
                {
                    commands.AddLast(new StackPusher(new SCListOpener()));
                    var subCommands = ParseCommands(tokens);
                    foreach (var subCommand in subCommands)
                        commands.AddLast(new StackPusher(new SCCommandContainer(subCommand)));
                    commands.AddLast(new ListGenerator());
                }
                else
                    commands.AddLast(ParseSingleCommand(tokens, token));
            }
            return commands;
        }

        public Command ParseSingleCommand(TokenReader<Token> tokens, Token currentToken) =>
            currentToken switch
            {
                Tokens.String str => new StackPusher(new BSObjects.SCString(str.value)),
                Tokens.Number num => new StackPusher(new SCNumber(num.value)),
                Tokens.Command cmd => environment.Commands[cmd.name],
                Tokens.ListOpener => new StackPusher(new SCListOpener()),
                Tokens.ListCloser => new ListGenerator(),
                Tokens.FunctionMark => new StackPusher(new SCCommandContainer(ParseSingleCommand(tokens, tokens.GetNext()))),
                _ => throw new NotImplementedException()
            };

        public static void Run(IEnumerable<Command> commands, RuntimeEnvironment runtimeEnvironment)
        {
            foreach (var command in commands)
                command.Call(runtimeEnvironment);
        }
    }
}
