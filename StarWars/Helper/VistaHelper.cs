using System.Windows.Forms;
using System.Drawing;

namespace StarWars.Helpers
{
    public class VistaHelper
    {
        public async Task ConfigurarVistaPersonasAsync(
            Label lblname,
            Label label1,
            Label label2,
            Label label3,
            Label label4,
            Label label5,
            Label label6,
            Label label7,
            Label label8,
            Label label9,
            Label label10,
            Label label11,
            Label label12,
            TextBox textBox6,
            TextBox textBox7,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            CheckedListBox checkedListBox1,
            CheckedListBox checkedListBox2,
            GroupBox groupBox1,
            Func<Task> cargarCombosPersonasAsync,
            Form form)
        {
            form.SuspendLayout();

            lblname.Text = "PERSONAS";
            label1.Text = "Nombre:";
            label2.Text = "Altura:";
            label3.Text = "Masa:";
            label4.Text = "Color de Piel:";
            label5.Text = "Color de Ojos:";
            label6.Text = "Color de Pelo:";
            label7.Text = "Cumpleaños:";

            textBox7.Visible = true;
            textBox6.Multiline = false;
            textBox6.Size = new Size(textBox6.Width, 20);

            comboBox1.Visible = true;
            label8.Text = "Genero:";

            comboBox2.Visible = true;
            label9.Text = "Especie:";

            comboBox3.Visible = true;
            label10.Text = "Planeta:";

            groupBox1.Visible = true;

            checkedListBox1.Visible = true;
            label11.Text = "Películas:";

            checkedListBox2.Visible = true;
            label12.Text = "Vehículos:";

            await cargarCombosPersonasAsync();

            form.ResumeLayout();
        }

        public void ConfigurarVistaPeliculas(
            Label lblname,
            Label label1,
            Label label2,
            Label label3,
            Label label4,
            Label label5,
            Label label6,
            Label label7,
            Label label8,
            Label label9,
            Label label10,
            Label label11,
            Label label12,
            TextBox textBox6,
            TextBox textBox7,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            CheckedListBox checkedListBox1,
            CheckedListBox checkedListBox2,
            GroupBox groupBox1,
            Form form)
        {
            form.SuspendLayout();

            lblname.Text = "PELICULAS";
            label1.Text = "Titulo:";
            label2.Text = "Episodio:";
            label3.Text = "Director:";
            label4.Text = "Productor:";
            label5.Text = "Lanzamiento:";
            label6.Text = "Avance:";
            label7.Text = "";

            textBox6.Multiline = true;
            textBox6.Size = new Size(textBox6.Width, 200);
            textBox7.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;

            label11.Text = "";
            label12.Text = "";

            groupBox1.Visible = false;

            form.ResumeLayout();
        }

        public void ConfigurarVistaPlanetas(
            Label lblname,
            Label label1,
            Label label2,
            Label label3,
            Label label4,
            Label label5,
            Label label6,
            Label label7,
            Label label8,
            Label label9,
            Label label10,
            Label label11,
            Label label12,
            TextBox textBox6,
            TextBox textBox7,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            CheckedListBox checkedListBox1,
            CheckedListBox checkedListBox2,
            GroupBox groupBox1,
            Form form)
        {
            form.SuspendLayout();

            lblname.Text = "PLANETAS";
            label1.Text = "Nombre:";
            label2.Text = "Periodo de Rotacion:";
            label3.Text = "Periodo Orbital:";
            label4.Text = "Diametro:";
            label5.Text = "Clima:";
            label6.Text = "Gravedad:";
            label7.Text = "Terreno:";

            textBox7.Visible = true;
            textBox6.Multiline = false;
            textBox6.Size = new Size(textBox6.Width, 20);

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;

            label11.Text = "";
            label12.Text = "";

            groupBox1.Visible = false;

            form.ResumeLayout();
        }
    }
}