using BeautifulSymbols.BSObjects;

namespace BeautifulSymbols.BSCommands
{
    internal class ArrayPush : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var val = environment.Pop();
            environment.GetCurrent().As<BSArray>().MakeOriginal().Values.Add(val);
        }
    }
}