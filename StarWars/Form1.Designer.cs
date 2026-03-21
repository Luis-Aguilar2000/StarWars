namespace StarWars
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button5 = new Button();
            btnpersona = new Button();
            btninicio = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            paneldata = new Panel();
            label8 = new Label();
            comboBox6 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            btnimagen = new Button();
            btnnuevo = new Button();
            btneliminar = new Button();
            button1 = new Button();
            lblname = new Label();
            btneditar = new Button();
            gbimage = new GroupBox();
            pictureBox1 = new PictureBox();
            dtgpersona = new DataGridView();
            cbtransporte = new ComboBox();
            cbespecies = new ComboBox();
            cbpelicula = new ComboBox();
            txtbuscar = new TextBox();
            cbplaneta = new ComboBox();
            btbuscar = new Button();
            btnPeliculas = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            paneldata.SuspendLayout();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPeliculas);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnpersona);
            panel1.Controls.Add(btninicio);
            panel1.Location = new Point(28, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(151, 948);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(2, 311);
            button5.Name = "button5";
            button5.Size = new Size(150, 52);
            button5.TabIndex = 12;
            button5.Text = "VIAJES ESPACIALES";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // btnpersona
            // 
            btnpersona.BackColor = Color.Transparent;
            btnpersona.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnpersona.FlatAppearance.BorderSize = 0;
            btnpersona.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnpersona.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnpersona.FlatStyle = FlatStyle.Flat;
            btnpersona.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnpersona.ForeColor = Color.White;
            btnpersona.Image = (Image)resources.GetObject("btnpersona.Image");
            btnpersona.Location = new Point(2, 195);
            btnpersona.Name = "btnpersona";
            btnpersona.Size = new Size(150, 52);
            btnpersona.TabIndex = 7;
            btnpersona.Text = "PERSONAS";
            btnpersona.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnpersona.UseVisualStyleBackColor = false;
            btnpersona.Click += btnpersona_Click;
            // 
            // btninicio
            // 
            btninicio.BackColor = Color.Transparent;
            btninicio.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btninicio.FlatAppearance.BorderSize = 0;
            btninicio.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btninicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btninicio.FlatStyle = FlatStyle.Flat;
            btninicio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btninicio.ForeColor = Color.White;
            btninicio.Image = (Image)resources.GetObject("btninicio.Image");
            btninicio.Location = new Point(1, 134);
            btninicio.Name = "btninicio";
            btninicio.Size = new Size(150, 52);
            btninicio.TabIndex = 6;
            btninicio.Text = "INICIO";
            btninicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btninicio.UseVisualStyleBackColor = false;
            btninicio.Click += btninicio_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(28, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(151, 72);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Location = new Point(221, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1013, 123);
            panel4.TabIndex = 0;
            // 
            // paneldata
            // 
            paneldata.Controls.Add(label8);
            paneldata.Controls.Add(comboBox6);
            paneldata.Controls.Add(comboBox5);
            paneldata.Controls.Add(comboBox4);
            paneldata.Controls.Add(comboBox3);
            paneldata.Controls.Add(comboBox2);
            paneldata.Controls.Add(comboBox1);
            paneldata.Controls.Add(label9);
            paneldata.Controls.Add(label10);
            paneldata.Controls.Add(label11);
            paneldata.Controls.Add(label12);
            paneldata.Controls.Add(label13);
            paneldata.Controls.Add(dateTimePicker1);
            paneldata.Controls.Add(label7);
            paneldata.Controls.Add(textBox6);
            paneldata.Controls.Add(label6);
            paneldata.Controls.Add(textBox5);
            paneldata.Controls.Add(label5);
            paneldata.Controls.Add(textBox4);
            paneldata.Controls.Add(label4);
            paneldata.Controls.Add(textBox3);
            paneldata.Controls.Add(label3);
            paneldata.Controls.Add(textBox2);
            paneldata.Controls.Add(label2);
            paneldata.Controls.Add(textBox1);
            paneldata.Controls.Add(label1);
            paneldata.Controls.Add(btnimagen);
            paneldata.Controls.Add(btnnuevo);
            paneldata.Controls.Add(btneliminar);
            paneldata.Controls.Add(button1);
            paneldata.Controls.Add(lblname);
            paneldata.Controls.Add(btneditar);
            paneldata.Controls.Add(gbimage);
            paneldata.Controls.Add(dtgpersona);
            paneldata.Controls.Add(cbtransporte);
            paneldata.Controls.Add(cbespecies);
            paneldata.Controls.Add(cbpelicula);
            paneldata.Controls.Add(txtbuscar);
            paneldata.Controls.Add(cbplaneta);
            paneldata.Controls.Add(btbuscar);
            paneldata.Location = new Point(179, 22);
            paneldata.Name = "paneldata";
            paneldata.Size = new Size(1390, 948);
            paneldata.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(251, 204, 60);
            label8.Location = new Point(442, 642);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 111;
            label8.Text = "Planeta:";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(572, 723);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(241, 28);
            comboBox6.TabIndex = 110;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(572, 679);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(241, 28);
            comboBox5.TabIndex = 109;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(572, 639);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(241, 28);
            comboBox4.TabIndex = 108;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(572, 592);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(241, 28);
            comboBox3.TabIndex = 107;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(572, 548);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(241, 28);
            comboBox2.TabIndex = 106;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(572, 508);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(241, 28);
            comboBox1.TabIndex = 105;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(251, 204, 60);
            label9.Location = new Point(442, 725);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 104;
            label9.Text = "Vehiculo: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(251, 204, 60);
            label10.Location = new Point(442, 681);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 103;
            label10.Text = "Peliculas:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(251, 204, 60);
            label11.Location = new Point(442, 594);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 102;
            label11.Text = "Especie:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(251, 204, 60);
            label12.Location = new Point(442, 550);
            label12.Name = "label12";
            label12.Size = new Size(66, 20);
            label12.TabIndex = 101;
            label12.Text = "Idioma:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(251, 204, 60);
            label13.Location = new Point(442, 508);
            label13.Name = "label13";
            label13.Size = new Size(67, 20);
            label13.TabIndex = 100;
            label13.Text = "Genero:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(172, 772);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(241, 27);
            dateTimePicker1.TabIndex = 99;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(251, 204, 60);
            label7.Location = new Point(42, 772);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 98;
            label7.Text = "Cumpleaños:";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Location = new Point(172, 728);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(241, 27);
            textBox6.TabIndex = 97;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(251, 204, 60);
            label6.Location = new Point(42, 730);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 96;
            label6.Text = "Color de Pelo:";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(172, 684);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(241, 27);
            textBox5.TabIndex = 95;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(251, 204, 60);
            label5.Location = new Point(42, 686);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 94;
            label5.Text = "Color de Ojos:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(172, 642);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(241, 27);
            textBox4.TabIndex = 93;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(251, 204, 60);
            label4.Location = new Point(42, 644);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 92;
            label4.Text = "Color de Piel:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(172, 597);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(241, 27);
            textBox3.TabIndex = 91;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 204, 60);
            label3.Location = new Point(42, 599);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 90;
            label3.Text = "Masa: ";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(172, 553);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(241, 27);
            textBox2.TabIndex = 89;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(251, 204, 60);
            label2.Location = new Point(42, 555);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 88;
            label2.Text = "Altura:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(172, 508);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 27);
            textBox1.TabIndex = 87;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(251, 204, 60);
            label1.Location = new Point(42, 515);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 86;
            label1.Text = "Nombre:";
            // 
            // btnimagen
            // 
            btnimagen.Image = (Image)resources.GetObject("btnimagen.Image");
            btnimagen.ImageAlign = ContentAlignment.MiddleLeft;
            btnimagen.Location = new Point(930, 834);
            btnimagen.Name = "btnimagen";
            btnimagen.Size = new Size(168, 37);
            btnimagen.TabIndex = 79;
            btnimagen.Text = "Subir Archivo";
            btnimagen.UseVisualStyleBackColor = true;
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
            btnnuevo.Location = new Point(1199, 597);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(136, 56);
            btnnuevo.TabIndex = 85;
            btnnuevo.Text = "NUEVO";
            btnnuevo.TextAlign = ContentAlignment.MiddleRight;
            btnnuevo.UseVisualStyleBackColor = false;
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
            btneliminar.Location = new Point(1199, 668);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(136, 56);
            btneliminar.TabIndex = 84;
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
            button1.Location = new Point(1199, 746);
            button1.Name = "button1";
            button1.Size = new Size(136, 56);
            button1.TabIndex = 83;
            button1.Text = "GUARDAR";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Swis721 BlkCn BT", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblname.ForeColor = Color.FromArgb(251, 204, 60);
            lblname.Location = new Point(595, 77);
            lblname.Name = "lblname";
            lblname.Size = new Size(218, 52);
            lblname.TabIndex = 82;
            lblname.Text = "PERSONAS";
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
            btneditar.Location = new Point(1199, 515);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(136, 56);
            btneditar.TabIndex = 81;
            btneditar.Text = "EDITAR";
            btneditar.TextAlign = ContentAlignment.MiddleRight;
            btneditar.UseVisualStyleBackColor = false;
            // 
            // gbimage
            // 
            gbimage.BackColor = Color.Transparent;
            gbimage.Controls.Add(pictureBox1);
            gbimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbimage.ForeColor = Color.FromArgb(251, 204, 60);
            gbimage.Location = new Point(891, 492);
            gbimage.Name = "gbimage";
            gbimage.Size = new Size(261, 336);
            gbimage.TabIndex = 80;
            gbimage.TabStop = false;
            gbimage.Text = "Imagen";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(19, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 271);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dtgpersona
            // 
            dtgpersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgpersona.Location = new Point(12, 132);
            dtgpersona.Name = "dtgpersona";
            dtgpersona.RowHeadersWidth = 51;
            dtgpersona.Size = new Size(1366, 339);
            dtgpersona.TabIndex = 78;
            // 
            // cbtransporte
            // 
            cbtransporte.FormattingEnabled = true;
            cbtransporte.Location = new Point(440, 21);
            cbtransporte.Name = "cbtransporte";
            cbtransporte.Size = new Size(131, 28);
            cbtransporte.TabIndex = 77;
            // 
            // cbespecies
            // 
            cbespecies.FormattingEnabled = true;
            cbespecies.Location = new Point(303, 21);
            cbespecies.Name = "cbespecies";
            cbespecies.Size = new Size(131, 28);
            cbespecies.TabIndex = 76;
            // 
            // cbpelicula
            // 
            cbpelicula.FormattingEnabled = true;
            cbpelicula.Location = new Point(166, 21);
            cbpelicula.Name = "cbpelicula";
            cbpelicula.Size = new Size(131, 28);
            cbpelicula.TabIndex = 75;
            // 
            // txtbuscar
            // 
            txtbuscar.BackColor = SystemColors.Window;
            txtbuscar.BorderStyle = BorderStyle.FixedSingle;
            txtbuscar.Location = new Point(941, 21);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(316, 27);
            txtbuscar.TabIndex = 72;
            // 
            // cbplaneta
            // 
            cbplaneta.FormattingEnabled = true;
            cbplaneta.Location = new Point(29, 19);
            cbplaneta.Name = "cbplaneta";
            cbplaneta.Size = new Size(131, 28);
            cbplaneta.TabIndex = 74;
            // 
            // btbuscar
            // 
            btbuscar.Location = new Point(1263, 19);
            btbuscar.Name = "btbuscar";
            btbuscar.Size = new Size(94, 29);
            btbuscar.TabIndex = 73;
            btbuscar.Text = "Buscar";
            btbuscar.UseVisualStyleBackColor = true;
            // 
            // btnPeliculas
            // 
            btnPeliculas.BackColor = Color.Transparent;
            btnPeliculas.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnPeliculas.FlatAppearance.BorderSize = 0;
            btnPeliculas.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnPeliculas.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnPeliculas.FlatStyle = FlatStyle.Flat;
            btnPeliculas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPeliculas.ForeColor = Color.White;
            btnPeliculas.Image = (Image)resources.GetObject("btnPeliculas.Image");
            btnPeliculas.Location = new Point(2, 253);
            btnPeliculas.Name = "btnPeliculas";
            btnPeliculas.Size = new Size(150, 52);
            btnPeliculas.TabIndex = 13;
            btnPeliculas.Text = "PELICULAS";
            btnPeliculas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPeliculas.UseVisualStyleBackColor = false;
            btnPeliculas.Click += btnPeliculas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1614, 997);
            Controls.Add(panel2);
            Controls.Add(paneldata);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            paneldata.ResumeLayout(false);
            paneldata.PerformLayout();
            gbimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Button btninicio;
        private Button btnpersona;
        private Button button5;
        private Panel paneldata;
        private ComboBox cbtransporte;
        private ComboBox cbespecies;
        private ComboBox cbpelicula;
        private TextBox txtbuscar;
        private ComboBox cbplaneta;
        private Button btbuscar;
        private Label label8;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button btnimagen;
        private Button btnnuevo;
        private Button btneliminar;
        private Button button1;
        private Label lblname;
        private Button btneditar;
        private GroupBox gbimage;
        private PictureBox pictureBox1;
        private DataGridView dtgpersona;
        private Button btnPeliculas;
    }
}
