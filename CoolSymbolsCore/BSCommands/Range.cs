using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class Range : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var num = environment.Pop().As<Number>();
            var arr = new BSObjects.BSArray();
            for (int i = 0; i < num.Value; i++)
                arr.Values.Add((Number)i);
            environment.Push(arr);
        }
    }
}
