using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Unpack : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.Pop().As<SCArray>();
            foreach (var item in arr.Values) 
                environment.Push(item);
        }
    }
}
