using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class ArrayDoubleSwap : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<BSArray>();
            arr.MakeOriginal();
            var temp = arr.Values.Last();
            arr.Values[arr.Values.Count-1] = arr.Values[arr.Values.Count-2];
            arr.Values[arr.Values.Count-2] = temp;
        }
    }
}
