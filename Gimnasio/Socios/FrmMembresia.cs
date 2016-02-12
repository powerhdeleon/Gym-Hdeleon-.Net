using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Socios
{
    public partial class FrmMembresia : Form
    {
        public int id = 0;
        clsSocio oSocio = new clsSocio();
        Membresias.clsMembresia oMembresia = new Membresias.clsMembresia();
        clsSocioMembresia oSocioMembresia = new clsSocioMembresia();
        public FrmMembresia()
        {
            InitializeComponent();
        }

        private void FrmMembresia_Load(object sender, EventArgs e)
        {
            if (oSocio.getDatos(id))
            {
                lblNombre.Text = oSocio.datos.Nombre + " " + oSocio.datos.Paterno + " " + oSocio.datos.Materno;
                lblTelefono.Text = oSocio.datos.Telefono;
                txtObservaciones.Text = oSocio.datos.Observaciones;

                if (oSocio.datos.foto != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(oSocio.datos.foto);
                    Bitmap image = new Bitmap(stream);
                    pbFoto.Image = image;
                }
            }
            else
            {
                MessageBox.Show(oSocio.getError());
            }
            //llenado de combo
            Membresias.clsMembresia.getCboMembresias(cboMembresia);
            if (cboMembresia.Items.Count <= 0)
            {
                MessageBox.Show("No existen tipos de membresias agregadas al sistema, por favor ve al modulo de membresias y agregar una para poder ser asignada a los socios");
                this.Close();
            }
            

            refrescaLista();
            interfaz();
        }

        private void interfaz()
        {
            try
            {
                dgvLista.Columns[0].Visible = false;
                dgvLista.Columns[dgvLista.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                Utilidades.OperacionesFormulario.quitaOrdenamientoGridView(dgvLista);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex.Message);
            }

        }


        private void cboMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMembresia.Items.Count > 0)
                {
                    id = int.Parse(cboMembresia.SelectedValue.ToString());

                    if (oMembresia.getDatos(id))
                    {
                        lblPrecio.Text = oMembresia.datos.Precio.ToString();
                        lblMeses.Text = oMembresia.datos.meses.ToString();
                        lblHoraInicial.Text = oMembresia.datos.horaInicio.ToString();
                        lblHoraFinal.Text = oMembresia.datos.horaFinal.ToString();
                    }
                }
                //con esto evito la falla al abrir el formulario
            }catch{}

        }

        private void refrescaLista()
        {
            if (!oSocioMembresia.getDatos(dgvLista, oSocio.datos.idSocio))
            {
                MessageBox.Show(oSocioMembresia.getError());
            }
            else
            {
                if (dgvLista.Rows.Count > 0)
                {
                 //   dtpFechaInicio.Enabled = false;
                    dtpFechaInicio.MinDate = DateTime.Parse(Utilidades.OperacionesFormulario.getValorCelda(dgvLista, 2, 0));
                    dtpFechaInicio.Value = DateTime.Parse(Utilidades.OperacionesFormulario.getValorCelda(dgvLista, 2, 0));
                }
                else
                {
                   // dtpFechaInicio.Enabled = true;
                    dtpFechaInicio.MinDate = DateTime.Parse("01/01/1753");
                    dtpFechaInicio.Value = DateTime.Now;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oSocioMembresia.idMembresia = oMembresia.datos.idMembresia;
            oSocioMembresia.idSocio = oSocio.datos.idSocio;
            oSocioMembresia.Precio = oMembresia.datos.Precio;
            oSocioMembresia.fechaInicioMembresia = dtpFechaInicio.Value;
            oSocioMembresia.idUsuarioLog = Utilidades.clsUsuario.idUsuario;

            if (oSocioMembresia.add())
            {
                refrescaLista();
            }
            else
            {
                MessageBox.Show(oSocioMembresia.getError());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                int id = int.Parse(Utilidades.OperacionesFormulario.getValorCelda(dgvLista, 0, 0));
                if (id > 0)
                {
                    if (MessageBox.Show("Estas seguro de eliminar el ultimo registro agregado de membresia", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (oSocioMembresia.changeState(3, id))
                        {
                            refrescaLista();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error " + oSocioMembresia.getError());
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Debe existir una fila seleccionada");
                }
            }
            else
            {
                MessageBox.Show("No existen membresias para ser eliminadas");
            }
        }
    }
}
