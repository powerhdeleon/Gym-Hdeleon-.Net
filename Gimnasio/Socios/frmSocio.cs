using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Gimnasio.Socios
{
    public partial class frmSocio : Form
    {
        public int id = 0;
        clsSocio oSocio = new clsSocio();

        public frmSocio()
        {
            InitializeComponent();
        }

        private void frmSocio_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                cargaDatos();
            }

        }

        private void cargaDatos()
        {
            if (oSocio.getDatos(id))
            {

                txtNombre.Text = oSocio.datos.Nombre;
                txtPaterno.Text = oSocio.datos.Paterno;
                txtMaterno.Text = oSocio.datos.Materno;
                txtTelefono.Text = oSocio.datos.Telefono;
                txtObservaciones.Text = oSocio.datos.Observaciones;

                if(oSocio.datos.foto!=null)
                {
                    MemoryStream stream = new MemoryStream(oSocio.datos.foto);
                    Bitmap image = new Bitmap(stream);
                    pbFoto.Image = image;
                }

            }
            else
            {
                MessageBox.Show("Ocurrio un problema al cargar los datos " + oSocio.getError());
                this.Close();
            }
        }

        /// <summary>
        /// aqui abrimos la captura de imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbFoto_Click(object sender, EventArgs e)
        {
            frmFoto frmF = new frmFoto();
            frmF.pbFotoSocio = pbFoto;
            frmF.Show();
            frmF.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id <= 0)
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
            try
            {
                //validaciones
                if (txtNombre.Text.Trim().Equals("") || txtPaterno.Text.Trim().Equals("") || txtMaterno.Text.Equals(""))
                {
                    MessageBox.Show("Nombre, Apellido Paterno y Apellido Materno son obligatorios");
                    return;
                }
              

                //asignacion de datos
                oSocio.Nombre = txtNombre.Text.Trim();
                oSocio.Paterno = txtPaterno.Text.Trim();
                oSocio.Materno = txtMaterno.Text.Trim();
                oSocio.Telefono = txtTelefono.Text.Trim();
                oSocio.Observaciones = txtObservaciones.Text.Trim();
                if(pbFoto.Image!=null)
                oSocio.foto = Utilidades.OperacionesFormulario.conviertePicBoxImageToByte(pbFoto);
                oSocio.idUsuarioLog = Utilidades.clsUsuario.idUsuario;
                if (oSocio.add())
                {
                    MessageBox.Show("Registro agregado con exito");
                    this.Close();
                }
                else
                    MessageBox.Show(oSocio.getError());

            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocurrio un error de sistema " + EX.Message);
            }
        }

        private void modifica()
        {

            try
            {
                //validaciones
                if (txtNombre.Text.Trim().Equals("") || txtPaterno.Text.Trim().Equals("") || txtMaterno.Text.Equals(""))
                {
                    MessageBox.Show("Nombre, Apellido Paterno y Apellido Materno son obligatorios");
                    return;
                }

                //asignacion de datos
                oSocio.Nombre = txtNombre.Text.Trim();
                oSocio.Paterno = txtPaterno.Text.Trim();
                oSocio.Materno = txtMaterno.Text.Trim();
                oSocio.Telefono = txtTelefono.Text.Trim();
                oSocio.Observaciones = txtObservaciones.Text.Trim();
                if (pbFoto.Image != null)
                    oSocio.foto = Utilidades.OperacionesFormulario.conviertePicBoxImageToByte(pbFoto);

                oSocio.idUsuarioLog = Utilidades.clsUsuario.idUsuario;
                if (oSocio.edit(id))
                {
                    MessageBox.Show("Registro modificado con exito");
                    this.Close();
                }
                else
                    MessageBox.Show(oSocio.getError());

            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocurrio un error de sistema " + EX.Message);
            }
        }

    }
}
