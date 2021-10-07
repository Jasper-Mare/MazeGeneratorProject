using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class GenerateMaze : Form {
        User user;
        GeneratorOptions options = new GeneratorOptions();

        //===options=controls===//
        ComboBox drpdwn_GenType;
        Button bttn_ChooseTemplate;
        ComboBox drpdwn_Style;
        CheckBox chbx_Minotaur;
        CheckBox chbx_MovingWalls;
        CheckBox chbx_ReducedVisiblity;
        CheckBox chbx_Keys;
        NumericUpDown[] updwn_biasStrengths;
        //======================//

        public GenerateMaze(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void GenerateMaze_Load(object sender, EventArgs e) {
            lbl_Username.Font = StyleSheet.Headings;
            lbl_Username.Text = "Hello " + user.Name;
            bttn_back.Font = StyleSheet.Body;

            //pannel scrollbars
            pnl_Options.AutoScroll = false;
            pnl_Options.HorizontalScroll.Enabled = false;
            pnl_Options.HorizontalScroll.Visible = false;
            pnl_Options.HorizontalScroll.Maximum = 0;
            pnl_Options.AutoScroll = true;

            //generation type
            drpdwn_GenType = new ComboBox();
            drpdwn_GenType.DropDownStyle = ComboBoxStyle.DropDownList;
            drpdwn_GenType.Items.Add("Gamma (squares)");
            drpdwn_GenType.Items.Add("Delta (triangles)");
            drpdwn_GenType.Items.Add("Theta (circle)");
            drpdwn_GenType.Location = new Point(5, 5);
            pnl_Options.Controls.Add(drpdwn_GenType);

            //Choose template
            bttn_ChooseTemplate = new Button();
            bttn_ChooseTemplate.Location = new Point(5, 45);
            bttn_ChooseTemplate.Text = "Choose a template.";
            bttn_ChooseTemplate.Click += Bttn_ChooseTemplate_Click;
            pnl_Options.Controls.Add(bttn_ChooseTemplate);

            //
        }

        private void Bttn_ChooseTemplate_Click(object sender, EventArgs e) {
            //opens file dialog

        }

        private void bttn_back_Click(object sender, EventArgs e) {
            Program.appWindow.SetActiveForm(new MainMenu(user));
        }


    }
}
