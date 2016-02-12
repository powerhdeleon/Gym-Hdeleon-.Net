using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Utilidades
{
    public abstract class  clsModulo
    {
        protected List<string> error = new List<string>();


        /// <summary>
        /// metodo que realizara el refresh de los datos
        /// </summary>
        /// <param name="dgv">recibe el datagridview donde actualizara los datos</param>
        /// <returns>regresa si hubo exito</returns>
        public abstract bool getDatos(DataGridView dgv);

        /// <summary>
        /// metodo que llena los datos de solo un registro
        /// </summary>
        /// <returns>regresa exito</returns>
        public abstract bool getDatos(int id);

        /// <summary>
        /// metodo que agrega un registro
        /// </summary>
        /// <returns>true si ocurrio exito</returns>
        public abstract bool add();

        /// <summary>
        /// metodo que cambia estado del registro
        /// </summary>
        /// <param name="newState"></param>
        /// <returns>regresa true exito</returns>
        public abstract bool changeState(int newState, int id);

        /// <summary>
        /// metodo que edita un registro
        /// </summary>
        /// <param name="lCampos">lista de campos para crear el update</param>
        /// <param name="id">id del registro a modificar</param>
        /// <returns>regresa true exito</returns>
        public abstract bool edit(int id);

        /// <summary>
        /// metodo utilizado para la busqueda
        /// </summary>
        /// <param name="dgv">Grid view para actualizar datos</param>
        /// <param name="campo">campo a buscar</param>
        /// <param name="valor">valor del campo</param>
        /// <returns></returns>
        public abstract bool search(DataGridView dgv, int campo, string valor);

        /// <summary>
        /// metodo que limpia atributos que deben limpiarse
        /// </summary>
        public void clear()
        {
            error = new List<string>();
        }

          /// <summary>
        /// Obtiene listado de errores
        /// </summary>
        /// <returns>regresa la lista de errores</returns>
        public string getError()
        {
            string err="";
            foreach (string e in error)
            {
                err += e + ",";
            }
            err = err.Substring(0, err.Length - 1);
            return err;
        }
    }
}
