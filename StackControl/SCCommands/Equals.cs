using StackControl;
using StackControl.SCObjects;
using StackControl.SCCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControle.SCCommands
{
    public abstract class NumberComparatorCommand : BuiltInCommand
    {
        public abstract bool Compare(double n1, double n2);
        public override void Call(RuntimeEnvironment environment)
        {
            var obj1 = toDouble(environment.Pop());
            var obj2 = toDouble(environment.Pop());

            environment.Push(Compare(obj1, obj2) ? (SCNumber)1 : (SCNumber)0);
        }

        double toDouble(SCObject obj) => obj switch
        {
            SCNumber number => number.Value,
			StackControl.SCObjects.SCString str => str.Values.Count,
			SCArray arr => arr.Values.Count,
            _ => throw new NotImplementedException()
        };
    }
    public class Bigger : NumberComparatorCommand
    {
        public override bool Compare(double n1, double n2) =>
            n1 > n2;
    }
    public class Smaller : NumberComparatorCommand
    {
        public override bool Compare(double n1, double n2) =>
            n1 < n2;
    }
    public class BiggerOrEquals : NumberComparatorCommand
    {
        public override bool Compare(double n1, double n2) =>
            n1 >= n2;
    }
    public class SmallerOrEquals : NumberComparatorCommand
    {
        public override bool Compare(double n1, double n2) =>
            n1 <= n2;
    }

    public class Equals : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(environment.Pop().SCEquals(environment.Pop()) ? (SCNumber)1 : (SCNumber)0);
    }
    
}
