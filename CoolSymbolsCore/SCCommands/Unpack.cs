using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Unpack : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.Pop().As<BSObjects.SCArray>();
            foreach (var item in arr.Values) 
                environment.Push(item);
        }
    }
}
