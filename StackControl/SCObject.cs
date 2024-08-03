using StackControl.BSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public abstract class SCObject : ICallable
    {
        public virtual string StackView() => "?";
        public override string ToString() => $"BSObject: {StackView()}";
        public virtual SCObject Clone() => this;

        public virtual bool SCEquals(SCObject other) => GetType().IsEquivalentTo(other.GetType());

        public T As<T>() where T : class => (this as T) ?? throw new BSWrongArgumentTypeException();

        public void Call(RuntimeEnvironment environment) =>
            environment.Push(SCEquals(environment.Pop()) ? (SCNumber) 1 : (SCNumber) 0);
            //environment.Push(environment.Pop().SCEquals(environment.Pop()) ? (Number)1 : (Number)0);
    }
}
