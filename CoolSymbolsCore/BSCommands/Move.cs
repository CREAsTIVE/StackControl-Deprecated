using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class Move : BuiltInFunction
    {
        public Move(int val) => this.val = val;
        int val;
        public override void Call(RuntimeEnvironment environment) => environment.Move(val);
    }
}
