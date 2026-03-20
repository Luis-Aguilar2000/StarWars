namespace StarWars
{
    partial class personas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(personas));
            panel1 = new Panel();
            comboBox10 = new ComboBox();
            comboBox9 = new ComboBox();
            comboBox8 = new ComboBox();
            comboBox7 = new ComboBox();
            btbuscar = new Button();
            textBuscar = new TextBox();
            panel2 = new Panel();
            btnnuevo = new Button();
            btneliminar = new Button();
            button1 = new Button();
            lblname = new Label();
            btneditar = new Button();
            lblplaneta = new Label();
            gbimage = new GroupBox();
            btnimagen = new Button();
            pictureBox1 = new PictureBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            lbltransporte = new Label();
            lblpelicula = new Label();
            lblespecie = new Label();
            lblidioma = new Label();
            lblgenero = new Label();
            dtpcumpleaños = new DateTimePicker();
            lblcumpleaños = new Label();
            txtcpelo = new TextBox();
            lblcpelo = new Label();
            txtcojos = new TextBox();
            lblcojos = new Label();
            txtcpiel = new TextBox();
            lblcpiel = new Label();
            txtmasa = new TextBox();
            lblmass = new Label();
            txtaltura = new TextBox();
            lblaltura = new Label();
            txtnombre = new TextBox();
            lblnombre = new Label();
            dtgpersona = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox10);
            panel1.Controls.Add(comboBox9);
            panel1.Controls.Add(comboBox8);
            panel1.Controls.Add(comboBox7);
            panel1.Controls.Add(btbuscar);
            panel1.Controls.Add(textBuscar);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1392, 69);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // comboBox10
            // 
            comboBox10.FormattingEnabled = true;
            comboBox10.Location = new Point(450, 24);
            comboBox10.Name = "comboBox10";
            comboBox10.Size = new Size(131, 28);
            comboBox10.TabIndex = 41;
            // 
            // comboBox9
            // 
            comboBox9.FormattingEnabled = true;
            comboBox9.Location = new Point(313, 24);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(131, 28);
            comboBox9.TabIndex = 40;
            // 
            // comboBox8
            // 
            comboBox8.FormattingEnabled = true;
            comboBox8.Location = new Point(176, 24);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new Size(131, 28);
            comboBox8.TabIndex = 39;
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(39, 22);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(131, 28);
            comboBox7.TabIndex = 38;
            // 
            // btbuscar
            // 
            btbuscar.Location = new Point(1273, 22);
            btbuscar.Name = "btbuscar";
            btbuscar.Size = new Size(94, 29);
            btbuscar.TabIndex = 2;
            btbuscar.Text = "Buscar";
            btbuscar.UseVisualStyleBackColor = true;
            btbuscar.Click += btbuscar_Click;
            // 
            // textBuscar
            // 
            textBuscar.BackColor = SystemColors.Window;
            textBuscar.BorderStyle = BorderStyle.FixedSingle;
            textBuscar.Location = new Point(951, 24);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(316, 27);
            textBuscar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnimagen);
            panel2.Controls.Add(btnnuevo);
            panel2.Controls.Add(btneliminar);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(lblname);
            panel2.Controls.Add(btneditar);
            panel2.Controls.Add(lblplaneta);
            panel2.Controls.Add(gbimage);
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(comboBox5);
            panel2.Controls.Add(comboBox6);
            panel2.Controls.Add(comboBox3);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(lbltransporte);
            panel2.Controls.Add(lblpelicula);
            panel2.Controls.Add(lblespecie);
            panel2.Controls.Add(lblidioma);
            panel2.Controls.Add(lblgenero);
            panel2.Controls.Add(dtpcumpleaños);
            panel2.Controls.Add(lblcumpleaños);
            panel2.Controls.Add(txtcpelo);
            panel2.Controls.Add(lblcpelo);
            panel2.Controls.Add(txtcojos);
            panel2.Controls.Add(lblcojos);
            panel2.Controls.Add(txtcpiel);
            panel2.Controls.Add(lblcpiel);
            panel2.Controls.Add(txtmasa);
            panel2.Controls.Add(lblmass);
            panel2.Controls.Add(txtaltura);
            panel2.Controls.Add(lblaltura);
            panel2.Controls.Add(txtnombre);
            panel2.Controls.Add(lblnombre);
            panel2.Controls.Add(dtgpersona);
            panel2.Location = new Point(1, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(1392, 880);
            panel2.TabIndex = 2;
            // 
            // btnnuevo
            // 
            btnnuevo.BackColor = Color.FromArgb(251, 204, 60);
            btnnuevo.BackgroundImageLayout = ImageLayout.None;
            btnnuevo.FlatAppearance.BorderSize = 0;
            btnnuevo.FlatStyle = FlatStyle.Flat;
            btnnuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnuevo.ForeColor = SystemColors.Window;
            btnnuevo.Image = (Image)resources.GetObject("btnnuevo.Image");
            btnnuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnnuevo.Location = new Point(1198, 534);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(136, 56);
            btnnuevo.TabIndex = 45;
            btnnuevo.Text = "NUEVO";
            btnnuevo.TextAlign = ContentAlignment.MiddleRight;
            btnnuevo.UseVisualStyleBackColor = false;
            btnnuevo.Click += btnnuevo_Click;
            // 
            // btneliminar
            // 
            btneliminar.BackColor = Color.FromArgb(251, 204, 60);
            btneliminar.BackgroundImageLayout = ImageLayout.None;
            btneliminar.FlatAppearance.BorderSize = 0;
            btneliminar.FlatStyle = FlatStyle.Flat;
            btneliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btneliminar.ForeColor = SystemColors.Window;
            btneliminar.Image = (Image)resources.GetObject("btneliminar.Image");
            btneliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btneliminar.Location = new Point(1198, 605);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(136, 56);
            btneliminar.TabIndex = 44;
            btneliminar.Text = "ELIMINAR";
            btneliminar.TextAlign = ContentAlignment.MiddleRight;
            btneliminar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(251, 204, 60);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Window;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(1198, 683);
            button1.Name = "button1";
            button1.Size = new Size(136, 56);
            button1.TabIndex = 43;
            button1.Text = "GUARDAR";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Swis721 BlkCn BT", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblname.ForeColor = Color.FromArgb(251, 204, 60);
            lblname.Location = new Point(594, 14);
            lblname.Name = "lblname";
            lblname.Size = new Size(218, 52);
            lblname.TabIndex = 42;
            lblname.Text = "PERSONAS";
            lblname.Click += label1_Click;
            // 
            // btneditar
            // 
            btneditar.BackColor = Color.FromArgb(251, 204, 60);
            btneditar.BackgroundImageLayout = ImageLayout.None;
            btneditar.FlatAppearance.BorderSize = 0;
            btneditar.FlatStyle = FlatStyle.Flat;
            btneditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btneditar.ForeColor = SystemColors.Window;
            btneditar.Image = (Image)resources.GetObject("btneditar.Image");
            btneditar.ImageAlign = ContentAlignment.MiddleLeft;
            btneditar.Location = new Point(1198, 452);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(136, 56);
            btneditar.TabIndex = 38;
            btneditar.Text = "EDITAR";
            btneditar.TextAlign = ContentAlignment.MiddleRight;
            btneditar.UseVisualStyleBackColor = false;
            // 
            // lblplaneta
            // 
            lblplaneta.AutoSize = true;
            lblplaneta.BackColor = Color.Transparent;
            lblplaneta.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblplaneta.ForeColor = Color.FromArgb(251, 204, 60);
            lblplaneta.Location = new Point(441, 586);
            lblplaneta.Name = "lblplaneta";
            lblplaneta.Size = new Size(69, 20);
            lblplaneta.TabIndex = 37;
            lblplaneta.Text = "Planeta:";
            // 
            // gbimage
            // 
            gbimage.BackColor = Color.Transparent;
            gbimage.Controls.Add(pictureBox1);
            gbimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbimage.ForeColor = Color.FromArgb(251, 204, 60);
            gbimage.Location = new Point(890, 429);
            gbimage.Name = "gbimage";
            gbimage.Size = new Size(261, 336);
            gbimage.TabIndex = 35;
            gbimage.TabStop = false;
            gbimage.Text = "Imagen";
            // 
            // btnimagen
            // 
            btnimagen.Image = (Image)resources.GetObject("btnimagen.Image");
            btnimagen.ImageAlign = ContentAlignment.MiddleLeft;
            btnimagen.Location = new Point(929, 771);
            btnimagen.Name = "btnimagen";
            btnimagen.Size = new Size(168, 37);
            btnimagen.TabIndex = 1;
            btnimagen.Text = "Subir Archivo";
            btnimagen.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(19, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 271);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(571, 667);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(241, 28);
            comboBox4.TabIndex = 34;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(571, 623);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(241, 28);
            comboBox5.TabIndex = 33;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(571, 583);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(241, 28);
            comboBox6.TabIndex = 32;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(571, 536);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(241, 28);
            comboBox3.TabIndex = 31;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(571, 492);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(241, 28);
            comboBox2.TabIndex = 30;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(571, 452);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(241, 28);
            comboBox1.TabIndex = 29;
            // 
            // lbltransporte
            // 
            lbltransporte.AutoSize = true;
            lbltransporte.BackColor = Color.Transparent;
            lbltransporte.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltransporte.ForeColor = Color.FromArgb(251, 204, 60);
            lbltransporte.Location = new Point(441, 669);
            lbltransporte.Name = "lbltransporte";
            lbltransporte.Size = new Size(83, 20);
            lbltransporte.TabIndex = 27;
            lbltransporte.Text = "Vehiculo: ";
            // 
            // lblpelicula
            // 
            lblpelicula.AutoSize = true;
            lblpelicula.BackColor = Color.Transparent;
            lblpelicula.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpelicula.ForeColor = Color.FromArgb(251, 204, 60);
            lblpelicula.Location = new Point(441, 625);
            lblpelicula.Name = "lblpelicula";
            lblpelicula.Size = new Size(79, 20);
            lblpelicula.TabIndex = 25;
            lblpelicula.Text = "Peliculas:";
            // 
            // lblespecie
            // 
            lblespecie.AutoSize = true;
            lblespecie.BackColor = Color.Transparent;
            lblespecie.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblespecie.ForeColor = Color.FromArgb(251, 204, 60);
            lblespecie.Location = new Point(441, 538);
            lblespecie.Name = "lblespecie";
            lblespecie.Size = new Size(70, 20);
            lblespecie.TabIndex = 21;
            lblespecie.Text = "Especie:";
            // 
            // lblidioma
            // 
            lblidioma.AutoSize = true;
            lblidioma.BackColor = Color.Transparent;
            lblidioma.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblidioma.ForeColor = Color.FromArgb(251, 204, 60);
            lblidioma.Location = new Point(441, 494);
            lblidioma.Name = "lblidioma";
            lblidioma.Size = new Size(66, 20);
            lblidioma.TabIndex = 19;
            lblidioma.Text = "Idioma:";
            lblidioma.Click += label5_Click;
            // 
            // lblgenero
            // 
            lblgenero.AutoSize = true;
            lblgenero.BackColor = Color.Transparent;
            lblgenero.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblgenero.ForeColor = Color.FromArgb(251, 204, 60);
            lblgenero.Location = new Point(441, 452);
            lblgenero.Name = "lblgenero";
            lblgenero.Size = new Size(67, 20);
            lblgenero.TabIndex = 17;
            lblgenero.Text = "Genero:";
            // 
            // dtpcumpleaños
            // 
            dtpcumpleaños.Location = new Point(171, 709);
            dtpcumpleaños.Name = "dtpcumpleaños";
            dtpcumpleaños.Size = new Size(241, 27);
            dtpcumpleaños.TabIndex = 16;
            // 
            // lblcumpleaños
            // 
            lblcumpleaños.AutoSize = true;
            lblcumpleaños.BackColor = Color.Transparent;
            lblcumpleaños.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcumpleaños.ForeColor = Color.FromArgb(251, 204, 60);
            lblcumpleaños.Location = new Point(41, 709);
            lblcumpleaños.Name = "lblcumpleaños";
            lblcumpleaños.Size = new Size(105, 20);
            lblcumpleaños.TabIndex = 15;
            lblcumpleaños.Text = "Cumpleaños:";
            // 
            // txtcpelo
            // 
            txtcpelo.BackColor = SystemColors.Window;
            txtcpelo.BorderStyle = BorderStyle.FixedSingle;
            txtcpelo.Location = new Point(171, 665);
            txtcpelo.Name = "txtcpelo";
            txtcpelo.Size = new Size(241, 27);
            txtcpelo.TabIndex = 14;
            // 
            // lblcpelo
            // 
            lblcpelo.AutoSize = true;
            lblcpelo.BackColor = Color.Transparent;
            lblcpelo.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcpelo.ForeColor = Color.FromArgb(251, 204, 60);
            lblcpelo.Location = new Point(41, 667);
            lblcpelo.Name = "lblcpelo";
            lblcpelo.Size = new Size(116, 20);
            lblcpelo.TabIndex = 13;
            lblcpelo.Text = "Color de Pelo:";
            // 
            // txtcojos
            // 
            txtcojos.BackColor = SystemColors.Window;
            txtcojos.BorderStyle = BorderStyle.FixedSingle;
            txtcojos.Location = new Point(171, 621);
            txtcojos.Name = "txtcojos";
            txtcojos.Size = new Size(241, 27);
            txtcojos.TabIndex = 12;
            // 
            // lblcojos
            // 
            lblcojos.AutoSize = true;
            lblcojos.BackColor = Color.Transparent;
            lblcojos.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcojos.ForeColor = Color.FromArgb(251, 204, 60);
            lblcojos.Location = new Point(41, 623);
            lblcojos.Name = "lblcojos";
            lblcojos.Size = new Size(117, 20);
            lblcojos.TabIndex = 11;
            lblcojos.Text = "Color de Ojos:";
            // 
            // txtcpiel
            // 
            txtcpiel.BackColor = SystemColors.Window;
            txtcpiel.BorderStyle = BorderStyle.FixedSingle;
            txtcpiel.Location = new Point(171, 579);
            txtcpiel.Name = "txtcpiel";
            txtcpiel.Size = new Size(241, 27);
            txtcpiel.TabIndex = 10;
            // 
            // lblcpiel
            // 
            lblcpiel.AutoSize = true;
            lblcpiel.BackColor = Color.Transparent;
            lblcpiel.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcpiel.ForeColor = Color.FromArgb(251, 204, 60);
            lblcpiel.Location = new Point(41, 581);
            lblcpiel.Name = "lblcpiel";
            lblcpiel.Size = new Size(111, 20);
            lblcpiel.TabIndex = 9;
            lblcpiel.Text = "Color de Piel:";
            // 
            // txtmasa
            // 
            txtmasa.BackColor = SystemColors.Window;
            txtmasa.BorderStyle = BorderStyle.FixedSingle;
            txtmasa.Location = new Point(171, 534);
            txtmasa.Name = "txtmasa";
            txtmasa.Size = new Size(241, 27);
            txtmasa.TabIndex = 8;
            // 
            // lblmass
            // 
            lblmass.AutoSize = true;
            lblmass.BackColor = Color.Transparent;
            lblmass.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblmass.ForeColor = Color.FromArgb(251, 204, 60);
            lblmass.Location = new Point(41, 536);
            lblmass.Name = "lblmass";
            lblmass.Size = new Size(57, 20);
            lblmass.TabIndex = 7;
            lblmass.Text = "Masa: ";
            // 
            // txtaltura
            // 
            txtaltura.BackColor = SystemColors.Window;
            txtaltura.BorderStyle = BorderStyle.FixedSingle;
            txtaltura.Location = new Point(171, 490);
            txtaltura.Name = "txtaltura";
            txtaltura.Size = new Size(241, 27);
            txtaltura.TabIndex = 6;
            // 
            // lblaltura
            // 
            lblaltura.AutoSize = true;
            lblaltura.BackColor = Color.Transparent;
            lblaltura.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblaltura.ForeColor = Color.FromArgb(251, 204, 60);
            lblaltura.Location = new Point(41, 492);
            lblaltura.Name = "lblaltura";
            lblaltura.Size = new Size(59, 20);
            lblaltura.TabIndex = 5;
            lblaltura.Text = "Altura:";
            // 
            // txtnombre
            // 
            txtnombre.BackColor = SystemColors.Window;
            txtnombre.BorderStyle = BorderStyle.FixedSingle;
            txtnombre.Location = new Point(171, 448);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(241, 27);
            txtnombre.TabIndex = 4;
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.BackColor = Color.Transparent;
            lblnombre.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnombre.ForeColor = Color.FromArgb(251, 204, 60);
            lblnombre.Location = new Point(41, 450);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(74, 20);
            lblnombre.TabIndex = 3;
            lblnombre.Text = "Nombre:";
            // 
            // dtgpersona
            // 
            dtgpersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgpersona.Location = new Point(11, 69);
            dtgpersona.Name = "dtgpersona";
            dtgpersona.RowHeadersWidth = 51;
            dtgpersona.Size = new Size(1366, 339);
            dtgpersona.TabIndex = 0;
            // 
            // personas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1390, 948);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "personas";
            Text = "personas";
            Load += personas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            gbimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TextBox textBuscar;
        private Button btbuscar;
        private Panel panel2;
        private DataGridView dtgpersona;
        private TextBox txtnombre;
        private Label lblnombre;
        private TextBox txtmasa;
        private Label lblmass;
        private TextBox txtaltura;
        private Label lblaltura;
        private Label lblcumpleaños;
        private TextBox txtcpelo;
        private Label lblcpelo;
        private TextBox txtcojos;
        private Label lblcojos;
        private TextBox txtcpiel;
        private Label lblcpiel;
        private DateTimePicker dtpcumpleaños;
        private TextBox textBox1;
        private Label lbltransporte;
        private TextBox textBox2;
        private Label lblpelicula;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label lblespecie;
        private TextBox textBox5;
        private Label lblidioma;
        private Label lblgenero;
        private ComboBox comboBox1;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private GroupBox gbimage;
        private Button btnimagen;
        private PictureBox pictureBox1;
        private Label lblplaneta;
        private ComboBox comboBox10;
        private ComboBox comboBox9;
        private ComboBox comboBox8;
        private ComboBox comboBox7;
        private Button btneditar;
        private Label lblname;
        private Button btnnuevo;
        private Button btneliminar;
        private Button button1;
    }
}