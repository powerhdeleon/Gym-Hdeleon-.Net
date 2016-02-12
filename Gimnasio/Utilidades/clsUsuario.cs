using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimnasio.Utilidades
{
    class clsUsuario
    {
        public static bool existeSesion=false;
        public static string usuario = "";
        public static int idUsuario=0;
        public static string nombre="";
        public static string error = "";

        public static bool login(string usuario_,string password_){
            bool exito = false;
            error = "";
            try
            {
                dsGimnasioTableAdapters.usuarioTableAdapter ta = new dsGimnasioTableAdapters.usuarioTableAdapter();
                dsGimnasio.usuarioDataTable dt = ta.login(usuario_, password_);
                dsGimnasio.usuarioRow dr = null;
                if (dt.Rows.Count > 0)
                {
                    dr = (dsGimnasio.usuarioRow)dt.Rows[0];
                    nombre = dr.Nombre;
                    idUsuario = dr.idUsuario;
                    usuario = dr.Usuario;
                    existeSesion = true;

                    exito = true;
                }
                else
                {
                    error = "Usuario o password incorrecto";
                }

            }catch(Exception ex){
                error = "ERROR SISTEMA "+ex.Message;
            }

            return exito;
        }

        public static bool salir()
        {
            bool exito = false;
            error = "";
            try
            {
                    nombre ="";
                    idUsuario =0;
                    usuario = "";
                    existeSesion = false;

                    exito = true;

            }
            catch (Exception ex)
            {
                error = "ERROR SISTEMA " + ex.Message;
            }

            return exito;
        }

    }
}
