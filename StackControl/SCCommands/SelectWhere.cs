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
    public class SelectWhere : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var method = environment.Pop().As<ICallable>();
            var arr = environment.Pop().As<SCArray>();
            var newArr = environment.Push(new SCArray()).As<SCArray>();

            foreach (var item in arr.Values)
            {
                environment.Push(item);
                method.Call(environment);
                var res = environment.Pop().As<Number>();
                if (res.Value != 0)
                    newArr.Values.Add(item);
            }
        }
    }
}
