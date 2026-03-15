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
            btbuscar = new Button();
            textBuscar = new TextBox();
            lblbuscar = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btbuscar);
            panel1.Controls.Add(textBuscar);
            panel1.Controls.Add(lblbuscar);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1083, 69);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // btbuscar
            // 
            btbuscar.Location = new Point(659, 22);
            btbuscar.Name = "btbuscar";
            btbuscar.Size = new Size(94, 29);
            btbuscar.TabIndex = 2;
            btbuscar.Text = "Buscar";
            btbuscar.UseVisualStyleBackColor = true;
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
            lblbuscar.Location = new Point(73, 22);
            lblbuscar.Name = "lblbuscar";
            lblbuscar.Size = new Size(52, 20);
            lblbuscar.TabIndex = 0;
            lblbuscar.Text = "Buscar";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(1, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(1083, 630);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1061, 319);
            dataGridView1.TabIndex = 0;
            // 
            // personas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1085, 702);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "personas";
            Text = "personas";
            Load += personas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TextBox textBuscar;
        private Label lblbuscar;
        private Button btbuscar;
        private Panel panel2;
        private DataGridView dataGridView1;
    }
}