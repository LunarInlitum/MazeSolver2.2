using System.Collections.Generic;

namespace MazeSolver2._2
{
    public class DirectionFactory
    {
        public static List<Node> AppendLeft(List<Node> path, Node node)
        {
            List<Node> newPath = new List<Node>(path.Count + 1);
            newPath.Add(node);
            foreach (var n in path)
            {
                newPath.Add(n);
            }

            return newPath;
        }
    }
}