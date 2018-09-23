using System.Collections.Generic;

namespace MazeSolver2._2
{
    public class DepthFirst
    {
        public bool completed;
        
        public List<Node> Solve(Maze maze)
        {
            Node start = maze.GetStart();
            Node end = maze.GetEnd();
            int width = maze.width;
            List<Node> stack = new List<Node>();
            stack.Add(start);
            Node[] prev = new Node[maze.height * maze.width];
            bool[] visited = new bool[maze.height * maze.width];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            completed = false;
            Node current;

            while (stack.Count > 0)
            {
                current = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);

                if (current == end)
                {
                    completed = true;
                    break;
                }

                visited[current.Position().Y * width + current.Position().X] = true;

                foreach (var n in current.neighbours)
                {
                    if (n != null)
                    {
                        int npos = n.Position().Y * width + n.Position().X;
                        if (visited[npos] == false)
                        {
                            stack.Add(n);
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