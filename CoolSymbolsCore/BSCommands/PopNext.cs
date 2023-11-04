using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class PopNext : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            environment.Move(1);
            environment.Pop();
        }
    }
}
