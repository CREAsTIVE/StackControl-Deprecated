using StackControl.SCObjects;
using StackControl.SCCommands;
using StackControl.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
	public class Tokenizer
	{
		public Environment environment;
		public Tokenizer(Environment env) { this.environment = env; }

		const string NameSymbols = "abcdefghijklmnopqrstuvwxyz";

		public string Unparse(IEnumerable<Token> tokens)
		{
			string result = "";

			foreach (var token in tokens)
				result += token switch
				{
					Tokens.String str => $"\"{str.value.ToString().Replace("\"", "\\\"\"")}\"",
					Tokens.Number number => $"{number.value}",
					Tokens.ListOpener => "[",
					Tokens.ListCloser => "]",
					Tokens.FunctionOpener => "(",
					Tokens.FunctionCloser => ")",
					Tokens.Source source => source.any,
					Tokens.Command cmd => cmd.name,
					Tokens.FunctionMark => "#",
					_ => "unknow"
				};

			return result;
		}

		public LinkedList<Token> Parse(StringReader reader)
		{
			var tokens = new LinkedList<Token>();

			while (reader.HasNext())
			{
				var next = reader.Next();

				if (next == '"')
				{
					var str = "";
					while (reader.HasNext())
					{
						next = reader.Next();
						if (next == '\\')
							next = reader.Next();
						else if (next == '"')
							break;
						str += next;
					}
					tokens.AddLast(new Tokens.String(str));
				}
				else if (char.IsDigit(next))
				{
					var number = int.Parse(next.ToString());
					while (reader.HasNext())
					{
						next = reader.Next();
						if (!char.IsDigit(next))
						{
							reader.Back(); break;
						}
						number = number * 10 + int.Parse(next.ToString());
					}
					tokens.AddLast(new Tokens.Number(number));

				}
				else if (NameSymbols.Contains(char.ToLower(next)))
				{
					string name = next.ToString();
					while (reader.HasNext())
					{
						next = reader.Next();
						if (!(char.IsDigit(next) || NameSymbols.Contains(char.ToLower(next))))
						{
							reader.Back(); break;
						}
						name += next;
					}
					if (environment.Aliases.TryGetValue(name, out var al))
						name = al;

					tokens.AddLast(new Tokens.Command(name));

				}
				else if (next == '[')
					tokens.AddLast(new Tokens.ListOpener());
				else if (next == ']')
					tokens.AddLast(new Tokens.ListCloser());
				else if (next == '(')
					tokens.AddLast(new Tokens.FunctionOpener());
				else if (next == ')')
					tokens.AddLast(new Tokens.FunctionCloser());
				else if (char.IsSeparator(next))
					tokens.AddLast(new Tokens.Source(next.ToString()));
				else if (next == '#')
					tokens.AddLast(new FunctionMark());
				else
					tokens.AddLast(new Tokens.Command(next.ToString()));
			}

			return tokens;
		}
	}
	public class Token { }
	namespace Tokens
	{
		public class String : Token
		{
			public string value;
			public String(string v) => value = v;
		}
		public class Source : Token
		{
			public string any;
			public Source(string any) => this.any = any;
		}
		public class Number : Token
		{
			public double value;
			public Number(double v) => value = v;
		}
		public class Command : Token
		{
			public string name;
			public Command(string name)
			{
				this.name = name;
			}
		}
		public class ListOpener : Token { }
		public class ListCloser : Token { }
		public class FunctionOpener : Token { }
		public class FunctionCloser : Token { }
		public class FunctionMark : Token { }
		
	}
}
