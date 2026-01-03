namespace Carniceria
{
    partial class VentaForm
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            dgvProductos = new DataGridView();
            label2 = new Label();
            dgvVenta = new DataGridView();
            label3 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            button4 = new Button();
            button2 = new Button();
            label6 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnAceptar = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblInfo = new Label();
            label7 = new Label();
            txtboxBuscarProducto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(106, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(292, 29);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 1;
            label1.Text = "Clientes";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 193);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(437, 335);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 3;
            label2.Text = "Productos";
            // 
            // dgvVenta
            // 
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Location = new Point(506, 44);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(446, 235);
            dgvVenta.TabIndex = 4;
            dgvVenta.CellContentClick += dgvVenta_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(506, 15);
            label3.Name = "label3";
            label3.Size = new Size(49, 21);
            label3.TabIndex = 5;
            label3.Text = "Venta";
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(506, 297);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 152);
            panel1.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(5, 9);
            label5.Name = "label5";
            label5.Size = new Size(133, 21);
            label5.TabIndex = 27;
            label5.Text = "Agregar Producto";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10F);
            button4.Location = new Point(17, 110);
            button4.Name = "button4";
            button4.Size = new Size(89, 26);
            button4.TabIndex = 26;
            button4.Text = "Limpiar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F);
            button2.Location = new Point(318, 110);
            button2.Name = "button2";
            button2.Size = new Size(107, 26);
            button2.TabIndex = 24;
            button2.Text = "Añadir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(231, 70);
            label6.Name = "label6";
            label6.Size = new Size(100, 19);
            label6.TabIndex = 22;
            label6.Text = "Precio unitario:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(337, 69);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(88, 23);
            textBox4.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(5, 37);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 19;
            label4.Text = "Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(231, 37);
            label8.Name = "label8";
            label8.Size = new Size(67, 19);
            label8.TabIndex = 16;
            label8.Text = "Cantidad:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(337, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(88, 23);
            textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(87, 34);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(113, 23);
            textBox2.TabIndex = 17;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 12F);
            btnAceptar.Location = new Point(817, 490);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(135, 38);
            btnAceptar.TabIndex = 24;
            btnAceptar.Text = "Finalizar Venta";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 56);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(38, 15);
            lblNombre.TabIndex = 26;
            lblNombre.Text = "label7";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(12, 83);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(38, 15);
            lblApellido.TabIndex = 27;
            lblApellido.Text = "label9";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(12, 109);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(44, 15);
            lblInfo.TabIndex = 28;
            lblInfo.Text = "label10";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 166);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 29;
            label7.Text = "busca un producto";
            // 
            // txtboxBuscarProducto
            // 
            txtboxBuscarProducto.Location = new Point(134, 163);
            txtboxBuscarProducto.Name = "txtboxBuscarProducto";
            txtboxBuscarProducto.Size = new Size(175, 23);
            txtboxBuscarProducto.TabIndex = 30;
            txtboxBuscarProducto.TextChanged += txtboxBuscarProducto_TextChanged;
            // 
            // VentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(964, 540);
            Controls.Add(txtboxBuscarProducto);
            Controls.Add(label7);
            Controls.Add(lblInfo);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(panel1);
            Controls.Add(btnAceptar);
            Controls.Add(label3);
            Controls.Add(dgvVenta);
            Controls.Add(label2);
            Controls.Add(dgvProductos);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "VentaForm";
            Text = "VentaForm";
            Load += VentaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private DataGridView dgvProductos;
        private Label label2;
        private DataGridView dgvVenta;
        private Label label3;
        private Panel panel1;
        private Button button4;
        private Button button2;
        private Label label6;
        private TextBox textBox4;
        private Label label4;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnAceptar;
        private Label label5;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblInfo;
        private Label label7;
        private TextBox txtboxBuscarProducto;
    }
}