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

        private string _mazeName;

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
            _mazeName = nodes ? "OUTPUT_" + name + "_" + method + "_" + "nodes" : "OUTPUT_" + name + "_" + method + "_";
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

        public void OutputMap(bool showNodes, bool addColor, List<Node> path, bool gif, bool completed)
        {
            
            Bitmap myBitmap = new Bitmap(width, height + 6);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (maze[x, y])
                    {
                        myBitmap.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        myBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }

            if (showNodes)
            {
                foreach (var node in _nodes)
                {
                    if (addColor)
                    {
                        myBitmap = node.AddColoredPosition(myBitmap);
                    }
                    else
                    {
                        myBitmap = node.AddPosition(myBitmap);
                    }
                }
            }

            if (completed)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Point a = path[i].Position();
                    Point b = path[i + 1].Position();

                    // blue - red;
                    double rF = (double) i / (double) path.Count;
                    double r = rF * (double) 255;
                    Color color = Color.FromArgb((int) r, 0, 255);

                    myBitmap.SetPixel(path[i].x, path[i].y, color);

                    if (gif)
                    {
                        //myBitmap.Save("output/" + _mazeName + "_" + i + ".png");
                    }

                    if (a.X == b.X)
                    {
                        for (int ab = Math.Min(a.Y, b.Y); ab < Math.Max(a.Y, b.Y); ab++)
                        {
                            myBitmap.SetPixel(a.X, ab, color);
                            //if(gif)
                                //myBitmap.Save("output/" + _mazeName + "_" + i + "_" + ab +".png");
                        }
                    }

                    if (a.Y == b.Y)
                    {
                        for (int ab = Math.Min(a.X, b.X); ab < Math.Max(a.X, b.X); ab++)
                        {
                            myBitmap.SetPixel(ab, a.Y, color);
                            //if(gif)
                               // myBitmap.Save("output/" + _mazeName + "_" + i + "_" + ab +".png");
                        }
                    }
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = height; y < height + 6; y++)
                {
                    myBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                }
            }

            //For Tiny Maps
            PixelAlpha pixelAlpha = new PixelAlpha();
            if (width <= 25)
            {
                string countS = path.Count.ToString().Length > 1 ? path.Count.ToString() : "0" + path.Count.ToString();

                int currentCharIndex = 0;
                
                foreach (var c in countS)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1), height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }
            }
            else if(width >= 75)
            {
                string countS = path.Count.ToString().Length > 1 ? "Path Length:" + path.Count: "Path Length:0" + path.Count ;

                int currentCharIndex = 0;
                
                foreach (var c in countS)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1), height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }
            }
            else if(width >= 42)
            {
                string countS = path.Count.ToString().Length > 1 ? "Length:" + path.Count: "Length:0" + path.Count ;

                int currentCharIndex = 0;
                
                foreach (var c in countS)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1), height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }
            }
            else if(width >= 26)
            {
                string countS = path.Count.ToString().Length > 1 ? "Len:" + path.Count: "Len:0" + path.Count ;

                int currentCharIndex = 0;
                
                foreach (var c in countS)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1), height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }
            }

            myBitmap.Save(_mazeName + ".png");
            Console.WriteLine("Completed Path length: " + path.Count);
        }

        public void OutputConsoleInfo()
        {
            
            Console.WriteLine("Completed Path saved as " + _mazeName + ".png");
            
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