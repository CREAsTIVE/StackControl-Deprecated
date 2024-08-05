using StackControl;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StackControlWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, STDIO
	{
		Compiler compiler;
		StackControl.Environment environment;
		StackControl.RuntimeEnvironment? runtimeEnvironment;

		public bool IsReadOnly => false;
		public bool IsDebug => true;

		public MainWindow()
		{
			InitializeComponent();

			environment = StackControl.Environment.Default;
			compiler = new(environment);
		}

		void DumpRuntimeEnvResults() =>
			StackConsole.Text = runtimeEnvironment?.Stack?.Select(e => e.StackView())?.JoinEnumerable("\r\n");

		private void RunButton_Click(object sender, RoutedEventArgs e) =>
			Run();
		void Run()
		{

			if (!(KeepRuntimeCheckBox?.IsChecked ?? false) || runtimeEnvironment is null)
				runtimeEnvironment = new();

			OutputConsole.Text = "";
			Debug("Executing...");

			var parsed = compiler.tokenizer.Parse(ProgramConsole.Text);

			try
			{
				if (SimplifyCheckBox?.IsChecked ?? false)
					ProgramConsole.Text = compiler.tokenizer.Unparse(parsed);

				// loads input
				storedLines = InputConsole.Text.Replace("\r", "").Split('\n').AsEnumerable().GetEnumerator();

				var comands = compiler.ParseCommands(parsed.ToArray());

				Compiler.Run(comands, runtimeEnvironment);
				DumpRuntimeEnvResults();

				Debug($"Done!");
			}
			catch (Exception ex)
			{
				Debug($"Error:\r\n{ex}");
				DumpRuntimeEnvResults();
			}
		}

		private void ResetEnvButton_Click(object sender, RoutedEventArgs e) =>
			environment = StackControl.Environment.Default;

		IEnumerator<string>? storedLines;
		public string ReadLine()
		{
			var v = storedLines?.Current ?? throw new Exception("No IO provided");
			storedLines?.MoveNext();
			return v;
		}
			

		public void Print(string line) =>
			OutputConsole.Text += line.Replace("\n", "\r\n");

		public void Debug(string message) =>
			OutputConsole.Text += $"\r\n[DEBUG] {message}\r\n";

		private void ProgramConsole_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				Run();
		}
	}
}