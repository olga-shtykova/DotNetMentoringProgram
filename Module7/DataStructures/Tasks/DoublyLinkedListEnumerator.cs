using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly Link<T> _head;
        private Link<T> _currentLink;

        public DoublyLinkedListEnumerator(Link<T> head)
        {
            _head = head;
        }

        public T Current => _currentLink.Data;

        object IEnumerator.Current => _currentLink.Data;

        public bool MoveNext()
        {
            if (_currentLink == null)
            {
                _currentLink = _head;
                return true;
            }

            _currentLink = _currentLink.Next;

            return _currentLink != null;
        }

        public void Reset()
        {
            _currentLink = null;
        }

        public void Dispose()
        { }
    }
}
