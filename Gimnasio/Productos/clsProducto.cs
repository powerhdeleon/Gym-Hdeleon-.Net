using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Productos
{
    class clsProducto : Utilidades.clsModulo
    {
        public dsGimnasio.productoRow datos;
        public string Nombre = "";
        public decimal Precio=0;
        public string Descripcion="";
        public decimal Costo=0;
        public int idUsuarioLog = 0;


        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwproductosTableAdapter ta = new dsGimnasioTableAdapters.vwproductosTableAdapter();
                dsGimnasio.vwproductosDataTable dt = ta.GetData();
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public override bool getDatos(int id)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.productoTableAdapter ta = new dsGimnasioTableAdapters.productoTableAdapter();
                dsGimnasio.productoDataTable dt = ta.GetDataById(id);

                if (dt.Rows.Count > 0)
                {
                    datos = (dsGimnasio.productoRow)dt.Rows[0];
                    exito = true;
                }


            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public override bool add()
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.productoTableAdapter ta = new dsGimnasioTableAdapters.productoTableAdapter();
                ta.add(Nombre, Descripcion, Precio, idUsuarioLog, Costo);

                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public override bool changeState(int newState, int id)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.productoTableAdapter ta = new dsGimnasioTableAdapters.productoTableAdapter();
                ta.cambiaEstado(newState, id);

                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public override bool edit(int id)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.productoTableAdapter ta = new dsGimnasioTableAdapters.productoTableAdapter();
                ta.edit(Nombre, Descripcion, Precio, Costo, id);

                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public override bool search(System.Windows.Forms.DataGridView dgv, int campo, string valor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// metodo que llena un combo y pone autocompletar
        /// </summary>
        /// <param name="cbo"></param>
        public static void getProductosEnCbo(System.Windows.Forms.ComboBox cbo)
        {
            dsGimnasioTableAdapters.productoTableAdapter ta = new dsGimnasioTableAdapters.productoTableAdapter();
            dsGimnasio.productoDataTable dt = ta.GetDataActivos();
            dsGimnasio.productoDataTable dt2 = ta.GetDataActivos();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (dsGimnasio.productoRow dr in dt2.Rows)
            {
                coleccion.Add(dr.Nombre);
            }

            cbo.DataSource = dt;
            cbo.ValueMember = "idProducto";
            cbo.DisplayMember = "Nombre";

            // llenar el autocompletar
            cbo.AutoCompleteCustomSource = coleccion;
            cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        #region metodos de reportes

        //actualiza inventario
        public bool getDatosRptInventario(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptinventarioTableAdapter ta = new dsGimnasioTableAdapters.rptinventarioTableAdapter();
                dsGimnasio.rptinventarioDataTable dt = ta.GetData();
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public bool getDatosRptVentaProductos(System.Windows.Forms.DataGridView dgv,DateTime fecha1, DateTime fecha2)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptventaproductosTableAdapter ta = new dsGimnasioTableAdapters.rptventaproductosTableAdapter();
                dsGimnasio.rptventaproductosDataTable dt = ta.GetDataByFecha(fecha1, fecha2);
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        #endregion

    }
}
