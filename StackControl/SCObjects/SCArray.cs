using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
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
    public class SCArray : SCArray<SCObject> { }
    public class SCArray<T> : SCObject, ICallable where T : SCObject
    {
        public bool Original = true;

        public List<T> Values;
        public SCArray(List<T> values) { Values = values; Original = false; }
        public SCArray() { Values = new(); }
        public SCArray(SCArray<T> old)
        {
            Values = old.Values;
            Original = false;
        }

        // Call before update values
        public SCArray<T> MakeOriginal()
        {
            if (Original)
                return this;
            Original = true;
            Values = new List<T>(Values);
            return this;
        }

        public override SCObject Clone() => new SCArray<T>(Values);

        public override string StackView() => $"[{string.Join(" ", Values.Select(e => e.StackView()))}]";

        public new void Call(RuntimeEnvironment environment)
        {
            foreach (var item in Values)
                item.As<ICallable>().Call(environment);
        }

        public override bool SCEquals(SCObject other)
        {
            if (other is SCEmptyArray) return Values.Count == 0;
            else if (other is SCArray<T> arr) {
                if (arr.Values == Values) return true;
                if (arr.Values.Count == Values.Count)
                {
                    for (var i = 0; i < arr.Values.Count; i++)
                        if (!arr.Values[i].SCEquals(Values[i]))
                            return false;
                    return true;
                }
            }
            return false;
        }
    }
}
