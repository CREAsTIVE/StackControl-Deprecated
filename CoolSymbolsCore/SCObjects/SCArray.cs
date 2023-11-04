using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
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

        public override string StackView() => $"[{string.Join(", ", Values.Select(e => e.StackView()))}]";

        public void Call(RuntimeEnvironment environment)
        {
            foreach (var item in Values)
                item.As<ICallable>().Call(environment);
        }
    }
}
