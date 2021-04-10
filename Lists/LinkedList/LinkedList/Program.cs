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

        public void insertFirst(int key)
        {
            var newNode = new Node(key);

            if (first == null)
                last = newNode;
            else
                newNode.next = first;

            first = newNode;
        }

        public void insertlast(int key)
        {
            var newNode = new Node(key);

            if (last == null)
                first = newNode;
            else
                last.next = newNode;

            last = newNode;
        }

        public Node searchNode(int givenKey)
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

        public void insertAfterKey(int afterKey, int givenKey)
        {
            var currentNode = searchNode(afterKey);
            
            if (currentNode == null)
                return;
            
            var newNode = new Node(givenKey);

            newNode.next = currentNode.next;
            currentNode.next = newNode;

            if (currentNode == last)
                last = newNode;
        }

        public void deleteFirst()
        {
            if (first == null)
                return;

            first = first.next;
        }

        public void deleteLast()
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
        
        public void deleteGivenKey(int givenKey)
        {
            var toDelete = first;
            Node previousNode = null;
            
            if (toDelete == null)
                return;

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

        public void printList()
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
            
            myList.insertFirst(6);
            myList.insertFirst(7);
            
            myList.insertlast(3);
            myList.insertlast(5);
            
            myList.insertAfterKey(6, 8);
            myList.insertAfterKey(3, 9);
            
            myList.printList();
            
            Console.WriteLine();
            
            myList.deleteFirst();
            myList.deleteLast();
            myList.deleteGivenKey(8);
            
            myList.printList();
        }
    }
}
