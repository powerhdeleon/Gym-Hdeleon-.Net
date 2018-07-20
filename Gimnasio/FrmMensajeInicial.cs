using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmMensajeInicial : Form
    {
        public FrmMensajeInicial()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://hdeleon.net/software-para-gimnasio-hdeleon-version-1-9-codigo-fuente-c-net/");
            Process.Start(sInfo);

            this.Close();
        }
    }
}
