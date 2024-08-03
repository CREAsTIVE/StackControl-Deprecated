using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class DubForward : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			environment.Push(environment.GetCurrent());
			environment.Move(-1);
		}
	}
}
// [a b] a ()