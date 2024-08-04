using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCObjects
{
    public class SCChar : SCObject
    {
        public char value;
        public SCChar(char value) => this.value = value;
        public override bool SCEquals(SCObject other) => other switch
        {
            SCChar ch => value == ch.value,
            SCNumber id => value == id.Value,
            _ => false
        };

        public override string StackView() => $"'{value}'";
		public override SCObject Clone() => new SCChar(value);
	}
    public class SCString : SCArray
    {
        public SCString(string value) => Values = value.Select<char, SCObject>(ch => new SCChar(ch)).ToList();
        public SCString(SCArray charrArr) => Values = new List<SCObject>(charrArr.Values);

        public string StringValue => Values.Select(element => element.As<SCChar>().value).JoinEnumerable("");


		public override string StackView() => $"\"{StringValue}\"";

        public override SCObject Clone() => new SCString(this);

        // public static implicit operator SCString(SCArray arr) => 
    }
}
