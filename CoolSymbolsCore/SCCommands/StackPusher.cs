using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    internal class StackPusher : BuiltInFunction
    {
        public override string RawView => $"↓{Value.StackView()}";
        public StackPusher(SCObject value) => Value = value;
        public SCObject Value;
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(Value);
    }
}
