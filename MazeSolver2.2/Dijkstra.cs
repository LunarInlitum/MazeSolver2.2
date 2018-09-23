using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Priority_Queue;

namespace MazeSolver2._2
{
    public class Dijkstra
    {
        private Maze maze;
        public bool completed;

        public Dijkstra(Maze maze)
        {
            this.maze = maze;
        }

        public List<Node> Solve()
        {
            var width = maze.width;
            
            var total = maze.width * maze.height;

            var start = maze.GetStart();
            var end = maze.GetEnd();
            var endPos= end.Position();

            bool[] visited = new bool[total];
            
            Node[] prev = new Node[total];

            var infinity = float.PositiveInfinity;
            float[] distances = new float[total];
            
            FibNode[] nodeIndex = new FibNode[total];

            for (var i = 0; i < total; i++)
            {
                visited[i] = false;
                distances[i] = infinity;
            }

            var unvisited = new FibPQ();

            distances[start.Position().Y * width + start.Position().X] = 0;
            FibNode startNode = new FibNode(0, start);
            nodeIndex[start.Position().Y * width + start.Position().X] = startNode;
            unvisited.insert(startNode);

            int count = 0;
            completed = false;

            while (unvisited.len() > 0)
            {
                count += 1;

                FibNode n = unvisited.RemoveMinimum();

                //
                Node u = n.value;
                Point uPos = u.Position();
                int uPosIndex = uPos.Y * width + uPos.X;

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
                        Point vPos = v.Position();
                        int vPosIndex = vPos.Y * width + vPos.X;

                        if (visited[vPosIndex] == false)
                        {
                            int d = (vPos.Y - uPos.Y) + (vPos.X - uPos.X);

                            int newDistance = (int)distances[uPosIndex] + d;

                            if (newDistance < distances[vPosIndex])
                            {
                                var vNode = nodeIndex[vPosIndex];
                                
                                //v isn't alread in the queue - add it
                                if (vNode == null)
                                {
                                    vNode = new FibNode(newDistance, v);
                                    unvisited.insert(vNode);
                                    nodeIndex[vPosIndex] = vNode;
                                    distances[vPosIndex] = newDistance;
                                    prev[vPosIndex] = u;
                                }
                                //v is already in the queue - decrease it's key
                                else
                                {
                                    unvisited.decreaseKey(vNode, newDistance);
                                    distances[vPosIndex] = newDistance;
                                    prev[vPosIndex] = u;
                                }
                            }
                        }
                    }
                }

                visited[uPosIndex] = true;
            }  
            
           //Recontruct the path.
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