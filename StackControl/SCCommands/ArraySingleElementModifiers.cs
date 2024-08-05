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
	public class ArrayPut : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
			if (arr.Values.Count == 0) throw new StackOverflowException();
			environment.Stack.AddLast(arr.Values.Last());
			arr.Values.RemoveAt(arr.Values.Count - 1);
		}
	}
	public class ArrayPop : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
			environment.Push(arr.Values[arr.Values.Count - 1]);
			arr.Values.RemoveAt(arr.Values.Count - 1);
		}
	}
	public class ArrayPopFirst : BuiltInCommand
	{
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
			environment.Push(arr.Values[0]);
			arr.Values.RemoveAt(0);
		}
	}

	public class ArrayDelete : BuiltInCommand
	{
		public bool first = false;
		public override void Call(RuntimeEnvironment environment)
		{
			var arr = environment.GetCurrent().As<SCArray>().MakeOriginal();
			arr.Values.RemoveAt(first ? 0 : arr.Values.Count-1);
		}
	}
}