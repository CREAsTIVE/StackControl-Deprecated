using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public abstract class BuiltInCommand : Command
    {
        public override string RawView => "<built-in function>";
    }
}
