using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if (newList.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var result = newList.RemoveAt(0);
                return result;
            }
        }

        public void Enqueue(T item)
        {
            newList.Add(item);
        }

        public T Pop()
        {
            if (newList.Length == 0)
            {
                throw new InvalidOperationException();
            }  
            else
            {
                return newList.RemoveAt(newList.Length - 1);
            }                
        }

        public void Push(T item)
        {
            newList.Add(item);
        }
    }
}
