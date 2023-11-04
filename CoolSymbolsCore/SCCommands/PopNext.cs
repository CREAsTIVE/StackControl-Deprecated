using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class PopNext : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            environment.Move(1);
            environment.Pop();
        }
    }
}
