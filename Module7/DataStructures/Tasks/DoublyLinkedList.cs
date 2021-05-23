using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable
    {
        private Link<T> head;
        private Link<T> tail;

        public int Length { get; private set; }

        public DoublyLinkedList()
        {
            head = tail = null;
            Length = 0;
        }

        public void Add(T e)
        {
            if (head == null)
            {
                this.head = new Link<T>(e, null, null);
                this.tail = head;
                this.Length++;
            }
            else
            {
                Link<T> newLink = new Link<T>(e, null, this.tail);
                this.tail.Next = newLink;
                this.tail = newLink;
                this.Length++;
            }
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentException();
            }

            Link<T> newLink = new Link<T>(e, this.head, this.tail);

            if (head == null)
            {   // list is empty, index must be 0
                head = newLink;
                tail = newLink;
            }
            else if (index == 0)
            {   // add before head
                newLink.Next = head;
                head.Previous = newLink;
                head = newLink;
            }
            else if (index == Length)
            {   // add after tail
                newLink.Previous = tail;
                tail.Next = newLink;
                tail = newLink;
            }
            else
            {
                Link<T> linkRef = head;
                for (int i = 1; i < index; i++)
                {
                    linkRef = linkRef.Next;
                }

                // linkRef now points to the node before the add point
                newLink.Next = linkRef.Next;
                linkRef.Next = newLink;
                newLink.Previous = linkRef;
                newLink.Next.Previous = newLink;
            }
            Length++;
        }

        public T ElementAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            Link<T> linkRef = head;
           
            for (int i = 0; i < index; i++)
            {
                linkRef = linkRef.Next;
            }
            return linkRef.Data;
        }       

        public void Remove(T item)
        {
            if (head != null)
            {
                if (head.Data.Equals(item))
                {
                    head = head.Next;
                    Length--;
                    return;
                }

                Link<T> current = head.Next;
                Link<T> previous = head;

                while (current != null)
                {
                    if (current.Data.Equals(item))
                    {
                        previous.Next = current.Next;
                        Length--;
                        return;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                Link<T> newLink = new Link<T>(item, head, tail);
                head = newLink;
                tail = newLink;
                Length = 1;
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            Link<T> linkRef = head;
            
            for (int i = 0; i < index; i++)
            {
                linkRef = linkRef.Next;                
            }

            Link<T> current = head.Next;
            Link<T> previous = head;

            if (Length == 0)
            {
                this.head = null;
            }
            else if (previous == null)
            {
                this.head = current.Next;
                this.head.Previous = null;
            }
            else if (index == Length - 1)
            {
                previous.Next = current.Next;
                tail = previous;
                current = null;
            }
            else
            {
                previous.Next = current.Next;
                current.Next.Previous = previous;
            }
            Length--;

            return linkRef.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this.head, this.tail, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
