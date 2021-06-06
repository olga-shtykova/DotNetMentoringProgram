using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _newList = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (_newList.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var result = _newList.RemoveAt(0);

            return result;
        }

        public void Enqueue(T item) => _newList.Add(item);        

        public T Pop()
        {
            if (_newList.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return _newList.RemoveAt(_newList.Length - 1);
        }

        public void Push(T item)
        {
            _newList.Add(item);
        }
    }
}
