namespace StarWars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            colorpanel();

        }

        //METODOS
        private void colorpanel()
        {
            panel1.BackColor = Color.FromArgb(60, 100, 100, 100);
            panel2.BackColor = Color.FromArgb(30, 100, 100, 100);
            paneldata.BackColor = Color.FromArgb(28, 100, 100, 100);

        }

        private void btnpersona_Click(object sender, EventArgs e)
        {
            abrirformulario(new personas());
        }

        private void abrirformulario(object formhijo)
        {
            if (this.paneldata.Controls.Count > 0)
            {
                this.paneldata.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.paneldata.Controls.Add(fh);
            this.paneldata.Tag = fh;
            fh.Show();

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            paneldata.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirformulario(new planetas());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirformulario(new especies());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirformulario(new peliculas());
        }
    }
}
