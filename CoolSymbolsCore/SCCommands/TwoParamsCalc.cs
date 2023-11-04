using StackControl.BSObjects;
using System.Text;

namespace StackControl.SCCommands
{
    public abstract class TwoParamsCalc : BuiltInFunction
    {
        public abstract Number Calculate(Number x, Number y);
        public abstract Number Calculate(IEnumerable<Number> numbers);
        public override void Call(RuntimeEnvironment environment)
        {
            var current = environment.GetCurrent();

            if (current is BSObjects.SCArray arr)
            {
                environment.Pop();
                environment.Push(Calculate(arr.Values.Select(e => (e as Number) ?? throw new BSNotANumberException())));
            }
            else if (current is Number firstNumber)
            {
                environment.Pop();
                Number secondNumber = (environment.GetCurrent() as Number) ?? throw new BSNotANumberException();
                environment.Pop();
                environment.Push(Calculate(firstNumber, secondNumber));
            }
            else throw new BSWrongArgumentTypeException();
        }
    }

    public class Add : TwoParamsCalc
    {
        public override string RawView => "<+>";
        public override Number Calculate(Number x, Number y) =>
            x.Value + y.Value;

        public override Number Calculate(IEnumerable<Number> numbers) =>
            numbers.Sum(x => x.Value);
    }

    public class Mul : TwoParamsCalc
    {
        public override string RawView => "<*>";
        public override Number Calculate(Number x, Number y) =>
            x.Value * y.Value;

        public override Number Calculate(IEnumerable<Number> numbers) =>
            numbers.Select(n => n.Value).Aggregate((acc, v) => acc * v);
    }

    public class Sub : TwoParamsCalc
    {
        public override string RawView => "<->";
        public override Number Calculate(Number x, Number y) =>
            x.Value - y.Value;

        public override Number Calculate(IEnumerable<Number> numbers) =>
            throw new BSWrongArgumentTypeException();
    }
    public class Div : TwoParamsCalc
    {
        public override string RawView => "</>";
        public override Number Calculate(Number x, Number y) =>
            x.Value / y.Value;

        public override Number Calculate(IEnumerable<Number> numbers) =>
            throw new BSWrongArgumentTypeException();
    }
    public class Mod : TwoParamsCalc
    {
        public override string RawView => "<%>";
        public override Number Calculate(Number x, Number y) =>
            x.Value % y.Value;

        public override Number Calculate(IEnumerable<Number> numbers) =>
            throw new BSWrongArgumentTypeException();
    }
}
