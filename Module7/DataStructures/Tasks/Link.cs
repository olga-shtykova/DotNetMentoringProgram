using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class Link<T>
    {
        public Link<T> Next { get; set; }
        public Link<T> Previous { get; set; }
        public T Data { get; set; }

        public Link()
        { }
        public Link(T data, Link<T> next, Link<T> previous)
        {
            this.Data = data;
            this.Next = next;
            this.Previous = previous;
        }
    }
}
