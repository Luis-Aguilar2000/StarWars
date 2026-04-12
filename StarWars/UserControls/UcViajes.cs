using PersistenceLibrary.Interfaces;
using StarWars.Models;
using StarWars.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StarWars.UserControls
{
    public partial class UcCalculadoraViajes : UserControl
    {
        private readonly IPlanetaService _planetaService;
        private readonly ITransporteService _transporteService;

        public UcCalculadoraViajes(IPlanetaService planetaService, ITransporteService transporteService)
        {
            InitializeComponent();
            _planetaService = planetaService;
            _transporteService = transporteService;

            this.Load += UcViajes_Load;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            btnCalcular.Click += button1_Click;
        }

        private async void UcViajes_Load(object sender, EventArgs e)
        {
            try
            {
                var planetas = await _planetaService.ObtenerPlanetas();
                var naves = await _transporteService.ObtenerNaves();

                var listaPlanetas1 = new List<Planeta>();
                listaPlanetas1.Add(new Planeta { Id = 0, Nombre = "Seleccionar planeta" });
                listaPlanetas1.AddRange(planetas);

                var listaPlanetas2 = new List<Planeta>();
                listaPlanetas2.Add(new Planeta { Id = 0, Nombre = "Seleccionar planeta" });
                listaPlanetas2.AddRange(planetas);

                var listaNaves = new List<Transporte>();
                listaNaves.Add(new Transporte { Id = 0, Nombre = "Seleccionar nave" });
                listaNaves.AddRange(naves);

                comboBox1.DataSource = null;
                comboBox2.DataSource = null;
                comboBox3.DataSource = null;

                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = listaPlanetas1;
                comboBox1.SelectedIndex = 0;

                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = listaPlanetas2;
                comboBox2.SelectedIndex = 0;

                comboBox3.DisplayMember = "Nombre";
                comboBox3.ValueMember = "Id";
                comboBox3.DataSource = listaNaves;
                comboBox3.SelectedIndex = 0;

                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;

                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Planeta planeta && planeta.Id != 0)
            {
                CargarImagen(planeta.Picture, pictureBox1);
            }
            else
            {
                LimpiarPictureBox(pictureBox1);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is Planeta planeta && planeta.Id != 0)
            {
                CargarImagen(planeta.Picture, pictureBox2);
            }
            else
            {
                LimpiarPictureBox(pictureBox2);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem is Transporte nave && nave.Id != 0)
            {
                CargarImagen(nave.Picture, pictureBox3);
                textBox1.Text = nave.MGLT ?? "";
            }
            else
            {
                LimpiarPictureBox(pictureBox3);
                textBox1.Text = "";
            }
        }

        private void CargarImagen(string ruta, PictureBox pb)
        {
            try
            {
                LimpiarPictureBox(pb);

                if (!string.IsNullOrWhiteSpace(ruta) && File.Exists(ruta))
                {
                    using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    {
                        pb.Image = System.Drawing.Image.FromStream(fs);
                    }

                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pb.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
            }
        }

        private void LimpiarPictureBox(PictureBox pb)
        {
            if (pb.Image != null)
            {
                pb.Image.Dispose();
                pb.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcularTiempoViaje();
        }
        private void CalcularTiempoViaje()
        {
            try
            {
                richTextBox1.Clear();
                textBox3.Text = "";

                if (!(comboBox1.SelectedItem is Planeta origen) || origen.Id == 0)
                {
                    MessageBox.Show("Seleccione el planeta de origen.");
                    return;
                }

                if (!(comboBox2.SelectedItem is Planeta destino) || destino.Id == 0)
                {
                    MessageBox.Show("Seleccione el planeta de destino.");
                    return;
                }

                if (!(comboBox3.SelectedItem is Transporte nave) || nave.Id == 0)
                {
                    MessageBox.Show("Seleccione la nave.");
                    return;
                }

                if (origen.Id == destino.Id)
                {
                    MessageBox.Show("Origen y destino no pueden ser iguales.");
                    return;
                }

                if (!double.TryParse(textBox2.Text, out double distanciaKm) || distanciaKm <= 0)
                {
                    MessageBox.Show("Ingrese una distancia válida en KM.");
                    return;
                }

                if (!double.TryParse(nave.MGLT, out double mglt))
                {
                    MessageBox.Show("La nave no tiene MGLT válido.");
                    return;
                }

                double velocidadKmS = mglt * 400;

                double tiempoSegundos = distanciaKm / velocidadKmS;
                double tiempoMinutos = tiempoSegundos / 60;
                double tiempoHoras = tiempoSegundos / 3600;
                double tiempoDias = tiempoHoras / 24;

                textBox3.Text = tiempoHoras.ToString("F4");

                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.AppendText("=== CALCULO DE VIAJE ===\n");
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                richTextBox1.AppendText("Origen: " + origen.Nombre + "\n");
                richTextBox1.AppendText("Destino: " + destino.Nombre + "\n");
                richTextBox1.AppendText("Nave: " + nave.Nombre + "\n");
                richTextBox1.AppendText("Velocidad de la nave: " + mglt + "MGLT" + "\n" );

                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.AppendText("1 MGLT = 400 km/s\n");
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                richTextBox1.AppendText("Velocidad: " + velocidadKmS.ToString("F2") + " km/s\n");
                richTextBox1.AppendText("Distancia: " + distanciaKm.ToString("F2") + " km\n\n");

                richTextBox1.AppendText("Tiempo del viaje:\n");
                richTextBox1.AppendText("- " + tiempoSegundos.ToString("F2") + " segundos\n");
                richTextBox1.AppendText("- " + tiempoMinutos.ToString("F2") + " minutos\n");
                richTextBox1.AppendText("- " + tiempoHoras.ToString("F4") + " horas\n");
                richTextBox1.AppendText("- " + tiempoDias.ToString("F4") + " días\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular: " + ex.Message);
            }
        }
    }
}