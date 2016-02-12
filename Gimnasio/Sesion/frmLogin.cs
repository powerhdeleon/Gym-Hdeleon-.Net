using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Sesion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();
            //VALIDACIONES
            if (usuario.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Usuario y password son obligatorios");
                return;
            }
            //PROCESO
            if (Utilidades.clsUsuario.login(usuario, password))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(Utilidades.clsUsuario.error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
