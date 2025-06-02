using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Proyecto_TopFilter
{
    public partial class Form2 : Form
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

        VideoCapture capture;
        Mat frame;
        bool _isPlaying = false;

        enum Filtro { Original, Invertir, Relieve, Contraste, Pixelado, 
                      Ruido, Rojo, Verde, Azul }
        Filtro videoFiltro = Filtro.Original;

        int anchoFrame;
        int altoFrame;

        int[] histoR;
        int[] histoG;
        int[] histoB;

        public Form2()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            frame = new Mat();
            timer1.Interval = 33;
            timer1.Tick += Timer_Tick;
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void editarImagen_menuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Show();

            if (capture != null)
            {
                timer1.Stop();
                capture?.Dispose();
                capture = null;
            }
        }

        private void detectarColor_menuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Show();

            if (capture != null)
            {
                timer1.Stop();
                capture?.Dispose();
                capture = null;
            }
        }

        private void cargarVideo_btn_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    capture = new VideoCapture(openFileDialog1.FileName);
                    _isPlaying = true;
                    timer1.Start();

                    anchoFrame = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.FrameWidth));
                    altoFrame = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.FrameHeight));
                }
            }
            else
            {
                capture?.Dispose();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    capture = new VideoCapture(openFileDialog1.FileName);
                    _isPlaying = true;

                    anchoFrame = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.FrameWidth));
                    altoFrame = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.FrameHeight));
                }
            }
        }

        private void calcularHistograma(Image<Bgr, byte> imagen)
        {
            //En histo# se guarda el total de veces que existe ese valor de color en la imagen, 0-255
            histoR = new int[256];
            histoG = new int[256];
            histoB = new int[256];

            int valor_canalR, valor_canalG, valor_canalB;

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (capture != null)
            {
                try
                {
                    if (_isPlaying)
                    {
                        capture.Read(frame);
                        if (!frame.IsEmpty)
                        {
                            Video_pictureBox.Image?.Dispose();
                            Bitmap frameOriginal = frame.ToBitmap();
                            switch (videoFiltro)
                            {
                                case Filtro.Relieve:
                                    Video_pictureBox.Image = frameOriginal.ConvolucionFiltro((ConvolucionBase)(new FiltroRelieve()));
                                    break;
                                case Filtro.Contraste:
                                    Video_pictureBox.Image = frameOriginal.Contraste(80);
                                    break;
                                case Filtro.Ruido:
                                    Video_pictureBox.Image = frameOriginal.Ruido(15, 165, 255);
                                    break;
                                case Filtro.Pixelado:
                                    Video_pictureBox.Image = frameOriginal.Pixelado(16);
                                    break;
                                case Filtro.Invertir:
                                    Video_pictureBox.Image = frameOriginal.Invertir();
                                    break;
                                case Filtro.Rojo:
                                    Video_pictureBox.Image = frameOriginal.TinteColor(true, false, false);
                                    break;
                                case Filtro.Verde:
                                    Video_pictureBox.Image = frameOriginal.TinteColor(false, true, false);
                                    break;
                                case Filtro.Azul:
                                    Video_pictureBox.Image = frameOriginal.TinteColor(false, false, true);
                                    break;
                                case Filtro.Original:
                                    Video_pictureBox.Image = frameOriginal;
                                    break;
                            }
                            Image<Bgr, byte> image = ((Bitmap)Video_pictureBox.Image).ToImage<Bgr, byte>();
                            calcularHistograma(image);
                        }
                        else
                        {
                            // Detiene el video al terminar los frames
                            _isPlaying = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                if (_isPlaying)
                {
                    _isPlaying = false;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _isPlaying = false;
            capture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, 0); //Reinicia el conteo de frames al primero
            Video_pictureBox.Image = null;
            Video_pictureBox.Invalidate(); //Redibuja la imagen del video

        }

        private void revertirCambios_btn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Original;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void ContrasteBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Contraste;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void RelieveBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Relieve;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void InvertirBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Invertir;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void TinteRojoBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Rojo;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void TinteVerdeBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Verde;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void TinteAzulBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Azul;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void PixeladoBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Pixelado;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void RuidoBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                videoFiltro = Filtro.Ruido;
                if (!_isPlaying)
                {
                    _isPlaying = true;
                }
            }
        }

        private void DetenerVideo()
        {
            _isPlaying = false;
            timer1.Stop();
            capture?.Dispose();
            capture = null;
            frame?.Dispose();
            Video_pictureBox.Image?.Dispose();
            Video_pictureBox.Image = null;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            DetenerVideo();
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

        private void HistoRGB_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (histoR != null && histoG != null && histoB != null)
            {
                DibujarHistogramaRGB(e.Graphics, HistoRGB_pictureBox.Width, HistoRGB_pictureBox.Height);
            }
        }
    }
}
