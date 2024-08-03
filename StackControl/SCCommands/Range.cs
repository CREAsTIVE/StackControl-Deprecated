using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Range : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var num = environment.Pop().As<SCNumber>();
            var arr = new BSObjects.SCArray();
            for (int i = 0; i < num.Value; i++)
                arr.Values.Add((SCNumber)i);
            environment.Push(arr);
        }
    }
}
