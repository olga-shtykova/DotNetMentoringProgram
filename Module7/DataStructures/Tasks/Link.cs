namespace Tasks
{
    public class Link<T>
    {
        public Link<T> Next { get; set; }
        public Link<T> Previous { get; set; }
        public T Data { get; set; }

        public Link(T data, Link<T> next, Link<T> previous)
        {
            Data = data;
            Next = next;
            Previous = previous;
        }
    }
}
