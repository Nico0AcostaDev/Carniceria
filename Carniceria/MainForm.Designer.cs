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
            menuStrip1.Items.AddRange(new ToolStripItem[] { ventasToolStripMenuItem, deudasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarVentaToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // generarVentaToolStripMenuItem
            // 
            generarVentaToolStripMenuItem.Name = "generarVentaToolStripMenuItem";
            generarVentaToolStripMenuItem.Size = new Size(147, 22);
            generarVentaToolStripMenuItem.Text = "Generar Venta";
            generarVentaToolStripMenuItem.Click += generarVentaToolStripMenuItem_Click;
            // 
            // deudasToolStripMenuItem
            // 
            deudasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { deudasParcialesToolStripMenuItem1 });
            deudasToolStripMenuItem.Name = "deudasToolStripMenuItem";
            deudasToolStripMenuItem.Size = new Size(58, 20);
            deudasToolStripMenuItem.Text = "Deudas";
            // 
            // deudasParcialesToolStripMenuItem1
            // 
            deudasParcialesToolStripMenuItem1.Name = "deudasParcialesToolStripMenuItem1";
            deudasParcialesToolStripMenuItem1.Size = new Size(180, 22);
            deudasParcialesToolStripMenuItem1.Text = "Deudas y Pagos";
            deudasParcialesToolStripMenuItem1.Click += deudasParcialesToolStripMenuItem1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
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
