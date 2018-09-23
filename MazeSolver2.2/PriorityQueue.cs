namespace MazeSolver2._2
{
    public interface PriorityQueue
    {

        int len();

        void insert(FibNode node);

        FibNode minimum();

        FibNode RemoveMinimum();

        void decreaseKey(FibNode node, int newPriority);

    }

    public class FibPQ : PriorityQueue
    {

        public FibonacciHeap heap;
        
        public FibPQ()
        {
            heap = new FibonacciHeap();
        }


        public int len()
        {
            return heap.count;
        }

        public void insert(FibNode node)
        {
            heap.insert(node);
        }

        public FibNode minimum()
        {
            return heap.Minimum();
        }

        public FibNode RemoveMinimum()
        {
            return heap.RemoveMinimum();
        }

        public void decreaseKey(FibNode node, int newPriority)
        {
            heap.DecreaseKey(node, newPriority);
        }
    }

    public class HeapPQ : PriorityQueue
    {
        public int count = 0;

        public HeapPQ()
        {
            
            
        }
        
        public int len()
        {
            return count;
        }

        public void insert(FibNode node)
        {
            throw new System.NotImplementedException();
        }

        public FibNode minimum()
        {
            throw new System.NotImplementedException();
        }

        public FibNode RemoveMinimum()
        {
            throw new System.NotImplementedException();
        }

        public void decreaseKey(FibNode node, int newPriority)
        {
            throw new System.NotImplementedException();
        }
    }
}