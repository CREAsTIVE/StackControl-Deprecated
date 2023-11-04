using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols
{
    public class RuntimeEnvironment
    {

        public LinkedList<BSObject> Stack = new();
        public LinkedListNode<BSObject>? CursorNode;

        public void Push(BSObject value)
        {
            if (CursorNode != null)
                CursorNode = Stack.AddAfter(CursorNode, value);
            else
                CursorNode = Stack.AddFirst(value);
        }

        public BSObject Pop()
        {
            if (CursorNode == null)
                throw new BSStackUnderflowException();
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
                        CursorNode = CursorNode?.Next ?? throw new BSStackOverflowException();
                    else
                        CursorNode = Stack.First;
            else
                for (var i = 0; i < -offset; i++)
                    if (CursorNode == null)
                        throw new BSStackUnderflowException();
                    else
                        CursorNode = CursorNode?.Previous;
        }

        public BSObject? Current { get => CursorNode?.Value; }
        public BSObject GetCurrent() => CursorNode?.Value ?? throw new BSStackUnderflowException();
    }
}
