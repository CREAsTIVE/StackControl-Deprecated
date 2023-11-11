using StackControl;
using StackControl.BSObjects;
using StackControl.SCCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControle.SCCommands
{
    public abstract class Comparator : BuiltInCommand
    {
        public abstract bool Compare(double n1, double n2);
        public override void Call(RuntimeEnvironment environment)
        {
            var obj1 = toDouble(environment.Pop());
            var obj2 = toDouble(environment.Pop());

            environment.Push(Compare(obj1, obj2) ? (Number)1 : (Number)0);
        }

        double toDouble(SCObject obj) => obj switch
        {
            Number number => number.Value,
            SCArray arr => arr.Values.Count,
            StackControl.BSObjects.String str => str.Value.Length,
            _ => throw new NotImplementedException()
        };
    }
    public class Bigger : Comparator
    {
        public override bool Compare(double n1, double n2) =>
            n1 > n2;
    }
    public class Smaller : Comparator
    {
        public override bool Compare(double n1, double n2) =>
            n1 < n2;
    }
    public class BiggerOrEquals : Comparator
    {
        public override bool Compare(double n1, double n2) =>
            n1 >= n2;
    }
    public class SmallerOrEquals : Comparator
    {
        public override bool Compare(double n1, double n2) =>
            n1 <= n2;
    }

    public class Equals : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(environment.Pop().SCEquals(environment.Pop()) ? (Number)1 : (Number)0);
    }
    
}
