using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Reportes
{
    public partial class frmReportes : Form
    {
        Productos.clsProducto oProducto = new Productos.clsProducto();
        Membresias.clsMembresia oMembresia = new Membresias.clsMembresia();
        Socios.clsSocio oSocio = new Socios.clsSocio();

        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            refrescaListaInventario();
            refrescaListaMembresias();
            refrescaListaSocios();
            refrescaListaRegistro();
            refrescaListaVisitas();
            refrescaListaVentaProductos();

            interfaz();
        }

        #region metodos refrescadores
        private void refrescaListaInventario()
        {
            if (!oProducto.getDatosRptInventario(dgvListaInventario))
            {
                MessageBox.Show(oProducto.getError());
            }


        }
        private void refrescaListaMembresias()
        {
            DateTime fecha1 = dtpFecha1Membresia.Value;
            DateTime fecha2 = dtpFecha2Membresia.Value;

            if (!oMembresia.getDatosRptMembresias(dgvListaMembresias,fecha1,fecha2))
            {
                MessageBox.Show(oMembresia.getError());
            }

            //sacar el total
            lblTotalMembresia.Text = "$ " + getTotalMembresia().ToString();
        }

        private void refrescaListaSocios()
        {
            if (!oSocio.getDatosRptSocios(dgvListaSocios))
            {
                MessageBox.Show(oSocio.getError());
            }


        }

        private void refrescaListaRegistro()
        {
            DateTime fecha = dtpFecha1Registro.Value;


            if (!oSocio.getDatosRptRegistro(dgvListaRegistro, fecha))
            {
                MessageBox.Show(oSocio.getError());
            }

        }

        private void refrescaListaVisitas()
        {
            DateTime fecha = dtpFecha1Visitas.Value;


            if (!oSocio.getDatosRptVisitas(dgvListaVisitas, fecha))
            {
                MessageBox.Show(oSocio.getError());
            }

            //sacar el total
            lblTotalVisitas.Text = "$ " + getTotalVisitas().ToString();
        }

        private void refrescaListaVentaProductos()
        {
            DateTime fecha1 = dtpFecha1VtaProductos.Value;
            DateTime fecha2 = dtpFecha2VtaProductos.Value;

            if (!oProducto.getDatosRptVentaProductos(dgvListaVentaProductos, fecha1, fecha2))
            {
                MessageBox.Show(oProducto.getError());
            }

            //sacar el total
            lblTotalVentaProductos.Text = "$ " + getTotalVentaProductos().ToString();
        }
        #endregion

        #region interfaces

        private void interfaz()
        {
            this.SuspendLayout();
          
            try
            {
                dgvListaInventario.Columns[0].Visible = false;
                dgvListaInventario.Columns[dgvListaInventario.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex.Message);
            }

            try
            {
                dgvListaMembresias.Columns[0].Visible = false;
                dgvListaMembresias.Columns[dgvListaInventario.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtpFecha1Membresia.Value = DateTime.Now.Date;
                dtpFecha2Membresia.Value = DateTime.Now.Date;

                dtpFecha1VtaProductos.Value = DateTime.Now.Date;
                dtpFecha2VtaProductos.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex.Message);
            }

            try
            {
                dgvListaVentaProductos.Columns[0].Visible = false;
                dgvListaVentaProductos.Columns[dgvListaInventario.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtpFecha1VtaProductos.Value = DateTime.Now.Date;
                dtpFecha2VtaProductos.Value = DateTime.Now.Date;

                dtpFecha1Registro.Value = DateTime.Now.Date;
                dtpFecha1Visitas.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex.Message);
            }

            this.ResumeLayout();
        }

 
        #endregion

        #region metodos del formulario
        private decimal getTotalMembresia()
        {
            decimal total = 0;

            foreach (DataGridViewRow dr in dgvListaMembresias.Rows)
            {
                total+=decimal.Parse(dr.Cells[dr.Cells.Count-1].Value.ToString());
            }
            return total;
        }

        private decimal getTotalVisitas()
        {
            decimal total = 0;

            foreach (DataGridViewRow dr in dgvListaVisitas.Rows)
            {
                total += decimal.Parse(dr.Cells[dr.Cells.Count - 1].Value.ToString());
            }
            return total;
        }

        private decimal getTotalVentaProductos()
        {
            decimal total = 0;

            foreach (DataGridViewRow dr in dgvListaVentaProductos.Rows)
            {
                total += decimal.Parse(dr.Cells[dr.Cells.Count - 1].Value.ToString());
            }
            return total;
        }

        #endregion

        private void frmReportes_Enter(object sender, EventArgs e)
        {
            refrescaListaInventario();
            refrescaListaMembresias();
            refrescaListaSocios();
            refrescaListaRegistro();
            refrescaListaVisitas();
            refrescaListaVentaProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refrescaListaMembresias();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refrescaListaRegistro();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refrescaListaVisitas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refrescaListaVentaProductos();
        }

  
    }
}
