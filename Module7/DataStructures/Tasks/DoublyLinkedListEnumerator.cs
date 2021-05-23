using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public struct DoublyLinkedListEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private Link<T> head;
        private Link<T> tail;
        private Link<T> currentLink;
        private int length;
        private bool startedFlag;

        public DoublyLinkedListEnumerator(Link<T> head, Link<T> tail, int length)
        {
            this.head = head;
            this.tail = tail;
            this.currentLink = null;
            this.length = length;
            this.startedFlag = false;
        }

        public T Current
        {
            get { return this.currentLink.Data; }
        }

        public void Dispose()
        {
            this.head = null;
            this.tail = null;
            this.currentLink = null;
        }

        object IEnumerator.Current
        {
            get { return this.currentLink.Data; }
        }

        public bool MoveNext()
        {
            if (this.startedFlag == false)
            {
                this.currentLink = this.head;
                this.startedFlag = true;
            }
            else
            {
                this.currentLink = this.currentLink.Next;
            }

            return this.currentLink != null;
        }

        public void Reset()
        {
            this.currentLink = this.head;
        }
    }
}
