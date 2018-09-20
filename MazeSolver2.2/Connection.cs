namespace MazeSolver2._2
{
    public class Connection
    {
        private int pixels;
        private Node startNode;
        private Node endNode;

        public Connection(int pixels, Node startNode, Node endNode)
        {
            this.pixels = pixels;
            this.startNode = startNode;
            this.endNode = endNode;
        }
    }
}