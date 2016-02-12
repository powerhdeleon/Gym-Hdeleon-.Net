using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Socios
{
    class clsSocioMembresia : Utilidades.clsModulo
    {
        dsGimnasio.sociomembresiaRow datos;
        public int idUsuarioLog=0;
        public int idSocio=0,idMembresia=0;
        public decimal Precio=0;
        public DateTime fechaInicioMembresia;

        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwsociomembresiasTableAdapter ta = new dsGimnasioTableAdapters.vwsociomembresiasTableAdapter();
                dsGimnasio.vwsociomembresiasDataTable dt = ta.GetData();
                dgv.DataSource = dt;
                exito = true;
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }

            return exito;
        }

        public  bool getDatos(System.Windows.Forms.DataGridView dgv,int idSocio)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwsociomembresiasTableAdapter ta = new dsGimnasioTableAdapters.vwsociomembresiasTableAdapter();
                dsGimnasio.vwsociomembresiasDataTable dt = ta.GetDataByIdSocio(idSocio);
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
            throw new NotImplementedException();
        }

        public override bool add()
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.sociomembresiaTableAdapter ta = new dsGimnasioTableAdapters.sociomembresiaTableAdapter();
                ta.add(idUsuarioLog,idSocio,idMembresia,Precio,fechaInicioMembresia);

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
                dsGimnasioTableAdapters.sociomembresiaTableAdapter ta = new dsGimnasioTableAdapters.sociomembresiaTableAdapter();
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
            throw new NotImplementedException();
        }

        public override bool search(System.Windows.Forms.DataGridView dgv, int campo, string valor)
        {
            throw new NotImplementedException();
        }


    }
}
