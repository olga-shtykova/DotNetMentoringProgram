using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Link<T> _head;
        private Link<T> _tail;

        public int Length { get; private set; }              

        public void Add(T e)
        {
            if (Length == 0)
            {
                _head = new Link<T>(e, null, null);
                _tail = _head;
                Length++;
            }
            else
            {
                var link = new Link<T>(e, null, _tail);
                _tail.Next = link;
                _tail = link;
                Length++;
            }
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            var link = new Link<T>(e, _head, _tail);

            if (Length == 0 && index == 0)
            {
                _head = link;
            }
            else if (Length != 0 && index == 0)
            {
                link.Next = _head;
                _head.Previous = link;
                _head = link;
                _head.Previous = null;
            }
            else if (index == Length)
            {
                link.Previous = _tail;
                _tail.Next = link;
                _tail = link;
                _tail.Next = null;
            }
            else
            {
                var current = _head;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                link.Next = current.Previous.Next;
                link.Previous = current.Previous;
                current.Previous.Next = link;
                current.Previous = link;
            }           

            Length++;
        }

        public T ElementAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            var link = _head;
           
            for (int i = 0; i < index; i++)
            {
                link = link.Next;
            }

            return link.Data;
        }       

        public void Remove(T item)
        {
            if (_head == null) return;

            if (_head.Data.Equals(item))
            {
                _head.Next.Previous = null;
                _head = _head.Next;
                Length--;
            }
            else if (_tail.Data.Equals(item))
            {
                _tail.Previous.Next = null;
                _tail = _tail.Previous;
                Length--;
            }
            else
            {
                var current = _head.Next;

                while (current != null && current.Data.Equals(item))
                {
                    if (current.Data.Equals(item))
                    {                            
                        if (current.Next != null)
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                            Length--;
                        }
                    }                       

                    current = current.Next;
                }
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= Length || index < 0 || Length == 0)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            var link = _head;

            if (index == 0)
            {
                link.Next.Previous = null;
                _head = _head.Next;
                Length--;
            }
            else if (index == Length - 1)
            {
                link = _tail;
                link.Previous.Next = null;
                _tail = _tail.Previous;
                Length--;
            }
            else
            {
                link = _head;

                for (int i = 0; i < index; i++)
                {
                    link = link.Next;
                }

                link.Previous.Next = link.Next;
                link.Next.Previous = link.Previous;
                Length--;
            }

            return link.Data;
        }

        public IEnumerator<T> GetEnumerator() => new DoublyLinkedListEnumerator<T>(_head);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();        
    }
}
