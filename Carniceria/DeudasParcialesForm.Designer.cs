namespace Carniceria
{
    partial class DeudasParcialesForm
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
            dgvDeuda = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dgvDetalle = new DataGridView();
            button1 = new Button();
            dgvPagos = new DataGridView();
            label3 = new Label();
            button3 = new Button();
            label8 = new Label();
            panel1 = new Panel();
            label7 = new Label();
            label9 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxPago = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDeuda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDeuda
            // 
            dgvDeuda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeuda.Location = new Point(12, 41);
            dgvDeuda.Name = "dgvDeuda";
            dgvDeuda.Size = new Size(490, 348);
            dgvDeuda.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 1;
            label1.Text = "Deudas Activas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(613, 9);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Detalle Deuda";
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(600, 41);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(427, 348);
            dgvDetalle.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(508, 41);
            button1.Name = "button1";
            button1.Size = new Size(86, 55);
            button1.TabIndex = 4;
            button1.Text = "Visualizar detalle y pagos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(12, 424);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.Size = new Size(490, 348);
            dgvPagos.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 406);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 7;
            label3.Text = "Detalle Pagos";
            // 
            // button3
            // 
            button3.Location = new Point(313, 73);
            button3.Name = "button3";
            button3.Size = new Size(87, 28);
            button3.TabIndex = 24;
            button3.Text = "Abonar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 45);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 16;
            label8.Text = "Monto Total :";
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBoxPago);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(600, 424);
            panel1.Name = "panel1";
            panel1.Size = new Size(427, 110);
            panel1.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(295, 45);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(239, 45);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 29;
            label9.Text = "Cliente :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 45);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 9);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 27;
            label5.Text = "Ingresar Pago";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 80);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 22;
            label6.Text = "Pago :";
            // 
            // textBoxPago
            // 
            textBoxPago.Location = new Point(60, 77);
            textBoxPago.Name = "textBoxPago";
            textBoxPago.Size = new Size(88, 23);
            textBoxPago.TabIndex = 21;
            // 
            // DeudasParcialesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 782);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(dgvPagos);
            Controls.Add(button1);
            Controls.Add(dgvDetalle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDeuda);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "DeudasParcialesForm";
            Text = "DeudasParcialesForm";
            Load += DeudasParcialesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDeuda).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDeuda;
        private Label label1;
        private Label label2;
        private DataGridView dgvDetalle;
        private Button button1;
        private DataGridView dgvPagos;
        private Label label3;
        private Button button3;
        private Label label8;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBoxPago;
        private Label label7;
        private Label label9;
    }
}