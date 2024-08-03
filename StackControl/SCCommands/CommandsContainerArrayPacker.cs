using StackControl.SCObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class CommandsContainerArrayPacker : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(new SCCommandContainer(new CommandsContainerArrayCaller(environment.Pop().As<SCObjects.SCArray>().Values)));
    }
}
