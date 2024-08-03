using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCObjects
{
    public interface ICallable
    {
        public void Call(RuntimeEnvironment environment);
    }
}
