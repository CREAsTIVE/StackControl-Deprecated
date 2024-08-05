using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class NumberUnaryOperation : BuiltInCommand
	{
		public delegate double UnaryOperation(double value);
		UnaryOperation operation;
		public NumberUnaryOperation(UnaryOperation op) => operation = op;
		
		public override void Call(RuntimeEnvironment environment)
		{
			var stackValue = environment.Pop();
			if (stackValue is SCNumber number)
				environment.Push((SCNumber)operation(number.Value));
			else if (stackValue is SCArray array)
				environment.Push(new SCArray(array.Values.Select<SCObject, SCObject>(e => (SCNumber)operation(e.As<SCNumber>().Value)).ToList()));
		}
	}
}
