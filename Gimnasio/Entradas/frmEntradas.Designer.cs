namespace Gimnasio.Entradas
{
    partial class frmEntradas
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
            // 
            // cmdAbilitar
            // 
            this.cmdAbilitar.Visible = false;
            // 
            // cmdDesabilitar
            // 
            this.cmdDesabilitar.Visible = false;
            // 
            // cmdModificar
            // 
            this.cmdModificar.Size = new System.Drawing.Size(96, 31);
            this.cmdModificar.Text = "Mostrar";
            // 
            // frmEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmEntradas";
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.frmEntradas_Load);
            this.spContenedor.Panel1.ResumeLayout(false);
            this.spContenedor.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContenedor)).EndInit();
            this.spContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
