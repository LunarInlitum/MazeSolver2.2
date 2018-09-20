using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using CommandLine;
using CommandLine.Text;

namespace MazeSolver2._2
{
    internal class Program
    {
        
        /*Input argument thingies*/

        private string _mazeFileName, _method;

        private bool _showNodes;
        private bool _addColor;
        private bool _gif;
        
        private Maze _maze;
        
        // 0 = North
        // 1 = East
        // 2 = South
        // 3 = West


        private void GetArguments(string[] args)
        {
            var o = new Options();
            if (Parser.Default.ParseArguments(args, o)) {
                // Values are available here
                if(!string.IsNullOrEmpty(o.InputFile))
                    _mazeFileName = o.InputFile;
                
                _method = o.Method;
                _showNodes = o.ShowNodes;
                _addColor = o.AddColor;
                _gif = o.OutputGif;

            }

        }
        
        //Setup converts png into a boolean array to be used.
        private void Setup()
        {
            var imageMap = new Bitmap(Image.FromFile(_mazeFileName));
            _maze = new Maze(imageMap.Width, imageMap.Height);
            for (var y = 0; y < imageMap.Height; y++)
            {
                for (var x = 0; x < imageMap.Width; x++)
                {
                    var pixelColor = imageMap.GetPixel(x, y);
                    _maze.SetPixel(x, y, pixelColor == Color.FromArgb(255, 0, 0, 0));
                }
            }

            _maze.SetCustomName(_mazeFileName.Substring(0, _mazeFileName.Length - 4), _method, _showNodes);
        }

        private void BetterOnePass()
        {

            var width = _maze.width;
            var height = _maze.height;
            
            Node[] topNodes = new Node[width];

            for (var y = 0; y < width - 1; y++)
            {
                topNodes[y] = null;
            }
            
            _maze.SetStart();
            topNodes[_maze.GetStart().x] = _maze.GetStart();

            Node t;

            for (var y = 1; y < height - 1; y++)
            {
                
                bool prv = true;
                var cur = true;
                var nxt = _maze.GetPixel(1, y);

                Node leftNode = null;

                for (var x = 1; x < width - 1; x++)
                {
                    prv = cur;
                    cur = nxt;
                    nxt = _maze.GetPixel(x+1, y);

                    Node n = null;
    
                        if (!cur)
                        {
                            if (!prv)
                            {
                                if (!nxt)
                                {
                                    // Path Path Path
                                    //Got to create a node only if there is a path above or below this boi
    
                                    //To set the colours correctly just checking if there is path above and below first
                                    if (!_maze.GetPixel(x, y - 1) && !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Cross);
                                        if (leftNode != null)
                                        {
                                            leftNode.neighbours[1] = n;
                                            n.neighbours[3] = leftNode;
                                        }
    
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                    else if (!_maze.GetPixel(x, y - 1) || !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Junction);
                                        if (leftNode != null)
                                        {
                                            leftNode.neighbours[1] = n;
                                            n.neighbours[3] = leftNode;
                                        }
    
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                }
                                else
                                {
                                    //Path Path Wall
                                    //Create path at end of corridor
                                    
                                    if (!_maze.GetPixel(x, y - 1) && !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Junction);
                                        if (leftNode != null)
                                        {
                                            leftNode.neighbours[1] = n;
                                            n.neighbours[3] = leftNode;
                                        }
    
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                    else if (!_maze.GetPixel(x, y - 1) || !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Corner);
                                        if (leftNode != null)
                                        {
                                            leftNode.neighbours[1] = n;
                                            n.neighbours[3] = leftNode;
                                        }
    
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                    else
                                    {
                                        n = new Node(x, y, _maze.Dead);
                                        if (leftNode != null)
                                        {
                                            leftNode.neighbours[1] = n;
                                            n.neighbours[3] = leftNode;
                                        }
    
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                }
                            }
                            else
                            {
                                if (!nxt)
                                {
                                    //Wall Path Path
                                    //Create path at start of corridor
                                    
                                    if (!_maze.GetPixel(x, y - 1) && !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Junction);
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                    else if (!_maze.GetPixel(x, y - 1) || !_maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Corner);
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                    else
                                    {
                                        n = new Node(x, y, _maze.Dead);
                                        leftNode = n;
                                        _maze.AddNode(n);
                                    }
                                }
                                else
                                {
                                    //Wall Path Wall
                                    //Create node only if in dead end
                                    if (_maze.GetPixel(x, y - 1) || _maze.GetPixel(x, y + 1))
                                    {
                                        n = new Node(x, y, _maze.Dead);
                                        _maze.AddNode(n);
                                    }
                                }
                            }
    
                            //Check if node is nothing then a connection can be made
                            if (n != null)
                            {
                                //Clear above, connect to waiting top node
    
                                if (!_maze.GetPixel(x, y - 1))
                                {
                                    t = topNodes[x];
                                    t.neighbours[2] = n;
                                    n.neighbours[0] = t;
                                }
    
                                //if clear below, put this new node in the top row for the next connection
                                if (!_maze.GetPixel(x, y + 1))
                                {
                                    topNodes[x] = n;
                                }
                                else
                                {
                                    topNodes[x] = null;
                                }
                            }
                        }
                        else
                        {
                            //This boi is a wall :P
                        }
                    }
                }

            if (_maze.SetEnd())
            {

                int x = _maze.GetEnd().x;
                
                for (int y = 1; y < _maze.GetEnd().y; y++)
                {
                    if (!_maze.GetPixel(x, _maze.GetEnd().y - y) && _maze.GetAboveNode(x, _maze.GetEnd().y - y) != null)
                    {
                        t = _maze.GetAboveNode(_maze.GetEnd().x, _maze.GetEnd().y - y);
                        t.neighbours[2] = _maze.GetEnd();
                        _maze.GetEnd().neighbours[0] = t;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Something went wrong with the end node");
            }

        }

        private void Solve()
        {
            List<Node> path = new List<Node>();
            int count = 0;
            int len = 0;
            bool completed = false;
            switch (_method)
            {
                    case "leftturn":
                        LeftTurn leftTurn = new LeftTurn();
                        path = leftTurn.solve(_maze);
                        count = leftTurn.count;
                        len = leftTurn.len;
                        completed = leftTurn.completed;
                        break;
            }
            
            _maze.OutputMap(_showNodes, _addColor, path, count, _gif, completed);
        }
        
        private void Run(string[] args)
        {
            GetArguments(args);

            if (!string.IsNullOrEmpty(_mazeFileName))
            {
                
                Stopwatch setup = new Stopwatch();
                Console.WriteLine("Starting setup");
                setup.Start();
                Setup();
                setup.Stop();
                
                Console.WriteLine("Setup took " + setup.Elapsed);
                
                Stopwatch onePass = new Stopwatch();
                Console.WriteLine("Starting Onepass");
                onePass.Reset();
                onePass.Start();
                BetterOnePass();
                onePass.Stop();
                
                Console.WriteLine("One Pass took " + onePass.Elapsed);
                
                Stopwatch solve = new Stopwatch();
                Console.WriteLine("Starting Solve");
                solve.Reset();
                solve.Start();
                Solve();
                solve.Stop();
                Console.WriteLine("Solving the maze took " + solve.Elapsed);
                Console.WriteLine("Outputing Console Information");
                _maze.OutputConsoleInfo();
                
                Console.WriteLine("Total elipsed time:\t" + (onePass.Elapsed + setup.Elapsed + solve.Elapsed));
            }

            Environment.Exit(1);
        }
        
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }

        //This class is used to handle arguements for console
        private class Options
        {
            [Option('i', "input", Required = true, HelpText = "Input file to be processed.")]
            public string InputFile { get; set; }
            
            [Option('m', "method", DefaultValue = "dijkstra", HelpText = "Choose what method you wish to use.\n" + "\tCurrently available methods:\n" + "\t\tDijkstra\n" + "\t\tLeft\n")]
            public string Method { get; set; }
            
            [Option('n', "node", DefaultValue = false, HelpText = "Shows the nodes of the maze.")]
            public bool ShowNodes { get; set; }
            
            [Option('c', "color", DefaultValue = false, HelpText = "Adds a bit of colour to the nodes to help with debugging")]
            public bool AddColor { get; set; }
            
            [Option('g', "gif", DefaultValue = false, HelpText = "Make a gif if the maze gets solved?")]
            public bool OutputGif { get; set; }
            
            [ParserState]
            public IParserState LastParserState { get; set; }
                
            [HelpOption]
            public string GetUsage()
            {
                string str = HelpText.AutoBuild(this,
                  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));

                return str;
            }
        }
    }
}