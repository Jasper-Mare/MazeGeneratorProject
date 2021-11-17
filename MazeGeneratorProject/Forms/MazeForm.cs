﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class MazeForm : Form {
        //====================================================================================//
        //=== engine vars === engine vars === engine vars === engine vars === engine vars === //
        //====================================================================================//
        #region Engine Variables
        new const int Width  = 720;
        new const int Height = 720;

        Bitmap image = new Bitmap(Width, Height);
        Graphics gfx;
        System.Timers.Timer Updater = new System.Timers.Timer(1);
        Stopwatch updateTimer = new Stopwatch();
        Stopwatch frameTimer = new Stopwatch();

        InterpolationMode interpMode = InterpolationMode.NearestNeighbor;
        PointF CameraPos;
        #endregion

        Stopwatch UserTime = new Stopwatch();
        User user;

        Random rng = new Random();

        GeneratorOptions options;
        Maze maze;

        bool paused = false;

        bool KeySelectPressed = false;
        bool KeyCWPressed = false;
        bool KeyCCWPressed = false;

        struct marker {
            public static int currentCellIndex;
            public static int nextCellIndex;
            public static float proportionAlongPassage;
            public static readonly float speed = 1;
            public enum stateType { waiting, moving }
            public static stateType State = stateType.waiting;
        }

        int selectedDirection;

        public MazeForm(User user, GeneratorOptions options) {
            InitializeComponent();
            this.user = user;
            this.options = options;
        }

        private void MazeForm_Load(object sender, EventArgs e) { //runs before the form appears
            lbl_Username.Font = StyleSheet.Body;
            lbl_Username.Text = user.Name;
            lbl_timer.Font = StyleSheet.Body;

            Canvas.InterpolationMode = interpMode;
            Canvas.Image = image;
            
            pnl_pausedMenu.Hide();

            gfx = Graphics.FromImage(image);
            gfx.InterpolationMode = interpMode;
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

        }

        private void MazeForm_Shown(object sender, EventArgs e) { //runs after the form has loaded and appeared.
            bttn_Start.Text = "Loading...";
            bttn_Start.Enabled = false;

            maze = new Maze();
            maze.Generate(options);

            bttn_Start.Text = "START";
            bttn_Start.Enabled = true;
        }

        private void bttn_Start_Click(object sender, EventArgs e) {
            marker.currentCellIndex = maze.startCell;
            marker.nextCellIndex = maze.startCell;
            marker.proportionAlongPassage = 1;

            KeyPreview = true;
            KeyDown += KeyPressed;
            KeyUp += KeyUnpressed;

            //start the timer
            Updater.Elapsed += UpdateLoop;
            Updater.Enabled = true;
            Canvas.Invalidate();
            Canvas.Paint += Canvas_Paint;
            UserTime.Start();

            bttn_Start.Hide();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            float deltaT = frameTimer.ElapsedMilliseconds / 1000f;
            frameTimer.Restart();
            
            if (paused) {

            } else {
                lbl_timer.Text = "Time: " + UserTime.Elapsed.ToString(@"hh\:mm\:ss\:f");

                Brush psgBrsh = options.Appearance.PassageBrush;
                int psgW = options.Appearance.passageW;
                Pen debugPen = new Pen(Color.FromArgb(64, Color.Lime), psgW); debugPen.EndCap = LineCap.Round; debugPen.StartCap = LineCap.Round;

                Point markerPos = new Point((int)(maze.Cells[marker.currentCellIndex].X + (maze.Cells[marker.nextCellIndex].X - maze.Cells[marker.currentCellIndex].X) * marker.proportionAlongPassage - psgW / 2), (int)(maze.Cells[marker.currentCellIndex].Y + (maze.Cells[marker.nextCellIndex].Y - maze.Cells[marker.currentCellIndex].Y) * marker.proportionAlongPassage - psgW / 2));
                CameraPos = markerPos;

                gfx.FillRectangle(options.Appearance.WallBrush, 0,0, Width, Height);
                gfx.ResetClip();
                gfx.TranslateTransform(Width/2, Height/2);
                gfx.TranslateTransform(-CameraPos.X, -CameraPos.Y);
                gfx.SetClip(new Rectangle((int)CameraPos.X-Width/2, (int)CameraPos.Y-Height/2, Width, Height));
                //gfx.ScaleTransform(0.5f,0.5f);
                //https://www.vbforums.com/showthread.php?624596-RESOLVED-Offsetting-a-HatchBrush
                gfx.RenderingOrigin = new Point((int)CameraPos.X, (int)CameraPos.Y);
                
                int i = 0;
                foreach (Cell c in maze.Cells) {
                    foreach (Connection conn in c.Neighbours) {
                        if (conn.Connected) {
                            //draw link
                            if (0 <= conn.NeighbourIndex && conn.NeighbourIndex < maze.Cells.Length) {
                                //gfx.DrawLine(debugPen, c.Position, maze.Cells[conn.NeighbourIndex].Position); //for debugging
                                gfx.FillPolygon(psgBrsh, LineToPolygon(c.Position, maze.Cells[conn.NeighbourIndex].Position, psgW));
                            }

                        }
                    }
                    gfx.FillEllipse(psgBrsh, c.X-psgW/2, c.Y-psgW/2, psgW, psgW);

                    gfx.DrawString(i.ToString(), StyleSheet.Body, SystemBrushes.ControlText, c.X-10, c.Y-10);
                    i++;
                }
                gfx.FillEllipse(Brushes.Red, maze.Cells[maze.startCell].X-psgW/2, maze.Cells[maze.startCell].Y-psgW/2, psgW, psgW);
                gfx.FillEllipse(Brushes.Red, maze.Cells[maze.endCell  ].X-psgW/2, maze.Cells[maze.endCell  ].Y-psgW/2, psgW, psgW);

                //draw marker
                gfx.FillEllipse(Brushes.Green, markerPos.X, markerPos.Y, psgW, psgW);
                if (marker.State == marker.stateType.waiting) {
                    Pen p = new Pen(Color.Yellow, 5);
                    AdjustableArrowCap arrowCap = new AdjustableArrowCap(5,5);
                    p.CustomEndCap = arrowCap;
                    p.StartCap = LineCap.Flat;
                    gfx.DrawLine(p, maze.Cells[marker.currentCellIndex].Position, maze.Cells[maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex].Position);
                }

                gfx.ResetTransform();
            }
                        
            Canvas.Invalidate();
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
            Updater.Enabled = false;
            float deltaT = paused? 0 : updateTimer.ElapsedMilliseconds / 1000f;
            updateTimer.Restart();

            //marker movement
            if (marker.State == marker.stateType.moving) { marker.proportionAlongPassage += deltaT*marker.speed; }
            if (marker.currentCellIndex == maze.endCell) { MazeDone(false); return; } //maze is solved, so leave this function before it is re-enabled
            
            if (marker.proportionAlongPassage >= 1) {
                marker.proportionAlongPassage = 0;
                int lastCellIndex = marker.currentCellIndex;
                marker.currentCellIndex = marker.nextCellIndex;

                Connection[] nextConnections = maze.Cells[marker.currentCellIndex].NeighboursConnected.Where(n => n.NeighbourIndex != lastCellIndex).ToArray();
                if (nextConnections.Length == 1) { //passage
                    marker.nextCellIndex = nextConnections[0].NeighbourIndex;
                } else { //dead end or junction
                    marker.State = marker.stateType.waiting;
                }
            }

            if (marker.State == marker.stateType.waiting) {
                int numDir = maze.Cells[marker.currentCellIndex].NeighboursConnected.Length;
                if (KeySelectPressed) {
                    marker.nextCellIndex = maze.Cells[marker.currentCellIndex].NeighboursConnected[selectedDirection].NeighbourIndex;
                    marker.State = marker.stateType.moving;
                    KeySelectPressed = false;
                    selectedDirection = 0;
                }
                if (KeyCWPressed) { //index+
                    selectedDirection = (selectedDirection+numDir+1)%numDir;
                    KeyCWPressed = false;
                }
                if (KeyCCWPressed) { //index-
                    selectedDirection = (selectedDirection+numDir-1)%numDir;
                    KeyCCWPressed = false;
                }
            }
            
            Updater.Enabled = true;
        }

        private void KeyPressed(object sender, KeyEventArgs e) {
            if (e.KeyCode == user.KeyCW    ) { KeyCWPressed = true; }
            if (e.KeyCode == user.KeyCCW   ) { KeyCCWPressed = true; }
        }
        private void KeyUnpressed(object sender, KeyEventArgs e) {
            if (e.KeyCode == user.KeySelect) { KeySelectPressed = true; }
            if (e.KeyCode == Keys.Escape) { paused = !paused; if (paused) { UserTime.Stop(); pnl_pausedMenu.Show(); } else { UserTime.Start(); pnl_pausedMenu.Hide(); } } //toggle paused
        }

        private void bttn_GiveUp_Click(object sender, EventArgs e) {
            MazeDone(true);
        }

        void MazeDone(bool gaveUp) { 
            
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