using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Gimnasio.Socios
{
    public partial class frmFoto : Form
    {
        private bool existenDispositivos = false;
        private bool fotografiaHecha = false;
        private FilterInfoCollection dispositivosDeVideo;
        private VideoCaptureDevice fuenteDeVideo = null;
        public PictureBox pbFotoSocio = null;
        public frmFoto()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmFoto_Load(object sender, EventArgs e)
        {
            if (existenDispositivos)
            {
        	    fuenteDeVideo = new VideoCaptureDevice(dispositivosDeVideo[0].MonikerString);
        	    fuenteDeVideo.NewFrame += new NewFrameEventHandler(MostrarImagen);
        	    fuenteDeVideo.Start();
        	}
        	else
        	{
        	    MessageBox.Show("No se encuentra ningún dispositivo de vídeo en el sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
             }
        }

        /*
     *  Identifica los dispositivos disponibles
     */
        private void BuscarDispositivos()
        {
            dispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice); 

            if (dispositivosDeVideo.Count == 0)
                existenDispositivos = false;
            else
                existenDispositivos = true;
        }

        /*
         *  Muestra imagen en el PictureBox
         */
        private void MostrarImagen(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pbFoto.Image = imagen;
            
        }

        /*
         *  Deja de capturar imágenes, obteniendo la última capturada
         */
        private void Capturar()
        {
            if (fuenteDeVideo != null)
            {
                if (fuenteDeVideo.IsRunning)
                {
                    pbFotoSocio.Image = pbFoto.Image;
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Capturar();
            fotografiaHecha = true;
        }

        private void frmFoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fuenteDeVideo!=null)
            fuenteDeVideo.Stop();
        }

    }
}
