using StackControl;
using StackControl.SCObjects;
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
                environment.Push(item.Clone());
                method.Call(environment);
                var res = environment.Pop().As<SCNumber>();
                if (res.Value != 0)
                    newArr.Values.Add(item);
            }
        }
    }
}
