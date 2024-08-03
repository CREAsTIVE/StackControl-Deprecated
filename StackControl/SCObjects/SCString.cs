using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
    public class SCString : SCObject
    {
        public SCString(string value) => this.Value = value;
        public string Value;

        public override string StackView() => $"\"{Value}\"";

        public override SCObject Clone() => new SCString(Value);

        public override bool SCEquals(SCObject other) =>
            other is SCString str && str.Value == Value;
    }
}
