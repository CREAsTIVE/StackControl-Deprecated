using StackControl;

namespace StackControlWindowsForms
{
	public partial class MainWindow : Form, STDIO
	{
		public bool IsReadOnly => false;
		public bool IsDebug => false;

		public void Debug(string message) => OutputContainer.Text += $"[DEBUG] {message}\r\n";

		public void Print(string line) => OutputContainer.Text += line.Replace("\n", "\r\n");

		int currentLine = 0;
		string[] inputLines = new string[0];
		public string ReadLine() => inputLines[currentLine++];

		StackControl.Environment environment;
		StackControl.RuntimeEnvironment? runtimeEnvironment;
		Compiler compiler;
		public MainWindow()
		{
			InitializeComponent();
			environment = new();
			compiler = new(environment);
		}

		void exec()
		{
			if (ClearStack.Checked || runtimeEnvironment is null)
				runtimeEnvironment = new();
			try
			{
				OutputContainer.Text = "[DEBUG] Executing...\r\n";

				runtimeEnvironment.IO = this;
				currentLine = 0;
				inputLines = InputContainer.Text.Split("\n");

				var code = CommandInsert.Text;

				var tokens = compiler.tokenizer.Parse(code);
				if (ToSymbols.Checked)
					CommandInsert.Text = compiler.tokenizer.Unparse(tokens);

				var commands = compiler.ParseCommands(tokens.ToArray());
				Compiler.Run(commands, runtimeEnvironment);

				StackView.Text = string.Join("\r\n", runtimeEnvironment.Stack.Select(e => e.StackView()));

				OutputContainer.Text += "\r\n[DEBUG] Finished!";
			} catch (Exception ex)
			{
				OutputContainer.Text += $"\r\n[ERROR] {ex}";
				StackView.Text = string.Join("\r\n", runtimeEnvironment.Stack.Select(e => e.StackView()));
			}
		}
		private void ExecuteButton_Click(object sender, EventArgs e)
		{
			exec();
		}
	}
}
