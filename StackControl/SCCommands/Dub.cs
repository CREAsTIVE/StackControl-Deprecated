using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class Dub : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) => environment.Push(environment.GetCurrent().Clone());
    }
    public class QuadroDublication : BuiltInCommand
    {
		public override void Call(RuntimeEnvironment environment)
		{
			var e2 = environment.GetCurrent().Clone();
            environment.Move(-1);
            var e1 = environment.GetCurrent().Clone();
            environment.Move(1);
            environment.Push(e1);
            environment.Push(e2);
		}
	}
}
