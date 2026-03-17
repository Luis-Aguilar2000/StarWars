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
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnpersona = new Button();
            btninicio = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            paneldata = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnpersona);
            panel1.Controls.Add(btninicio);
            panel1.Location = new Point(28, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(151, 702);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(3, 427);
            button4.Name = "button4";
            button4.Size = new Size(150, 52);
            button4.TabIndex = 11;
            button4.Text = "VEHICULOS";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(3, 369);
            button3.Name = "button3";
            button3.Size = new Size(150, 52);
            button3.TabIndex = 10;
            button3.Text = "PELICULAS";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(3, 311);
            button2.Name = "button2";
            button2.Size = new Size(150, 52);
            button2.TabIndex = 9;
            button2.Text = "PLANETAS";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(251, 204, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 204, 60);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 204, 60);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(0, 253);
            button1.Name = "button1";
            button1.Size = new Size(150, 52);
            button1.TabIndex = 8;
            button1.Text = "ESPECIES";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            paneldata.Location = new Point(179, 22);
            paneldata.Name = "paneldata";
            paneldata.Size = new Size(1085, 702);
            paneldata.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1288, 747);
            Controls.Add(panel2);
            Controls.Add(paneldata);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel paneldata;
        private Button btninicio;
        private Button btnpersona;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
    }
}
