using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
    public class String : SCObject
    {
        public String(string value) => this.Value = value;
        public string Value;

        public override string StackView() => $"\"{Value}\"";

        public override SCObject Clone() => new String(Value);

        public override bool SCEquals(SCObject other) =>
            other is String str && str.Value == Value;
    }
}
