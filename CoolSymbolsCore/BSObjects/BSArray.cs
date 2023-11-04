using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSObjects
{
    public class BSArray : BSObject, ICallable
    {
        public bool Original = true;

        public List<BSObject> Values;
        public BSArray(List<BSObject> values) { Values = values; Original = false; }
        public BSArray() { Values = new(); }
        public BSArray(BSArray old)
        {
            Values = old.Values;
            Original = false;
        }

        // Call before update values
        public BSArray MakeOriginal()
        {
            if (Original)
                return this;
            Original = true;
            Values = new List<BSObject>(Values);
            return this;
        }

        public override BSObject Clone() => new BSArray(Values);

        public override string StackView() => $"[{string.Join(", ", Values.Select(e => e.StackView()))}]";

        public void Call(RuntimeEnvironment environment)
        {
            foreach (var item in Values)
                item.As<ICallable>().Call(environment);
        }
    }
}
