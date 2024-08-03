using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class InlineIfElse : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            environment.Pop().As<ICallable>().Call(environment);
            
            if (environment.Pop().As<SCNumber>().Value != 0)
            {
                environment.Move(-1);
                environment.Pop();
                environment.Move(1);
                environment.Pop().As<ICallable>().Call(environment);
            }
            else
            {
                environment.Pop();
                environment.Pop().As<ICallable>().Call(environment);
            }
        }
    }

    public class ExecuteWhen : BuiltInCommand
    {
		public override void Call(RuntimeEnvironment environment)
		{
            var action = environment.Pop().As<ICallable>();
            if (environment.Pop().As<SCNumber>().Value != 0)
                action.Call(environment);
		}
	}
}
