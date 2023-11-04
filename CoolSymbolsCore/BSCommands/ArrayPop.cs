using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class ArrayPop : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<BSArray>().MakeOriginal();
            arr.Values.RemoveAt(arr.Values.Count - 1);
        }
    }
    public class ArrayPopFirst : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<BSArray>().MakeOriginal();
            arr.Values.RemoveAt(0);
        }
    }

}
