using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorProject {
    class GeneratorOptions {
        public enum GenerationType {Gamma, Delta, Theta}
        public GenerationType generationType;
        public Bitmap TemplateImg;
        public Style Appearance;
        public bool Minotaur;
        public bool MovingWalls;
        public bool ReducedVisibility;
        public bool Keys;
        public float[] BiasStrengths;

        public GeneratorOptions() {

        }

    }

    public enum Difficulty { 
        Easy, Medium, Hard,
        Count //https://stackoverflow.com/a/16946240
    }

    public class Style {
        public Brush WallBrush;
        public Brush PassageBrush;
        public bool carved;

        public Style(Brush WallBrush, Brush PassageBrush, bool carved) {
            this.WallBrush = WallBrush;
            this.PassageBrush = PassageBrush;
            this.carved = carved;
        }
    }
}