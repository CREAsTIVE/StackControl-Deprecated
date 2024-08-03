using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
    public class SCNumber : SCObject
    {
        public SCNumber(double number) => Value = number;

        public double Value;
        public override string StackView() => Value.ToString();

        public static implicit operator SCNumber(double v) => new SCNumber(v);
        public override SCObject Clone() => new SCNumber(Value);

        public override bool SCEquals(SCObject obj) =>
            obj is SCNumber num && num.Value == Value;
    }
}
