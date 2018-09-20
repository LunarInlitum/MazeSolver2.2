using System;
using System.Diagnostics.Eventing.Reader;

namespace MazeSolver2._2
{
    public class FibHeap
    {
        public class Node
        {
            public int key;
            public _2.Node value;
            public int degree;
            public bool mark;
            public Node parent;
            public Node child;
            public Node previous;
            public Node next;
            
            public Node(int key, _2.Node value)
            {
                this.key = key;
                this.value = value;
                degree = 0;
                mark = false;
                parent = child = null;
                previous = next = null;
            }

            public bool isSingle()
            {
                return this == next;
            }

            public void insert(Node node)
            {
                if (node == null)
                {
                    return;
                }

                next.previous = node.previous;
                previous.next = next;
                next = node;
                node.previous = this;
            }

            public void remove()
            {
                previous.next = next;
                next.previous = previous;
                next = previous = this;

            }

            public void AddChild(Node node)
            {
                if (child == null)
                {
                    child = node;
                }
                else
                {
                    child.insert(node);
                }

                node.parent = this;
                node.mark = false;
                degree += 1;
            }

            public void RemoveChild(Node node)
            {
                if (node.parent != this)
                {
                    Console.WriteLine("Cannot remove child from a node that is not its parent.");
                }

                if (node.isSingle())
                {
                    if (child != node)
                    {
                        Console.WriteLine("Cannot remove a node that is not a child");
                    }

                    child = null;
                }
            }
        }

        public Node minnode;
        public int count;
        public int maxDegree;

        public FibHeap()
        {
            minnode = null;
            count = 0;
            maxDegree = 0;
            
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void insert(Node node)
        {
            count += 1;
            _insertNode(node);
            
        }

        public void _insertNode(Node node)
        {
            if (minnode == null)
            {
                minnode = node;
            }
            else
            {
                minnode.insert(node);
                if (node.key < minnode.key)
                    minnode = node;
            }
        }

        public Node Minimum()
        {
            if (minnode == null)
            {
                Console.WriteLine("Cannot return minimum of empty heap");
            }

            return minnode;
        }

        public void Merge(FibHeap heap)
        {
            minnode.insert(heap.minnode);
            if (minnode == null || heap.minnode != null && heap.minnode.key < minnode.key)
                minnode = heap.minnode;
            count += heap.count;
        }

        public Node RemoveMinimum()
        {
            if(minnode == null)
            {
                Console.WriteLine("Cannot remove from empty heap");
                
            }

            Node removedNode = minnode;
            Node c;
            count--;
            
            //Assign all old root children as new roots
            if (minnode.child != null)
            {
                c = minnode.child;

                while (true)
                {
                    c.parent = null;
                    c = c.next;
                    if (c == minnode.child)
                    {
                        break;
                    }
                }

                minnode.child = null;
                minnode.insert(c);
            }
            
            //If we have removed the last key
            if (minnode.next == minnode)
            {
                if (count != 0)
                {
                    Console.WriteLine("Heap error: Expected 0 keys, count is " + count);
                    
                }

                minnode = null;
                return removedNode;
            }
            
            //Merge any roots with the same degree
            int logSize = 100;
            Node[] degreeRoots = new Node[logSize];
            maxDegree = 0;
            Node currentPointer = minnode.next;

            while (true)
            {
                int currentDegree = currentPointer.degree;
                Node current = currentPointer;
                currentPointer = currentPointer.next;

                while (degreeRoots[currentDegree] != null)
                {
                    Node other = degreeRoots[currentDegree];
                    
                    //Swap if required

                    if (current.key > other.key)
                    {
                        Node temp = other;
                        other = current;
                        current = temp;
                    }
                }

                degreeRoots[currentDegree] = current;
                if (currentPointer == minnode)
                    break;
            }
            
            //Remove current root and find new minnode
            minnode = null;
            int newMaxDegree = 0;
            for (int d = 0; d < logSize; d++)
            {
                if (degreeRoots[d] != null)
                {
                    degreeRoots[d].next = degreeRoots[d].previous = degreeRoots[d];
                    _insertNode(degreeRoots[d]);
                    if (d > newMaxDegree)
                    {
                        newMaxDegree = d;
                    }
                }
            }

            maxDegree = newMaxDegree;
            return removedNode;
        }

        public void decreaseKey(Node node, int newKey)
        {
            if (newKey > node.key)
            {
                Console.WriteLine("Cannot decrease a key to a greater value");
            }
            else if(newKey == node.key)
            {
                return;
            }

            node.key = newKey;

            Node parent = node.parent;

            if (parent == null)
            {
                if (newKey < minnode.key)
                {
                    minnode = node;
                }

                return;
            }
            if (parent.key <= newKey)
            {
                return;
            }

            while (true)
            {
                parent.RemoveChild(node);
                _insertNode(node);

                if (parent.parent == null)
                {
                    break;
                }
                if (parent.mark == false)
                {
                    break;
                }
                node = parent;
                parent = parent.parent;
            }
        }
    }
}