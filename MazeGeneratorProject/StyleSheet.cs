﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MazeGeneratorProject;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorProject {
    static class StyleSheet {
        public static readonly Font Headings = new Font(FontFamily.GenericSerif, 40);
        public static readonly Font Body = new Font(FontFamily.GenericSansSerif, 12);
        //public static readonly Bitmap Backgroundimage = ;

        public static readonly Style[] mazestyles = {
            //          walls           passages
            new Style(Brushes.Black, Brushes.White),
            new Style(new HatchBrush(HatchStyle.HorizontalBrick, Color.Beige, Color.Firebrick), Brushes.NavajoWhite),
            new Style(new HatchBrush(HatchStyle.Shingle, Color.Maroon, Color.DarkRed), new HatchBrush(HatchStyle.Weave, Color.LightGray, Color.Gray)),

            //https://drewnoakes.com/snippets/GdiColorChart/
        };
    }
}
