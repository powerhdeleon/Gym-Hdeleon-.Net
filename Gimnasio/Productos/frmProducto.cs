using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gimnasio.Productos
{
    public partial class frmProducto : Form
    {
        public int id = 0;
        clsProducto oProducto = new clsProducto();

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                cargaDatos();
            }
        }

        private void cargaDatos()
        {
            if (oProducto.getDatos(id))
            {

                txtNombre.Text = oProducto.datos.Nombre;
                txtPrecio.Text = oProducto.datos.Precio.ToString();
                txtCosto.Text = oProducto.datos.Costo.ToString();
                txtDescripcion.Text = oProducto.datos.Descripcion.ToString();
                
            }
            else
            {
                MessageBox.Show("Ocurrio un problema al cargar los datos " + oProducto.getError());
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                agrega();
            }
            else
            {
                modifica();
            }
        }

        private void agrega()
        {
            try
            {
                //validaciones
                if (txtNombre.Text.Trim().Equals("") || txtPrecio.Text.Trim().Equals("") || txtCosto.Text.Equals(""))
                {
                    MessageBox.Show("Nombre, Precio y Costo son obligatorios");
                    return;
                }
                if (!ExpresionesRegulares.RegEX.isDecimal(txtPrecio.Text.Trim()))
                {
                    MessageBox.Show("El precio debe ser un numero valido, no se permiten letras ni caracteres que no sean numeros");
                    return;
                }
                if (!ExpresionesRegulares.RegEX.isDecimal(txtCosto.Text.Trim()))
                {
                    MessageBox.Show("El costo debe ser un numero valido, no se permiten letras ni caracteres que no sean numeros");
                    return;
                }
                if (decimal.Parse(txtPrecio.Text.ToString()) <= decimal.Parse(txtCosto.Text.ToString()))
                {
                    MessageBox.Show("El costo debe ser menor que el precio al publico");
                    return;
                }

                //asignacion de datos
                oProducto.Nombre = txtNombre.Text.Trim();
                oProducto.Precio = decimal.Parse(txtPrecio.Text.Trim());
                oProducto.Costo = decimal.Parse(txtCosto.Text.Trim());
                oProducto.Descripcion = txtDescripcion.Text.Trim();
                oProducto.idUsuarioLog = Utilidades.clsUsuario.idUsuario;
                if (oProducto.add())
                {
                    MessageBox.Show("Registro agregado con exito");
                    this.Close();
                }
                else
                    MessageBox.Show(oProducto.getError());

            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocurrio un error de sistema " + EX.Message);
            }
        }

        private void modifica()
        {

            try
            {
                //validaciones
                if (txtNombre.Text.Trim().Equals("") || txtPrecio.Text.Trim().Equals("") || txtCosto.Text.Equals(""))
                {
                    MessageBox.Show("Nombre, Precio y Costo son obligatorios");
                    return;
                }
                if (!ExpresionesRegulares.RegEX.isDecimal(txtPrecio.Text.Trim()))
                {
                    MessageBox.Show("El precio debe ser un numero valido, no se permiten letras ni caracteres que no sean numeros");
                    return;
                }
                if (!ExpresionesRegulares.RegEX.isDecimal(txtCosto.Text.Trim()))
                {
                    MessageBox.Show("El costo debe ser un numero valido, no se permiten letras ni caracteres que no sean numeros");
                    return;
                }
                if (decimal.Parse(txtPrecio.Text.ToString()) <= decimal.Parse(txtCosto.Text.ToString()))
                {
                    MessageBox.Show("El costo debe ser menor que el precio al publico");
                    return;
                }

                //asignacion de datos
                oProducto.Nombre = txtNombre.Text.Trim();
                oProducto.Precio = decimal.Parse(txtPrecio.Text.Trim());
                oProducto.Costo = decimal.Parse(txtCosto.Text.Trim());
                oProducto.Descripcion = txtDescripcion.Text.Trim();
                oProducto.idUsuarioLog = Utilidades.clsUsuario.idUsuario;
                if (oProducto.edit(id))
                {
                    MessageBox.Show("Registro modificado con exito");
                    this.Close();
                }
                else
                    MessageBox.Show(oProducto.getError());

            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocurrio un error de sistema " + EX.Message);
            }
        }


    }
}
