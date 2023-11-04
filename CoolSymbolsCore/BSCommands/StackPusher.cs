using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    internal class StackPusher : BuiltInFunction
    {
        public override string RawView => $"↓{Value.StackView()}";
        public StackPusher(BSObject value) => Value = value;
        public BSObject Value;
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(Value);
    }
}
