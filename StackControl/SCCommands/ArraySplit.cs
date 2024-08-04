using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class ArraySplit : BuiltInCommand
	{
		SCObject devider;
		public ArraySplit(SCObject devider)
		{
			this.devider = devider;
		}
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.Pop().As<SCArray>().MakeOriginal();
			var newValues = new SCArray();
			environment.Push(newValues);
			
			var currentSubList = new SCArray();

			foreach (var v in arr.Values)
			{
				if (v.SCEquals(devider))
				{
					newValues.Values.Add(currentSubList);
					currentSubList = new SCArray();
				}
				else
				{
					currentSubList.Values.Add(v);
				}
			}
			newValues.Values.Add(currentSubList);
		}
	}
}
