using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    internal class ListGenerator : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            BSObjects.BSArray array = new();
            var current = environment.GetCurrent();
            while (!(current is BSObjects.ListOpener))
            {
                array.Values.Add(current);
                environment.Pop();
                current = environment.GetCurrent();
            }
            environment.Pop();
            array.Values.Reverse();
            environment.Push(array);
        }
    }
}
