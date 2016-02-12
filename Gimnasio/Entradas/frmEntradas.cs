using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Entradas
{
    public partial class frmEntradas : Gimnasio.Utilidades.frmPadre
    {
        clsEntrada oEntrada = new clsEntrada();
        public frmEntradas()
        {
            InitializeComponent();
        }

        private void frmEntradas_Load(object sender, EventArgs e)
        {
            addEventos();
            refrescaLista();
            interfaz();
        }


        #region FUNCIONES COMUNES
        private void interfaz()
        {
            try
            {
                lblTitle.Text = "Entradas";
                dgvLista.Columns[0].Visible = false;
                dgvLista.Columns[dgvLista.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex.Message);
            }

        }
        private void addEventos()
        {
            cmdNuevo.Click += new EventHandler(nuevo);
            cmdModificar.Click += new EventHandler(mostrar);
            cmdEliminar.Click += new EventHandler(elimina);
        }

        private void refrescaLista()
        {
            if (!oEntrada.getDatos(dgvLista))
            {
                MessageBox.Show(oEntrada.getError());
            }


        }
        #endregion

        #region EVENTOS DE BOTONES

        private void nuevo(object sender, EventArgs e)
        {
            frmEntrada frmUs = new frmEntrada();
            frmUs.ShowDialog();
            refrescaLista();
        }


        private void elimina(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {
                //comprobar si es posible eliminarlo
                if (!oEntrada.posibleEliminar(id))
                {
                    MessageBox.Show("Es imposible eliminar esta entrada ya que productos de ella ya han sido vendidos, solo se puede eliminar una entrada al momento de ser creada, SE CUIDADOSO AL CREARLAS");
                    return;
                }

                if (MessageBox.Show("Estas seguro de eliminar el registro seleccionado", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (oEntrada.remove(id))
                    {
                        refrescaLista();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error " + oEntrada.getError());
                    }
                }

            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }

        private void mostrar(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {
                frmViewEntrada frmUs = new frmViewEntrada();
                frmUs.id = id;
                frmUs.ShowDialog();
              
              

            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }



        #endregion
    }
}
