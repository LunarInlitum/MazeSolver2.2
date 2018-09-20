using System.Drawing;

namespace MazeSolver2._2
{
    public class PathFactory
    {
        public static bool IsStraight(Maze maze, int x, int y)
        {
            if (!(y == 0 || x == 0 || y == maze.height - 1 || x == maze.width - 1))
            {
                if (!maze.GetPixel(x - 1, y) && !maze.GetPixel(x + 1, y) ||
                    !maze.GetPixel(x, y - 1) && !maze.GetPixel(x, y + 1))
                {
                    return true;
                }
            }

            return false;
        }
        
        //Used to check if the pixel is a wall
        public static bool IsWall(Maze maze, int x, int y)
        {
            return maze.GetPixel(x, y);
        }

        public static Color GetColorByPaths(Maze maze, bool[] paths)
        {
            var i = 0;
            foreach (var direction in paths)
            {
                if (direction)
                    i++;
            }

            return i == 1 ? maze.Dead :
                i == 2 ? maze.Corner :
                i == 3 ? maze.Junction :
                i == 4 ? maze.Cross : maze.BrokenNode;
        }

        //Used to check how many paths are connected to the current path.
        public static bool[] GetConnectedPaths(Maze maze, int x, int y)
        {
            bool[] connected = {false, false, false, false};
            
            if (y > 0)
                if (!IsWall(maze, x, y - 1))
                    connected[0] = true;
            if (x < maze.width - 1)
                if (!IsWall(maze, x + 1, y))
                    connected[1] = true;
            if (y < maze.height - 1)
                if (!IsWall(maze, x, y + 1))
                    connected[2] = true;
            if(x > 0)
                if (!IsWall(maze, x - 1, y))
                    connected[3] = true;
            return connected;

        }

        public static int GetNumberOfDirections(Maze maze, int x, int y)
        {
            int i = 0; 
            
            if (y > 0)
                if (!IsWall(maze, x, y - 1))
                    i++;
            if (x < maze.width - 1)
                if (!IsWall(maze, x + 1, y))
                    i++;
            if (y < maze.height - 1)
                if (!IsWall(maze, x, y + 1))
                    i++;
            if(x > 0)
                if (!IsWall(maze, x - 1, y))
                    i++;
            return i;
        }
        
    }
}