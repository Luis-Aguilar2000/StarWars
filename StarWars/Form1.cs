using Microsoft.EntityFrameworkCore;
using StarWars.Services;

namespace StarWars
{
    public partial class Form1 : Form
    {
        private readonly StarWarsService _service = new StarWarsService();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void Form1_Load(object sender, EventArgs e)
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

        // METODOS
        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);
        }

        private void btnpersona_Click(object sender, EventArgs e)
        {

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            paneldata.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}