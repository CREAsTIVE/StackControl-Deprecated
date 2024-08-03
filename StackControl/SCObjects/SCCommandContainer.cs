using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCObjects
{
    public class SCCommandContainer : SCObject, ICallable
    {
        public SCCommandContainer(Command command) => Command = command;
        public Command Command;
        public override string StackView() => $"{Command.RawView}";

        public override SCObject Clone() => new SCCommandContainer(Command);

        public void Call(RuntimeEnvironment environment) => Command.Call(environment);

        public override bool SCEquals(SCObject other)
        {
            if (other is SCCommandContainer cc)
                return cc.Command == Command;
            return false;
        }
    }
}
