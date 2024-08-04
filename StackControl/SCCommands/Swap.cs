using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Swap : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var a = environment.Pop();
            var b = environment.Pop();
            environment.Push(a);
            environment.Push(b);
        }
    }
}
