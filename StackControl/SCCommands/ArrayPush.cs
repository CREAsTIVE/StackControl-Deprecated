using StackControl.SCObjects;

namespace StackControl.SCCommands
{
    internal class ArrayPush : BuiltInCommand
    {
        public override void Call(RuntimeEnvironment environment)
        {
            var val = environment.Pop();
            environment.GetCurrent().As<SCArray>().MakeOriginal().Values.Add(val);
        }
    }
}