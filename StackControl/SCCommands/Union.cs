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
			var arr = environment.GetCurrent().As<SCArray<SCObject>>();
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
}
