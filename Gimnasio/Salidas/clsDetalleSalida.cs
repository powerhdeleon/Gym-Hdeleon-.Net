using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Salidas
{
    class clsDetalleSalida :Utilidades.clsModulo
    {
        public dsGimnasio.detallesalidaRow datos;

        public decimal CostoUnitario=0;
        public int idProducto = 0, idSalida;

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
                dsGimnasioTableAdapters.detallesalidaTableAdapter ta = new dsGimnasioTableAdapters.detallesalidaTableAdapter();
                ta.add(idProducto,CostoUnitario,idSalida);

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
            throw new NotImplementedException();
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
