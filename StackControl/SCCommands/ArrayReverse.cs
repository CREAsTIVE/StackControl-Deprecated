using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class ArrayReverse : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) => 
            environment.GetCurrent().As<SCArray>().MakeOriginal().Values.Reverse();
    }
}
