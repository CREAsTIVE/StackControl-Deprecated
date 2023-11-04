using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class ArrayReverse : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment) => 
            environment.GetCurrent().As<BSArray>().MakeOriginal().Values.Reverse();
    }
}
