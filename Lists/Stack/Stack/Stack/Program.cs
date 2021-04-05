using System;

namespace Stack
{
    internal class Stack
    {
        private readonly int[] _data;
        private const int StackDefaultSize = 25;
        private int _index;
    
        public Stack()
        {
            _data = new int[StackDefaultSize];
            _index = 0;
        }

        public Stack(int stackSize)
        {
            if (stackSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(stackSize), "Unable to have negative stack size");
            
            _data = new int[stackSize];
            _index = 0;
        }
        /*
        public int Pop()
        {
            return 0;
        }
        
        public int Peek()
        {
            return 0;
        }
        */
        
        public void Push(int key)
        {
            if (_index != _data.Length) return;
            
            var newArray = new int[2 * _data.Length];
            Array.Copy(_data, 0, newArray, 0, _index);

            _data[_index] = key;
            _index++;
        }
    }
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}