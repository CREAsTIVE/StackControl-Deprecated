using StackControl;

Compiler compiler = new Compiler();
while (true)
{
    Console.Write("$ ");
    RuntimeEnvironment environment = new RuntimeEnvironment();
	environment.IO = new ConsoleDIOI();

    var input = Console.ReadLine() ?? "";

    var parsed = compiler.tokenizer.Parse(input);

    Console.WriteLine("----------");

    Console.WriteLine($"Parsed:\n{compiler.tokenizer.Unparse(parsed)}");

	Console.WriteLine("----------");

	Compiler.Run(compiler.ParseCommands(parsed.ToArray()), environment);

	Console.WriteLine("----------");

	foreach (var stackVal in environment.Stack)
        Console.WriteLine(stackVal.StackView());
    Console.WriteLine("----------\n");
}