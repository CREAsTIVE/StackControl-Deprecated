using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class Unpack : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.Pop().As<BSObjects.BSArray>();
            foreach (var item in arr.Values) 
                environment.Push(item);
        }
    }
}
