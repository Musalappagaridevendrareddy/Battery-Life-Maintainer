using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.MaximizeBox = false;
            // turn of stretch
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeComponent();
            SetActivePanel(home1);

        }
        public void SetActivePanel(UserControl control)
        {
            home1.Visible = false;
            about1.Visible = false;
            control.Visible = true;
            
        }

        private void homePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActivePanel(home1);
        }

        private void aboutPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActivePanel(about1);
        }
    }
}
