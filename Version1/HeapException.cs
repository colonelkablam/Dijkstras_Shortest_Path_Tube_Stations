/*

 * adapted from Week 8
 * Tutorial Exercises: Heaps - HeapException class
 * Used for heap exceptions, e.g. extracting from an empty heap
 */

namespace Testing
{
    public class HeapException : Exception
    {
        public HeapException(string message) : base(message) { }

    }
}
