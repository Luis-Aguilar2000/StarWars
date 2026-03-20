using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StarWars.Services;
using StarWars.Models;

namespace StarWars
{
    public partial class personas : Form
    {
        private readonly StarWarsService _service = new StarWarsService();

        public personas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(28, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private async void personas_Load(object sender, EventArgs e)
        {
            colorpanel();

            try
            {
                var lista = await _service.GetPersonajesAsync();
                

                dtgpersona.DataSource = null;
                dtgpersona.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos ❌\n" + ex.Message);
            }
        }

        private async void btbuscar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}