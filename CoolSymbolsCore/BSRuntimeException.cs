using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols
{
    public class BSRuntimeException : Exception
    {
        public BSRuntimeException() { }
    }

    public class BSStackUnderflowException : BSRuntimeException { }

    public class BSStackOverflowException : BSRuntimeException { }

    public class BSNotANumberException : BSRuntimeException { }

    public class BSWrongArgumentTypeException : BSRuntimeException { }
}
