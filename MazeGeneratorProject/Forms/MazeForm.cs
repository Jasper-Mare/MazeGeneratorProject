using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class MazeForm : Form {
        //====================================================================================//
        //=== engine vars === engine vars === engine vars === engine vars === engine vars === //
        //====================================================================================//
        // #region is a keyword in c# that tells the IDE that this is a section of code I want to be able to minimise
        #region Engine Variables
        //the size of the image the maze is drawn on will be
        const int width  = 720;
        const int height = 720;

        Bitmap image = new Bitmap(width, height); //the image the maze will be drawn on
        Graphics gfx; //the graphics ogject that will draw the maze on the image
        System.Timers.Timer updater = new System.Timers.Timer(1); //a timer is an object in .net that will call a subroutine every set number of milliseconds
        //stopwatches are objects used to measure the time taken for a peice of code to run
        Stopwatch updateTimer = new Stopwatch(); //measures the time between the start of each itteration of the update loop
        Stopwatch frameTimer = new Stopwatch(); //measures the time between the start of each itteration of the draw loop

        InterpolationMode interpMode = InterpolationMode.NearestNeighbor; //the method used to interpolate or antialias the frame, I use nearest neighbour as it is the fastest and prevents bluring in the image
        PointF cameraPos; //the position in world coordinates of the 'camera' the world is viewed through
        float cameraZoom; //how zoomed-in the camera is (a zoom of 1 means that every 1 world distance unit == 1 pixel in the image)
        #endregion

        Stopwatch userTime = new Stopwatch(); //a stopwatch to measure the time the user takes to solve the maze
        User user; //the account of the current user

        Random rng = new Random(); //a random number generator

        GeneratorOptions options; //the generation and apperance options used for this maze.
        Maze maze; //the maze

        Size shadowSize = new Size(600,600); //the size of the area of light drawn around objects when shadows are on

        bool paused = false;
        bool solved = false;
        bool exitLocked;

        //whether a movement key is currently held, is turned on when the button is pressed, is turned off when that button is 
        bool keyUpPressed = false;
        bool keyDownPressed = false;
        bool keyRightPressed = false;
        bool keyLeftPressed = false;

        //a structure that holds all the information about the user's marker
        struct marker {
            public static int currentCellIndex; //the index of the cell the marker is currently on
            public static int nextCellIndex; //the index of the cell the marker is moving to
            public static float proportionAlongPassage; //how far the marker is between the current cell and the next cell (usually between 0 and 1)
            public const float speed = 2f;
            public static Stack<int> pastLocations = new Stack<int>(); //a collection of the route the user has followed so far
            public enum stateType { waiting, moving } //if the marker is waiting or moving, I didn't use a boolean because I felt that this made my code more readable
            public static stateType state = stateType.waiting;
        }
        int selectedDirection; //if the maze is a triangular maze, this holds the direction the movement pointer is pointing

        //a structure that holds all the information about the minotaur if it is active
        struct minotaur {
            public static List<int> path = new List<int>(); //the indexes of the cells the minotaur will travel through between it's current positionand it's target position
            public static float proportionAlongPassage; //how far the minotaur is between the current cell and the next cell (usually between 0 and 1)
            public const float speed = 1.8f;
            public static float hearingRange; //how far the minotaur can hear (changes based on the size of the maze)
            public static bool heardUser; //if the minotaur has heard the user
        }

        public MazeForm(User user, GeneratorOptions options) {
            InitializeComponent();
            this.user = user;
            this.options = options;
        }

        private void MazeForm_Load(object sender, EventArgs e) { //runs before the form appears
            lbl_Username.Font = StyleSheet.Body;
            lbl_Username.Text = user.Name;
            lbl_timer.Font = StyleSheet.Body;
            bttn_pause.Font = StyleSheet.Body;
            bttn_resume.Font = StyleSheet.Body;
            bttn_returnToMenu.Font = StyleSheet.Body;

            lbl_paused.Font = StyleSheet.Headings;

            Canvas.InterpolationMode = interpMode;
            Canvas.Image = image;

            exitLocked = options.Keys; //if the user has enabled the 'keys' feature (where a set of keys must be found before the maze can be completed) then the exit is locked, otherwise it is unlocked

            pnl_pausedMenu.Hide(); //hide the pause menu

            gfx = Graphics.FromImage(image); //set the graphics object
            gfx.InterpolationMode = interpMode;
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit; //make it so text fits the image

            minotaur.path.Clear(); //empty the minotaur's path (if this wasn't here, the minotaur would repeat the path it was following when in the previous maze)
        }

        private void MazeForm_Shown(object sender, EventArgs e) { //runs after the form has loaded and appeared.
            //make the start button unuseable while the maze is generating (generation is less than a second on the biggest size, but this is here so they user can't cause a crash in that time)
            bttn_Start.Text = "Loading...";
            bttn_Start.Enabled = false;

            maze = new Maze();
            maze.Generate(options); //generate the maze

            marker.pastLocations.Push(maze.StartCell); //put the first location of the marker on its past locations list

            //now the maze is generated, make the start button useable
            bttn_Start.Text = "START";
            bttn_Start.Enabled = true;
        }

        private void bttn_Start_Click(object sender, EventArgs e) { //when the maze starts
            marker.currentCellIndex = maze.StartCell; //place the marker in the start of the maze
            marker.nextCellIndex = maze.StartCell; //point the marker at its current cell
            marker.proportionAlongPassage = 1;

            KeyPreview = true; //allow the form to intercept keypresses to allow processing
            //link up the keypress events with the keypress subroutines
            KeyDown += KeyPressed;
            KeyUp += KeyUnpressed;

            //start the timer
            updater.Elapsed += UpdateLoop; //link the update timer to the update subroutine
            updater.Enabled = true; //turn on the timer
            Canvas.Invalidate(); //cause the picture box to re-draw, starting the drawloop
            Canvas.Paint += Canvas_Paint; //link the picturebox's draw event to the draw subroutine
            userTime.Start(); //start the timer measuring how long the user takes in the maze

            //position and centre the camera to fit the maze in view
            cameraPos = maze.Centre;
            cameraZoom = 650/MathF.Max(maze.Bounds.Width, maze.Bounds.Height);

            Random rng = new Random(); //initialise the random number generator

            //if the minotaur is on
            if (options.Minotaur) {
                minotaur.path.Add(rng.Next(0, maze.Cells.Length)); //set the minotaur's current position
                minotaur.hearingRange = options.Appearance.PassageW*MathF.Pow(1.03f,0.6f*options.Size+50); //calculate the distance the minotaur can hear in
            }

            bttn_Start.Hide(); //hide the start button
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            float deltaT = frameTimer.ElapsedMilliseconds/1000f; //calculate delta time in seconds
            frameTimer.Restart(); //restart the frametimer
            
            //delta time is the time between the starts of each drawloop, it is used to make motion in games smooth as speed won't drastically change if the framerate fluctuates allot

            if (!(paused || solved)) { //if the maze is running
                lbl_timer.Text = "Time: " + userTime.Elapsed.ToString(@"hh\:mm\:ss\:f"); //write the time spent in the maze to the topbar

                Brush psgBrsh = options.Appearance.PassageBrush; //make a reference to the passage brush so the code is more compact/readable (e.g. psgbrsh instead of options.Appearance.PassageBrush)
                int psgW = options.Appearance.PassageW; //make a coppy of the passage width so code is more compact/readable
                Point markerPos = LerpPos(maze.Cells[marker.currentCellIndex].Position, maze.Cells[marker.nextCellIndex].Position, marker.proportionAlongPassage); //calculate the visible position of the marker
                markerPos.X -= psgW / 2; markerPos.Y -= psgW / 2; //offset it to correct for alignment

                gfx.FillRectangle(options.Appearance.WallBrush, 0,0, width, height); //draw the background
                gfx.TranslateTransform(width/2, height/2); //offset the camera so world coordinates (0,0) is at the centre of the screen
                gfx.ScaleTransform(cameraZoom, cameraZoom); //zoom the camera
                gfx.TranslateTransform(-cameraPos.X, -cameraPos.Y); //move the camera to its position
                //https://www.vbforums.com/showthread.php?624596-RESOLVED-Offsetting-a-HatchBrush
                gfx.RenderingOrigin = new Point((int)cameraPos.X, (int)cameraPos.Y); //offset the origin of hatchbrushes
                
                //draw out all the cells and passages
                foreach (Cell c in maze.Cells) {
                    foreach (Connection conn in c.Neighbours) {
                        if (conn.Connected) {
                            //draw passage
                            if (!conn.hidden && 0 <= conn.NeighbourIndex && conn.NeighbourIndex < maze.Cells.Length) {
                                gfx.FillPolygon(psgBrsh, LineToPolygon(c.Position, maze.Cells[conn.NeighbourIndex].Position, psgW));
                            }

                        }
                    }
                    gfx.FillEllipse(psgBrsh, c.X-psgW/2, c.Y-psgW/2, psgW, psgW); //draw cell
                }

                if (exitLocked) { //if the exit is locked draw it in grey
                    gfx.FillEllipse(Brushes.DarkGray, maze.Cells[maze.EndCell].X-psgW/2, maze.Cells[maze.EndCell].Y-psgW/2, psgW, psgW);
                } else { //otherwise draw it in red
                    gfx.FillEllipse(Brushes.Red, maze.Cells[maze.EndCell].X-psgW/2, maze.Cells[maze.EndCell].Y-psgW/2, psgW, psgW);
                }
                
                //draw out the keys
                if (options.Keys) {
                    foreach (int keyLoc in maze.Keys.Where(k => k != -1)) {
                        gfx.FillEllipse(Brushes.Gold, maze.Cells[keyLoc].X - psgW / 2, maze.Cells[keyLoc].Y - psgW / 2, psgW, psgW);
                    }
                }

                //an array of all the indexes of cells the marker has visited
                int[] movestack = marker.pastLocations.ToArray();
                //draw out the path the marker has taken
                for (int i = 0; i < movestack.Length-1; i++) {
                    gfx.DrawLine(Pens.Blue, maze.Cells[movestack[i]].X, maze.Cells[movestack[i]].Y, maze.Cells[movestack[i+1]].X, maze.Cells[movestack[i+1]].Y);
                }

                //draw marker
                gfx.FillEllipse(Brushes.Green, markerPos.X, markerPos.Y, psgW, psgW);
                //if the maze requires the direction picker draw it
                if (marker.state == marker.stateType.waiting && options.GenerationType == GeneratorOptions._GenerationType.Delta) {
                    Pen p = new Pen(Color.Yellow, 5);
                    AdjustableArrowCap arrowCap = new AdjustableArrowCap(5,5);
                    p.CustomEndCap = arrowCap;
                    p.StartCap = LineCap.Flat;
                    gfx.DrawLine(p, maze.Cells[marker.currentCellIndex].Position, maze.Cells[maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex].Position);
                }


                if (options.Minotaur) { //if the minotaur is enabled
                    //copy the minotaur's path so the drawloop is working on the same data set fo this whole section instead of it being changed by the update loop partway through
                    int[] pathcopy = minotaur.path.ToArray();
                    //calculate the minotaur's position
                    PointF minotaurPos;
                    if (pathcopy.Count() >= 2) { 
                        minotaurPos = LerpPos(maze.Cells[pathcopy[0]].Position, maze.Cells[pathcopy[1]].Position, minotaur.proportionAlongPassage);
                    } else {
                        minotaurPos = maze.Cells[pathcopy[0]].Position;
                    }
                    minotaurPos.X -= psgW/2; minotaurPos.Y -= psgW/2;
                    
                    //draw the minotaur
                    gfx.FillEllipse(Brushes.Blue, minotaurPos.X, minotaurPos.Y, psgW, psgW);
                    //if it can hear the player draw a red ring on it
                    if (minotaur.heardUser) {
                        gfx.DrawEllipse(Pens.Red, minotaurPos.X+2, minotaurPos.Y+2, psgW-4, psgW-4);
                    }
                }

                //if reduced visibility is enabled
                if (options.ReducedVisibility) {
                    Region darkArea = new Region(new Rectangle((int)(maze.Centre.X-maze.Bounds.Width), (int)(maze.Centre.Y-maze.Bounds.Width), (int)maze.Bounds.Width*2, (int)maze.Bounds.Height*2));
                    GraphicsPath circle = new GraphicsPath();
                    
                    void cutArea(int x, int y) { //this is a local subroutine, it can only be called in this if statement
                        circle.AddEllipse(x-shadowSize.Width/2, y-shadowSize.Height/2, shadowSize.Width, shadowSize.Height); //create a circle centred on the position
                        darkArea.Exclude(circle); //cut the cricle out of the dark area (making it light)
                        circle.ClearMarkers(); //reset the circle
                    }

                    //exit
                    cutArea((int)maze.Cells[maze.EndCell].X, (int)maze.Cells[maze.EndCell].Y);
                    //keys
                    if (options.Keys) {
                        foreach (int keyLoc in maze.Keys.Where(k => k != -1)) {
                            cutArea((int)maze.Cells[keyLoc].X, (int)maze.Cells[keyLoc].Y);
                        }
                    }

                    //minotaur
                    if (options.Minotaur) {
                        //calculate minotaur's position
                        int[] pathcopy = minotaur.path.ToArray();
                        PointF minotaurPos;
                        if (pathcopy.Count() >= 2) { 
                            minotaurPos = LerpPos(maze.Cells[pathcopy[0]].Position, maze.Cells[pathcopy[1]].Position, minotaur.proportionAlongPassage);
                        } else {
                            minotaurPos = maze.Cells[pathcopy[0]].Position;
                        }
                        minotaurPos.X -= psgW/2; minotaurPos.Y -= psgW/2;

                        cutArea((int)minotaurPos.X, (int)minotaurPos.Y);
                    }

                    //marker
                    cutArea(markerPos.X, markerPos.Y);

                    darkArea.Translate(psgW/2f, psgW / 2f); //move the dark are to align to the maze
                    gfx.FillRegion(Brushes.Black, darkArea); //draw the darkness
                }

                gfx.ResetTransform(); //reset the transform so on the next frame the applied transform doesn't stack

            } else if (solved) { //if the maze is solved
                //switch to the solved menu
                bttn_pause.Hide();
                pnl_pausedMenu.Show();
                lbl_paused.Text = "You Have Solved The Maze";
                bttn_resume.Hide(); 
                return; //escape the draw loop before it starts again
            }
                        
            Canvas.Invalidate(); //cause the canvas to draw the next frame, thus causing a loop
        }

        Point LerpPos(PointF a, PointF b, float p) { //linear interpolating positions (a is the first point, b is the second point, p is the proportion to interpolate to)
            return new Point((int)(a.X + (b.X - a.X) * p), (int)(a.Y + (b.Y - a.Y) * p));

        }

        //creates a rotated rectangle between two points so a brush can be applied instead of a pen
        Point[] LineToPolygon(PointF p1, PointF p2, float width) {

            float dx = p1.X - p2.X, dy = p1.Y-p2.Y; //change in x, change in y
            float w = width/2;

            //get angle
            float ang = MathF.Atan2(dx,dy)+MathF.PI/2f; //get the angle between the line formed by the points and the vertical

            return new Point[4] { new Point((int)(p1.X+(w*MathF.Sin(ang))), (int)(p1.Y+(w*MathF.Cos(ang)))),
                                  new Point((int)(p1.X-(w*MathF.Sin(ang))), (int)(p1.Y-(w*MathF.Cos(ang)))),
                                  new Point((int)(p2.X-(w*MathF.Sin(ang))), (int)(p2.Y-(w*MathF.Cos(ang)))),
                                  new Point((int)(p2.X+(w*MathF.Sin(ang))), (int)(p2.Y+(w*MathF.Cos(ang))))};
        }

        private void UpdateLoop(object sender, EventArgs e) { //the loop in which the updating is happening
            if (solved || updater is null) { return; } //if the maze is solved or the update caller has been destroyed escape the loop
            updater.Enabled = false; //disable the updater so there aren't multiple instances of this loop running concurrently
            float deltaT = paused? 0 : updateTimer.ElapsedMilliseconds / 1000f; //get delta time, if the maze is paused deltat time is 0
            updateTimer.Restart();

            //marker movement
            if (marker.state == marker.stateType.moving) { 
                marker.proportionAlongPassage += deltaT*marker.speed; //move the marker along the passage by its speed moderated by delta time
            }
            if (!exitLocked && marker.currentCellIndex == maze.EndCell) { 
                solved = true;
                return; //maze is solved, so leave the updateloop before it is re-enabled
            } 
            
            if (marker.proportionAlongPassage >= 1) { //if it is at the end of the passage
                marker.proportionAlongPassage = 0; //reset it back to the start of the passage
                int lastCell = marker.currentCellIndex; //move the cells along one
                marker.currentCellIndex = marker.nextCellIndex;
                
                if (options.Keys && maze.Keys.Contains(marker.currentCellIndex)) { //if the marker is sitting on a key
                    maze.Keys[Array.IndexOf(maze.Keys, marker.currentCellIndex)] = -1; //make the key 'collected'
                    if (maze.Keys.Distinct().ToArray() is int[] distinct && distinct.Count() == 1 && distinct[0] == -1) { //if all keys are 'collected'
                        //found all keys
                        exitLocked = false;
                    }
                }

                //get all the places to go apart from where the marker just came from
                Connection[] nextConnections = maze.Cells[marker.currentCellIndex].NeighboursConnected.Where(n => n.NeighbourIndex != lastCell).ToArray();
                if (nextConnections.Length == 1) { //passage
                    marker.nextCellIndex = nextConnections[0].NeighbourIndex; //move to the other position
                } else { //dead end or junction
                    marker.state = marker.stateType.waiting; //wait for user input
                    if (selectedDirection > nextConnections.Length) { selectedDirection = 0; }
                }
            }

            if (marker.state == marker.stateType.waiting) { //if the marker is waiting
                if (options.GenerationType == GeneratorOptions._GenerationType.Delta) { //if the maze is triangular the direction picker is needed 
                    int numDir = maze.Cells[marker.currentCellIndex].NeighboursConnected.Length;
                    if (keyUpPressed) { //selecting direction
                        marker.proportionAlongPassage = 0;
                        marker.nextCellIndex = maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex;
                        marker.state = marker.stateType.moving; //start moving again
                        keyUpPressed = false; //key has been responed to so it is unset
                    }
                    //clockwise
                    if (keyRightPressed) { //index+
                        selectedDirection = (selectedDirection+numDir+1)%numDir;
                        keyRightPressed = false;
                    }
                    //anticlockwise
                    if (keyLeftPressed) { //index-
                        selectedDirection = (selectedDirection+numDir-1)%numDir;
                        keyLeftPressed = false;
                    }
                } else { //square maze so use direcitonal keys
                    int missingEntries = 0;

                    //up
                    if (maze.Cells[marker.currentCellIndex].Up) { //if the current cell has a cell above it
                        if (keyUpPressed) { //and the up key is pressed
                            if (maze.Cells[marker.currentCellIndex].Neighbours[0].Connected) { //and there is a passage between them
                                marker.proportionAlongPassage = 0;
                                marker.nextCellIndex = maze.Cells[marker.currentCellIndex].Neighbours[0].NeighbourIndex; //select that direction
                                marker.state = marker.stateType.moving;
                                keyUpPressed = false;
                            }
                        }
                    } else { //no cell above it, so add it to the missing count
                        missingEntries++;
                    }

                    //right
                    if (maze.Cells[marker.currentCellIndex].Right) { 
                        if (keyRightPressed) { 
                            if (maze.Cells[marker.currentCellIndex].Neighbours[1-missingEntries].Connected) {
                                marker.proportionAlongPassage = 0;
                                marker.nextCellIndex = maze.Cells[marker.currentCellIndex].Neighbours[1-missingEntries].NeighbourIndex;
                                marker.state = marker.stateType.moving;
                                keyRightPressed = false;
                            }
                        }
                    } else {
                        missingEntries++;
                    }

                    //down
                    if (maze.Cells[marker.currentCellIndex].Down) { 
                        if (keyDownPressed) { 
                            if (maze.Cells[marker.currentCellIndex].Neighbours[2-missingEntries].Connected) {
                                marker.proportionAlongPassage = 0;
                                marker.nextCellIndex = maze.Cells[marker.currentCellIndex].Neighbours[2-missingEntries].NeighbourIndex;
                                marker.state = marker.stateType.moving;
                                keyDownPressed = false;
                            }
                        }
                    } else {
                        missingEntries++;
                    }

                    //left
                    if (maze.Cells[marker.currentCellIndex].Left) { 
                        if (keyLeftPressed) { 
                            if (maze.Cells[marker.currentCellIndex].Neighbours[3-missingEntries].Connected) {
                                marker.proportionAlongPassage = 0;
                                marker.nextCellIndex = maze.Cells[marker.currentCellIndex].Neighbours[3-missingEntries].NeighbourIndex;
                                marker.state = marker.stateType.moving;
                                keyLeftPressed = false;
                            }
                        }
                    } else {
                        missingEntries++;
                    }

                }
            }

            //at the end of the passage, work out the trail
            if (marker.state == marker.stateType.moving && marker.proportionAlongPassage == 0) {
                if (marker.pastLocations.Count != 0) { marker.pastLocations.Pop(); } //remove the top one
                if (!(marker.pastLocations.Count != 0 && marker.pastLocations.Peek() == marker.nextCellIndex)) { //look at the new top one and if the marker is not backtracking
                    marker.pastLocations.Push(marker.currentCellIndex); //add it's current position to the trail
                    marker.pastLocations.Push(marker.nextCellIndex); //add it's destination to the trail
                }
            }

            if (options.MovingWalls) {

                for (int i = 0; i < maze.Cells.Length; i++) {
                    PointF pos = maze.Cells[i].Position;
                    pos.X += ((float)rng.NextDouble()-0.5f)*0.5f; //move the wall around randomly by a float between -0.5 and 0.5
                    pos.Y += ((float)rng.NextDouble()-0.5f)*0.5f;
                    maze.Cells[i].Position = pos;
                }

            }

            if (options.Minotaur) {
                minotaur.proportionAlongPassage += deltaT*minotaur.speed; //move the minotaur forwards
                if (minotaur.proportionAlongPassage >= 1) { //if it's at the end of the passage move it onto the next passage
                    if (minotaur.path.Count > 1) { minotaur.path.RemoveAt(0); }
                    minotaur.proportionAlongPassage = 0; 
                }

                if (minotaur.path[0] == marker.currentCellIndex) { //if the minotaur touches the marker reset the marker back to the start of the maze
                    marker.currentCellIndex = maze.StartCell;
                    marker.nextCellIndex = maze.StartCell;
                    marker.state = marker.stateType.waiting;
                    selectedDirection = 0;
                    marker.pastLocations.Clear();
                    marker.pastLocations.Push(maze.StartCell);
                }

                //hearing the user (if the distance squared is less that its hearing range squared and the marker is moving)
                minotaur.heardUser = (marker.state == marker.stateType.moving && distSq(maze.Cells[minotaur.path[0]].Position, maze.Cells[marker.currentCellIndex].Position) <= minotaur.hearingRange*minotaur.hearingRange);

                if (minotaur.path.Count == 1) { //if it is at the end of it's path, pathfind to a random location
                    List<int> tmp = minotaur.path;
                    int current = tmp[0], next = (tmp.Count >= 2)? tmp[1] : tmp[0];
                    tmp.Clear();
                    tmp.Add(current);
                    tmp.AddRange(maze.Solve(rng.Next(0, maze.Cells.Length), next));
                    minotaur.path = tmp;
                }
                if (minotaur.heardUser) { //if it heard the marker move, path find to the marker
                    List<int> tmp = minotaur.path;
                    int current = tmp[0], next = (tmp.Count >= 2) ? tmp[1] : tmp[0];
                    tmp.Clear();
                    tmp.Add(current);
                    tmp.AddRange(maze.Solve(marker.nextCellIndex, next));
                    minotaur.path = tmp;
                }

            }

            updater.Enabled = true; //re-enable the updater so it causes the update loop to repeat
        }

        float distSq(PointF a, PointF b) { //square root function is performance heavy, so I square the compared distance instead of squarerooting the result of this
            return (a.X-b.X)*(a.X-b.X)+(a.Y-b.Y)*(a.Y-b.Y);
        }

        private void KeyPressed(object sender, KeyEventArgs e) { //when a key is pressed, mark it as true
            if (e.KeyCode == user.KeyUp) { keyUpPressed = true; }
            if (e.KeyCode == user.KeyDown) { keyDownPressed = true; }
            if (e.KeyCode == user.KeyLeft) { keyLeftPressed = true; }
            if (e.KeyCode == user.KeyRight) { keyRightPressed = true; }
        }
        private void KeyUnpressed(object sender, KeyEventArgs e) { //when a key is released, mark it as false
            if (e.KeyCode == user.KeyUp) { keyUpPressed = false; }
            if (e.KeyCode == user.KeyDown) { keyDownPressed = false; }
            if (e.KeyCode == user.KeyLeft) { keyLeftPressed = false; }
            if (e.KeyCode == user.KeyRight) { keyRightPressed = false; }
            if (e.KeyCode == Keys.Escape) { togglePause(); } //toggle paused
        }

        private void bttn_return_Click(object sender, EventArgs e) {
            MazeDone(solved); //when the user finishes the maze or gives up this subroutine will run as the same button is used in both situations
        }
        private void bttn_pause_Click(object sender, EventArgs e) {
            togglePause();
        }

        void togglePause() {
            paused = !paused; //flip the paused boolean
            if (paused) { 
                userTime.Stop(); 
                pnl_pausedMenu.Show();
                bttn_pause.Text = "Resume";
            } else { 
                userTime.Start(); 
                pnl_pausedMenu.Hide();
                bttn_pause.Text = "Pause";
            }

        }

        void MazeDone(bool won) {
            //here I have to destroy some objects as the c# garbage collector won't always and will alow them to stick around for next time
            updater = null; //destroy the updater
            maze = null; //destroy the maze so it isn't re-used next time
            marker.pastLocations = new Stack<int>(); //reset the trail

            if (won) {
                user.Times[(int)options.Diff].Add(userTime.ElapsedMilliseconds/1000f); //add the user's new time
                user.SaveToFile(); //save their progress to the database
            }

            Program.AppWindow.SetActiveForm(new Forms.MainMenu(user)); //return to the main menu
        }

        private void bttn_resume_Click(object sender, EventArgs e) {
            togglePause();
        }
    }

    //a component I found online a while ago that allows setting the interpolation mode (anti-aliasing and upscaling mode). I use it because it prevents the maze becoming blurry
    /// <summary>
    /// A PictureBox with configurable interpolation mode.
    /// https://www.codeproject.com/Articles/717312/PixelBox-A-PictureBox-with-configurable-Interpolat
    /// </summary>
    public class PixelBox : PictureBox {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBox"> class.
        /// </see></summary>
        public PixelBox() {
            // Set default.
            InterpolationMode = InterpolationMode.Default;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        [Category("Behavior")]
        [DefaultValue(InterpolationMode.Default)]
        public InterpolationMode InterpolationMode { get; set; }
        #endregion

        #region Overrides of PictureBox
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"> event.
        /// </see></summary>
        /// <param name="pe" />A <see cref="T:System.Windows.Forms.PaintEventArgs"> that contains the event data. 
        protected override void OnPaint(PaintEventArgs pe) {
            pe.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(pe);
        }
        #endregion
    
    }
}