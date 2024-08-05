using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
    public class RuntimeEnvironment
    {

        public LinkedList<SCObject> Stack = new();
        public LinkedListNode<SCObject>? CursorNode;

        public SCObject Push(SCObject value)
        {
            if (CursorNode != null)
                CursorNode = Stack.AddAfter(CursorNode, value);
            else
                CursorNode = Stack.AddFirst(value);
            return CursorNode.Value;
        }

        public SCObject Pop()
        {
            if (CursorNode == null)
                throw new SCStackUnderflowException();
            var currentNode = CursorNode;
            CursorNode = CursorNode.Previous;
            Stack.Remove(currentNode);
            return currentNode.Value;
        }

        public void Move(int offset)
        {
            if (offset >= 0)
                for (var i = 0; i < offset; i++)
                    if (CursorNode != null)
                        CursorNode = CursorNode?.Next ?? throw new SCStackOverflowException();
                    else
                        CursorNode = Stack.First;
            else
                for (var i = 0; i < -offset; i++)
                    if (CursorNode == null)
                        throw new SCStackUnderflowException();
                    else
                        CursorNode = CursorNode?.Previous;
        }

        public SCObject? Current { get => CursorNode?.Value; }
        public SCObject GetCurrent() => CursorNode?.Value ?? throw new SCStackUnderflowException(); // TODO: NoValueException

        public STDIO? IO;
    }
}
