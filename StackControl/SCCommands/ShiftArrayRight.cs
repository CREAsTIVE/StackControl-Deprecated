using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class ShiftArrayRight : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>();
			var l = arr.Values.Last();
			arr.Values.RemoveAt(arr.Values.Count-1);
			arr.Values.Insert(0, l);
		}
	}

	public class ShiftArrayLeft : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>();
			var l = arr.Values.First();
			arr.Values.RemoveAt(0);
			arr.Values.Add(l);
		}
	}
}
