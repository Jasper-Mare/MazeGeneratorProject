using System.Drawing;

namespace MazeGeneratorProject {
    public class GeneratorOptions {
        public enum _GenerationType { Gamma, Delta, Theta }
        public _GenerationType GenerationType;
        public Bitmap TemplateImg;
        public Style Appearance;
        public bool Minotaur;
        public bool MovingWalls;
        public bool ReducedVisibility;
        public bool Keys;
        public float BiasStrength;
        public Difficulty Diff;
        public int Size;

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
        public int PassageW;
        public Style(Brush WallBrush,Brush PassageBrush,int PassageWidth) {
            this.WallBrush = WallBrush;
            this.PassageBrush = PassageBrush;
            PassageW = PassageWidth;
        }
    }
}