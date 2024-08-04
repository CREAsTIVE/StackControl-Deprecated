using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
	public class ArrayProduct : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arg = environment.Pop();
			int count;
			SCArray arr;

			if (arg is SCNumber num)
			{
				arr = environment.Pop().As<SCArray>();
				count = (int)num.Value;
			}
			else
			{
				arr = arg.As<SCArray>();
				count = arr.Values.Count;
			}

			var newList = new SCArray();

			foreach (var item in product(arr.Values, count))
			{
				var currentNewList = new SCArray();
				currentNewList.Values = item;
				newList.Values.Add(currentNewList);
			}

			environment.Push(newList);
		}
		List<List<SCObject>> product(IEnumerable<SCObject> objects, int n)
		{
			var newList = new List<List<SCObject>>();
			product(objects, [], newList, n);
			return newList;
		}
		void product(IEnumerable<SCObject> objects, IEnumerable<SCObject> currentObjects, List<List<SCObject>> finalList, int n=0)
		{
			if (n <= 1)
				objects.Select<SCObject, List<SCObject>>(obj => [.. currentObjects, obj]).Each(finalList.Add);
			else
				objects.Each(obj => product(objects, [..currentObjects, obj], finalList, n-1));
		}
	}
}
