using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSObjects
{
    public class CommandContainer : BSObject, ICallable
    {
        public CommandContainer(Command command) => Command = command;
        public Command Command;
        public override string StackView() => $"{Command.RawView}";

        public override BSObject Clone() => new CommandContainer(Command);

        public void Call(RuntimeEnvironment environment) => Command.Call(environment);
    }
}
