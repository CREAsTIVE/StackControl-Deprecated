using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class CommandContainerCaller : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment) => 
            environment.Pop().As<ICallable>().Call(environment);
    }
}
