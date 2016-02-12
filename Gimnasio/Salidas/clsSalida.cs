using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Salidas
{
    class clsSalida : Utilidades.clsModulo
    {

        public List<clsDetalleSalida> lDetalle = new List<clsDetalleSalida>();
        public dsGimnasio.salidaRow datos;
        public int idUsuarioLog = 0;
        public decimal Total = 0;

        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
            
                dsGimnasioTableAdapters.vwsalidasTableAdapter ta = new dsGimnasioTableAdapters.vwsalidasTableAdapter();
                dsGimnasio.vwsalidasDataTable dt = ta.GetData();
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public bool getDatosDetalle(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {

                dsGimnasioTableAdapters.vwdetallesalidaviewTableAdapter ta = new dsGimnasioTableAdapters.vwdetallesalidaviewTableAdapter();
                dsGimnasio.vwdetallesalidaviewDataTable dt = ta.GetDataByIdSalida(datos.idSalida);
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
                dsGimnasioTableAdapters.salidaTableAdapter ta = new dsGimnasioTableAdapters.salidaTableAdapter();
                dsGimnasio.salidaDataTable dt = ta.GetDataById(id);

                if (dt.Rows.Count > 0)
                {
                    datos = (dsGimnasio.salidaRow)dt.Rows[0];
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
                    dsGimnasioTableAdapters.salidaTableAdapter ta = new dsGimnasioTableAdapters.salidaTableAdapter();
                    ta.add(Total, idUsuarioLog);

                    //dar de alta salida

                    int? idSalida = 0;//utilizado para ver ultima salida
                    try
                    {
                        foreach (clsDetalleSalida de in lDetalle)
                        {
                            dsGimnasioTableAdapters.QueriesTableAdapter query = new dsGimnasioTableAdapters.QueriesTableAdapter();
                            idSalida = (int?)query.getLastIdSalida();

                            de.idSalida = idSalida.Value;
                            de.add();

                            //asigna el detalle salida a el detalle entrada
                            int? idDetalleSalida = query.getLastIdDetalleSalida();
                            dsGimnasioTableAdapters.detalleentradaTableAdapter taDE = new dsGimnasioTableAdapters.detalleentradaTableAdapter();
                            taDE.asignaSalida(idDetalleSalida.Value, de.idProducto);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.changeState(3, idSalida.Value);//se elimina la ultima salida
                        error.Add(ex.Message);
                    }

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
                dsGimnasioTableAdapters.salidaTableAdapter ta = new dsGimnasioTableAdapters.salidaTableAdapter();
                ta.cambiaEstado(newState, id);

                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        /// <summary>
        /// elimina utilizando delete
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        public  bool remove(int id)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.salidaTableAdapter ta = new dsGimnasioTableAdapters.salidaTableAdapter();
                ta.remove(id);

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
            throw new NotImplementedException();
        }

        public override bool search(System.Windows.Forms.DataGridView dgv, int campo, string valor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// metodo que verifica existencia de un producto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public static bool existenciaProducto(int cantidad,int idProducto)
        {
            bool existencia = false;

            dsGimnasioTableAdapters.vwdetalleentradaexistenteTableAdapter ta = new dsGimnasioTableAdapters.vwdetalleentradaexistenteTableAdapter();
            dsGimnasio.vwdetalleentradaexistenteDataTable dt = ta.GetDataByIdProducto(idProducto);

            //si hay algo de productos entra sino lo enviamos ya a la goma
            if (dt.Rows.Count > 0)
            {
                dsGimnasio.vwdetalleentradaexistenteRow dr= (dsGimnasio.vwdetalleentradaexistenteRow)dt.Rows[0];

                //ahora comparamos si la cantidad de productos de la salida se cubre
                if (cantidad <= dr.cantidad)
                {
                    existencia = true;
                }
            }
            else
            {
                return false;
            }

            return existencia;
        }
    }
}
