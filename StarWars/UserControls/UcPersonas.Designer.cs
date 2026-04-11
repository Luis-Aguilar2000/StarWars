namespace StarWars.UserControls
{
    partial class UcPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPersonas));
            btnrefesh = new Button();
            btncancelar = new Button();
            btnnuevo = new Button();
            lblname = new Label();
            btneditar = new Button();
            txtbuscar = new TextBox();
            btnbuscar = new Button();
            dtgpersona = new DataGridView();
            btnactualizar = new Button();
            groupBox1 = new GroupBox();
            checkedListBox1 = new CheckedListBox();
            checkedListBox2 = new CheckedListBox();
            lbPelicula = new Label();
            lbTransporte = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox7 = new TextBox();
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
            gbimage = new GroupBox();
            Picture1 = new PictureBox();
            btnimagen = new Button();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgpersona).BeginInit();
            groupBox1.SuspendLayout();
            gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Picture1).BeginInit();
            SuspendLayout();
            // 
            // btnrefesh
            // 
            btnrefesh.Location = new Point(1400, 17);
            btnrefesh.Name = "btnrefesh";
            btnrefesh.Size = new Size(80, 29);
            btnrefesh.TabIndex = 139;
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
            btncancelar.Location = new Point(254, 13);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(104, 48);
            btncancelar.TabIndex = 138;
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
            btnnuevo.Location = new Point(131, 12);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(104, 48);
            btnnuevo.TabIndex = 137;
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
            lblname.Location = new Point(592, 12);
            lblname.Name = "lblname";
            lblname.Size = new Size(218, 52);
            lblname.TabIndex = 136;
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
            btneditar.Location = new Point(9, 13);
            btneditar.Name = "btneditar";
            btneditar.Size = new Size(104, 46);
            btneditar.TabIndex = 135;
            btneditar.Text = "EDITAR";
            btneditar.TextAlign = ContentAlignment.MiddleRight;
            btneditar.UseVisualStyleBackColor = false;
            btneditar.Click += btneditar_Click;
            // 
            // txtbuscar
            // 
            txtbuscar.BackColor = SystemColors.Window;
            txtbuscar.BorderStyle = BorderStyle.FixedSingle;
            txtbuscar.Location = new Point(956, 19);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(316, 27);
            txtbuscar.TabIndex = 133;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(1300, 17);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(94, 29);
            btnbuscar.TabIndex = 134;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            btnbuscar.Click += btbuscar_Click;
            // 
            // dtgpersona
            // 
            dtgpersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgpersona.Location = new Point(16, 72);
            dtgpersona.Name = "dtgpersona";
            dtgpersona.RowHeadersWidth = 51;
            dtgpersona.Size = new Size(1455, 387);
            dtgpersona.TabIndex = 140;
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
            btnactualizar.Location = new Point(1003, 866);
            btnactualizar.Name = "btnactualizar";
            btnactualizar.Size = new Size(162, 45);
            btnactualizar.TabIndex = 165;
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
            groupBox1.Location = new Point(1033, 486);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(416, 326);
            groupBox1.TabIndex = 164;
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
            comboBox2.Location = new Point(783, 533);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(181, 28);
            comboBox2.TabIndex = 163;
            // 
            // comboBox3
            // 
            comboBox3.Enabled = false;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(783, 576);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(181, 28);
            comboBox3.TabIndex = 162;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Enabled = false;
            textBox7.Location = new Point(410, 745);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(181, 27);
            textBox7.TabIndex = 161;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(783, 491);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 28);
            comboBox1.TabIndex = 160;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(251, 204, 60);
            label10.Location = new Point(615, 580);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 159;
            label10.Text = "Planeta:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(251, 204, 60);
            label9.Location = new Point(614, 541);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 158;
            label9.Text = "Especie:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(251, 204, 60);
            label8.Location = new Point(614, 492);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 157;
            label8.Text = "Genero:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(251, 204, 60);
            label7.Location = new Point(242, 748);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 156;
            label7.Text = "Cumpleaños:";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Enabled = false;
            textBox6.Location = new Point(410, 706);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(181, 27);
            textBox6.TabIndex = 155;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(251, 204, 60);
            label6.Location = new Point(242, 706);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 154;
            label6.Text = "Color de Pelo:";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Enabled = false;
            textBox5.Location = new Point(410, 662);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(181, 27);
            textBox5.TabIndex = 153;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(251, 204, 60);
            label5.Location = new Point(242, 662);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 152;
            label5.Text = "Color de Ojos:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Enabled = false;
            textBox4.Location = new Point(410, 620);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(181, 27);
            textBox4.TabIndex = 151;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(251, 204, 60);
            label4.Location = new Point(242, 620);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 150;
            label4.Text = "Color de Piel:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Enabled = false;
            textBox3.Location = new Point(410, 575);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(181, 27);
            textBox3.TabIndex = 149;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(251, 204, 60);
            label3.Location = new Point(242, 575);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 148;
            label3.Text = "Masa: ";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Enabled = false;
            textBox2.Location = new Point(410, 531);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 27);
            textBox2.TabIndex = 147;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(251, 204, 60);
            label2.Location = new Point(242, 531);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 146;
            label2.Text = "Altura:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox1.Location = new Point(410, 486);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 27);
            textBox1.TabIndex = 145;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(251, 204, 60);
            label1.Location = new Point(242, 484);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 144;
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
            btneliminar.Location = new Point(1313, 866);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(136, 45);
            btneliminar.TabIndex = 143;
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
            btncrear.Location = new Point(1171, 866);
            btncrear.Name = "btncrear";
            btncrear.Size = new Size(136, 45);
            btncrear.TabIndex = 142;
            btncrear.Text = "CREAR";
            btncrear.TextAlign = ContentAlignment.MiddleRight;
            btncrear.UseVisualStyleBackColor = false;
            btncrear.Click += btncrear_Click;
            // 
            // gbimage
            // 
            gbimage.BackColor = Color.Transparent;
            gbimage.Controls.Add(Picture1);
            gbimage.Controls.Add(btnimagen);
            gbimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbimage.ForeColor = Color.FromArgb(251, 204, 60);
            gbimage.Location = new Point(30, 497);
            gbimage.Name = "gbimage";
            gbimage.Size = new Size(192, 304);
            gbimage.TabIndex = 141;
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
            // 
            // textBox8
            // 
            textBox8.Enabled = false;
            textBox8.Location = new Point(783, 492);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(181, 27);
            textBox8.TabIndex = 167;
            textBox8.Visible = false;
            // 
            // textBox9
            // 
            textBox9.Enabled = false;
            textBox9.Location = new Point(783, 534);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(181, 27);
            textBox9.TabIndex = 168;
            textBox9.Visible = false;
            // 
            // UcPersonas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnactualizar);
            Controls.Add(groupBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox3);
            Controls.Add(textBox7);
            Controls.Add(comboBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
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
            Controls.Add(btneliminar);
            Controls.Add(btncrear);
            Controls.Add(gbimage);
            Controls.Add(textBox8);
            Controls.Add(textBox9);
            Controls.Add(dtgpersona);
            Controls.Add(btnrefesh);
            Controls.Add(btncancelar);
            Controls.Add(btnnuevo);
            Controls.Add(lblname);
            Controls.Add(btneditar);
            Controls.Add(txtbuscar);
            Controls.Add(btnbuscar);
            Name = "UcPersonas";
            Size = new Size(1486, 948);
            ((System.ComponentModel.ISupportInitialize)dtgpersona).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Picture1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnrefesh;
        private Button btncancelar;
        private Button btnnuevo;
        private Label lblname;
        private Button btneditar;
        private TextBox txtbuscar;
        private Button btnbuscar;
        private DataGridView dtgpersona;
        private Button btnactualizar;
        private GroupBox groupBox1;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private Label lbPelicula;
        private Label lbTransporte;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private TextBox textBox7;
        private ComboBox comboBox1;
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
        private Button btneliminar;
        private Button btncrear;
        private GroupBox gbimage;
        private PictureBox Picture1;
        private Button btnimagen;
        private TextBox textBox8;
        private TextBox textBox9;
    }
}
