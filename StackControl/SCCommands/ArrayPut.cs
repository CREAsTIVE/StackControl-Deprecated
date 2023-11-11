using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class ArrayPut : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
            if (arr.Values.Count == 0) throw new StackOverflowException();
            environment.Stack.AddLast(arr.Values.Last());
            arr.Values.RemoveAt(arr.Values.Count - 1);
        }
    }
}
