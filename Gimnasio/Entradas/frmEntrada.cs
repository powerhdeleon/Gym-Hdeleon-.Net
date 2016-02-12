using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Entradas
{
    public partial class frmEntrada : Form
    {

        Productos.clsProducto oProducto = new Productos.clsProducto();
        clsEntrada oEntrada = new clsEntrada();
        decimal TOTAL = 0;
        
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            Productos.clsProducto.getProductosEnCbo(cboProducto);
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = 0;
            try
            {
                idProducto = int.Parse(cboProducto.SelectedValue.ToString());
                oProducto.getDatos(idProducto);

                lblCosto.Text = oProducto.datos.Costo.ToString();
                lblPrecio.Text = oProducto.datos.Precio.ToString();

            }catch{
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {

            //al dar enter se agrega el producto
            if (e.KeyCode == Keys.Enter)
            {
                if (!ExpresionesRegulares.RegEX.isNumber(txtCantidad.Text))
                {
                    MessageBox.Show("Solo debes capturar numeros en cantidad");
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                    return;
                }

                if (oProducto.datos==null)
                {
                    MessageBox.Show("Debes seleccionar un producto");
                    cboProducto.Text = "";
                    cboProducto.Focus();
                    return;
                }

                int cantidad=int.Parse(txtCantidad.Text.ToString());
                decimal total = cantidad * oProducto.datos.Costo;
               

                //boton
               
                
                //aqui se agrega al datagridview
                dgvLista.Rows.Add(new object[] { oProducto.datos.idProducto.ToString(),cantidad.ToString(),
                                                oProducto.datos.Nombre,oProducto.datos.Costo.ToString(),total.ToString(),"Eliminar"});

                calcularTotal();
              
                txtCantidad.Text = "1";
                cboProducto.Text = "";
                lblCosto.Text = "";
                lblPrecio.Text = "";
                cboProducto.Focus();
                oProducto = new Productos.clsProducto();
                    

            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // aqui solo sigues si se presiono la columna del boton
            if (e.RowIndex < 0 || e.ColumnIndex != dgvLista.Columns["Operaciones"].Index)
                return;

            // se obtiene el valor del productio
            int idProducto = int.Parse(dgvLista.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (MessageBox.Show("Estas seguro de eliminar el producto de esta entrada", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgvLista.Rows.RemoveAt(e.RowIndex);
                calcularTotal();
            }

        }

        private void calcularTotal()
        {
            TOTAL = 0;
            foreach (DataGridViewRow dr in dgvLista.Rows)
            {
                decimal totalD=decimal.Parse(dr.Cells[4].Value.ToString());
                TOTAL += totalD;
            }
            lblTotal.Text = "$ " + TOTAL.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validaciones
                //verificar si hay detalle
                if (dgvLista.Rows.Count <= 0)
                {
                    MessageBox.Show("Deben existir productos en la lista de la entrada");
                    return;
                }

                //asignacion de datos
                oEntrada.Total = TOTAL;
                oEntrada.idUsuarioLog = Utilidades.clsUsuario.idUsuario;
                //llenar detalle
                foreach (DataGridViewRow dr in dgvLista.Rows)
                {
                    int cant = int.Parse(dr.Cells[1].Value.ToString());
                    for (int i = 0; i < cant; i++)
                    {
                        clsDetalleEntrada de = new clsDetalleEntrada();
                        de.CostoUnitario = decimal.Parse(dr.Cells[3].Value.ToString());
                        de.idProducto = int.Parse(dr.Cells[0].Value.ToString());
                        oEntrada.lDetalleEmtrada.Add(de);
                    }
                }
                //se guarda
                if (oEntrada.add())
                {
                    MessageBox.Show("Registro agregado con exito");
                    this.Close();
                }
                else
                    MessageBox.Show(oProducto.getError());

            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocurrio un error de sistema " + EX.Message);
            }
        }
    }
}
