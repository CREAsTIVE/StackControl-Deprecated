using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    public class CommandsContainerArrayPacker : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment) =>
            environment.Push(new CommandContainer(new CommandsContainerArrayCaller(environment.Pop().As<BSObjects.SCArray>().Values)));
    }
}
