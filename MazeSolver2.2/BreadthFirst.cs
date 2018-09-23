using System.Collections.Generic;
using System.Globalization;

namespace MazeSolver2._2
{
    public class BreadthFirst
    {

        public bool completed = false;

        public List<Node> Solve(Maze maze)
        {
            Node start = maze.GetStart();
            Node end = maze.GetEnd();

            int width = maze.width;
            
            Node current;
            
            List<Node> queue = new List<Node>();
            queue.Add(start);
            
            Node[] prev = new Node[maze.width * maze.height];
            bool[] visited = new bool[maze.width * maze.height];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            visited[start.Position().Y * width + start.Position().X] = true;

            while (queue.Count > 0)
            {
                current = queue[queue.Count - 1];
                queue.RemoveAt(queue.Count - 1);

                if (current == end)
                {
                    completed = true;
                    break;
                }

                foreach (var n in current.neighbours)
                {
                    if (n != null)
                    {
                        int npos = n.Position().Y * width + n.Position().X;
                        if (visited[npos] == false)
                        {
                            queue = DirectionFactory.AppendLeft(queue, n);
                            visited[npos] = true;
                            prev[npos] = current;
                        }
                    }
                }
            }
            
            List<Node> path = new List<Node>();
            path.Add(end);
            current = end;
            while (current != null)
            {
                path = DirectionFactory.AppendLeft(path, current);
                current = prev[current.Position().Y * width + current.Position().X];
            }

            return path;
        }

    }
}