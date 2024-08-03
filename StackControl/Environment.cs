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
        public Dictionary<string, Command> Commands;
        public Environment()
        {
            Commands = new();
            MergeCommands(DefaulCommands);
            MergeDefines(DefaultAliases);
        }

        public static Dictionary<string, Command> DefaulCommands = new()
        {
            { "+", new Add() },
            { "-", new Sub() },
            { "*", new Mul() },
            { "/", new Div() },
            { "%", new Mod() },
            { ",", new Pop() },
            { ":", new Dub() },
            { "←", new Move(-1) },
            { "→", new Move(1) },
            { "⇡", new SCCommands.Range() },
            { "!", new CommandContainerCaller() },
            { "packfn", new CommandsContainerArrayPacker() },
            { "⇆", new SwapDouble()},
            { "⦽", new Unpack()},
            { "↹", new ArrayDoubleSwap() },
            { "?", new InlineIf()},
            { "⟺", new ArrayReverse() },
            { "∵", new Each() },
            { "⇥", new ArrayPut() },
            { "⇤", new ArrayPush() },
            { "⟄", new ArrayPop() },
            { "⟃", new ArrayPopFirst() },
            { "⟹", new Pop.Next() },
            { "⟸", new Pop.Shift() },
            { "⊚", new SelectWhere() },
            { "⊗", new IndexOf() },

            { "=", new Equals() },
            { "<", new Smaller() },
            { ">", new Bigger() },
            { "≤", new SmallerOrEquals() },
            { "≥", new BiggerOrEquals() },
            { "↥", new Maximum() },

            { "∪", new Union() },

            { "∅", new StackPusher(new SCEmptyArray()) }
        };

        public static Dictionary<string, string> DefaultAliases = new()
        {
            { "mvl", "←" },
            { "mvr", "→" },
            { "range", "⇡" },
            { "swap", "⇆" },
            { "unpack", "⦽" },
            { "arrswap", "↹" },
            { "reverse", "⟺" },

            { "each", "∵" },
            { "union", "∪" },

            { "aput", "⇥" },
            { "apush", "⇤" },
            { "apop", "⟄" },
            { "apopfirst", "⟃" },
            { "aempty", "∅" },

            { "popnext", "⟹" },
            { "popbefore", "⟸" },
            { "where", "⊚" },
            { "indexof", "⊗" },
            { "soreq", "≤" },
            { "boreq", "≥" },
            { "max", "↥" },
        };

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
