﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorProject {
    class Maze {
        public int startCell, endCell;
        public Cell [] Cells;

        //==generate==generate==generate==generate==
        public void Generate(GeneratorOptions options) {
            switch (options.generationType) {
                case GeneratorOptions.GenerationType.Gamma:
                    Cells = createGammaMesh(options.Size, options.Appearance.passageW*2);
                    break;
                case GeneratorOptions.GenerationType.Delta:
                    Cells = createDeltaMesh(options.Size, options.Appearance.passageW*2);
                    break;
                case GeneratorOptions.GenerationType.Theta:
                    Cells = createThetaMesh(options.Size, options.Appearance.passageW*2);
                    break;
                default:
                    return;
            }
            //this uses Kruskal's Algorithm with random weights to generate the maze
            List<List<int>> groups = new List<List<int>>();
            for (int i = 0; i < Cells.Length; i++) {
                groups.Add(new List<int>());
                groups[i].Add(i);
            }

            while (groups.Count > 1) {
                Random rng = new Random();
                //pick a group
                //pick a cell
                //pick a neighbour
                //if from different groups, merge the groups and add a connection

                //pick a group
                int group1Index = rng.Next(groups.Count);
                int cell1Index = -1;
                int cell2Index = -1;
                //pick a cell
                for (int indexInGrp1 = 0; indexInGrp1 < groups[group1Index].Count; indexInGrp1++) {
                    bool cell1HasValidNeighbour = false;
                    cell1Index = groups[group1Index][rng.Next(groups[group1Index].Count)];
                    Cell cell1TMP = Cells[cell1Index];

                    //pick a neighbour
                    int checkoffset = rng.Next(cell1TMP.Neighbours.Length);
                    for (int i = 0; i < cell1TMP.Neighbours.Length; i++) {
                        cell2Index = cell1TMP.Neighbours[(i+checkoffset)%cell1TMP.Neighbours.Length].NeighbourIndex;

                        if (!groups[group1Index].Contains(cell2Index)) {
                            cell1HasValidNeighbour = true;
                            break;
                        }
                    }


                    if (cell1HasValidNeighbour) { break; } //there will be a cell with a neighbour that isn't part of it's group
                }

                //if from different groups, merge the groups and add a connection
                if (cell1Index == -1) { throw new Exception("Cell1 not found."); }
                if (cell2Index == -1) { throw new Exception("Cell2 not found."); }
                Cell cell2 = Cells[cell2Index], cell1 = Cells[cell1Index];
                for (int i = 0; i < cell1.Neighbours.Length; i++) {
                    if (cell1.Neighbours[i].NeighbourIndex == cell2Index) { cell1.Neighbours[i].Connected = true; }
                }
                for (int i = 0; i < cell2.Neighbours.Length; i++) {
                    if (cell2.Neighbours[i].NeighbourIndex == cell1Index) { cell2.Neighbours[i].Connected = true; }
                }

                //find the group cell2 belongs to
                int group2Index = -1;
                for (int i = 0; i < groups.Count; i++) {
                    if (groups[i].Contains(cell2Index)) { group2Index = i; break; }
                }
                if (group2Index == -1) { throw new Exception("group2 not found."); }
                //merge them
                groups[group1Index].AddRange(groups[group2Index]); //add into group1
                groups.RemoveAt(group2Index); //remove group2
            }

        }

        private Cell[] createGammaMesh(int Size, float spaceing) { //square
            List<Cell> vertices = new List<Cell>();
            Random rng = new Random();
            //size is an edge length
            int mazeW = Size;
            int mazeH = (int)(Size*(float)(rng.Next(75, 125)/100f));

            //i = x+y*width
            //y = i/width
            //x = i%width
            for (int i = 0; i < mazeW*mazeH; i++) {
                int x = i % mazeW, y = i / mazeW;
                PointF pos = new PointF(x*spaceing, y*spaceing);

                List<Connection> neighbours = new List<Connection>();
                if (x != 0)       { neighbours.Add(new Connection((x-1)+(y*mazeW), false)); }
                if (x != mazeW-1) { neighbours.Add(new Connection((x+1)+(y*mazeW), false)); }

                if (y != 0)       { neighbours.Add(new Connection(x+((y-1)*mazeW), false)); }
                if (y != mazeH-1) { neighbours.Add(new Connection(x+((y+1)*mazeW), false)); }

                vertices.Add(new Cell(pos, neighbours.ToArray()));
            }
            
            startCell = rng.Next(0, mazeW); //x is random, y is 0
            endCell   = rng.Next(0, mazeW)+(mazeH-1)*mazeW; //x is random, y is height

            return vertices.ToArray();
        }
        private Cell[] createDeltaMesh(int Size, float spaceing) { //triangle
            List<Cell> vertices = new List<Cell>();
            int numNodes = (int)(0.5f*Size*(Size+1));

            int rowNumb = 0, colNumb = 0;
            for (int i = 0; i < numNodes; i++) {
                PointF pos = new PointF( (colNumb+(0.5f*(Size-rowNumb))-Size*0.5f)*spaceing, rowNumb*spaceing );
                
                List<Connection> neighbours = new List<Connection>();
                if (colNumb < rowNumb) {
                    neighbours.Add(new Connection(i+1, false)); //right
                    neighbours.Add(new Connection(i-rowNumb, false)); //top-right
                }
                if (rowNumb < Size-1) {
                    neighbours.Add(new Connection(i+rowNumb+1, false)); //bottom-left
                    neighbours.Add(new Connection(i+rowNumb+2, false)); //bottom-right
                }
                if (colNumb > 0) {
                    neighbours.Add(new Connection(i-1, false)); //left
                    neighbours.Add(new Connection(i-rowNumb-1, false)); //top-left
                }
                vertices.Add(new Cell(pos, neighbours.ToArray()));

                colNumb++;
                if (colNumb > rowNumb) { colNumb = 0; rowNumb++; }
            }

            Random rng = new Random();

            startCell = 0; //top-most point
            endCell = rng.Next(1, Size) + (int)(0.5f*Size*(Size-1)); //x is random, y is height

            //to find index of a cell:
            //to the left: sub 1
            //to the right: add 1
            //to the top-left: sub row numb & sub 1
            //to the top-right: sub row numb
            //to the bottom-left: add row numb & add 1
            //to the bottom-right: add row numb & add 2

            return vertices.ToArray();
        }
        private Cell[] createThetaMesh(int Size, float spaceing) { //circle
            List<Cell> vertices = new List<Cell>();
            Size = (int)MathF.Sqrt(Size);

            const int startingcells = 5;

            int i = 0;
            int numInOuterCircle = (int)MathF.Pow(2, Size-1)*startingcells;
            int outerRadius = (int)((numInOuterCircle*spaceing)/(2*MathF.PI));
            for (int r = 1; r <= Size; r++) {
                int numInCircle = (int)MathF.Pow(2, r-1)*startingcells;
                float drawRadius = (numInCircle*spaceing)/(2*MathF.PI);
                drawRadius = outerRadius*((float)r/Size);
                for (int proportion = 0; proportion < numInCircle; proportion++) {
                    float theta = (2*MathF.PI)*((float)proportion/numInCircle);

                    List<Connection> neighbours = new List<Connection>();
                    PointF pos = new PointF(drawRadius*MathF.Sin(theta), drawRadius*MathF.Cos(theta));

                    //add neighbour ccw
                    if (proportion == numInCircle-1) {
                        neighbours.Add(new Connection(i-proportion, false));
                    } else {
                        neighbours.Add(new Connection(i+1, false));
                    }
                    //add neighbour cw
                    if (proportion == 0) {
                        neighbours.Add(new Connection(i+(numInCircle)-1, false));
                    } else {
                        neighbours.Add(new Connection(i-1, false));
                    }

                    //add cell below
                    if ( r != 1 ) {
                        neighbours.Add(new Connection(i-proportion-numInCircle/2+proportion/2, false));
                    }
                    //add the 2 cells above
                    if (r != Size ) {
                        neighbours.Add(new Connection(i-proportion+numInCircle+proportion*2, false));
                        neighbours.Add(new Connection(i-proportion+numInCircle+proportion*2+1, false));
                    }

                    i++;
                    vertices.Add(new Cell(pos, neighbours.ToArray()));
                }
            }
            
            startCell = vertices.Count-(int)(numInOuterCircle*0.5f);
            endCell = vertices.Count-numInOuterCircle;

            return vertices.ToArray();
        }

        //==solve==solve==solve==solve==solve==solve==
        /// <summary>
        /// Finds a solution to the maze
        /// </summary>
        /// <returns> A list of indexes showing the route taken between the start and end. </returns>
        public int[] Solve() { 
            
            return new int[]{};
        }
    }

    struct Cell {
        public PointF Position { get; private set; }
        public Connection[] Neighbours;

        public Connection[] NeighboursConnected { get { return Neighbours.Where(n => n.Connected).ToArray(); } }
        public Connection[] NeighboursDisconnected { get { return Neighbours.Where(n => !n.Connected).ToArray(); } }
        public float X { get { return Position.X; } }
        public float Y { get { return Position.Y; } }

        public Cell(PointF position, Connection[] neighbours) {
            Position = position;
            Neighbours = neighbours;
        }
    }

    struct Connection {
        public readonly int NeighbourIndex;
        public bool Connected;

        public Connection(int index, bool connected) {
            NeighbourIndex = index;
            Connected = connected;
        }
    }
}