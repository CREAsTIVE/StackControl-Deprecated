using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public abstract class BuiltInFunction : Command
    {
        public override string RawView => "<built-in function>";
    }
}
