using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Socios
{
    class clsSocio : Utilidades.clsModulo
    {
        public dsGimnasio.socioRow datos;
        public string Nombre = "";
        public string Materno = "";
        public string Paterno = "";
        public string Observaciones = "";
        public string Telefono = "";
        public byte[] foto = null;
        public int idUsuarioLog = 0;
       
        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwsociosTableAdapter ta = new dsGimnasioTableAdapters.vwsociosTableAdapter();
                dsGimnasio.vwsociosDataTable dt = ta.GetData();
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
                dsGimnasioTableAdapters.socioTableAdapter ta = new dsGimnasioTableAdapters.socioTableAdapter();
                dsGimnasio.socioDataTable dt = ta.GetDataById(id);

                if (dt.Rows.Count > 0)
                {
                    datos = (dsGimnasio.socioRow)dt.Rows[0];
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
                dsGimnasioTableAdapters.socioTableAdapter ta = new dsGimnasioTableAdapters.socioTableAdapter();
                ta.add(Nombre, Paterno, Materno, Telefono, Observaciones, idUsuarioLog, foto);

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
                dsGimnasioTableAdapters.socioTableAdapter ta = new dsGimnasioTableAdapters.socioTableAdapter();
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
                dsGimnasioTableAdapters.socioTableAdapter ta = new dsGimnasioTableAdapters.socioTableAdapter();
                ta.edit(Nombre, Paterno, Materno, Telefono, Observaciones, foto, id);

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

        #region reportes

        public  bool getDatosRptSocios(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptsociosTableAdapter ta = new dsGimnasioTableAdapters.rptsociosTableAdapter();
                dsGimnasio.rptsociosDataTable dt = ta.GetData();
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public bool getDatosRptRegistro(System.Windows.Forms.DataGridView dgv,DateTime fecha)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptvisitasTableAdapter ta = new dsGimnasioTableAdapters.rptvisitasTableAdapter();
                dsGimnasio.rptvisitasDataTable dt = ta.GetDataByFecha(fecha);
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public bool getDatosRptVisitas(System.Windows.Forms.DataGridView dgv, DateTime fecha)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptvisitasTableAdapter ta = new dsGimnasioTableAdapters.rptvisitasTableAdapter();
                dsGimnasio.rptvisitasDataTable dt = ta.GetDataVisitasByFecha(fecha);
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
