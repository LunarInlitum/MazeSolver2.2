using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using CommandLine.Text;

namespace MazeSolver2._2
{
    public class LeftTurn
    {
        public bool completed;
        
        public List<Node> solve(Maze maze)
        {
            List<Node> path = new List<Node>();
            path.Add(maze.GetStart());

            var current = maze.GetStart().neighbours[2];

            if (current == null)
                return path;

            var heading = 2; //South

            var turn = 1; //Turning left, -1 for right

            var startPos = maze.GetStart().Position();
            var endPos = maze.GetEnd().Position();


            completed = false;

            while (true)
            {
                path.Add(current);

                Point position = current.Position();

                if (position == startPos || position == endPos)
                {
                    if (position == endPos)
                    {
                        completed = true;
                        path.Add(current);
                        break;
                    }
                }

                Node[] n = current.neighbours;
                //
                
                if (n[Minus(heading)] != null)
                {
                    heading = Minus(heading);
                    current = n[heading];
                }
                else if (n[heading] != null)
                {
                    current = n[heading];
                }else if (n[Add(heading)] != null)
                {
                    heading = Add(heading);
                    current = n[heading];
                }else if (n[AddTwo(heading)] != null)
                {
                    heading = AddTwo(heading);
                    current = n[heading];
                }

                completed = false;
            }

            return path;

        }

        private int Minus(int heading)
        {
            heading--;
            if (heading < 0)
            {
                heading = 3;
            }

            return heading;
        }
        
        private int Add(int heading)
        {
            heading++;
            if (heading > 3)
            {
                heading = 0;
            }

            return heading;
        }

        private int AddTwo(int heading)
        {
            heading += 2;
            if (heading == 4)
            {
                heading = 0;
            }

            if (heading == 5)
            {
                heading = 1;
            }

            return heading;
        }
    }
}