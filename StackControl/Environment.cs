using StackControl.SCObjects;
using StackControl.SCCommands;
using StackControle.SCCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public class Environment
    {
        public Dictionary<string, string> Aliases = new();
        public Dictionary<string, Command> Commands = new();

        public static Environment Default
        {
            get
            {
				var env = new Environment();

                // Math
                env.Command(new Add(), "+");
                env.Command(new Sub(), "-");
                env.Command(new ReversedSub(), "∸");
                env.Command(new Mul(), "÷", "div");
                env.Command(new Mod(), "%"); // Replace to % of value

                env.Command(new StackPusher(new SCNumber(double.PositiveInfinity)), "∞", "inf");

                // Stack
                env.Command(new Move(-1), "←", "mvl");
                env.Command(new Move(1), "→", "mvr");
                env.Command(new Pop(), ","); // change symbol?
                env.Command(new Pop.ShiftR(), "⟹", "shiftr");
                env.Command(new Pop.ShiftL(), "⟸", "shiftl");
                env.Command(new Duplicate(), ":");
                env.Command(new QuadroDuplicate(), "⁞", "quadrodup", "qdup");
                env.Command(new Swap(), "⇆", "swap");

				// Arrays
				env.Command(new StackPusher(new SCEmptyArray()), "∅", "aempty");
				env.Command(new SCCommands.Range(), "⇡", "range");
				env.Command(new ArraySplit(new SCChar(' ')), "⁜", "split"); // change icon

				env.Command(new ArrayUnpack(), "⦽", "unpack");

                env.Command(new ArraySwap(), "↹", "aswap");
                env.Command(new ArrayReverse(), "🗘", "areverse");
                env.Command(new ArrayPut(), "⇥", "aput");
                env.Command(new ArrayPush(), "⇤", "apush");
                env.Command(new ArrayPop(), "⟄", "apop");
                env.Command(new ArrayPopFirst(), "⟃", "apopfirst", "apopf");
                env.Command(new ShiftArrayRight(), "↶", "aloopr");
                env.Command(new ShiftArrayLeft(), "↷", "aloopl");

                env.Command(new ArraySelectWhere(), "⊚", "where");
                env.Command(new Each(), "∵", "each");
                env.Command(new NoPickEach(), "∴", "neach");
				env.Command(new Union(), "∪", "union");
				env.Command(new ArrayProduct(), "∏", "product");

				env.Command(new IndexOf(), "⊗", "indexof");
				env.Command(new Maximum(), "↥", "max");
				env.Command(new ArrayLength(), "⬌", "alen");

				env.Command(new StackPusher(new SCListOpenGeneratorCloser()), "⟧", "areverseclose");
				env.Command(new ListOpenGenerator(), "⟦", "areverseopen");

				// Function
				env.Command(new CommandContainerCaller(), "!"); // change icon?
                env.Command(new CommandsContainerArrayPacker(), "packfn");

                env.Command(new Repeat(), "⟲", "repeat");

                // Conditions
                env.Command(new IfElseCondition(), "⁇", "ifelse", "ie");
                env.Command(new IfCondition(), "?");

				env.Command(new Equals(), "=");
				env.Command(new Smaller(), "<");
				env.Command(new Bigger(), ">");
				env.Command(new SmallerOrEquals(), "≤", "leq");
				env.Command(new BiggerOrEquals(), "≥", "heq");

				// IO
				env.Command(new Read(), "R", "read");
				env.Command(new Print(), "W", "write");

				return env;
			}
        }
        public Environment()
        {

        }

        void Command(Command commandExecutor, string commandName, params string[] aliases)
        {
            Commands[commandName] = commandExecutor;
            aliases.Each(alias => Aliases[alias] = commandName);
            commandExecutor.CommandIcon = commandName;
        }

        public string? GetByAlias(string key)
        {
            if (Aliases.TryGetValue(key, out var res))
                return res;
            return null;
        }

        public void MergeDefines(Dictionary<string, string> aliases) =>
            Aliases = Aliases.Concat(aliases).ToDictionary(e => e.Key, e => e.Value);

        public void MergeCommands(Dictionary<string, Command> commands) =>
            Commands = Commands.Concat(commands).ToDictionary(e => e.Key, e => e.Value);
    }
}
