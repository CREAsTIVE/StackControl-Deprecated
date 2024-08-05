using StackControl.SCObjects;
using System.Text;

namespace StackControl.SCCommands
{
    public class TwoParamsOperation : BuiltInCommand
    {
        public delegate double CalculateFn(double x, double y);
        CalculateFn fn;
        public TwoParamsOperation(CalculateFn fn) => this.fn = fn;
        public override void Call(RuntimeEnvironment environment)
        {
            var current = environment.Pop();
            if (current is SCNumber number)
                environment.Push((SCNumber)fn(number.Value, environment.Pop().As<SCNumber>().Value));
            else if (current is SCArray array)
				environment.Push(
					array.Values.Reverse<SCObject>().Skip(1)
					.Aggregate(
                        array.Values.Last().As<SCNumber>(), 
                        (acc, val) => fn(acc.As<SCNumber>().Value, val.As<SCNumber>().Value)
                    )
				);
        }
    }
}
