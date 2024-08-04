using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
	public interface DIOI
	{
		public bool IsReadOnly { get; }
		public string ReadLine();
		public string ReadLine(string txt)
		{
			Print(txt);
			return ReadLine();
		}
		public void Print(string line);
		public void PrintLine(string line) => Print(line + "\n");
		

		public bool IsDebug { get; }
		public void Debug(string message);
	}

	public class ConsoleDIOI : DIOI
	{
		public bool IsReadOnly => false;
		public void Print(string line) => Console.Write(line);
		public string ReadLine() => Console.ReadLine() ?? "";

		public bool IsDebug => true;
		public void Debug(string message) => Console.WriteLine($"DEBUG: {message}");
	}
}
