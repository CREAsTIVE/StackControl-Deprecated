using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StackControl.SCObjects
{
    public class SCEmptyArray : SCObject // Represents empty array
    {
        public override string StackView() => "∅";
		public override bool SCEquals(SCObject other)
		{
            if (other is SCArray arr)
                return arr.Values.Count == 0;
            return base.SCEquals(other);
		}
	}
    public class SCArray : SCObject, ICallable
    {
        public bool Original = true;

        public List<SCObject> Values;
        public SCArray(List<SCObject> values) { Values = values; Original = false; }
        public SCArray() { Values = new(); }
        public SCArray(SCArray old)
        {
            Values = old.Values;
            Original = false;
        }

        // Call before update values
        public SCArray MakeOriginal()
        {
            if (Original)
                return this;
            Original = true;
            Values = new List<SCObject>(Values);
            return this;
        }

        public override SCObject Clone() => new SCArray(Values);

        public override string StackView() => $"[{string.Join(" ", Values.Select(e => e.StackView()))}]";

        public new void Call(RuntimeEnvironment environment)
        {
            foreach (var item in Values)
                item.As<ICallable>().Call(environment);
        }

        public override bool SCEquals(SCObject other)
        {
            if (other is SCEmptyArray) return Values.Count == 0;
            else if (other is SCArray arr) {
                if (arr.Values == Values) return true;
                if (arr.Values.Count == Values.Count)
                {
                    for (var i = 0; i < arr.Values.Count; i++)
                        if (!arr.Values[i].SCEquals(Values[i]))
                            return false;
                    return true;
                }
            }
            return other.SCEquals(Values[0]);
        }
    }
}
