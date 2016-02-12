using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Gimnasio.Utilidades
{
    /// <summary>
    /// Clase OperacionesFormulario sirve para contener funciones comunes de un formulario y sus controles
    /// Autor: Héctor de León Guevara
    /// Fecha de Creación: 27/08/2012
    /// </summary>
    class OperacionesFormulario
    {
      
        /// <summary>
        /// Obtiene el id de un gridview que contenga en la primer celda el id de registro
        /// </summary>
        /// <param name="dgv">gridview para obtener el id</param>
        /// <returns>Regresa el entero del id</returns>
        public static int getId(DataGridView dgv)
        {
            try
            {
                int id = 0;

                id = int.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                return id;
            }catch(Exception){
                return -1;
            }
        }

        /// <summary>
        /// borra todas las columnas de un grid, en versiones de windows falla clear y no se limpian todas
        /// </summary>
        /// <param name="dgv">Datagridview para borrar sus columnas</param>
        public static void LimpiaGrid(DataGridView dgv)
        {
            while (dgv.Rows.Count > 0)
            {
                dgv.Rows.Remove(dgv.Rows[dgv.Rows.Count - 1]);
            }
        }

        /// <summary>
        /// Obtiene el valor de un gridview reciviendo el numero de su locación de la celda
        /// </summary>
        /// <param name="dgv">gridview para obtener el valor</param>
        /// <param name="num">indice de la celda a seleccionar valor</param>
        /// <returns>Regresa el entero del id</returns>
        public static string getValorCelda(DataGridView dgv, int num)
        {
            string valor = "";

            valor = dgv.Rows[dgv.CurrentRow.Index].Cells[num].Value.ToString();

            return valor;
        }

        /// <summary>
        /// Obtiene el valor de un gridview reciviendo el numero de su locación de la celda y el numero de row
        /// </summary>
        /// <param name="dgv">gridview para obtener el valor</param>
        /// <param name="num">indice de la celda a seleccionar valor</param>
        /// <returns>Regresa el entero del id</returns>
        public static string getValorCelda(DataGridView dgv, int num,int row)
        {
            string valor = "";

            valor = dgv.Rows[row].Cells[num].Value.ToString();

            return valor;
        }

        /// <summary>
        /// metodo que quita el ordenamiento de columnas de un datagridview
        /// </summary>
        /// <param name="dgv"></param>
        public static void quitaOrdenamientoGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn Col in dgv.Columns)
            {

                Col.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }

        public static byte[] conviertePicBoxImageToByte(System.Windows.Forms.PictureBox pbImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Bitmap bmap = new System.Drawing.Bitmap(pbImage.Image);//liena agregad apa evitar el pedo de exepcion de gdi
            bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }


    }
}
