using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	internal class Union : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>();
			arr.MakeOriginal();

			var newArrValues = new List<SCObject>(arr.Values.Count);

			foreach (var item in arr.Values)
			{
				if (!newArrValues.Any(arrValue => arrValue.SCEquals(item)))
					newArrValues.Add(item);
			}

			arr.Values = newArrValues;
		}
	}
	public class Join : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr1 = environment.Pop().As<SCArray>();
			var arr2 = environment.Pop().As<SCArray>();

			arr1.MakeOriginal().Values = arr1.Values.Concat(arr2.Values).ToList();
			environment.Push(arr1);
		}
	}
}
