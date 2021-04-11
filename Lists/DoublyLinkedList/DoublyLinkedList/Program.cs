using System;

namespace DoublyLinkedList
{
    public class DoublyLinkedListDataStructure
    {
        public static Node first;
        public static Node last;
        
        public class Node
        {
            public int key;
            public Node next;
            public Node prev;

            public Node(int data) { key = data; next = null; }
        }

        public void InsertFirst(int key)
        {
            var newNode = new Node(key);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.next = first;
                first.prev = newNode;
                first = newNode;
            }
        }
        
        public void InsertLast(int key)
        {
            var newNode = new Node(key);

            if (last == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.prev = last;
                last.next = newNode;
                last = newNode;
            }
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
            Node currentNode = SearchNode(afterKey);

            if (currentNode == null)
                return;

            Node newNode = new Node(givenKey);

            newNode.prev = currentNode;
            newNode.next = currentNode.next;

            if (currentNode.next != null)
                currentNode.next.prev = newNode;

            currentNode.next = newNode;

            if (last == currentNode)
                last = newNode;
        }
        
        public void DeleteFirst()
        {
            if (first == null)
                return;

            first = first.next;

            if (first == null)
                last = null;
            else
                first.prev = null;
        }

        public void DeleteLast()
        {
            if (last == null)
                return;

            last = last.prev;

            if (last == null)
                first = null;
            else
                last.next = null;
        }

        public void DeleteGivenKey(int givenKey)
        {
            var toDelete = SearchNode(givenKey);

            if (toDelete.prev != null)
                toDelete.prev.next = toDelete.next;
            else
                first = toDelete.next;

            if (toDelete.next != null)
                toDelete.next.prev = toDelete.prev;
            else
                last = toDelete.prev;
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
            var myList = new DoublyLinkedListDataStructure();
            
            myList.InsertFirst(6);
            myList.InsertFirst(7);
            
            myList.InsertLast(3);
            myList.InsertLast(5);
            
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