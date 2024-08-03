using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class ArrayLength : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment) =>
			environment.Push((SCNumber)environment.Pop().As<SCArray>().Values.Count);
	}
}
