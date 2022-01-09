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
        #region Engine Variables
        const int width  = 720;
        const int height = 720;

        Bitmap image = new Bitmap(width, height);
        Graphics gfx;
        System.Timers.Timer updater = new System.Timers.Timer(1);
        Stopwatch updateTimer = new Stopwatch();
        Stopwatch frameTimer = new Stopwatch();

        InterpolationMode interpMode = InterpolationMode.NearestNeighbor;
        PointF cameraPos;
        float cameraZoom;
        #endregion

        Stopwatch userTime = new Stopwatch();
        User user;

        Random rng = new Random();

        GeneratorOptions options;
        Maze maze;

        Bitmap shadow;
        Size shadowSize = new Size(600,600);

        bool paused = false;
        bool solved = false;
        bool exitLocked;

        bool keyUpPressed = false;
        bool keyDownPressed = false;
        bool keyRightPressed = false;
        bool keyLeftPressed = false;

        struct marker {
            public static int currentCellIndex;
            public static int nextCellIndex;
            public static float proportionAlongPassage;
            public const float speed = 2f;
            public static Stack<int> pastLocations = new Stack<int>();
            public enum stateType { waiting, moving }
            public static stateType state = stateType.waiting;
        }
        int selectedDirection;

        struct minotaur {
            public static List<int> path = new List<int>();
            public static float proportionAlongPassage;
            public const float speed = 1.8f;
            public static float hearingRange;
            public static bool heardUser;
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

            exitLocked = options.Keys;
            shadow = (Bitmap)Image.FromFile(@"Database/shadow.png");

            pnl_pausedMenu.Hide();

            gfx = Graphics.FromImage(image);
            gfx.InterpolationMode = interpMode;
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            minotaur.path.Clear();
        }

        private void MazeForm_Shown(object sender, EventArgs e) { //runs after the form has loaded and appeared.
            bttn_Start.Text = "Loading...";
            bttn_Start.Enabled = false;

            maze = new Maze();
            maze.Generate(options);

            marker.pastLocations.Push(maze.StartCell);

            bttn_Start.Text = "START";
            bttn_Start.Enabled = true;
        }

        private void bttn_Start_Click(object sender, EventArgs e) {
            marker.currentCellIndex = maze.StartCell;
            marker.nextCellIndex = maze.StartCell;
            marker.proportionAlongPassage = 1;

            KeyPreview = true;
            KeyDown += KeyPressed;
            KeyUp += KeyUnpressed;

            //start the timer
            updater.Elapsed += UpdateLoop;
            updater.Enabled = true;
            Canvas.Invalidate();
            Canvas.Paint += Canvas_Paint;
            userTime.Start();

            cameraPos = maze.Centre;
            cameraZoom = 650/MathF.Max(maze.Bounds.Width, maze.Bounds.Height); //new PointF(1/(maze.Bounds.Width), 1/maze.Bounds.Height);

            if (options.Minotaur) {
                Random rng = new Random();
                minotaur.path.Add(rng.Next(0, maze.Cells.Length));
                minotaur.hearingRange = options.Appearance.PassageW*MathF.Pow(1.03f,0.6f*options.Size+50);
            }

            bttn_Start.Hide();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            float deltaT = frameTimer.ElapsedMilliseconds / 1000f;
            frameTimer.Restart();
            
            if (!(paused || solved)) {
                lbl_timer.Text = "Time: " + userTime.Elapsed.ToString(@"hh\:mm\:ss\:f");

                Brush psgBrsh = options.Appearance.PassageBrush;
                int psgW = options.Appearance.PassageW;
                Point markerPos = LerpPos(maze.Cells[marker.currentCellIndex].Position, maze.Cells[marker.nextCellIndex].Position, marker.proportionAlongPassage);
                markerPos.X -= psgW / 2; markerPos.Y -= psgW / 2;

                gfx.FillRectangle(options.Appearance.WallBrush, 0,0, width, height);
                gfx.ResetClip();
                gfx.TranslateTransform(width/2, height/2);
                gfx.ScaleTransform(cameraZoom, cameraZoom);
                gfx.TranslateTransform(-cameraPos.X, -cameraPos.Y);
                //if (options.ReducedVisibility) { gfx.SetClip(new Rectangle(markerPos.X-shadow.Width/2+1,markerPos.Y-shadow.Height/2+1, shadow.Width-2, shadow.Height-2)); }
                //https://www.vbforums.com/showthread.php?624596-RESOLVED-Offsetting-a-HatchBrush
                gfx.RenderingOrigin = new Point((int)cameraPos.X, (int)cameraPos.Y);
                
                //int i = 0;
                foreach (Cell c in maze.Cells) {
                    foreach (Connection conn in c.Neighbours) {
                        if (conn.Connected) {
                            //draw link
                            if (!conn.hidden && 0 <= conn.NeighbourIndex && conn.NeighbourIndex < maze.Cells.Length) {
                                //gfx.FillPolygon(Brushes.Black, LineToPolygon(c.Position, maze.Cells[conn.NeighbourIndex].Position, psgW+2));
                                gfx.FillPolygon(psgBrsh, LineToPolygon(c.Position, maze.Cells[conn.NeighbourIndex].Position, psgW));
                            }

                        }
                    }
                    //gfx.DrawString(i.ToString(), StyleSheet.Body, SystemBrushes.ControlText, c.X-10, c.Y-10);
                    //i++;
                }
                foreach (Cell c in maze.Cells) { 
                    gfx.FillEllipse(psgBrsh, c.X-psgW/2, c.Y-psgW/2, psgW, psgW);
                }

                if (exitLocked) { 
                    gfx.FillEllipse(Brushes.DarkGray, maze.Cells[maze.EndCell].X-psgW/2, maze.Cells[maze.EndCell].Y-psgW/2, psgW, psgW);
                } else { 
                    gfx.FillEllipse(Brushes.Red, maze.Cells[maze.EndCell].X-psgW/2, maze.Cells[maze.EndCell].Y-psgW/2, psgW, psgW);
                }
                
                if (options.Keys) {
                    foreach (int keyLoc in maze.Keys.Where(k => k != -1)) {
                        gfx.FillEllipse(Brushes.Gold, maze.Cells[keyLoc].X - psgW / 2, maze.Cells[keyLoc].Y - psgW / 2, psgW, psgW);
                    }
                }

                int[] movestack = marker.pastLocations.ToArray();
                for (int i = 0; i < movestack.Length-1; i++) {
                    gfx.DrawLine(Pens.Blue, maze.Cells[movestack[i]].X, maze.Cells[movestack[i]].Y, maze.Cells[movestack[i+1]].X, maze.Cells[movestack[i+1]].Y);
                }

                //draw marker
                gfx.FillEllipse(Brushes.Green, markerPos.X, markerPos.Y, psgW, psgW);
                if (marker.state == marker.stateType.waiting && options.GenerationType == GeneratorOptions._GenerationType.Delta) {
                    Pen p = new Pen(Color.Yellow, 5);
                    AdjustableArrowCap arrowCap = new AdjustableArrowCap(5,5);
                    p.CustomEndCap = arrowCap;
                    p.StartCap = LineCap.Flat;
                    gfx.DrawLine(p, maze.Cells[marker.currentCellIndex].Position, maze.Cells[maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex].Position);
                }


                if (options.Minotaur) {
                    int[] pathcopy = minotaur.path.ToArray();
                    PointF minotaurPos;
                    if (pathcopy.Count() >= 2) { 
                        minotaurPos = LerpPos(maze.Cells[pathcopy[0]].Position, maze.Cells[pathcopy[1]].Position, minotaur.proportionAlongPassage);
                    } else {
                        minotaurPos = maze.Cells[pathcopy[0]].Position;
                    }
                    minotaurPos.X -= psgW/2; minotaurPos.Y -= psgW/2;
                    
                    gfx.FillEllipse(Brushes.Blue, minotaurPos.X, minotaurPos.Y, psgW, psgW);
                    if (minotaur.heardUser) {
                        gfx.DrawEllipse(Pens.Red, minotaurPos.X+2, minotaurPos.Y+2, psgW-4, psgW-4);
                    }

                    //foreach (int i in pathcopy.ToArray()) {
                    //    gfx.FillEllipse(Brushes.Brown, maze.Cells[i].X-psgW/2+3, maze.Cells[i].Y-psgW/2+3, psgW-6, psgW-6);
                    //}
                }

                if (options.ReducedVisibility) {
                    Region darkArea = new Region(new Rectangle((int)(maze.Centre.X-maze.Bounds.Width), (int)(maze.Centre.Y-maze.Bounds.Width), (int)maze.Bounds.Width*2, (int)maze.Bounds.Height*2));
                    GraphicsPath circle = new GraphicsPath();

                    //gfx.DrawImageUnscaled(shadow, (int)maze.Cells[maze.EndCell].X-shadow.Width/2,(int)maze.Cells[maze.EndCell].Y-shadow.Height/2); //exit
                    circle.AddEllipse((int)maze.Cells[maze.EndCell].X-shadowSize.Width/2,(int)maze.Cells[maze.EndCell].Y-shadowSize.Height/2, shadowSize.Width, shadowSize.Height);
                    darkArea.Exclude(circle);
                    circle.ClearMarkers();
                    if (options.Keys) {
                        foreach (int keyLoc in maze.Keys.Where(k => k != -1)) {
                            //gfx.DrawImageUnscaled(shadow, (int)maze.Cells[keyLoc].X-shadow.Width/2, (int)maze.Cells[keyLoc].Y-shadow.Height/2); //keys
                            circle.AddEllipse((int)maze.Cells[keyLoc].X-shadowSize.Width/2, (int)maze.Cells[keyLoc].Y-shadowSize.Height/2, shadowSize.Width, shadowSize.Height);
                            darkArea.Exclude(circle);
                            circle.ClearMarkers();
                        }
                    }

                    if (options.Minotaur) {
                        int[] pathcopy = minotaur.path.ToArray();
                        PointF minotaurPos;
                        if (pathcopy.Count() >= 2) { 
                            minotaurPos = LerpPos(maze.Cells[pathcopy[0]].Position, maze.Cells[pathcopy[1]].Position, minotaur.proportionAlongPassage);
                        } else {
                            minotaurPos = maze.Cells[pathcopy[0]].Position;
                        }
                        minotaurPos.X -= psgW/2; minotaurPos.Y -= psgW/2;
                        //gfx.DrawImageUnscaled(shadow, (int)minotaurPos.X-shadow.Width/2, (int)minotaurPos.Y-shadow.Height/2); //minotaur
                        circle.AddEllipse((int)minotaurPos.X-shadowSize.Width/2, (int)minotaurPos.Y-shadowSize.Height/2, shadowSize.Width, shadowSize.Height);
                        darkArea.Exclude(circle);
                        circle.ClearMarkers();
                    }
                    //gfx.DrawImageUnscaled(shadow, markerPos.X-shadow.Width/2,markerPos.Y-shadow.Height/2); //player
                    circle.AddEllipse(markerPos.X-shadowSize.Width/2,markerPos.Y-shadowSize.Height/2, shadowSize.Width, shadowSize.Height);
                    darkArea.Exclude(circle);

                    darkArea.Translate(options.Appearance.PassageW/2f, options.Appearance.PassageW/2f);
                    gfx.FillRegion(Brushes.Black, darkArea);
                }

                gfx.ResetTransform();

                //debug the stack
                //for (int i = 0; i < movestack.Length; i++) {
                //    gfx.DrawString(movestack[i].ToString(), SystemFonts.DefaultFont, Brushes.Orange, new PointF(10, i*10+10));
                //}

            } else if (solved) {
                bttn_pause.Hide();
                pnl_pausedMenu.Show();
                lbl_paused.Text = "You Have Solved The Maze";
                bttn_resume.Hide(); //stop drawing
                return;
            }
                        
            Canvas.Invalidate();
        }

        Point LerpPos(PointF a, PointF b, float p) {
            return new Point((int)(a.X + (b.X - a.X) * p), (int)(a.Y + (b.Y - a.Y) * p));

        }

        Point[] LineToPolygon(PointF p1, PointF p2, float width) {

            float dx = p1.X - p2.X, dy = p1.Y-p2.Y;
            float w = width/2;

            //get angle
            float ang = MathF.Atan2(dx,dy)+MathF.PI/2f;

            return new Point[4] { new Point((int)(p1.X+(w*MathF.Sin(ang))), (int)(p1.Y+(w*MathF.Cos(ang)))),
                                  new Point((int)(p1.X-(w*MathF.Sin(ang))), (int)(p1.Y-(w*MathF.Cos(ang)))),
                                  new Point((int)(p2.X-(w*MathF.Sin(ang))), (int)(p2.Y-(w*MathF.Cos(ang)))),
                                  new Point((int)(p2.X+(w*MathF.Sin(ang))), (int)(p2.Y+(w*MathF.Cos(ang))))};
        }

        private void UpdateLoop(object sender, EventArgs e) {
            if (solved || updater is null) { return; }
            updater.Enabled = false;
            float deltaT = paused? 0 : updateTimer.ElapsedMilliseconds / 1000f;
            updateTimer.Restart();

            //marker movement
            if (marker.state == marker.stateType.moving) { 
                marker.proportionAlongPassage += deltaT*marker.speed;
            }
            if (!exitLocked && marker.currentCellIndex == maze.EndCell) { 
                solved = true;
                return; //maze is solved, so leave this function before it is re-enabled
            } 
            
            if (marker.proportionAlongPassage >= 1) {
                marker.proportionAlongPassage = 0;
                int lastCell = marker.currentCellIndex;
                marker.currentCellIndex = marker.nextCellIndex;
                
                if (options.Keys && maze.Keys.Contains(marker.currentCellIndex)) { 
                    maze.Keys[Array.IndexOf(maze.Keys, marker.currentCellIndex)] = -1;
                    if (maze.Keys.Distinct().ToArray() is int[] distinct && distinct.Count() == 1 && distinct[0] == -1) {
                        //found all keys
                        exitLocked = false;
                    }
                }

                Connection[] nextConnections = maze.Cells[marker.currentCellIndex].NeighboursConnected.Where(n => n.NeighbourIndex != lastCell).ToArray();
                if (nextConnections.Length == 1) { //passage
                    marker.nextCellIndex = nextConnections[0].NeighbourIndex;
                } else { //dead end or junction
                    marker.state = marker.stateType.waiting;
                    if (selectedDirection > nextConnections.Length) { selectedDirection = 0; }
                }
            }

            if (marker.state == marker.stateType.waiting) {
                if (options.GenerationType == GeneratorOptions._GenerationType.Delta) { 
                    int numDir = maze.Cells[marker.currentCellIndex].NeighboursConnected.Length;
                    if (keyUpPressed) {
                        marker.proportionAlongPassage = 0;
                        marker.nextCellIndex = maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex;
                        marker.state = marker.stateType.moving;
                        keyUpPressed = false;
                    }
                    if (keyRightPressed) { //index+
                        selectedDirection = (selectedDirection+numDir+1)%numDir;
                        keyRightPressed = false;
                    }
                    if (keyLeftPressed) { //index-
                        selectedDirection = (selectedDirection+numDir-1)%numDir;
                        keyLeftPressed = false;
                    }
                } else {
                    int missingEntries = 0;

                    if (maze.Cells[marker.currentCellIndex].Up) { 
                        if (keyUpPressed) {
                            if (maze.Cells[marker.currentCellIndex].Neighbours[0].Connected) {
                                marker.proportionAlongPassage = 0;
                                marker.nextCellIndex = maze.Cells[marker.currentCellIndex].Neighbours[0].NeighbourIndex;
                                marker.state = marker.stateType.moving;
                                keyUpPressed = false;
                            }
                        }
                    } else {
                        missingEntries++;
                    }
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

            if (marker.state == marker.stateType.moving && marker.proportionAlongPassage == 0) {
                if (marker.pastLocations.Count != 0) { marker.pastLocations.Pop(); }
                if (!(marker.pastLocations.Count != 0 && marker.pastLocations.Peek() == marker.nextCellIndex)) {
                    marker.pastLocations.Push(marker.currentCellIndex);
                    marker.pastLocations.Push(marker.nextCellIndex);
                }
            }

            if (options.MovingWalls) {
                bool hideWalls = (deltaT > 0 && rng.Next(0,(int)(10/deltaT)) == 0);
                bool showWalls = (deltaT > 0 && rng.Next(0,(int)(10/deltaT)) == 0);

                for (int i = 0; i < maze.Cells.Length; i++) {
                    PointF pos = maze.Cells[i].Position;
                    pos.X += ((float)rng.NextDouble()-0.5f)*0.5f;
                    pos.Y += ((float)rng.NextDouble()-0.5f)*0.5f;
                    maze.Cells[i].Position = pos;

                    //if (showWalls) {
                    //    for (int index = 0; index < maze.Cells[i].Neighbours.Length; index++) {
                    //        maze.Cells[i].Neighbours[index].hidden = false;
                    //    }
                    //} else if (hideWalls) {
                    //    int index = rng.Next(0, maze.Cells[i].Neighbours.Length);
                    //    maze.Cells[i].Neighbours[index].hidden = !maze.Cells[i].Neighbours[index].hidden;
                    //}
                }

            }

            if (options.Minotaur) {
                minotaur.proportionAlongPassage += deltaT * minotaur.speed;
                if (minotaur.proportionAlongPassage >= 1) {
                    if (minotaur.path.Count > 1) { minotaur.path.RemoveAt(0); }
                    minotaur.proportionAlongPassage = 0; 
                }

                if (minotaur.path[0] == marker.currentCellIndex) {
                    marker.currentCellIndex = maze.StartCell;
                    marker.nextCellIndex = maze.StartCell;
                    marker.state = marker.stateType.waiting;
                    selectedDirection = 0;
                    marker.pastLocations.Clear();
                    marker.pastLocations.Push(maze.StartCell);
                }

                //hearing the user
                minotaur.heardUser = (marker.state == marker.stateType.moving && distSq(maze.Cells[minotaur.path[0]].Position, maze.Cells[marker.currentCellIndex].Position) <= minotaur.hearingRange*minotaur.hearingRange);

                if (minotaur.path.Count == 1) {
                    List<int> tmp = minotaur.path;
                    int current = tmp[0], next = (tmp.Count >= 2)? tmp[1] : tmp[0];
                    tmp.Clear();
                    tmp.Add(current);
                    tmp.AddRange(maze.Solve(rng.Next(0, maze.Cells.Length), next));
                    minotaur.path = tmp;
                }
                if (minotaur.heardUser) {
                    List<int> tmp = minotaur.path;
                    int current = tmp[0], next = (tmp.Count >= 2) ? tmp[1] : tmp[0];
                    tmp.Clear();
                    tmp.Add(current);
                    tmp.AddRange(maze.Solve(marker.nextCellIndex, next));
                    minotaur.path = tmp;
                }

            }

            updater.Enabled = true;
        }

        float distSq(PointF a, PointF b) { //square root function is performance heavy, so I square the compared distance instead of squarerooting the actual distance^2
            return (a.X-b.X)*(a.X-b.X)+(a.Y-b.Y)*(a.Y-b.Y);
        }

        private void KeyPressed(object sender, KeyEventArgs e) {
            if (e.KeyCode == user.KeyUp) { keyUpPressed = true; }
            if (e.KeyCode == user.KeyDown) { keyDownPressed = true; }
            if (e.KeyCode == user.KeyLeft) { keyLeftPressed = true; }
            if (e.KeyCode == user.KeyRight) { keyRightPressed = true; }
        }
        private void KeyUnpressed(object sender, KeyEventArgs e) {
            if (e.KeyCode == user.KeyUp) { keyUpPressed = false; }
            if (e.KeyCode == user.KeyDown) { keyDownPressed = false; }
            if (e.KeyCode == user.KeyLeft) { keyLeftPressed = false; }
            if (e.KeyCode == user.KeyRight) { keyRightPressed = false; }
            if (e.KeyCode == Keys.Escape) { togglePause(); } //toggle paused
        }

        private void bttn_return_Click(object sender, EventArgs e) {
            MazeDone(!solved);
        }
        private void bttn_pause_Click(object sender, EventArgs e) {
            togglePause();
        }

        void togglePause() {
            paused = !paused; 
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

        void MazeDone(bool gaveUp) {
            updater = null;
            maze = null;
            marker.pastLocations = new Stack<int>();

            if (!gaveUp) {
                user.Times[(int)options.Diff].Add(userTime.ElapsedMilliseconds/1000f);
            }

            user.SaveToFile();

            Program.AppWindow.SetActiveForm(new Forms.MainMenu(user));
        }

        private void bttn_resume_Click(object sender, EventArgs e) {
            togglePause();
        }
    }


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