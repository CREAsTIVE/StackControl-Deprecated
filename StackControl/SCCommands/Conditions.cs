using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class IfElseCondition : BuiltInCommand
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

    public class IfCondition : BuiltInCommand
    {
		public override void Call(RuntimeEnvironment environment)
		{
            var action = environment.Pop().As<ICallable>();
			if (environment.Pop() is not SCNumber num || num.Value != 0)
				action.Call(environment);
		}
	}

    public class IfNotCondition : BuiltInCommand // ¿
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var action = environment.Pop().As<ICallable>();
			if (environment.Pop() is SCNumber num && num.Value == 0)
				action.Call(environment);
		}
	}
}
