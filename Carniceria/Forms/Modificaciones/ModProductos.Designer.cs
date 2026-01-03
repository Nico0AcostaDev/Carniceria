namespace Carniceria
{
    partial class ModProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModProductos));
            dgvProductos = new DataGridView();
            Modificaciones = new Label();
            label1 = new Label();
            AceptarBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            descripcionTxt = new TextBox();
            cantidadTxt = new TextBox();
            estadoTxt = new TextBox();
            lblUltActualizacion = new Label();
            precioTxt = new TextBox();
            btnEstadoHide = new Button();
            btnCantidadHide = new Button();
            btnPrecioHide = new Button();
            btnDescripcionHide = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 38);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(517, 359);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // Modificaciones
            // 
            Modificaciones.AutoSize = true;
            Modificaciones.Font = new Font("Segoe UI", 12F);
            Modificaciones.Location = new Point(12, 9);
            Modificaciones.Name = "Modificaciones";
            Modificaciones.Size = new Size(114, 21);
            Modificaciones.TabIndex = 1;
            Modificaciones.Text = "Modificaciones";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(557, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 2;
            label1.Text = "Descripcion";
            // 
            // AceptarBtn
            // 
            AceptarBtn.Font = new Font("Segoe UI", 12F);
            AceptarBtn.Location = new Point(899, 364);
            AceptarBtn.Name = "AceptarBtn";
            AceptarBtn.Size = new Size(97, 37);
            AceptarBtn.TabIndex = 3;
            AceptarBtn.Text = "Aceptar";
            AceptarBtn.UseVisualStyleBackColor = true;
            AceptarBtn.Click += AceptarBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(557, 78);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 4;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(557, 116);
            label3.Name = "label3";
            label3.Size = new Size(125, 21);
            label3.TabIndex = 5;
            label3.Text = "Ult Actualizacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(557, 153);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 6;
            label4.Text = "Estado";
            // 
            // descripcionTxt
            // 
            descripcionTxt.Location = new Point(707, 43);
            descripcionTxt.Name = "descripcionTxt";
            descripcionTxt.Size = new Size(180, 23);
            descripcionTxt.TabIndex = 7;
            // 
            // cantidadTxt
            // 
            cantidadTxt.Location = new Point(707, 80);
            cantidadTxt.Name = "cantidadTxt";
            cantidadTxt.Size = new Size(180, 23);
            cantidadTxt.TabIndex = 8;
            // 
            // estadoTxt
            // 
            estadoTxt.Location = new Point(707, 151);
            estadoTxt.Name = "estadoTxt";
            estadoTxt.Size = new Size(180, 23);
            estadoTxt.TabIndex = 10;
            // 
            // lblUltActualizacion
            // 
            lblUltActualizacion.AutoSize = true;
            lblUltActualizacion.Font = new Font("Segoe UI", 12F);
            lblUltActualizacion.Location = new Point(707, 116);
            lblUltActualizacion.Name = "lblUltActualizacion";
            lblUltActualizacion.Size = new Size(0, 21);
            lblUltActualizacion.TabIndex = 11;
            // 
            // precioTxt
            // 
            precioTxt.Location = new Point(707, 189);
            precioTxt.Name = "precioTxt";
            precioTxt.Size = new Size(180, 23);
            precioTxt.TabIndex = 13;
            // 
            // btnEstadoHide
            // 
            btnEstadoHide.Location = new Point(899, 150);
            btnEstadoHide.Name = "btnEstadoHide";
            btnEstadoHide.Size = new Size(61, 23);
            btnEstadoHide.TabIndex = 16;
            btnEstadoHide.Text = "Habilitar";
            btnEstadoHide.UseVisualStyleBackColor = true;
            btnEstadoHide.Click += btnEstadoHide_Click;
            // 
            // btnCantidadHide
            // 
            btnCantidadHide.Location = new Point(899, 80);
            btnCantidadHide.Name = "btnCantidadHide";
            btnCantidadHide.Size = new Size(61, 23);
            btnCantidadHide.TabIndex = 17;
            btnCantidadHide.Text = "Habilitar";
            btnCantidadHide.UseVisualStyleBackColor = true;
            btnCantidadHide.Click += btnCantidadHide_Click;
            // 
            // btnPrecioHide
            // 
            btnPrecioHide.Location = new Point(899, 189);
            btnPrecioHide.Name = "btnPrecioHide";
            btnPrecioHide.Size = new Size(61, 23);
            btnPrecioHide.TabIndex = 18;
            btnPrecioHide.Text = "Habilitar";
            btnPrecioHide.UseVisualStyleBackColor = true;
            btnPrecioHide.Click += btnPrecioHide_Click;
            // 
            // btnDescripcionHide
            // 
            btnDescripcionHide.Location = new Point(899, 43);
            btnDescripcionHide.Name = "btnDescripcionHide";
            btnDescripcionHide.Size = new Size(61, 23);
            btnDescripcionHide.TabIndex = 19;
            btnDescripcionHide.Text = "Habilitar";
            btnDescripcionHide.UseVisualStyleBackColor = true;
            btnDescripcionHide.Click += btnDescripcionHide_Click;
            // 
            // ModProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1008, 413);
            Controls.Add(btnDescripcionHide);
            Controls.Add(btnPrecioHide);
            Controls.Add(btnCantidadHide);
            Controls.Add(btnEstadoHide);
            Controls.Add(precioTxt);
            Controls.Add(lblUltActualizacion);
            Controls.Add(estadoTxt);
            Controls.Add(cantidadTxt);
            Controls.Add(descripcionTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(AceptarBtn);
            Controls.Add(label1);
            Controls.Add(Modificaciones);
            Controls.Add(dgvProductos);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ModProductos";
            Text = "Modificaciones";
            Load += ModificacionesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Label Modificaciones;
        private Label label1;
        private Button AceptarBtn;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox descripcionTxt;
        private TextBox cantidadTxt;
        private TextBox estadoTxt;
        private Label lblUltActualizacion;
        private TextBox precioTxt;
        private Button btnEstadoHide;
        private Button btnCantidadHide;
        private Button btnPrecioHide;
        private Button btnDescripcionHide;
    }
}
