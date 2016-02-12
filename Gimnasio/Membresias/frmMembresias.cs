using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Membresias
{
    public partial class frmMembresias : Gimnasio.Utilidades.frmPadre
    {
        clsMembresia oMembresia = new clsMembresia();

        public frmMembresias()
        {
            InitializeComponent();
        }

        private void frmMembresias_Load(object sender, EventArgs e)
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
                lblTitle.Text = "Membresias";
                dgvLista.Columns[0].Visible = false;
                dgvLista.Columns[dgvLista.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
            }catch(Exception ex){
                MessageBox.Show("Error de sistema "+ex.Message);
            }
            
        }
        private void addEventos()
        {
            cmdNuevo.Click += new EventHandler(nuevo);
            cmdModificar.Click += new EventHandler(modificar);
            cmdDesabilitar.Click += new EventHandler(desabilita);
            cmdAbilitar.Click += new EventHandler(abilita);
            cmdEliminar.Click += new EventHandler(elimina);
        }

        private void refrescaLista()
        {
            if (!oMembresia.getDatos(dgvLista))
            {
                MessageBox.Show(oMembresia.getError());
            }


        }
        #endregion

        #region EVENTOS DE BOTONES

        private void nuevo(object sender, EventArgs e)
        {
            frmMembresia frmUs = new frmMembresia();
            frmUs.ShowDialog();
            refrescaLista();
        }

        private void modificar(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {

                frmMembresia frm = new frmMembresia();
                frm.idMembresia = id;
                frm.ShowDialog();
                refrescaLista();
            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }

        private void desabilita(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {
                if (id == 1)
                {
                    MessageBox.Show("No puedes realizar esta acción en la membresia visita");
                    return;
                }
                if (oMembresia.changeState(2, id))
                {
                    refrescaLista();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error " + oMembresia.getError());
                }

            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }

        private void abilita(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {
                if (id == 1)
                {
                    MessageBox.Show("No puedes realizar esta acción en la membresia visita");
                    return;
                }
                if (oMembresia.changeState(1, id))
                {
                    refrescaLista();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error " + oMembresia.getError());
                }

            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }

        private void elimina(object sender, EventArgs e)
        {
            int id = Utilidades.OperacionesFormulario.getId(dgvLista);
            if (id > 0)
            {
                if (id == 1)
                {
                    MessageBox.Show("No puedes eliminar la membresia visita");
                    return;
                }
                if (MessageBox.Show("Estas seguro de eliminar el registro seleccionado", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (oMembresia.changeState(3, id))
                    {
                        refrescaLista();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error " + oMembresia.getError());
                    }
                }

            }
            else
            {
                MessageBox.Show("Debe existir una fila seleccionada");
            }
        }



        #endregion
    }
}
