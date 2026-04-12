namespace StarWars.UserControls
{
    partial class UcPlanetas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPlanetas));
            dtgPlanetas = new DataGridView();
            btnrefesh = new Button();
            btncancelar = new Button();
            btnnuevo = new Button();
            lblname = new Label();
            btneditar = new Button();
            txtbuscar = new TextBox();
            btnbuscar = new Button();
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
            gbimage = new GroupBox();
            Picture1 = new PictureBox();
            btnimagen = new Button();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            textBox8 = new TextBox();
            label8 = new Label();
            textBox9 = new TextBox();
            label9 = new Label();
            btnactualizar = new Button();
            btneliminar = new Button();
            btncrear = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgPlanetas).BeginInit();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Picture1).BeginInit();
            SuspendLayout();
            // 
            // dtgPlanetas
            // 
            dtgPlanetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPlanetas.Location = new Point(15, 74);
            dtgPlanetas.Name = "dtgPlanetas";
            dtgPlanetas.RowHeadersWidth = 51;
            dtgPlanetas.Size = new Size(1455, 387);
            dtgPlanetas.TabIndex = 148;
            // 
            // btnrefesh
            // 
            btnrefesh.Location = new Point(1399, 19);
            btnrefesh.Name = "btnrefesh";
            btnrefesh.Size = new Size(80, 29);
            btnrefesh.TabIndex = 147;
            btnrefesh.Text = "Refresh";
            btnrefesh.UseVisualStyleBackColor = true;
            btnrefesh.Click += btnrefesh_Click;
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
            btncancelar.Location = new Point(253, 15);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(104, 48);
            btncancelar.TabIndex = 146;
            btncancelar.Text = "CANCELAR";
            btncancelar.TextAlign = ContentAlignment.MiddleRight;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
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
            btnnuevo.Location = new Point(130, 14);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(104, 48);
            btnnuevo.TabIndex = 145;
            btnnuevo.Text = "NUEVO";
            btnnuevo.TextAlign = ContentAlignment.MiddleRight;
            btnnuevo.UseVisualStyleBackColor = false;
            btnnuevo.Click += btnnuevo_Click;
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Swis721 BlkCn BT", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblname.ForeColor = Color.FromArgb(251, 204, 60);
            lblname.Location = new Point(591, 14);
            lblname.Name = "lblname";
            lblname.Size = new Size(208, 52);
            lblname.TabIndex = 144;
            lblname.Text = "PLANETAS";
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
            btneditar.Location = new Point(8, 15);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(104, 46);
            btneditar.TabIndex = 143;
            btneditar.Text = "EDITAR";
            btneditar.TextAlign = ContentAlignment.MiddleRight;
            btneditar.UseVisualStyleBackColor = false;
            btneditar.Click += btneditar_Click;
            // 
            // txtbuscar
            // 
            txtbuscar.BackColor = SystemColors.Window;
            txtbuscar.BorderStyle = BorderStyle.FixedSingle;
            txtbuscar.Location = new Point(955, 21);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(316, 27);
            txtbuscar.TabIndex = 141;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(1299, 19);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(94, 29);
            btnbuscar.TabIndex = 142;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            btnbuscar.Click += btbuscar_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Enabled = false;
            textBox5.Location = new Point(439, 679);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(181, 27);
            textBox5.TabIndex = 159;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(251, 204, 60);
            label5.Location = new Point(251, 681);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 158;
            label5.Text = "Clima:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Enabled = false;
            textBox4.Location = new Point(439, 637);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(181, 27);
            textBox4.TabIndex = 157;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(251, 204, 60);
            label4.Location = new Point(251, 639);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 156;
            label4.Text = "Diametro:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Enabled = false;
            textBox3.Location = new Point(439, 592);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(181, 27);
            textBox3.TabIndex = 155;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 204, 60);
            label3.Location = new Point(251, 594);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 154;
            label3.Text = "Periodo Orbital:";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Enabled = false;
            textBox2.Location = new Point(439, 548);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 27);
            textBox2.TabIndex = 153;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(251, 204, 60);
            label2.Location = new Point(251, 550);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 152;
            label2.Text = "Periodo de Rotacion:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox1.Location = new Point(439, 503);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 27);
            textBox1.TabIndex = 151;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(251, 204, 60);
            label1.Location = new Point(251, 503);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 150;
            label1.Text = "Nombre:";
            // 
            // gbimage
            // 
            gbimage.BackColor = Color.Transparent;
            gbimage.Controls.Add(Picture1);
            gbimage.Controls.Add(btnimagen);
            gbimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbimage.ForeColor = Color.FromArgb(251, 204, 60);
            gbimage.Location = new Point(39, 516);
            gbimage.Name = "gbimage";
            gbimage.Size = new Size(192, 304);
            gbimage.TabIndex = 149;
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
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Enabled = false;
            textBox6.Location = new Point(439, 727);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(181, 27);
            textBox6.TabIndex = 163;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(251, 204, 60);
            label6.Location = new Point(251, 769);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 162;
            label6.Text = "Terreno:";
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Enabled = false;
            textBox7.Location = new Point(439, 769);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(181, 27);
            textBox7.TabIndex = 161;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(251, 204, 60);
            label7.Location = new Point(251, 727);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 160;
            label7.Text = "Gravedad:";
            // 
            // textBox8
            // 
            textBox8.BackColor = SystemColors.Window;
            textBox8.BorderStyle = BorderStyle.FixedSingle;
            textBox8.Enabled = false;
            textBox8.Location = new Point(840, 506);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(181, 27);
            textBox8.TabIndex = 167;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(251, 204, 60);
            label8.Location = new Point(672, 548);
            label8.Name = "label8";
            label8.Size = new Size(88, 20);
            label8.TabIndex = 166;
            label8.Text = "Poblacion:";
            // 
            // textBox9
            // 
            textBox9.BackColor = SystemColors.Window;
            textBox9.BorderStyle = BorderStyle.FixedSingle;
            textBox9.Enabled = false;
            textBox9.Location = new Point(840, 550);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(181, 27);
            textBox9.TabIndex = 165;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(251, 204, 60);
            label9.Location = new Point(672, 506);
            label9.Name = "label9";
            label9.Size = new Size(134, 20);
            label9.TabIndex = 164;
            label9.Text = "Agua Superficial";
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
            btnactualizar.Location = new Point(1024, 880);
            btnactualizar.Name = "btnactualizar";
            btnactualizar.Size = new Size(162, 45);
            btnactualizar.TabIndex = 170;
            btnactualizar.Text = "ACTUALIZAR";
            btnactualizar.TextAlign = ContentAlignment.MiddleRight;
            btnactualizar.UseVisualStyleBackColor = false;
            btnactualizar.Click += btnactualizar_Click;
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
            btneliminar.Location = new Point(1334, 880);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(136, 45);
            btneliminar.TabIndex = 169;
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
            btncrear.Location = new Point(1192, 880);
            btncrear.Name = "btncrear";
            btncrear.Size = new Size(136, 45);
            btncrear.TabIndex = 168;
            btncrear.Text = "CREAR";
            btncrear.TextAlign = ContentAlignment.MiddleRight;
            btncrear.UseVisualStyleBackColor = false;
            btncrear.Click += btncrear_Click;
            // 
            // UcPlanetas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnactualizar);
            Controls.Add(btneliminar);
            Controls.Add(btncrear);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(textBox9);
            Controls.Add(label9);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(gbimage);
            Controls.Add(dtgPlanetas);
            Controls.Add(btnrefesh);
            Controls.Add(btncancelar);
            Controls.Add(btnnuevo);
            Controls.Add(lblname);
            Controls.Add(btneditar);
            Controls.Add(txtbuscar);
            Controls.Add(btnbuscar);
            Name = "UcPlanetas";
            Size = new Size(1486, 948);
            ((System.ComponentModel.ISupportInitialize)dtgPlanetas).EndInit();
            gbimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Picture1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgPlanetas;
        private Button btnrefesh;
        private Button btncancelar;
        private Button btnnuevo;
        private Label lblname;
        private Button btneditar;
        private TextBox txtbuscar;
        private Button btnbuscar;
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
        private GroupBox gbimage;
        private PictureBox Picture1;
        private Button btnimagen;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox9;
        private Label label9;
        private Button btnactualizar;
        private Button btneliminar;
        private Button btncrear;
    }
}
