using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    internal class ListGenerator : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            SCObjects.SCArray array = new();
            var current = environment.GetCurrent();
            while (!(current is SCObjects.SCListOpener))
            {
                array.Values.Add(current);
                environment.Pop();
                current = environment.GetCurrent();
            }
            environment.Pop();
            array.Values.Reverse();
            environment.Push(array);
        }
    }

    public class ListOpenGenerator : BuiltInCommand
    {
		public override void Call(RuntimeEnvironment environment)
		{
			SCObjects.SCArray array = new();
			var current = environment.GetCurrent();
			while (!(current is SCObjects.SCListOpenGeneratorCloser))
			{
				array.Values.Add(current);
				environment.Pop();
                environment.Move(1);
				current = environment.GetCurrent();
			}
			environment.Pop();
			environment.Push(array);
		}
	}
}
