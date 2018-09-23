using System.Collections.Generic;
using System.Drawing;
using System.Xml.Schema;

namespace MazeSolver2._2
{
    public class AStar
    {

        public bool completed;
        
        public List<Node> Solve(Maze maze)
        {
            int width = maze.width;
            int total = maze.width * maze.height;

            var start = maze.GetStart();
            var startPos = start.Position();
            var end = maze.GetEnd();
            var endPos = end.Position();
            
            bool[] visited = new bool[total];
            Node[] prev = new Node[total];

            var infinity = float.PositiveInfinity;
            float[] distances = new float[total];
            
            var unvisited = new FibPQ();
            
            FibNode[] nodeIndex = new FibNode[total];

            for (var i = 0; i < total; i++)
            {
                visited[i] = false;
                distances[i] = infinity;
            }

            distances[start.Position().Y * width + start.Position().X] = 0;
            var startNode = new FibNode(0, start);
            nodeIndex[start.Position().Y * width + start.Position().X] = startNode;
            unvisited.insert(startNode);

            completed = false;

            while (unvisited.len() > 0)
            {
                var n = unvisited.RemoveMinimum();
                var u = n.value;
                var uPos = u.Position();
                var uPosIndex = uPos.Y * width + uPos.X;

                if (distances[uPosIndex] == infinity)
                {
                    break;
                }

                if (uPos == endPos)
                {
                    completed = true;
                    break;
                }

                foreach (var v in u.neighbours)
                {
                    if (v != null)
                    {
                        var vPos = v.Position();
                        var vPosIndex = vPos.Y * width + vPos.X;

                        if (visited[vPosIndex] == false)
                        {
                            var d = (vPos.Y - uPos.Y) + (vPos.X - uPos.X);

                            var newDistance = distances[uPosIndex] + d;

                            var remaining = (vPos.Y - endPos.Y) + (vPos.X - endPos.X);

                            if (newDistance < distances[vPosIndex])
                            {
                                var vNode = nodeIndex[vPosIndex];

                                if (vNode == null)
                                {
                                    vNode = new FibNode((int)newDistance + remaining, v);
                                    unvisited.insert(vNode);
                                    nodeIndex[vPosIndex] = vNode;

                                    distances[vPosIndex] = newDistance;
                                    prev[vPosIndex] = u;
                                }
                                else
                                {
                                    unvisited.decreaseKey(vNode, (int)newDistance + remaining);
                                    distances[vPosIndex] = newDistance;
                                    prev[vPosIndex] = u;
                                }        
                            }
                        }
                    }
                }

                visited[uPosIndex] = true;
            }
            
            List<Node> path = new List<Node>();

            Node current = end;
            path.Add(current);
            while (current != null)
            {
                path = DirectionFactory.AppendLeft(path, current);
                current = prev[current.Position().Y * width + current.Position().X];
            }

            return path;
        }
    }
}