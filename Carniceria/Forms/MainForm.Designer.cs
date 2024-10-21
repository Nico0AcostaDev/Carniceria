namespace Carniceria
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            generarVentaToolStripMenuItem = new ToolStripMenuItem();
            deudasToolStripMenuItem = new ToolStripMenuItem();
            deudasParcialesToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.SteelBlue;
            menuStrip1.Items.AddRange(new ToolStripItem[] { ventasToolStripMenuItem, deudasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(704, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarVentaToolStripMenuItem });
            ventasToolStripMenuItem.Font = new Font("Segoe UI", 15F);
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(81, 32);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // generarVentaToolStripMenuItem
            // 
            generarVentaToolStripMenuItem.Name = "generarVentaToolStripMenuItem";
            generarVentaToolStripMenuItem.Size = new Size(207, 32);
            generarVentaToolStripMenuItem.Text = "Generar Venta";
            generarVentaToolStripMenuItem.Click += generarVentaToolStripMenuItem_Click;
            // 
            // deudasToolStripMenuItem
            // 
            deudasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { deudasParcialesToolStripMenuItem1 });
            deudasToolStripMenuItem.Font = new Font("Segoe UI", 15F);
            deudasToolStripMenuItem.Name = "deudasToolStripMenuItem";
            deudasToolStripMenuItem.Size = new Size(89, 32);
            deudasToolStripMenuItem.Text = "Deudas";
            // 
            // deudasParcialesToolStripMenuItem1
            // 
            deudasParcialesToolStripMenuItem1.Name = "deudasParcialesToolStripMenuItem1";
            deudasParcialesToolStripMenuItem1.Size = new Size(221, 32);
            deudasParcialesToolStripMenuItem1.Text = "Deudas y Pagos";
            deudasParcialesToolStripMenuItem1.Click += deudasParcialesToolStripMenuItem1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(704, 369);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Menu";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem generarVentaToolStripMenuItem;
        private ToolStripMenuItem deudasToolStripMenuItem;
        private ToolStripMenuItem deudasParcialesToolStripMenuItem1;
    }
}
