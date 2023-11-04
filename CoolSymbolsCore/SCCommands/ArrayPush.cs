using StackControl.BSObjects;

namespace StackControl.SCCommands
{
    internal class ArrayPush : BuiltInFunction
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var val = environment.Pop();
            environment.GetCurrent().As<SCArray>().MakeOriginal().Values.Add(val);
        }
    }
}