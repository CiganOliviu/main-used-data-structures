using System;

namespace Stack
{
    public class StackDataStructure
    {
        private readonly int[] _data;
        private const int StackDefaultSize = 25;
        private int _index;
    
        public StackDataStructure()
        {
            _data = new int[StackDefaultSize];
            _index = 0;
        }
        
        public StackDataStructure(int stackSize)
        {
            if (stackSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(stackSize), "Unable to have negative stack size");
            
            _data = new int[stackSize];
            _index = 0;
        }
        
        public void Pop()
        {
            _data[_index] = 0;
            _index -= 1;
        }

        public int Peek()
        {
            var index = _index - 1;
            return _data[index];
        }

        public void Push(int key)
        {
            if (_index == _data.Length) return;
            
            _data[_index] = key;
            _index++;
        }
        
        public int[] GetStack()
        {
            return _data;
        }

        public void Output()
        {
            for (var it = 0; it < _index; it++)
                Console.Write(_data[it] + " ");

            Console.WriteLine();
        }
    }
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var stack = new StackDataStructure(9);
            
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
                
            stack.Output();
            Console.WriteLine(stack.Peek());
            stack.Pop();
            stack.Output();
            Console.WriteLine(stack.Peek());
            stack.Output();
        }
    }
}