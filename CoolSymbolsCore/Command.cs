using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols
{
    public abstract class Command
    {
        public abstract void Call(RuntimeEnvironment environment);
        public abstract string RawView { get; }
    }
}
