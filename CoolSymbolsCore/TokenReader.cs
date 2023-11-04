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

        public TokenReader(T[] tokens) => this.tokens = tokens;
        
        public bool HasNext() => pos < tokens.Length;
        public T GetNext() => tokens[pos++];

        public static implicit operator TokenReader<T>(T[] t) => new TokenReader<T>(t);
    }
}
