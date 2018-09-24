using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MazeSolver2._2
{
    public class Maze
    {
        //True = wall | False = Path
        private bool[,] maze;
        private readonly List<Node> _nodes = new List<Node>();

        private Node _start, _end;

        public string mazeName;

        public Color BrokenNode = Color.Yellow;
        public Color Dead = Color.DarkMagenta;
        public Color Corner = Color.BurlyWood;
        public Color Junction = Color.DarkSalmon;
        public Color Cross = Color.Teal;

        public int width, height;

        public Maze(int width, int height)
        {
            maze = new bool[width, height];
            this.width = width;
            this.height = height;

        }

        public bool GetPixel(int x, int y)
        {
            return maze[x, y];
        }

        public void SetCustomName(string name, string method, bool nodes)
        {
            mazeName = nodes ? "OUTPUT_" + name + "_" + method + "_" + "nodes" : "OUTPUT_" + name + "_" + method + "_";
        }

        public void AddNode(Node node)
        {
            _nodes.Add(node);
        }
        

        private void AddNode(int x, int y, Color color)
        {
            var node = new Node(x, y, color);
            _nodes.Add(node);
        }

        public void SetStart()
        {
            
            for(int x = 0; x < width; x++)
            {
                if (!GetPixel(x, 0))
                {
                    AddNode(x, 0, Color.Green);
                    _start = _nodes[_nodes.Count - 1];
                }
            }
        }
        
        public bool SetEnd()
        {
            for(int x = 0; x < width; x++)
            {
                if (!GetPixel(x,  height - 1))
                {
                    AddNode(x, height - 1, Color.Red);
                    _end = _nodes[_nodes.Count - 1];
                    return true;
                }
            }

            return false;
        }

        public Node GetStart()
        {
            return _start;
        }
       
        public Node GetEnd()
        {
            return _end;
        }

        public bool[] GetMazeAsBoolArray()
        {
            List<bool> list = new List<bool>();
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    list.Add(GetPixel(x, y));
                }
            }

            bool[] array = list.ToArray();
            return array;
        }

        public void OutputMap(bool showNodes, bool addColor, List<Node> path, bool addInfo, bool gif, bool completed)
        {
            ImageHandler.OutputMap(this, path, showNodes, addColor, completed, addInfo, gif);
        }

        public bool[,] GetMaze()
        {
            return maze;
        }

        public List<Node> GetNodes()
        {
            return _nodes;
        }

        public void OutputConsoleInfo()
        {
            
            Console.WriteLine("Completed Path saved as " + mazeName + ".png");
            
            Console.WriteLine("Total amount of nodes:\t" + _nodes.Count);
            
            Console.WriteLine("Total amount of connections:\t0");
            
        }

        public void SetPixel(int x, int y, bool value)
        {
            maze[x, y] = value;
        }

        public Node GetAboveNode(int x, int y)
        {

            foreach (var n in _nodes)
            {
                if (n.x == x && n.y == y)
                    return n;
            }

            return null;
        }
    }
}