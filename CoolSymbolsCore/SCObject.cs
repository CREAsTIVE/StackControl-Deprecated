using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public abstract class SCObject
    {
        public virtual string StackView() => "?";
        public override string ToString() => $"BSObject: {StackView()}";
        public virtual SCObject Clone() => this;

        public T As<T>() where T : class => (this as T) ?? throw new BSWrongArgumentTypeException();
    }
}
