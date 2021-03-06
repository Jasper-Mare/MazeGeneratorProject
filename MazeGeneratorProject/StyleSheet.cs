using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MazeGeneratorProject {
    static class StyleSheet {
        public static readonly Font Headings = new Font("Gill Sans MT", 35);
        public static readonly Font Body = new Font(FontFamily.GenericSansSerif, 12);

        public static readonly Style[] MazeStyles = {
            //        walls          passages       passage width
            new Style(Brushes.Black, Brushes.White, 40),
            new Style(new HatchBrush(HatchStyle.HorizontalBrick, Color.Beige, Color.Firebrick), Brushes.NavajoWhite, 40),
            new Style(new HatchBrush(HatchStyle.Shingle, Color.Maroon, Color.DarkRed), new HatchBrush(HatchStyle.Weave, Color.LightGray, Color.Gray), 40),

            //https://drewnoakes.com/snippets/GdiColorChart/
        };
    }
}
