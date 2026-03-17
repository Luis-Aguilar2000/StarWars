namespace StarWars
{
    partial class planetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(planetas));
            panel1 = new Panel();
            btbuscar = new Button();
            textBuscar = new TextBox();
            lblbuscar = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btbuscar);
            panel1.Controls.Add(textBuscar);
            panel1.Controls.Add(lblbuscar);
            panel1.Location = new Point(-2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1395, 69);
            panel1.TabIndex = 3;
            // 
            // btbuscar
            // 
            btbuscar.Location = new Point(659, 22);
            btbuscar.Name = "btbuscar";
            btbuscar.Size = new Size(94, 29);
            btbuscar.TabIndex = 2;
            btbuscar.Text = "Buscar";
            btbuscar.UseVisualStyleBackColor = true;
            btbuscar.Click += btbuscar_Click;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(140, 22);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(496, 27);
            textBuscar.TabIndex = 1;
            // 
            // lblbuscar
            // 
            lblbuscar.AutoSize = true;
            lblbuscar.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblbuscar.ForeColor = Color.FromArgb(251, 204, 60);
            lblbuscar.Location = new Point(73, 22);
            lblbuscar.Name = "lblbuscar";
            lblbuscar.Size = new Size(66, 23);
            lblbuscar.TabIndex = 0;
            lblbuscar.Text = "Buscar";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1367, 319);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(1393, 881);
            panel2.TabIndex = 4;
            // 
            // planetas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1390, 948);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "planetas";
            Text = "planetas";
            Load += planetas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btbuscar;
        private TextBox textBuscar;
        private Label lblbuscar;
        private DataGridView dataGridView1;
        private Panel panel2;
    }
}