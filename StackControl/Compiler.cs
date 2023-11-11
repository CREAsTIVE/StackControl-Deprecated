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
                if (token is Tokens.String str)
                    commands.AddLast(new StackPusher(new BSObjects.String(str.value)));
                else if (token is Tokens.Number num)
                    commands.AddLast(new StackPusher(new Number(num.value)));
                else if (token is Tokens.Command cmd)
                    commands.AddLast(environment.Commands[cmd.name]);
                else if (token is Tokens.ListOpener)
                    commands.AddLast(new StackPusher(new ListOpener()));
                else if (token is Tokens.ListCloser)
                    commands.AddLast(new ListGenerator());
                else if (token is Tokens.FunctionOpener)
                {
                    commands.AddLast(new StackPusher(new ListOpener()));
                    commands = new LinkedList<Command>(commands.Concat(ParseCommands(tokens).Select(e => new StackPusher(new CommandContainer(e)))));
                    commands.AddLast(new ListGenerator());
                }
                else if (token is Tokens.FunctionCloser)
                    break;
            }
            return commands;
        }

        public static void Run(IEnumerable<Command> commands, RuntimeEnvironment runtimeEnvironment)
        {
            foreach (var command in commands)
                command.Call(runtimeEnvironment);
        }
    }
}
