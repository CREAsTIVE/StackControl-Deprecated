using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class InlineIf : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            environment.Pop().As<ICallable>().Call(environment);
            
            if (environment.Pop().As<Number>().Value != 0)
            {
                environment.Move(-1);
                environment.Pop();
                environment.Move(1);
                environment.Pop().As<ICallable>().Call(environment);
            }
            else
            {
                environment.Pop();
                environment.Pop().As<ICallable>().Call(environment);
            }
        }
    }
}
