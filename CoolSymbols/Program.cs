using StackControl;

Compilator compilator = new Compilator();
while (true)
{
    Console.Write("$ ");
    RuntimeEnvironment environment = new RuntimeEnvironment();
    var input = Console.ReadLine() ?? "";
    var tokens = Compilator.SepOnTokens(input);
    compilator.UnpuckAliases(tokens);

    Console.WriteLine("---------");
    Console.WriteLine("Formatted: ");
    Console.WriteLine(string.Join(" ", tokens));

    Compilator.Run(compilator.GenerateCommands(tokens), environment);

    Console.WriteLine("---------");
    foreach (var stackVal in environment.Stack)
        Console.WriteLine(stackVal.StackView());
    Console.WriteLine("---------\n");
}