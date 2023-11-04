using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Dub : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment) => environment.Push(environment.GetCurrent().Clone());
    }
}
