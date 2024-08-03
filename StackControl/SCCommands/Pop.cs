using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Pop : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) => environment.Pop();
		public class Next : BuiltInCommand
		{
			public override void Call(RuntimeEnvironment environment)
			{
				environment.Move(1);
				environment.Pop();
			}
		}
		public class Shift : BuiltInCommand
		{
			public override void Call(RuntimeEnvironment environment)
			{
				environment.Move(-1);
				environment.Pop();
				environment.Move(1);
			}
		}
	}
    
}
