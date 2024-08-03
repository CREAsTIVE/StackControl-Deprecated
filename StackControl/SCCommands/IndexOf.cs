using StackControl;
using StackControl.BSObjects;
using StackControl.SCCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControle.SCCommands
{
    public class IndexOf : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var prep = environment.Pop().As<ICallable>();
            var arr = environment.Pop().As<SCArray>();
            
            var result = environment.Push(new SCArray()).As<SCArray>();

            for (var i = 0; i < arr.Values.Count; i++)
            {
                environment.Push(arr.Values[i]);
                prep.Call(environment);
                var prepResult = environment.Pop().As<SCNumber>();
                if (prepResult.Value != 0) result.Values.Add((SCNumber)i);
            }
        }
    }
}
