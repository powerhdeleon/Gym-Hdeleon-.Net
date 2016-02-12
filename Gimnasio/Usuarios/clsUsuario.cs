using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Usuarios
{
    class clsUsuario : Utilidades.clsModulo
    {
        public dsGimnasio.usuarioRow datos;
        public string Usuario="";
        public string Password="";
        public string Nombre="";

        public override bool getDatos(System.Windows.Forms.DataGridView dgv)
        {
            clear();
            bool exito = false;
            try
            {
                dsGimnasioTableAdapters.vwusuariosTableAdapter taUsuarios = new dsGimnasioTableAdapters.vwusuariosTableAdapter();
                dsGimnasio.vwusuariosDataTable dtUsuarios = taUsuarios.GetData();
                dgv.DataSource = dtUsuarios;
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
                 dsGimnasioTableAdapters.usuarioTableAdapter taUsuarios = new dsGimnasioTableAdapters.usuarioTableAdapter();
                 dsGimnasio.usuarioDataTable dtUsuarios = taUsuarios.GetDataByIdUsuario(id);

                 if (dtUsuarios.Rows.Count > 0)
                 {
                     datos = (dsGimnasio.usuarioRow)dtUsuarios.Rows[0];
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
                dsGimnasioTableAdapters.usuarioTableAdapter taUsuarios = new dsGimnasioTableAdapters.usuarioTableAdapter();
                taUsuarios.add(Usuario, Nombre, Password);
                
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
                dsGimnasioTableAdapters.usuarioTableAdapter taUsuarios = new dsGimnasioTableAdapters.usuarioTableAdapter();
                taUsuarios.cambiaEstado(newState, id);

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
                dsGimnasioTableAdapters.usuarioTableAdapter taUsuarios = new dsGimnasioTableAdapters.usuarioTableAdapter();
                taUsuarios.edit(Usuario, Nombre,Password,id);

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
    }
}
