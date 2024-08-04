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
            var onFalse = environment.Pop().As<ICallable>();
            var onTrue = environment.Pop().As<ICallable>();
            if (environment.Pop().As<SCNumber>().Value != 0)
                onTrue.Call(environment);
            else
                onFalse.Call(environment);
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
