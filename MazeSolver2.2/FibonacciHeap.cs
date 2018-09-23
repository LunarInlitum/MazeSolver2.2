using System;
using System.Net.NetworkInformation;

namespace MazeSolver2._2
{

    public class FibNode
    {

        public int key;
        public Node value;
        public int degree;
        public bool mark;
        public FibNode parent;
        public FibNode child;
        public FibNode previous;
        public FibNode next;
        
        
        public FibNode(int key, Node value)
        {
            this.key = key;
            this.value = value;
            degree = 0;
            mark = false;
            parent = child = null;
            previous = next = this;
        }

        public bool IsSingle()
        {
            return this == next;
        }

        public void Insert(FibNode node)
        {
            if (node == null)
            {
                return;
            }

            next.previous = node.previous;
            node.previous.next = next;
            next = node;
            node.previous = this;
        }

        //Removes the Node from the heap and set the previous and next nodes to eachother
        public void Remove()
        {
            previous.next = next;
            next.previous = previous;
            next = previous = this;
        }

        public void AddChild(FibNode node)
        {
            if (child == null)
            {
                child = node;
            }
            else
            {
                child.Insert(node);
            }

            node.parent = this;
            node.mark = false;
            degree++;
        }

        public void RemoveChild(FibNode node)
        {
            if (node.parent != this)
            {
                Console.WriteLine("Cannot remove child from a node that is not its parent");
            }

            if (node.IsSingle())
            {
                if (child != node)
                {
                    Console.WriteLine("Cannot remove a node that is not a child");
                }

                child = null;
            }
            else
            {
                if (child == node)
                {
                    child = node.next;
                }
                node.Remove();
            }

            node.parent = null;
            node.mark = false;
            degree--;

        }
    }
    
    public class FibonacciHeap
    {

        public FibNode minNode = null;
        public int count = 0;
        public int maxDegree = 0;

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void insert(FibNode node)
        {
            count++;
            InsertNode(node);
        }

        public void InsertNode(FibNode node)
        {
            if (minNode == null)
            {
                minNode = node;
            }
            else
            {
                minNode.Insert(node);
                if (node.key < minNode.key)
                {
                    minNode = node;
                }
            }
        }

        public FibNode Minimum()
        {
            if (minNode == null)
            {
                Console.WriteLine("No minimum in heap");
            }

            return minNode;
        }

        public void Merge(FibonacciHeap heap)
        {
            minNode.Insert(heap.minNode);
            if (minNode == null || heap.minNode != null && heap.minNode.key < minNode.key)
                minNode = heap.minNode;
            count += heap.count;
        }

        public FibNode RemoveMinimum()
        {
            if (minNode == null)
            {
                Console.WriteLine("Boi I can't remove from an empty heap");
            }
            else
            {
                FibNode removeNode = minNode;
                count--;

                //Assign all old root children as new roots
                if (minNode.child != null)
                {
                    FibNode c = minNode.child;

                    while (true)
                    {
                        c.parent = null;
                        c = c.next;
                        if (c == minNode.child)
                            break;
                    }

                    minNode.child = null;
                    minNode.Insert(c);
                }
                
                //Check if the last key has been removed
                if (minNode.next == minNode)
                {
                    if (count != 0)
                    {
                        //Expected 0 keys
                    }

                    minNode = null;
                    return removeNode;
                }

                int logsize = 100;
                FibNode[] degreeRoots = new FibNode[logsize];
                maxDegree = 0;
                FibNode currentPointer = minNode.next;

                while (true)
                {
                    int currentDegree = currentPointer.degree;
                    FibNode current = currentPointer;
                    currentPointer = currentPointer.next;
                    while (degreeRoots[currentDegree] != null)
                    {
                        FibNode other = degreeRoots[currentDegree];
                        if (current.key > other.key)
                        {
                            FibNode temp = other;
                            other = current;
                            current = temp;
                        }
                        
                        other.Remove();
                        current.AddChild(other);
                        degreeRoots[currentDegree] = null;
                        currentDegree++;
                    }

                    degreeRoots[currentDegree] = current;
                    if (currentPointer == minNode)
                        break;
                }
                
                //Remove current root and find new minnode
                minNode = null;
                var newMaxDegree = 0;

                for (int d = 0; d < logsize; d++)
                {
                    if (degreeRoots[d] != null)
                    {
                        degreeRoots[d].next = degreeRoots[d].previous = degreeRoots[d];
                        InsertNode(degreeRoots[d]);
                        if (d > newMaxDegree)
                            newMaxDegree = d;
                    }
                }

                maxDegree = newMaxDegree;
                return removeNode;
            }

            return null;
        }

        public void DecreaseKey(FibNode node, int newKey)
        {
            if (newKey > node.key)
            {
                Console.WriteLine("Cant decrease a key to a greater value");
            }
            else if (newKey == node.key)
            {
                return;
            }

            node.key = newKey;

            FibNode parent = node.parent;

            if (parent == null)
            {
                if (newKey < minNode.key)
                {
                    minNode = node;
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
                InsertNode(node);
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