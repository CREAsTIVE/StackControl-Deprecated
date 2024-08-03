using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class ArrayPop : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
            environment.Push(arr.Values[arr.Values.Count - 1]);
            arr.Values.RemoveAt(arr.Values.Count - 1);
        }
    }
    public class ArrayPopFirst : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
			environment.Push(arr.Values[0]);
			arr.Values.RemoveAt(0);
        }
    }

}
