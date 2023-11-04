using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    internal class CommandsContainerArrayCaller : Command
    {

        IEnumerable<BSObject> commands;
        public CommandsContainerArrayCaller(IEnumerable<BSObject> commands) => this.commands = commands;

        public override string RawView => $"({string.Join(" ", commands.Select(e => e.As<CommandContainer>().Command.RawView))})";

        public override void Call(RuntimeEnvironment environment)
        {
            foreach (var item in commands)
                item.As<CommandContainer>().Command.Call(environment);
        }
    }
}
