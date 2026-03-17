using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StarWars
{
    public partial class planetas : Form
    {
        public planetas()
        {
            InitializeComponent();
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {

        }
        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(28, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private void planetas_Load(object sender, EventArgs e)
        {
            colorpanel();
        }
    }
}
