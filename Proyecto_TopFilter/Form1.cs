using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_TopFilter
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Variables que guardarán la info de la imagen original
        // y la que tenga el filtro
        private Bitmap imagenOriginal = null;
        private Bitmap imagenResultante = null;
        bool filtroRojo = false;
        bool filtroVerde = false;
        bool filtroAzul = false;

        int anchoFrame;
        int altoFrame;

        int[] histoR;
        int[] histoG;
        int[] histoB;

        public Form1()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            imagenResultante = new Bitmap(500, 380);
            anchoFrame = 500;
            altoFrame = 380;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Salir_pictureBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        //Navegación
        private void editarVideo_menuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();
            form2.Show();
        }

        private void detectarColor_menuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Show();
        }

        // Botón para subir la imagen a la que se aplicarán los filtros
        private void cargarImagen_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Cargar la imagen
                imagenOriginal = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);

                imagenResultante = imagenOriginal;

                // Mostrar la imagen en el recuadro principal
                Imagen_pictureBox.Image = imagenResultante;
                Imagen_pictureBox.Image.RotateFlip(Rotate(imagenResultante));

                // Mostrar la imagen original en el recuadro pequeño
                Original_pictureBox.Image = imagenOriginal;

                anchoFrame = Imagen_pictureBox.Image.Width;
                altoFrame = Imagen_pictureBox.Image.Height;

                calcularHistograma();
            }
        }

        private void revertirCambios_btn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null && imagenResultante != null)
            {
                imagenResultante = imagenOriginal;
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void guardarImagen_btn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagenResultante.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }

        // Cambia la imagen a su orientación correcta cuando se muestra en el PictureBox
        private RotateFlipType Rotate(Image bmp)
        {
            const int OrientationId = 0x0112;
            PropertyItem pi = bmp.PropertyItems.Select(x => x)
                                        .FirstOrDefault(x => x.Id == OrientationId);
            if (pi == null)
                return RotateFlipType.RotateNoneFlipNone;

            byte o = pi.Value[0];

            //Orientaciones
            if (o == 2) //TopRight
                return RotateFlipType.RotateNoneFlipX;
            if (o == 3) //BottomRight
                return RotateFlipType.RotateNoneFlipXY;
            if (o == 4) //BottomLeft
                return RotateFlipType.RotateNoneFlipY;
            if (o == 5) //LeftTop
                return RotateFlipType.Rotate90FlipX;
            if (o == 6) //RightTop
                return RotateFlipType.Rotate90FlipNone;
            if (o == 7) //RightBottom
                return RotateFlipType.Rotate90FlipY;
            if (o == 8) //LeftBottom
                return RotateFlipType.Rotate90FlipXY;

            return RotateFlipType.RotateNoneFlipNone; //TopLeft
        }

        private void calcularHistograma()
        {
            //En histo# se guarda el total de veces que existe ese valor de color en la imagen, 0-255
            histoR = new int[256];
            histoG = new int[256];
            histoB = new int[256];

            int valor_canalR, valor_canalG, valor_canalB;

            Image<Bgr, byte> imagen = imagenResultante.ToImage<Bgr,byte>();
            byte[,,] data = imagen.Data;

            for (int y = 0; y < altoFrame; y++)
            {
                for (int x = 0; x < anchoFrame; x++)
                {
                    valor_canalB = data[y, x, 0];
                    histoB[valor_canalB]++;

                    valor_canalG = data[y, x, 1];
                    histoG[valor_canalG]++;

                    valor_canalR = data[y, x, 2];
                    histoR[valor_canalR]++;
                }
            }

            HistoRojo_pictureBox.Invalidate();
            HistoVerde_pictureBox.Invalidate();
            HistoAzul_pictureBox.Invalidate();
            HistoRGB_pictureBox.Invalidate();
        }

        private void GaussianoBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                ConvolucionBase filtro = (ConvolucionBase)(new FiltroGaussiano());
                imagenResultante = imagenOriginal.ConvolucionFiltro(filtro);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void BordesBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                ConvolucionBase filtro = (ConvolucionBase)(new FiltroBordes());
                imagenResultante = imagenOriginal.ConvolucionFiltro(filtro, true);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void ContrasteBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenResultante = imagenOriginal.Contraste(80);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void InvertirBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenResultante = imagenOriginal.Invertir();
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void RelieveBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                ConvolucionBase filtro = (ConvolucionBase)(new FiltroRelieve());
                imagenResultante = imagenOriginal.ConvolucionFiltro(filtro);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void TinteRojoBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenResultante = imagenOriginal.TinteColor(true, false, false);
                Imagen_pictureBox.Image = imagenResultante;
                filtroRojo = true;
                calcularHistograma();
            }
        }

        private void TinteVerdeBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenResultante = imagenOriginal.TinteColor(false, true, false);
                Imagen_pictureBox.Image = imagenResultante;
                filtroVerde = true;
                calcularHistograma();
            }
        }

        private void TinteAzulBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                imagenResultante = imagenOriginal.TinteColor(false, false, true);
                Imagen_pictureBox.Image = imagenResultante;
                filtroAzul = true;
                calcularHistograma();
            }
        }

        private void PixeladoBtn_Click(object sender, EventArgs e)
        {
            if(imagenOriginal != null)
            {
                int mosaico = Convert.ToInt32(numericUpDown1.Value);
                imagenResultante = imagenOriginal.Pixelado(mosaico);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void CaricaturizarBtn_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                int umbral = Convert.ToInt32(numericUpDown2.Value);
                imagenResultante = imagenOriginal.EfectoCaricaturizar(umbral);
                Imagen_pictureBox.Image = imagenResultante;
                calcularHistograma();
            }
        }

        private void DibujarHistograma(Graphics g, int ancho, int alto, int[] histo, Pen pen)
        {
            int valorMaximo = histo.Max();

            float anchoBarra = ancho / 256f;

            for (int i = 0; i < 256; i++)
            {
                float altoBarra = (histo[i] / (float)valorMaximo) * alto;

                g.DrawLine(pen, i * anchoBarra, alto, i * anchoBarra, alto - altoBarra);
            }
        }

        private void DibujarHistogramaRGB(Graphics g, int ancho, int alto)
        {
            int valorMaximo = histoR.Concat(histoG).Concat(histoB).Max();

            float anchoBarra = ancho / 256f;

            for (int i = 0; i < 256; i++)
            {
                float altoBarraR = (histoR[i] / (float)valorMaximo) * alto;
                float altoBarraG = (histoG[i] / (float)valorMaximo) * alto;
                float altoBarraB = (histoB[i] / (float)valorMaximo) * alto;

                g.DrawLine(Pens.Red, i * anchoBarra, alto, i * anchoBarra, alto - altoBarraR);
                g.DrawLine(Pens.Green, i * anchoBarra + 1, alto, i * anchoBarra + 1, alto - altoBarraG);
                g.DrawLine(Pens.Blue, i * anchoBarra + 2, alto, i * anchoBarra + 2, alto - altoBarraB);
            }
        }

        private void HistoRGB_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (histoR != null && histoG != null && histoB != null)
            {
                DibujarHistogramaRGB(e.Graphics, HistoRGB_pictureBox.Width, HistoRGB_pictureBox.Height);
            }
        }

        private void HistoRojo_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (histoR != null)
            {
                DibujarHistograma(e.Graphics, HistoRojo_pictureBox.Width, HistoRojo_pictureBox.Height,
                    histoR, Pens.Red);
            }
        }

        private void HistoVerde_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (histoG != null)
            {
                DibujarHistograma(e.Graphics, HistoVerde_pictureBox.Width, HistoVerde_pictureBox.Height,
                    histoG, Pens.Green);
            }
        }

        private void HistoAzul_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (histoB != null)
            {
                DibujarHistograma(e.Graphics, HistoAzul_pictureBox.Width, HistoAzul_pictureBox.Height,
                    histoB, Pens.Blue);
            }
        }
    }
}
