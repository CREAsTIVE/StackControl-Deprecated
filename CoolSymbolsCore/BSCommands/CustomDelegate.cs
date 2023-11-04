using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class CustomDelegate : Command
    {
        public List<Command> Commands = new();
        public override string RawView => throw new NotImplementedException();

        public override void Call(RuntimeEnvironment environment)
        {
        }
    }
}
