namespace Carniceria.Forms
{
    partial class AltProductos
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
            AceptarBtn = new Button();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            descripcionTxt = new TextBox();
            PrecioTxt = new TextBox();
            tipoComboBox = new ComboBox();
            cantidadTxt = new TextBox();
            nombreProdTxt = new TextBox();
            SuspendLayout();
            // 
            // AceptarBtn
            // 
            AceptarBtn.Location = new Point(218, 207);
            AceptarBtn.Name = "AceptarBtn";
            AceptarBtn.Size = new Size(75, 23);
            AceptarBtn.TabIndex = 0;
            AceptarBtn.Text = "Aceptar";
            AceptarBtn.UseVisualStyleBackColor = true;
            AceptarBtn.Click += AceptarBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 79);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 4;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 113);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 5;
            label5.Text = "Tipo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 141);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 6;
            label6.Text = "Cantidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 48);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 7;
            label7.Text = "Descripcion";
            // 
            // descripcionTxt
            // 
            descripcionTxt.Location = new Point(120, 47);
            descripcionTxt.Name = "descripcionTxt";
            descripcionTxt.Size = new Size(100, 23);
            descripcionTxt.TabIndex = 8;
            // 
            // PrecioTxt
            // 
            PrecioTxt.Location = new Point(120, 76);
            PrecioTxt.Name = "PrecioTxt";
            PrecioTxt.Size = new Size(100, 23);
            PrecioTxt.TabIndex = 9;
            // 
            // tipoComboBox
            // 
            tipoComboBox.FormattingEnabled = true;
            tipoComboBox.Location = new Point(120, 110);
            tipoComboBox.Name = "tipoComboBox";
            tipoComboBox.Size = new Size(121, 23);
            tipoComboBox.TabIndex = 10;
            // 
            // cantidadTxt
            // 
            cantidadTxt.Location = new Point(120, 139);
            cantidadTxt.Name = "cantidadTxt";
            cantidadTxt.Size = new Size(100, 23);
            cantidadTxt.TabIndex = 11;
            // 
            // nombreProdTxt
            // 
            nombreProdTxt.Location = new Point(120, 19);
            nombreProdTxt.Name = "nombreProdTxt";
            nombreProdTxt.Size = new Size(100, 23);
            nombreProdTxt.TabIndex = 12;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 250);
            Controls.Add(nombreProdTxt);
            Controls.Add(cantidadTxt);
            Controls.Add(tipoComboBox);
            Controls.Add(PrecioTxt);
            Controls.Add(descripcionTxt);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(AceptarBtn);
            Name = "Productos";
            Text = "Altas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AceptarBtn;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox descripcionTxt;
        private TextBox PrecioTxt;
        private ComboBox tipoComboBox;
        private TextBox cantidadTxt;
        private TextBox nombreProdTxt;
    }
}