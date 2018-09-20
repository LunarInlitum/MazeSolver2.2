
using System.Drawing;
using Priority_Queue;

namespace MazeSolver2._2
{
    public class Node : FastPriorityQueueNode
    {
        public Node[] neighbours = {null, null, null, null};
        
        public int x, y;

        private Color color;

        public Node(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public Bitmap AddPosition(Bitmap bitmap)
        {
            bitmap.SetPixel(x, y, Color.Aquamarine);
            return bitmap;
        }

        public Bitmap AddColoredPosition(Bitmap bitmap)
        {
            bitmap.SetPixel(x, y, color);
            return bitmap;
        }

        public Point Position()
        {
            return new Point(x, y);
        }
    }
}