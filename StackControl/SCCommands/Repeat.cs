using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class Repeat : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var invoke = environment.Pop().As<ICallable>();
			var times = environment.Pop().As<SCNumber>();

			for (var i = 0; i < times.Value; i++)
				invoke.Call(environment);
		}
	}
}
