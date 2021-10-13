using System;
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
        new const int Height = 400;

        Bitmap image = new Bitmap(Width, Height);
        Graphics gfx;
        System.Timers.Timer Updater = new System.Timers.Timer(1);
        Stopwatch updateTimer = new Stopwatch();
        Stopwatch frameTimer = new Stopwatch();
        float updateElapsedTime = 0;
        float gfxElapsedTime = 0;

        InterpolationMode interpMode = InterpolationMode.NearestNeighbor;

        Dictionary<Keys, bool> PressedKeys = new Dictionary<Keys, bool>();
        #endregion

        Stopwatch UserTime = new Stopwatch();
        User user;
        GeneratorOptions options;

        public MazeForm(User user, GeneratorOptions options) {
            InitializeComponent();
            this.user = user;
            this.options = options;
        }

        private void MazeForm_Load(object sender, EventArgs e) {
            lbl_Username.Font = StyleSheet.Body;
            lbl_Username.Text = user.Name;
            lbl_timer.Font = StyleSheet.Body;

            KeyPreview = true;
            KeyDown += KeyPressed;
            KeyUp += KeyUnpressed;

            Canvas.SizeMode = PictureBoxSizeMode.Zoom;
            Canvas.InterpolationMode = interpMode;
            Canvas.Image = image;
            Controls.Add(Canvas);

            gfx = Graphics.FromImage(image);
            gfx.InterpolationMode = interpMode;
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            
        }
        private void bttn_Start_Click(object sender, EventArgs e) {
            //start the timer
            Canvas.Invalidate();
            Canvas.Paint += Canvas_Paint;
            Updater.Elapsed += UpdateLoop;
            Updater.Enabled = true;
            UserTime.Start();

            bttn_Start.Hide();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            float deltaT = frameTimer.ElapsedMilliseconds / 1000f;
            gfxElapsedTime += deltaT;
            frameTimer.Restart();

            lbl_timer.Text = "Time: "+UserTime.Elapsed.ToString();

            gfx.Clear(Color.CornflowerBlue);

            Canvas.Invalidate();
        }

        private void UpdateLoop(object sender, EventArgs e) {
            Updater.Enabled = false;
            float deltaT = updateTimer.ElapsedMilliseconds / 1000f;
            updateTimer.Restart();
            updateElapsedTime += deltaT;

            

            Updater.Enabled = true;
        }

        private void KeyPressed(object sender, KeyEventArgs e) {
            if (!PressedKeys.ContainsKey(e.KeyCode)) { PressedKeys.Add(e.KeyCode, true); }
            else { PressedKeys[e.KeyCode] = true; }
        }
        private void KeyUnpressed(object sender, KeyEventArgs e) {
            if (!PressedKeys.ContainsKey(e.KeyCode)) { PressedKeys.Add(e.KeyCode, false); }
            else { PressedKeys[e.KeyCode] = false; }
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