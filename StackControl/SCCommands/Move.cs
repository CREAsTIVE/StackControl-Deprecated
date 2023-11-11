using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Move : BuiltInCommand
    {
        public Move(int val) => this.val = val;
        int val;
        public override void Call(RuntimeEnvironment environment) => environment.Move(val);
    }
}
