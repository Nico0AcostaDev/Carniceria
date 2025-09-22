namespace Carniceria.Forms.Altas
{
    partial class Clientes
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            Nombretxt = new TextBox();
            Infotxt = new TextBox();
            Telefonotxt = new TextBox();
            Direcciontxt = new TextBox();
            Emailtxt = new TextBox();
            Apellidotxt = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 102);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 3;
            label3.Text = "Info Relevante";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 132);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 4;
            label4.Text = "Direccion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 167);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 5;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 71);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 6;
            label6.Text = "Telefono";
            // 
            // Nombretxt
            // 
            Nombretxt.Location = new Point(107, 12);
            Nombretxt.Name = "Nombretxt";
            Nombretxt.Size = new Size(172, 23);
            Nombretxt.TabIndex = 7;
            // 
            // Infotxt
            // 
            Infotxt.Location = new Point(114, 99);
            Infotxt.Name = "Infotxt";
            Infotxt.Size = new Size(165, 23);
            Infotxt.TabIndex = 8;
            // 
            // Telefonotxt
            // 
            Telefonotxt.Location = new Point(107, 70);
            Telefonotxt.Name = "Telefonotxt";
            Telefonotxt.Size = new Size(172, 23);
            Telefonotxt.TabIndex = 9;
            // 
            // Direcciontxt
            // 
            Direcciontxt.Location = new Point(107, 132);
            Direcciontxt.Name = "Direcciontxt";
            Direcciontxt.Size = new Size(172, 23);
            Direcciontxt.TabIndex = 10;
            // 
            // Emailtxt
            // 
            Emailtxt.Location = new Point(107, 164);
            Emailtxt.Name = "Emailtxt";
            Emailtxt.Size = new Size(172, 23);
            Emailtxt.TabIndex = 11;
            // 
            // Apellidotxt
            // 
            Apellidotxt.Location = new Point(107, 41);
            Apellidotxt.Name = "Apellidotxt";
            Apellidotxt.Size = new Size(172, 23);
            Apellidotxt.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(189, 204);
            button1.Name = "button1";
            button1.Size = new Size(90, 36);
            button1.TabIndex = 13;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 252);
            Controls.Add(button1);
            Controls.Add(Apellidotxt);
            Controls.Add(Emailtxt);
            Controls.Add(Direcciontxt);
            Controls.Add(Telefonotxt);
            Controls.Add(Infotxt);
            Controls.Add(Nombretxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox Nombretxt;
        private TextBox Infotxt;
        private TextBox Telefonotxt;
        private TextBox Direcciontxt;
        private TextBox Emailtxt;
        private TextBox Apellidotxt;
        private Button button1;
    }
}