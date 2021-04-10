using NUnit.Framework;
using LinkedList;

namespace TestLinkedList
{
    public class Tests
    {
        private LinkedListDataStructure _myList;
        
        [SetUp]
        public void Setup()
        {
            _myList = new LinkedListDataStructure();
        }

        [Test]
        public void Test__() 
        {
            Assert.Pass();
        }
    }
}