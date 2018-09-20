using System;
using System.Drawing;
using Priority_Queue;

namespace MazeSolver2._2
{
    public class Dijkstra
    {
        private Maze maze;

        public Dijkstra(Maze maze)
        {
            this.maze = maze;

            var width = maze.width;
            
            var total = maze.width * maze.height;

            var start = maze.GetStart();
            var end = maze.GetEnd();
            var endPos= end.Position();

            bool[] visited = new bool[total];
            
            Node[] prev = new Node[total];

            var infinity = float.PositiveInfinity;
            float[] distances = new float[total];
            
            Node[] nodeIndex = new Node[total];

            for (var i = 0; i < total; i++)
            {
                visited[i] = false;
                prev[i] = null;
                distances[i] = infinity;
                nodeIndex[i] = null;
            }

            distances[start.Position().X * width + start.Position().Y] = 0;
            
        }
    }
}