using NUnit.Framework;
using Stack;

namespace TestStack
{
    public class Tests
    {
        private StackDataStructure _stack;
        [SetUp]
        public void Setup()
        {
            _stack = new StackDataStructure(5);
        }

        [Test]
        public void Test_Push_()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _stack.Push(4);
            _stack.Push(5);

            var expected = new int[] {1, 2, 3, 4, 5};
            
            Assert.AreEqual(_stack.GetStack(), expected);
        }

        [Test]
        public void Test_Pop_()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _stack.Push(4);
            _stack.Push(5);

            var expected = new int[] {1, 2, 3, 4, 5};

            for (var it = 0; it < expected.Length; it++)
                Assert.True(_stack.GetStack()[it] == expected[it]);
        }
    }
}