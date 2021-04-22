using System;

namespace Trees
{
    public class BinarySearchTree
    {
        public Node root = null;

        public class Node
        {
            public int key;
            public Node right;
            public Node left;

            public Node(int data)
            {
                key = data;
                right = null;
                left = null;
            }
        }
        
        public Node InsertNode(int key)
        {
            var newNode = new Node(key);

            var currentNode = root;
            Node toInsert = null;

            while (currentNode != null)
            {
                toInsert = currentNode;

                currentNode = key < currentNode.key ? currentNode.left : currentNode.right;
            }

            if (toInsert == null)
                toInsert = newNode;
            else
                if (key < toInsert.key)
                    toInsert.left = newNode;
                else
                    toInsert.right = newNode;

            return toInsert;
        }

        public Node SearchNode(Node node, int key)
        {
            if (node == null || node.key == key)
                return node;

            return SearchNode(node.key < key ? node.left : node.right, key);
        }

        public Node FindMinimum(Node root)
        {
            if (root == null)
                return null;

            var currentNode = root;

            while (currentNode.left != null)
                currentNode = currentNode.left;

            return currentNode;
        }

        public Node FindMaximum(Node root)
        {
            if (root == null)
                return null;

            var currentNode = root;

            while (currentNode.right != null)
                currentNode = currentNode.right;

            return currentNode;
        }

        public Node FindSuccessor(Node root, Node node)
        {
            if (node == null || root == null)
                return null;

            if (node.right != null)
                return FindMinimum(node.right);

            var currentNode = root;
            Node successor = null;

            while (currentNode != null && currentNode.key != node.key)
            {
                if (node.key < currentNode.key)
                {
                    successor = currentNode;
                    currentNode = currentNode.left;
                }
                else
                    currentNode = currentNode.right;
            }

            return currentNode == null ? null : successor;
        }

        public Node FindPredecessor(Node root, Node node)
        {
            if (node == null || root == null)
                return null;

            if (node.left != null)
                return FindMaximum(node.left);

            var currentNode = root;
            Node predecessor = null;

            while (currentNode != null && currentNode.key != node.key)
            {
                if (node.key < currentNode.key)
                    currentNode = currentNode.left;
                else
                {
                    predecessor = currentNode;
                    currentNode = currentNode.right;
                }
            }

            return currentNode == null ? null : predecessor;
        }

        public Node DeleteNode (Node root, int key)
        {
            if (root == null)
                return root;

            if (key < root.key)
                root.left = DeleteNode(root.left, key);
            else
                if (key > root.key)
                    root.right = DeleteNode(root.right, key);
                else
                {
                    Node node;
                    if (root.left == null)
                    {
                        node = root.right;
                        return node;
                    }

                    if (root.right == null)
                    {
                        node = root.left;
                        return node;
                    }

                    node = FindMinimum(root.right);
                    root.key = node.key;
                    root.right = DeleteNode(root.right, node.key);
                }

            return root;
        }

        public void InOrderPrinting(Node root)
        {
            if (root == null)
                return;
            
            InOrderPrinting(root.left);
            Console.Write(root.key + " ");
            InOrderPrinting(root.right);
        }

        public void PreOrderPrinting(Node root)
        {
            if (root == null) 
                return;
            
            Console.Write(root.key + " ");
            PreOrderPrinting(root.left);
            PreOrderPrinting(root.right);
        }

        public void PostOrderPrinting(Node root)
        {
            if (root == null)
                return;
            
            PostOrderPrinting(root.left);
            PostOrderPrinting(root.right);
            Console.Write(root.key + " ");
        } 
    }
    
    internal static class Program
    {
        private static void TestsInsertion(BinarySearchTree myTree)
        {
            const int nodesToInsert = 11;
            int[] keys = {15, 6, 18, 17, 20, 3, 7, 2, 4, 13, 9};

            myTree.root = myTree.InsertNode(keys[0]);

            for (var i = 1; i < nodesToInsert; i++)
                myTree.InsertNode(keys[i]);

            myTree.InOrderPrinting(myTree.root);

            Console.WriteLine();
        }

        public static void TestsSearch(BinarySearchTree myTree)
        {
            int key = 15;
            var node = myTree.SearchNode(myTree.root, key);

            Console.WriteLine(node != null ? "The node has been found." : "The node has not been found.");
        }

        private static void TestsSuccessor(BinarySearchTree myTree)
        {
            const int key = 15;
            var node = myTree.SearchNode(myTree.root, key);

            var successor = myTree.FindSuccessor(myTree.root, node);

            if (successor != null)
                Console.WriteLine("The node with key = " + node.key + " has " + successor.key + " as successor.");
            else
                Console.WriteLine("The node doesn't have a successor");
        }
        
        private static void TestsPredecessor(BinarySearchTree myTree)
        {
            const int key = 15;
            var node = myTree.SearchNode(myTree.root, key);

            var predecessor = myTree.FindPredecessor(myTree.root, node);

            if (predecessor != null)
                Console.WriteLine("The node with key = " + node.key + " has " + predecessor.key + " as predecessor.");
            else
                Console.WriteLine("The node doesn't have a predecessor ");
        }

        private static void TestsDeletion(BinarySearchTree myTree)
        {
            const int key = 15;

            Console.WriteLine("Node to delete : " + key);

            myTree.root = myTree.DeleteNode(myTree.root, key);

            myTree.InOrderPrinting(myTree.root);
            Console.WriteLine();
        }

        private static void TestsPrinting(BinarySearchTree myTree)
        {
            myTree.InOrderPrinting(myTree.root);
            Console.WriteLine();

            myTree.PreOrderPrinting(myTree.root);
            Console.WriteLine();

            myTree.PostOrderPrinting(myTree.root);
            Console.WriteLine();
        }
        
        private static void Main(string[] args)
        {
            var myTree = new BinarySearchTree();
            
            TestsInsertion(myTree);
            
            TestsSearch(myTree);
            
            TestsSuccessor(myTree);
            TestsPredecessor(myTree);
            
            TestsPrinting(myTree);
            
            TestsDeletion(myTree);
        }
    }
}