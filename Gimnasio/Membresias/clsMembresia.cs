using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Membresias
{
    class clsMembresia : Utilidades.clsModulo
    {
        public dsGimnasio.membresiaRow datos;
        public string Nombre="";
        public decimal Precio;
        public int meses = 0;
        public TimeSpan horaInicio;
        public TimeSpan horaFinal;
        public int idUsuarioLog = 0;

        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwmembresiasTableAdapter ta = new dsGimnasioTableAdapters.vwmembresiasTableAdapter();
                dsGimnasio.vwmembresiasDataTable dt = ta.GetData();
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
                dsGimnasioTableAdapters.membresiaTableAdapter ta = new dsGimnasioTableAdapters.membresiaTableAdapter();
                dsGimnasio.membresiaDataTable dt = ta.GetDataByIdMembresia(id);

                if (dt.Rows.Count > 0)
                {
                    datos = (dsGimnasio.membresiaRow)dt.Rows[0];
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
                dsGimnasioTableAdapters.membresiaTableAdapter ta = new dsGimnasioTableAdapters.membresiaTableAdapter();
                ta.add(Nombre, Precio, idUsuarioLog, meses, horaInicio,horaFinal);

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
                dsGimnasioTableAdapters.membresiaTableAdapter ta= new dsGimnasioTableAdapters.membresiaTableAdapter();
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
                dsGimnasioTableAdapters.membresiaTableAdapter ta = new dsGimnasioTableAdapters.membresiaTableAdapter();
                ta.edit(Nombre, Precio, meses, horaInicio, horaFinal, id);
               
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
        /// metodo que llena un combo con las membresias activas
        /// </summary>
        /// <param name="cbo"></param>
        public static void getCboMembresias(System.Windows.Forms.ComboBox cbo)
        {
            dsGimnasioTableAdapters.membresiaTableAdapter ta = new dsGimnasioTableAdapters.membresiaTableAdapter();
            dsGimnasio.membresiaDataTable dt = ta.GetDataActivos();
            cbo.DataSource = dt;
            cbo.ValueMember = "idMembresia";
            cbo.DisplayMember = "Nombre";
           
        }

        #region metodos de reportes
        public bool getDatosRptMembresias(System.Windows.Forms.DataGridView dgv,DateTime fecha1,DateTime fecha2)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.rptmembresiasTableAdapter ta = new dsGimnasioTableAdapters.rptmembresiasTableAdapter();
                dsGimnasio.rptmembresiasDataTable dt = ta.GetDataByFecha(fecha1, fecha2);
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
