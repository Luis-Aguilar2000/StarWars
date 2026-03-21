using Microsoft.EntityFrameworkCore;
using RestLibrary.Interfaces;
using StarWars.Data;
using StarWars.Dtos;

namespace StarWars
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestApi _restApi;

        public Form1(ApplicationDbContext context, IRestApi restApi)
        {
            InitializeComponent();
            _context = context;
            _restApi = restApi;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            colorpanel();

            try
            {
                var result = await _restApi.Get<PeopleResponse<PersonajeJsonModel>>(
                    "https://swapi.dev/api/",
                    "people/"
                );

                dtgpersona.DataSource = result.Results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
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