using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
    public class Number : SCObject
    {
        public Number(double number) => Value = number;

        public double Value;
        public override string StackView() => Value.ToString();

        public static implicit operator Number(double v) => new Number(v);
        public override SCObject Clone() => new Number(Value);

        public override bool SCEquals(SCObject obj) =>
            obj is Number num && num.Value == Value;
    }
}
