namespace Gimnasio.Usuarios
{
    partial class frmUsuarios
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
            ((System.ComponentModel.ISupportInitialize)(this.spContenedor)).BeginInit();
            this.spContenedor.Panel1.SuspendLayout();
            this.spContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // spContenedor
            // 
            this.spContenedor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            // 
            // spContenedor.Panel1
            // 
            this.spContenedor.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spContenedor.Panel1MinSize = 100;
            // 
            // spContenedor.Panel2
            // 
            this.spContenedor.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spContenedor.Panel2MinSize = 100;
            this.spContenedor.Size = new System.Drawing.Size(823, 503);
            this.spContenedor.SplitterDistance = 105;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(823, 503);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.spContenedor.Panel1.ResumeLayout(false);
            this.spContenedor.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContenedor)).EndInit();
            this.spContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
