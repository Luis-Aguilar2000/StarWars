using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StarWars
{
    public partial class vehiculos : Form
    {
        public vehiculos()
        {
            InitializeComponent();
        }

        private void vehiculos_Load_1(object sender, EventArgs e)
        {
            colorpanel();
        }

        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(28, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(28, 100, 100, 100);
        }
    }
}
