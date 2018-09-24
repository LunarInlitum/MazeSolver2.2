using System;
using System.Collections.Generic;
using System.Drawing;

namespace MazeSolver2._2
{
    public class ImageHandler
    {
        public static void OutputMap(Maze mazeClass, List<Node> path, bool showNodes, bool addColor, bool completed, bool addInfo, bool gif)
        {

            var width = mazeClass.width;
            var height = mazeClass.height;
            var maze = mazeClass.GetMaze();
            var nodes = mazeClass.GetNodes();

            if (!showNodes && addColor)
            {
                showNodes = true;
            }
            
            //Creating map
            Bitmap myBitmap = new Bitmap(width, addInfo && showNodes ? height + 12 : addInfo ? height + 6 : height );

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

            //Adds the completed path
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

            if (addInfo && !showNodes)
            {
                //Add area
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
                    string countS = path.Count.ToString().Length > 1
                        ? path.Count.ToString()
                        : "0" + path.Count.ToString();

                    int currentCharIndex = 0;

                    foreach (var c in countS)
                    {
                        bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                        for (int iy = 0; iy < 5; iy++)
                        {
                            for (int ix = 0; ix < 4; ix++)
                            {
                                int pixelIndex = iy * 4 + ix;
                                myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                    height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                            }
                        }

                        currentCharIndex++;
                    }
                }
                else if (width >= 75)
                {
                    string countS = path.Count.ToString().Length > 1
                        ? "Path Length:" + path.Count
                        : "Path Length:0" + path.Count;

                    int currentCharIndex = 0;

                    foreach (var c in countS)
                    {
                        bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                        for (int iy = 0; iy < 5; iy++)
                        {
                            for (int ix = 0; ix < 4; ix++)
                            {
                                int pixelIndex = iy * 4 + ix;
                                myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                    height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                            }
                        }

                        currentCharIndex++;
                    }
                }
                else if (width >= 42)
                {
                    string countS = path.Count.ToString().Length > 1 ? "Length:" + path.Count : "Length:0" + path.Count;

                    int currentCharIndex = 0;

                    foreach (var c in countS)
                    {
                        bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                        for (int iy = 0; iy < 5; iy++)
                        {
                            for (int ix = 0; ix < 4; ix++)
                            {
                                int pixelIndex = iy * 4 + ix;
                                myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                    height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                            }
                        }

                        currentCharIndex++;
                    }
                }
                else if (width >= 26)
                {
                    string countS = path.Count.ToString().Length > 1 ? "Len:" + path.Count : "Len:0" + path.Count;

                    int currentCharIndex = 0;

                    foreach (var c in countS)
                    {
                        bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                        for (int iy = 0; iy < 5; iy++)
                        {
                            for (int ix = 0; ix < 4; ix++)
                            {
                                int pixelIndex = iy * 4 + ix;
                                myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                    height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                            }
                        }

                        currentCharIndex++;
                    }
                }
            }

            if (showNodes && addInfo)
            {
                PixelAlpha pixelAlpha = new PixelAlpha();
                //Add Area
                for (int x = 0; x < width; x++)
                {
                    for (int y = height; y < myBitmap.Height; y++)
                    {
                        myBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                }

                string firstRow = "";
                string secondRow = "";
                
                //For the tiny maps
                if (width <= 25)
                {
                    firstRow = path.Count.ToString().Length > 1 ? path.Count.ToString() : "0" + path.Count;
                    secondRow = nodes.Count.ToString().Length > 1 ? nodes.Count.ToString() : "0" + nodes.Count;
                }
                else if (width >= 80)
                {
                    firstRow = path.Count.ToString().Length > 1
                        ? "Path Length:" + path.Count
                        : "Path Length:0" + path.Count;
                    secondRow = "Node total: " + nodes.Count;
                }
                else if (width >= 42)
                {
                    firstRow = path.Count.ToString().Length > 1
                        ? "Length:" + path.Count
                        : "Length:0" + path.Count;
                    secondRow = "Nodes: " + nodes.Count;
                }
                else if (width >= 26)
                {
                    firstRow = path.Count.ToString().Length > 1 ? "Len:" + path.Count : "Len:0" + path.Count;
                    secondRow = "n:" + nodes.Count;
                }
                
                int currentCharIndex = 0;
                foreach (var c in firstRow)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                height + iy + 1, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }

                currentCharIndex = 0;
                foreach (var c in secondRow)
                {
                    bool[] currentChar = pixelAlpha.GetPixelCharacter(c);
                    for (int iy = 0; iy < 5; iy++)
                    {
                        for (int ix = 0; ix < 4; ix++)
                        {
                            int pixelIndex = iy * 4 + ix;
                            myBitmap.SetPixel(currentCharIndex * 4 + ix + (1 * currentCharIndex + 1),
                                height + iy + 1 + 6, currentChar[pixelIndex] ? Color.Black : Color.White);
                        }
                    }

                    currentCharIndex++;
                }
            }
            
            //Adds the nodes to the maze
            if (showNodes)
            {
                foreach (var node in nodes)
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

            myBitmap.Save(mazeClass.mazeName + ".png");
            Console.WriteLine("Completed Path length: " + path.Count);
        }
    }
}