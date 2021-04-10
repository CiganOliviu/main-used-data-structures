using System;

namespace LinkedList
{
    public class LinkedListDataStructure
    {
        public static Node first;
        public static Node last;
            
        public class Node
        {
            public int key;
            public Node next;
                
            public Node(int data) { key = data; next = null; }
        }

        public void InsertFirst(int key)
        {
            var newNode = new Node(key);

            if (first == null)
                last = newNode;
            else
                newNode.next = first;

            first = newNode;
        }

        public void Insertlast(int key)
        {
            var newNode = new Node(key);

            if (last == null)
                first = newNode;
            else
                last.next = newNode;

            last = newNode;
        }

        public Node SearchNode(int givenKey)
        {
            var currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.key == givenKey)
                    break;
                
                currentNode = currentNode.next;
            }

            return currentNode;
        }

        public void InsertAfterKey(int afterKey, int givenKey)
        {
            var currentNode = SearchNode(afterKey);
            
            if (currentNode == null)
                return;
            
            var newNode = new Node(givenKey);

            newNode.next = currentNode.next;
            currentNode.next = newNode;

            if (currentNode == last)
                last = newNode;
        }

        public void DeleteFirst()
        {
            if (first == null)
                return;

            first = first.next;
        }

        public void DeleteLast()
        {
            var toDelete = first;
            Node previousNode = null;
            
            if (toDelete == null)
                return;

            while (toDelete != last)
            {
                previousNode = toDelete;
                toDelete = toDelete.next;
            }

            previousNode.next = null;
            last = previousNode;
        }
        
        public void DeleteGivenKey(int givenKey)
        {
            var toDelete = first;

            if (toDelete == null)
                return;
            
            Node previousNode = null;

            while (toDelete != null)
            {
                if (toDelete.key == givenKey)
                    break;
                
                previousNode = toDelete;
                toDelete = toDelete.next;
            }

            if (toDelete == first)
            {
                first = first.next;

                if (first == null)
                    last = null;
            }
            else
            {
                previousNode.next = toDelete.next;

                if (toDelete == last)
                    last = previousNode;
            }
        }

        public void PrintList()
        {
            Console.WriteLine("My list is :");

            var currentNode = first;

            while (currentNode != null)
            {
                Console.Write(currentNode.key + " ");
                currentNode = currentNode.next;
            }
        }
    }
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var myList = new LinkedListDataStructure();
            
            myList.InsertFirst(6);
            myList.InsertFirst(7);

            myList.Insertlast(3);
            myList.Insertlast(5);
            
            myList.InsertAfterKey(6, 8);
            myList.InsertAfterKey(3, 9);
            
            myList.PrintList();
            
            Console.WriteLine();
            
            myList.DeleteFirst();
            myList.DeleteLast();
            myList.DeleteGivenKey(8);
            
            myList.PrintList();
        }
    }
}
