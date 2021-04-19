using System;
using System.IO;

namespace AdvancedCSharp
{
    public class AnswerEventArgs<T> : EventArgs where T : FileSystemInfo
    {
        public T FoundItem { get; set; }
    }
}
