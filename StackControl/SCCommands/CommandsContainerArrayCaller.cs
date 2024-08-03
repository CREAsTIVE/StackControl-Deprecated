using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCCommands
{
    internal class CommandsContainerArrayCaller : Command
    {

        IEnumerable<SCObject> commands;
        public CommandsContainerArrayCaller(IEnumerable<SCObject> commands) => this.commands = commands;

        public override string RawView => $"({string.Join(" ", commands.Select(e => e.As<SCCommandContainer>().Command.RawView))})";

        public override void Call(RuntimeEnvironment environment)
        {
            foreach (var item in commands)
                item.As<SCCommandContainer>().Command.Call(environment);
        }
    }
}
