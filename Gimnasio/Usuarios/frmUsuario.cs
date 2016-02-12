using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Usuarios
{
    public partial class frmUsuario : Form
    {
        public int idUsuario = 0;
        clsUsuario oUsuario = new clsUsuario();

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            
            if (idUsuario > 0)
            {
                cargaDatos();
            }
        }

        private void cargaDatos()
        {
            if (oUsuario.getDatos(idUsuario))
            {
                txtUsuario.Text = oUsuario.datos.Usuario;
                txtNombre.Text = oUsuario.datos.Nombre;
            }
            else
            {
                MessageBox.Show("Ocurrio un problema al cargar los datos "+oUsuario.getError());
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idUsuario <= 0)
            {
                agrega();
            }
            else
            {
                modifica();
            }
        }

        private void agrega()
        {
            
            oUsuario.Usuario = txtUsuario.Text.Trim();
            oUsuario.Nombre = txtNombre.Text.Trim();
            oUsuario.Password = txtPassword.Text.Trim();

            if (oUsuario.Usuario.Equals("") || oUsuario.Password.Equals(""))
            {
                MessageBox.Show("Usuario y password son obligatorios");
                return;
            }

            if (oUsuario.add())
            {
                MessageBox.Show("Registro agregado con exito");
                this.Close();
            }
            else
                MessageBox.Show(oUsuario.getError());
                   
        }

        private void modifica()
        {
            oUsuario.Usuario = txtUsuario.Text.Trim();
            oUsuario.Nombre = txtNombre.Text.Trim();
            oUsuario.Password = txtPassword.Text.Trim();

            if (oUsuario.Usuario.Equals("") || oUsuario.Password.Equals(""))
            {
                MessageBox.Show("Usuario y password son obligatorios");
                return;
            }
            
            if (oUsuario.edit(idUsuario))
            {
                MessageBox.Show("Registro modificado con exito");
                this.Close();
            }
            else
                MessageBox.Show(oUsuario.getError());
        }

    }
}
