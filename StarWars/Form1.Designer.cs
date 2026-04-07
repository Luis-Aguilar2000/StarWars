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
            btnvehiculos = new Button();
            btnespecies = new Button();
            btnplanetas = new Button();
            btnPeliculas = new Button();
            btnviajes = new Button();
            btnpersona = new Button();
            btninicio = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            paneldata = new Panel();
            textBox12 = new TextBox();
            textBox10 = new TextBox();
            label12 = new Label();
            textBox11 = new TextBox();
            label13 = new Label();
            comboBox4 = new ComboBox();
            label11 = new Label();
            btncancelar = new Button();
            btnactualizar = new Button();
            groupBox1 = new GroupBox();
            checkedListBox1 = new CheckedListBox();
            checkedListBox2 = new CheckedListBox();
            lbPelicula = new Label();
            lbTransporte = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox7 = new TextBox();
            btnnuevo = new Button();
            comboBox1 = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
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
            btneliminar = new Button();
            btncrear = new Button();
            lblname = new Label();
            btneditar = new Button();
            gbimage = new GroupBox();
            Picture1 = new PictureBox();
            btnimagen = new Button();
            dtgpersona = new DataGridView();
            txtbuscar = new TextBox();
            btbuscar = new Button();
            richTextBox1 = new RichTextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            btnrefesh = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            paneldata.SuspendLayout();
            groupBox1.SuspendLayout();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Picture1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnvehiculos);
            panel1.Controls.Add(btnespecies);
            panel1.Controls.Add(btnplanetas);
            panel1.Controls.Add(btnPeliculas);
            panel1.Controls.Add(btnviajes);
            panel1.Controls.Add(btnpersona);
            panel1.Controls.Add(btninicio);
            panel1.Location = new Point(28, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(151, 948);
            panel1.TabIndex = 0;
            // 
            // btnvehiculos
            // 
            btnvehiculos.BackColor = Color.Transparent;
            btnvehiculos.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnvehiculos.FlatAppearance.BorderSize = 0;
            btnvehiculos.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnvehiculos.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnvehiculos.FlatStyle = FlatStyle.Flat;
            btnvehiculos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnvehiculos.ForeColor = Color.White;
            btnvehiculos.Image = (Image)resources.GetObject("btnvehiculos.Image");
            btnvehiculos.Location = new Point(0, 427);
            btnvehiculos.Name = "btnvehiculos";
            btnvehiculos.Size = new Size(150, 52);
            btnvehiculos.TabIndex = 16;
            btnvehiculos.Text = "VEHICULOS";
            btnvehiculos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnvehiculos.UseVisualStyleBackColor = false;
            btnvehiculos.Click += btvehiculos_Click;
            // 
            // btnespecies
            // 
            btnespecies.BackColor = Color.Transparent;
            btnespecies.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnespecies.FlatAppearance.BorderSize = 0;
            btnespecies.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnespecies.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnespecies.FlatStyle = FlatStyle.Flat;
            btnespecies.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnespecies.ForeColor = Color.White;
            btnespecies.Image = (Image)resources.GetObject("btnespecies.Image");
            btnespecies.Location = new Point(0, 369);
            btnespecies.Name = "btnespecies";
            btnespecies.Size = new Size(150, 52);
            btnespecies.TabIndex = 15;
            btnespecies.Text = "ESPECIES";
            btnespecies.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnespecies.UseVisualStyleBackColor = false;
            btnespecies.Click += btespecies_Click;
            // 
            // btnplanetas
            // 
            btnplanetas.BackColor = Color.Transparent;
            btnplanetas.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnplanetas.FlatAppearance.BorderSize = 0;
            btnplanetas.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnplanetas.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnplanetas.FlatStyle = FlatStyle.Flat;
            btnplanetas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnplanetas.ForeColor = Color.White;
            btnplanetas.Image = (Image)resources.GetObject("btnplanetas.Image");
            btnplanetas.Location = new Point(1, 311);
            btnplanetas.Name = "btnplanetas";
            btnplanetas.Size = new Size(150, 52);
            btnplanetas.TabIndex = 14;
            btnplanetas.Text = "PLANETAS";
            btnplanetas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnplanetas.UseVisualStyleBackColor = false;
            btnplanetas.Click += btplanetas_Click;
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
            // btnviajes
            // 
            btnviajes.BackColor = Color.Transparent;
            btnviajes.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            btnviajes.FlatAppearance.BorderSize = 0;
            btnviajes.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            btnviajes.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            btnviajes.FlatStyle = FlatStyle.Flat;
            btnviajes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnviajes.ForeColor = Color.White;
            btnviajes.Image = (Image)resources.GetObject("btnviajes.Image");
            btnviajes.Location = new Point(0, 485);
            btnviajes.Name = "btnviajes";
            btnviajes.Size = new Size(150, 52);
            btnviajes.TabIndex = 12;
            btnviajes.Text = "VIAJES ESPACIALES";
            btnviajes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnviajes.UseVisualStyleBackColor = false;
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
            paneldata.Controls.Add(btnrefesh);
            paneldata.Controls.Add(textBox12);
            paneldata.Controls.Add(textBox10);
            paneldata.Controls.Add(label12);
            paneldata.Controls.Add(textBox11);
            paneldata.Controls.Add(label13);
            paneldata.Controls.Add(comboBox4);
            paneldata.Controls.Add(label11);
            paneldata.Controls.Add(btncancelar);
            paneldata.Controls.Add(btnactualizar);
            paneldata.Controls.Add(groupBox1);
            paneldata.Controls.Add(comboBox2);
            paneldata.Controls.Add(comboBox3);
            paneldata.Controls.Add(textBox7);
            paneldata.Controls.Add(btnnuevo);
            paneldata.Controls.Add(comboBox1);
            paneldata.Controls.Add(label10);
            paneldata.Controls.Add(label9);
            paneldata.Controls.Add(label8);
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
            paneldata.Controls.Add(btneliminar);
            paneldata.Controls.Add(btncrear);
            paneldata.Controls.Add(lblname);
            paneldata.Controls.Add(btneditar);
            paneldata.Controls.Add(gbimage);
            paneldata.Controls.Add(dtgpersona);
            paneldata.Controls.Add(txtbuscar);
            paneldata.Controls.Add(btbuscar);
            paneldata.Controls.Add(richTextBox1);
            paneldata.Controls.Add(textBox8);
            paneldata.Controls.Add(textBox9);
            paneldata.Location = new Point(179, 22);
            paneldata.Name = "paneldata";
            paneldata.Size = new Size(1486, 948);
            paneldata.TabIndex = 2;
            // 
            // textBox12
            // 
            textBox12.BackColor = SystemColors.Window;
            textBox12.BorderStyle = BorderStyle.FixedSingle;
            textBox12.Enabled = false;
            textBox12.Location = new Point(791, 681);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(181, 27);
            textBox12.TabIndex = 131;
            // 
            // textBox10
            // 
            textBox10.BackColor = SystemColors.Window;
            textBox10.BorderStyle = BorderStyle.FixedSingle;
            textBox10.Enabled = false;
            textBox10.Location = new Point(791, 594);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(181, 27);
            textBox10.TabIndex = 130;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(251, 204, 60);
            label12.Location = new Point(621, 681);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 129;
            label12.Text = "Label12";
            // 
            // textBox11
            // 
            textBox11.BackColor = SystemColors.Window;
            textBox11.BorderStyle = BorderStyle.FixedSingle;
            textBox11.Enabled = false;
            textBox11.Location = new Point(791, 637);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(181, 27);
            textBox11.TabIndex = 128;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(251, 204, 60);
            label13.Location = new Point(624, 730);
            label13.Name = "label13";
            label13.Size = new Size(68, 20);
            label13.TabIndex = 127;
            label13.Text = "Label13";
            // 
            // comboBox4
            // 
            comboBox4.Enabled = false;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(791, 727);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(181, 28);
            comboBox4.TabIndex = 126;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(251, 204, 60);
            label11.Location = new Point(623, 642);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 125;
            label11.Text = "Label11";
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.FromArgb(251, 204, 60);
            btncancelar.BackgroundImageLayout = ImageLayout.None;
            btncancelar.FlatAppearance.BorderSize = 0;
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancelar.ForeColor = SystemColors.Window;
            btncancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btncancelar.Location = new Point(257, 15);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(104, 48);
            btncancelar.TabIndex = 121;
            btncancelar.Text = "CANCELAR";
            btncancelar.TextAlign = ContentAlignment.MiddleRight;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnactualizar
            // 
            btnactualizar.BackColor = Color.FromArgb(251, 204, 60);
            btnactualizar.BackgroundImageLayout = ImageLayout.None;
            btnactualizar.Enabled = false;
            btnactualizar.FlatAppearance.BorderSize = 0;
            btnactualizar.FlatStyle = FlatStyle.Flat;
            btnactualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnactualizar.ForeColor = SystemColors.Window;
            btnactualizar.Image = (Image)resources.GetObject("btnactualizar.Image");
            btnactualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnactualizar.Location = new Point(1011, 883);
            btnactualizar.Name = "btnactualizar";
            btnactualizar.Size = new Size(162, 45);
            btnactualizar.TabIndex = 120;
            btnactualizar.Text = "ACTUALIZAR";
            btnactualizar.TextAlign = ContentAlignment.MiddleRight;
            btnactualizar.UseVisualStyleBackColor = false;
            btnactualizar.Click += btnactualizar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox1);
            groupBox1.Controls.Add(checkedListBox2);
            groupBox1.Controls.Add(lbPelicula);
            groupBox1.Controls.Add(lbTransporte);
            groupBox1.Location = new Point(1041, 503);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(416, 326);
            groupBox1.TabIndex = 119;
            groupBox1.TabStop = false;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Enabled = false;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(13, 26);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(185, 246);
            checkedListBox1.TabIndex = 117;
            // 
            // checkedListBox2
            // 
            checkedListBox2.Enabled = false;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(222, 26);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(185, 246);
            checkedListBox2.TabIndex = 118;
            // 
            // lbPelicula
            // 
            lbPelicula.AutoSize = true;
            lbPelicula.BackColor = Color.Transparent;
            lbPelicula.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPelicula.ForeColor = Color.FromArgb(251, 204, 60);
            lbPelicula.Location = new Point(70, 289);
            lbPelicula.Name = "lbPelicula";
            lbPelicula.Size = new Size(72, 20);
            lbPelicula.TabIndex = 111;
            lbPelicula.Text = "Pelicula:";
            // 
            // lbTransporte
            // 
            lbTransporte.AutoSize = true;
            lbTransporte.BackColor = Color.Transparent;
            lbTransporte.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTransporte.ForeColor = Color.FromArgb(251, 204, 60);
            lbTransporte.Location = new Point(278, 289);
            lbTransporte.Name = "lbTransporte";
            lbTransporte.Size = new Size(78, 20);
            lbTransporte.TabIndex = 103;
            lbTransporte.Text = "Vehiculo:";
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(791, 550);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(181, 28);
            comboBox2.TabIndex = 115;
            // 
            // comboBox3
            // 
            comboBox3.Enabled = false;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(791, 593);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(181, 28);
            comboBox3.TabIndex = 114;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Enabled = false;
            textBox7.Location = new Point(418, 762);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(181, 27);
            textBox7.TabIndex = 112;
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
            btnnuevo.Location = new Point(134, 14);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(104, 48);
            btnnuevo.TabIndex = 85;
            btnnuevo.Text = "NUEVO";
            btnnuevo.TextAlign = ContentAlignment.MiddleRight;
            btnnuevo.UseVisualStyleBackColor = false;
            btnnuevo.Click += btnnuevo_Click;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(791, 508);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 28);
            comboBox1.TabIndex = 105;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(251, 204, 60);
            label10.Location = new Point(623, 597);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 102;
            label10.Text = "Planeta:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(251, 204, 60);
            label9.Location = new Point(622, 558);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 101;
            label9.Text = "Especie:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(251, 204, 60);
            label8.Location = new Point(622, 509);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 100;
            label8.Text = "Genero:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(251, 204, 60);
            label7.Location = new Point(250, 765);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 98;
            label7.Text = "Cumpleaños:";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Enabled = false;
            textBox6.Location = new Point(418, 723);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(181, 27);
            textBox6.TabIndex = 97;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(251, 204, 60);
            label6.Location = new Point(250, 723);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 96;
            label6.Text = "Color de Pelo:";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Enabled = false;
            textBox5.Location = new Point(418, 679);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(181, 27);
            textBox5.TabIndex = 95;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(251, 204, 60);
            label5.Location = new Point(250, 679);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 94;
            label5.Text = "Color de Ojos:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Enabled = false;
            textBox4.Location = new Point(418, 637);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(181, 27);
            textBox4.TabIndex = 93;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(251, 204, 60);
            label4.Location = new Point(250, 637);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 92;
            label4.Text = "Color de Piel:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Enabled = false;
            textBox3.Location = new Point(418, 592);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(181, 27);
            textBox3.TabIndex = 91;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 204, 60);
            label3.Location = new Point(250, 592);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 90;
            label3.Text = "Masa: ";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Enabled = false;
            textBox2.Location = new Point(418, 548);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 27);
            textBox2.TabIndex = 89;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(251, 204, 60);
            label2.Location = new Point(250, 548);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 88;
            label2.Text = "Altura:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox1.Location = new Point(418, 503);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 27);
            textBox1.TabIndex = 87;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(251, 204, 60);
            label1.Location = new Point(250, 501);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 86;
            label1.Text = "Nombre:";
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
            btneliminar.Location = new Point(1321, 883);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(136, 45);
            btneliminar.TabIndex = 84;
            btneliminar.Text = "ELIMINAR";
            btneliminar.TextAlign = ContentAlignment.MiddleRight;
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
            // btncrear
            // 
            btncrear.BackColor = Color.FromArgb(251, 204, 60);
            btncrear.BackgroundImageLayout = ImageLayout.None;
            btncrear.Enabled = false;
            btncrear.FlatAppearance.BorderSize = 0;
            btncrear.FlatStyle = FlatStyle.Flat;
            btncrear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncrear.ForeColor = SystemColors.Window;
            btncrear.Image = (Image)resources.GetObject("btncrear.Image");
            btncrear.ImageAlign = ContentAlignment.MiddleLeft;
            btncrear.Location = new Point(1179, 883);
            btncrear.Name = "btncrear";
            btncrear.Size = new Size(136, 45);
            btncrear.TabIndex = 83;
            btncrear.Text = "CREAR";
            btncrear.TextAlign = ContentAlignment.MiddleRight;
            btncrear.UseVisualStyleBackColor = false;
            btncrear.Click += btncrear_Click;
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Swis721 BlkCn BT", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblname.ForeColor = Color.FromArgb(251, 204, 60);
            lblname.Location = new Point(595, 14);
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
            btneditar.Location = new Point(12, 15);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(104, 46);
            btneditar.TabIndex = 81;
            btneditar.Text = "EDITAR";
            btneditar.TextAlign = ContentAlignment.MiddleRight;
            btneditar.UseVisualStyleBackColor = false;
            btneditar.Click += btneditar_Click;
            // 
            // gbimage
            // 
            gbimage.BackColor = Color.Transparent;
            gbimage.Controls.Add(Picture1);
            gbimage.Controls.Add(btnimagen);
            gbimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbimage.ForeColor = Color.FromArgb(251, 204, 60);
            gbimage.Location = new Point(38, 514);
            gbimage.Name = "gbimage";
            gbimage.Size = new Size(192, 304);
            gbimage.TabIndex = 80;
            gbimage.TabStop = false;
            gbimage.Text = "Imagen";
            // 
            // Picture1
            // 
            Picture1.Location = new Point(19, 39);
            Picture1.Name = "Picture1";
            Picture1.Size = new Size(153, 194);
            Picture1.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture1.TabIndex = 0;
            Picture1.TabStop = false;
            // 
            // btnimagen
            // 
            btnimagen.Enabled = false;
            btnimagen.ImageAlign = ContentAlignment.MiddleLeft;
            btnimagen.Location = new Point(32, 246);
            btnimagen.Name = "btnimagen";
            btnimagen.Size = new Size(118, 39);
            btnimagen.TabIndex = 79;
            btnimagen.Text = "Subir Archivo";
            btnimagen.UseVisualStyleBackColor = true;
            btnimagen.Click += btnimagen_Click;
            // 
            // dtgpersona
            // 
            dtgpersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgpersona.Location = new Point(12, 84);
            dtgpersona.Name = "dtgpersona";
            dtgpersona.RowHeadersWidth = 51;
            dtgpersona.Size = new Size(1455, 387);
            dtgpersona.TabIndex = 78;
            // 
            // txtbuscar
            // 
            txtbuscar.BackColor = SystemColors.Window;
            txtbuscar.BorderStyle = BorderStyle.FixedSingle;
            txtbuscar.Location = new Point(959, 21);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(316, 27);
            txtbuscar.TabIndex = 72;
            // 
            // btbuscar
            // 
            btbuscar.Location = new Point(1303, 19);
            btbuscar.Name = "btbuscar";
            btbuscar.Size = new Size(94, 29);
            btbuscar.TabIndex = 73;
            btbuscar.Text = "Buscar";
            btbuscar.UseVisualStyleBackColor = true;
            btbuscar.Click += btbuscar_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(791, 509);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(370, 214);
            richTextBox1.TabIndex = 122;
            richTextBox1.Text = "";
            richTextBox1.Visible = false;
            // 
            // textBox8
            // 
            textBox8.Enabled = false;
            textBox8.Location = new Point(791, 509);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(181, 27);
            textBox8.TabIndex = 123;
            textBox8.Visible = false;
            // 
            // textBox9
            // 
            textBox9.Enabled = false;
            textBox9.Location = new Point(791, 551);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(181, 27);
            textBox9.TabIndex = 124;
            textBox9.Visible = false;
            // 
            // btnrefesh
            // 
            btnrefesh.Location = new Point(1403, 19);
            btnrefesh.Name = "btnrefesh";
            btnrefesh.Size = new Size(80, 29);
            btnrefesh.TabIndex = 132;
            btnrefesh.Text = "Refresh";
            btnrefesh.UseVisualStyleBackColor = true;
            btnrefesh.Click += btnrefesh_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1677, 997);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Picture1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Button btninicio;
        private Button btnpersona;
        private Button btnviajes;
        private Panel paneldata;
        private TextBox txtbuscar;
        private Button btbuscar;
        private Label lbPelicula;
        private ComboBox comboBox1;
        private Label lbTransporte;
        private Label label10;
        private Label label9;
        private Label label8;
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
        private Button btncrear;
        private Label lblname;
        private Button btneditar;
        private GroupBox gbimage;
        private PictureBox Picture1;
        private DataGridView dtgpersona;
        private Button btnPeliculas;
        private Button btnplanetas;
        private Button btnvehiculos;
        private Button btnespecies;
        private TextBox textBox7;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private GroupBox groupBox1;
        private Button btnactualizar;
        private Button btncancelar;
        private RichTextBox richTextBox1;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label12;
        private TextBox textBox11;
        private Label label13;
        private ComboBox comboBox4;
        private Label label11;
        private TextBox textBox12;
        private Button btnrefesh;
    }
}
