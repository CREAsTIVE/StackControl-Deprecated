using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Each : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var callable = environment.Pop().As<ICallable>();
            var array = environment.GetCurrent().As<SCArray>();

            array.MakeOriginal();
            for (var i = 0; i < array.Values.Count; i++)
            {
                environment.Push(array.Values[i]);
                callable.Call(environment);
                var newValue = environment.Pop();
                array.Values[i] = newValue;
            }
        }
    }
}
