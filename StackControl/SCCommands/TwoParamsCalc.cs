using StackControl.SCObjects;
using System.Text;

namespace StackControl.SCCommands
{
    public abstract class TwoParamsCalc : BuiltInCommand
    {
        public abstract SCNumber Calculate(SCNumber x, SCNumber y);
        public abstract SCNumber Calculate(IEnumerable<SCNumber> numbers);
        public override void Call(RuntimeEnvironment environment)
        {
            var current = environment.GetCurrent();

            if (current is SCObjects.SCArray arr)
            {
                environment.Pop();
                environment.Push(Calculate(arr.Values.Select(e => (e as SCNumber) ?? throw new BSNotANumberException())));
            }
            else if (current is SCNumber firstNumber)
            {
                environment.Pop();
                SCNumber secondNumber = (environment.GetCurrent() as SCNumber) ?? throw new BSNotANumberException();
                environment.Pop();
                environment.Push(Calculate(firstNumber, secondNumber));
            }
            else throw new SCWrongArgumentTypeException();
        }
    }

    public class Add : TwoParamsCalc
    {
        public override string RawView => "<+>";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            x.Value + y.Value;

        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            numbers.Sum(x => x.Value);
    }

    public class Mul : TwoParamsCalc
    {
        public override string RawView => "<*>";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            x.Value * y.Value;

        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            numbers.Select(n => n.Value).Aggregate((acc, v) => acc * v);
    }

    public class Sub : TwoParamsCalc
    {
        public override string RawView => "<->";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            x.Value - y.Value;

        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            throw new SCWrongArgumentTypeException();
    }

    public class ReversedSub : TwoParamsCalc
    {
        public override string RawView => "<∸>";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            y.Value - x.Value;
        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            throw new SCWrongArgumentTypeException();
	}
    public class Div : TwoParamsCalc
    {
        public override string RawView => "</>";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            x.Value / y.Value;

        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            throw new SCWrongArgumentTypeException();
    }
    public class Mod : TwoParamsCalc
    {
        public override string RawView => "<%>";
        public override SCNumber Calculate(SCNumber x, SCNumber y) =>
            x.Value % y.Value;

        public override SCNumber Calculate(IEnumerable<SCNumber> numbers) =>
            throw new SCWrongArgumentTypeException();
    }
}
