using BeautifulSymbols.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSCommands
{
    public class ArrayPut : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var arr = environment.GetCurrent().As<BSArray>().MakeOriginal();
            if (arr.Values.Count == 0) throw new StackOverflowException();
            environment.Stack.AddLast(arr.Values.Last());
            arr.Values.RemoveAt(arr.Values.Count - 1);
        }
    }
}
