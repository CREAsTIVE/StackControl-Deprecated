using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public class SCRuntimeException : Exception
    {
        public SCRuntimeException() { }
    }

    public class SCStackUnderflowException : SCRuntimeException { }

    public class SCStackOverflowException : SCRuntimeException { }

    public class BSNotANumberException : SCRuntimeException { }

    public class SCWrongArgumentTypeException : SCRuntimeException { }
}
