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
            RichTextBox richTextBox1,
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
            comboBox1.Visible = true;
            label8.Text = "Genero:";

            comboBox2.Visible = true;
            label9.Text = "Especie:";

            comboBox3.Visible = true;
            label10.Text = "Planeta:";

            richTextBox1.Visible = false;

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
            RichTextBox richTextBox1,
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
            label6.Text = "";
            label7.Text = "";

            textBox6.Visible = false;
            textBox7.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            richTextBox1.Visible = true;

            label8.Text = "Avance:";
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
            TextBox textBox8,
            TextBox textBox9,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            RichTextBox richTextBox1,

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

            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            label8.Text = "Agua Superficial";
            label9.Text = "Poblacion";
            label10.Text = "";
            richTextBox1.Visible = false;

            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;

            label11.Text = "";
            label12.Text = "";

            groupBox1.Visible = false;

            form.ResumeLayout();
        }

        public void LimpiarControles(
    TextBox textBox1,
    TextBox textBox2,
    TextBox textBox3,
    TextBox textBox4,
    TextBox textBox5,
    TextBox textBox6,
    TextBox textBox7,
    TextBox textBox8,
    TextBox textBox9,
    ComboBox comboBox1,
    ComboBox comboBox2,
    ComboBox comboBox3,
    RichTextBox richTextBox1,
    CheckedListBox checkedListBox1,
    CheckedListBox checkedListBox2,
    PictureBox picture1)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            richTextBox1.Text = "";

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);

            if (picture1.Image != null)
            {
                picture1.Image.Dispose();
                picture1.Image = null;
            }
        }

        public void HabilitarControles(
            TextBox textBox1,
            TextBox textBox2,
            TextBox textBox3,
            TextBox textBox4,
            TextBox textBox5,
            TextBox textBox6,
            TextBox textBox7,
            TextBox textBox8,
            TextBox textBox9,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            RichTextBox richTextBox1,
            CheckedListBox checkedListBox1,
            CheckedListBox checkedListBox2,
            Button btneditar,
            Button btnnuevo,
            Button btncancelar,
            Button btnimagen,
            Button btneliminar)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            richTextBox1.Enabled = true;

            checkedListBox1.Enabled = true;
            checkedListBox2.Enabled = true;

            btneditar.Enabled = false;
            btnnuevo.Enabled = false;
            btncancelar.Enabled = true;
            btnimagen.Enabled = true;
            btneliminar.Enabled = false;
        }

        public void DeshabilitarControles(
            TextBox textBox1,
            TextBox textBox2,
            TextBox textBox3,
            TextBox textBox4,
            TextBox textBox5,
            TextBox textBox6,
            TextBox textBox7,
            TextBox textBox8,
            TextBox textBox9,
            ComboBox comboBox1,
            ComboBox comboBox2,
            ComboBox comboBox3,
            CheckedListBox checkedListBox1,
            CheckedListBox checkedListBox2,
            Button btnimagen,
            Button btnnuevo,
            Button btneliminar,
            Button btneditar,
            Button btnactualizar)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;


            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            checkedListBox1.Enabled = false;
            checkedListBox2.Enabled = false;

            btnimagen.Enabled = false;
            btnnuevo.Enabled = true;
            btneliminar.Enabled = true;
            btneditar.Enabled = true;
            btnactualizar.Enabled = false;
        }
    }
}