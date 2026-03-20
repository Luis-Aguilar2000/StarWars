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
            cbtransporte = new ComboBox();
            cbespecies = new ComboBox();
            cbpelicula = new ComboBox();
            cbplaneta = new ComboBox();
            btbuscar = new Button();
            txtbuscar = new TextBox();
            panel2 = new Panel();
            btnimagen = new Button();
            btnnuevo = new Button();
            btneliminar = new Button();
            button1 = new Button();
            lblname = new Label();
            btneditar = new Button();
            gbimage = new GroupBox();
            pictureBox1 = new PictureBox();
            dtgpersona = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cbtransporte);
            panel1.Controls.Add(cbespecies);
            panel1.Controls.Add(cbpelicula);
            panel1.Controls.Add(cbplaneta);
            panel1.Controls.Add(btbuscar);
            panel1.Controls.Add(txtbuscar);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1392, 69);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // cbtransporte
            // 
            cbtransporte.FormattingEnabled = true;
            cbtransporte.Location = new Point(450, 24);
            cbtransporte.Name = "cbtransporte";
            cbtransporte.Size = new Size(131, 28);
            cbtransporte.TabIndex = 41;
            // 
            // cbespecies
            // 
            cbespecies.FormattingEnabled = true;
            cbespecies.Location = new Point(313, 24);
            cbespecies.Name = "cbespecies";
            cbespecies.Size = new Size(131, 28);
            cbespecies.TabIndex = 40;
            // 
            // cbpelicula
            // 
            cbpelicula.FormattingEnabled = true;
            cbpelicula.Location = new Point(176, 24);
            cbpelicula.Name = "cbpelicula";
            cbpelicula.Size = new Size(131, 28);
            cbpelicula.TabIndex = 39;
            // 
            // cbplaneta
            // 
            cbplaneta.FormattingEnabled = true;
            cbplaneta.Location = new Point(39, 22);
            cbplaneta.Name = "cbplaneta";
            cbplaneta.Size = new Size(131, 28);
            cbplaneta.TabIndex = 38;
            cbplaneta.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
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
            // txtbuscar
            // 
            txtbuscar.BackColor = SystemColors.Window;
            txtbuscar.BorderStyle = BorderStyle.FixedSingle;
            txtbuscar.Location = new Point(951, 24);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(316, 27);
            txtbuscar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label8);
            panel2.Controls.Add(comboBox6);
            panel2.Controls.Add(comboBox5);
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(comboBox3);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnimagen);
            panel2.Controls.Add(btnnuevo);
            panel2.Controls.Add(btneliminar);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(lblname);
            panel2.Controls.Add(btneditar);
            panel2.Controls.Add(gbimage);
            panel2.Controls.Add(dtgpersona);
            panel2.Location = new Point(1, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(1392, 880);
            panel2.TabIndex = 2;
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
            dtgpersona.Location = new Point(11, 69);
            dtgpersona.Name = "dtgpersona";
            dtgpersona.RowHeadersWidth = 51;
            dtgpersona.Size = new Size(1366, 339);
            dtgpersona.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(251, 204, 60);
            label1.Location = new Point(41, 452);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 46;
            label1.Text = "Nombre:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(171, 445);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 27);
            textBox1.TabIndex = 47;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(171, 709);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(241, 27);
            dateTimePicker1.TabIndex = 59;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(251, 204, 60);
            label7.Location = new Point(41, 709);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 58;
            label7.Text = "Cumpleaños:";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Location = new Point(171, 665);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(241, 27);
            textBox6.TabIndex = 57;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(251, 204, 60);
            label6.Location = new Point(41, 667);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 56;
            label6.Text = "Color de Pelo:";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(171, 621);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(241, 27);
            textBox5.TabIndex = 55;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(251, 204, 60);
            label5.Location = new Point(41, 623);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 54;
            label5.Text = "Color de Ojos:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(171, 579);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(241, 27);
            textBox4.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(251, 204, 60);
            label4.Location = new Point(41, 581);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 52;
            label4.Text = "Color de Piel:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(171, 534);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(241, 27);
            textBox3.TabIndex = 51;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 204, 60);
            label3.Location = new Point(41, 536);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 50;
            label3.Text = "Masa: ";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(171, 490);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(241, 27);
            textBox2.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(251, 204, 60);
            label2.Location = new Point(41, 492);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 48;
            label2.Text = "Altura:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(251, 204, 60);
            label8.Location = new Point(441, 579);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 71;
            label8.Text = "Planeta:";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(571, 660);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(241, 28);
            comboBox6.TabIndex = 70;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(571, 616);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(241, 28);
            comboBox5.TabIndex = 69;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(571, 576);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(241, 28);
            comboBox4.TabIndex = 68;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(571, 529);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(241, 28);
            comboBox3.TabIndex = 67;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(571, 485);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(241, 28);
            comboBox2.TabIndex = 66;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(571, 445);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(241, 28);
            comboBox1.TabIndex = 65;
            comboBox1.SelectedIndexChanged += comboBox16_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(251, 204, 60);
            label9.Location = new Point(441, 662);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 64;
            label9.Text = "Vehiculo: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(251, 204, 60);
            label10.Location = new Point(441, 618);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 63;
            label10.Text = "Peliculas:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(251, 204, 60);
            label11.Location = new Point(441, 531);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 62;
            label11.Text = "Especie:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(251, 204, 60);
            label12.Location = new Point(441, 487);
            label12.Name = "label12";
            label12.Size = new Size(66, 20);
            label12.TabIndex = 61;
            label12.Text = "Idioma:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(251, 204, 60);
            label13.Location = new Point(441, 445);
            label13.Name = "label13";
            label13.Size = new Size(67, 20);
            label13.TabIndex = 60;
            label13.Text = "Genero:";
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
        private TextBox txtbuscar;
        private Button btbuscar;
        private Panel panel2;
        private DataGridView dtgpersona;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private GroupBox gbimage;
        private Button btnimagen;
        private PictureBox pictureBox1;
        private ComboBox cbtransporte;
        private ComboBox cbespecies;
        private ComboBox cbpelicula;
        private ComboBox cbplaneta;
        private Button btneditar;
        private Label lblname;
        private Button btnnuevo;
        private Button btneliminar;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
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
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}