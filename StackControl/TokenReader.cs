using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public class TokenReader<T>
    {
        T[] tokens;
        int pos = 0;

		public TokenReader(T[] tokens) => this.tokens = tokens.Where(token => token is not Tokens.Source).ToArray();

		public bool HasNext => pos < tokens.Length;
		public T GetNext() => tokens[pos++];

        public static implicit operator TokenReader<T>(T[] t) => new TokenReader<T>(t);
    }

    public class StringReader
    {
        string str;
        int pos = 0;

        public StringReader(string v) { this.str = v; }

        public bool HasNext() => pos < str.Length;
        public char Next() => str[pos++];
        public void Back() => pos--;

        public static implicit operator StringReader(string s) => new StringReader(s);
    }
}
