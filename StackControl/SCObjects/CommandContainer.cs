using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.BSObjects
{
    public class CommandContainer : SCObject, ICallable
    {
        public CommandContainer(Command command) => Command = command;
        public Command Command;
        public override string StackView() => $"{Command.RawView}";

        public override SCObject Clone() => new CommandContainer(Command);

        public void Call(RuntimeEnvironment environment) => Command.Call(environment);

        public override bool SCEquals(SCObject other)
        {
            if (other is CommandContainer cc)
                return cc.Command == Command;
            return false;
        }
    }
}
