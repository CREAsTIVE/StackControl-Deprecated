using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class Print : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment) =>
			environment?.IO?.PrintLine(environment.Pop().As<SCString>().StringValue);
	}

	public class Read : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment) =>
			environment.Push(new SCString(environment?.IO?.ReadLine() ?? throw new Exception("No IO defined exception")));
	}
}
