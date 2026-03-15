using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StarWars
{
    public partial class personas : Form
    {
        public personas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            colorpanel();
        }

        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(28, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private void personas_Load(object sender, EventArgs e)
        {

        }
    }
}
