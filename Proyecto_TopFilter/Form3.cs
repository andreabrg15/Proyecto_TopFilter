using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace Proyecto_TopFilter
{
    public partial class Form3 : Form
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

        struct XYZ
        {
            public double X;
            public double Y; 
            public double Z;
        }

        struct Lab
        {
            public double L;
            public double a; 
            public double b;
        }

        Color color;
        XYZ espacioxyz;
        Lab espacioLab;

        float radioCirculoCroma;
        Bitmap circuloBase;

        public Form3()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            circuloBase = new Bitmap(CirculoCromatico_pictureBox.Width, CirculoCromatico_pictureBox.Height);
            Graphics g = Graphics.FromImage(circuloBase);
            dibujarCirculoColor(g, circuloBase.Width, circuloBase.Height);
            CirculoCromatico_pictureBox.Image = (Bitmap)circuloBase.Clone();

            frame = new Mat();
            timer1.Interval = 33;
            timer1.Tick += Timer1_Tick;
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

        private void editarVideo_menuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();
            form2.Show();

            if (capture != null)
            {
                timer1.Stop();
                capture?.Dispose();
                capture = null;
            }
        }

        private void manual_menuBtn_Click(object sender, EventArgs e)
        {
            string manualURL = "https://drive.google.com/file/d/17lLXQnzNhYL8cqgngaNIDKEMWHLsSRo7/view?usp=sharing";

            try
            {
                Process.Start(manualURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void encenderCamBtn_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture(0);
                capture.Start();
                timer1.Start();
            }
        }

        private void apagarCamBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture?.Dispose();
                capture = null;
                timer1.Stop();

                Camara_pictureBox.Image = null;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (capture != null)
            {
                try
                {
                    capture.Read(frame);
                    Camara_pictureBox.Image?.Dispose();
                    Camara_pictureBox.Image = frame.ToBitmap();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Camara_pictureBox_Click(object sender, EventArgs e)
        {
            if (Camara_pictureBox.Image != null)
            {
                MouseEventArgs punteroMouse = (MouseEventArgs)e;
                color = ((Bitmap)Camara_pictureBox.Image).GetPixel(punteroMouse.X, punteroMouse.Y);

                if (!color.IsEmpty)
                {
                    R_label.Text = "R: " + color.R.ToString();
                    G_label.Text = "G: " + color.G.ToString();
                    B_label.Text = "B: " + color.B.ToString();

                    pictureBox2.BackColor = color;

                    EspacioRGBaEspacioCIELab(color.R, color.G, color.B);
                    L_label.Text = "L* " + espacioLab.L.ToString("0.00");
                    a_label.Text = "a* " + espacioLab.a.ToString("0.00");
                    be_label.Text = "b* " + espacioLab.b.ToString("0.00");

                    X_label.Text = "X: " + espacioxyz.X.ToString("0.00");
                    Y_label.Text = "Y: " + espacioxyz.Y.ToString("0.00");
                    Z_label.Text = "Z: " + espacioxyz.Z.ToString("0.00");

                    ubicarColorenCirculoCromatico();
                }
            }
        }

        private void EspacioRGBaEspacioCIELab(byte R, byte G, byte B)
        {
            double[] rgb = new double[3];
            rgb[0] = R;
            rgb[1] = G;
            rgb[2] = B;

            // Se normalizan los valores RGB
            for (int i = 0; i < 3; i++)
            {
                rgb[i] = rgb[i] / 255;
                if (rgb[i] > 0.04045)
                {
                    rgb[i] = Math.Pow((rgb[i] + 0.055) / 1.055, 2.4);
                }
                else
                {
                    rgb[i] = rgb[i] / 12.92;
                }
                rgb[i] = rgb[i] * 100;
            }

            double[] espacioXYZ = new double[3];

            // X
            espacioXYZ[0] = (rgb[0] * 0.4124) + (rgb[1] * 0.3576) + (rgb[2] * 0.1805);
            // Y
            espacioXYZ[1] = (rgb[0] * 0.2126) + (rgb[1] * 0.7152) + (rgb[2] * 0.0722);
            // Z
            espacioXYZ[2] = (rgb[0] * 0.0193) + (rgb[1] * 0.1192) + (rgb[2] * 0.9505);

            espacioxyz.X = espacioXYZ[0];
            espacioxyz.Y = espacioXYZ[1];
            espacioxyz.Z = espacioXYZ[2];

            espacioXYZ[0] = espacioXYZ[0] / 95.047;
            espacioXYZ[1] = espacioXYZ[1] / 100.0;
            espacioXYZ[2] = espacioXYZ[2] / 108.883;

            for (int i = 0; i < 3; i++)
            {
                if (espacioXYZ[i] > 0.008856)
                {
                    espacioXYZ[i] = Math.Pow(espacioXYZ[i], 0.3333333333333333);
                }
                else
                {
                    espacioXYZ[i] = (7.787 * espacioXYZ[i]) + (16 / 116);
                }
            }

            // XYZ a CIELab
            espacioLab.L = (116 * espacioXYZ[1]) - 16;
            espacioLab.a = 500 * (espacioXYZ[0] - espacioXYZ[1]);
            espacioLab.b = 200 * (espacioXYZ[1] - espacioXYZ[2]);
        }

        private void ubicarColorenCirculoCromatico()
        {
            Bitmap copia = (Bitmap)circuloBase.Clone();

            int ancho = copia.Width;
            int alto = copia.Height;

            PointF centro = new PointF( ancho / 2.0f, alto / 2.0f);
            float hue = -color.GetHue();
            double radianes = hue * Math.PI / 180;
            float saturacion = color.GetSaturation();


            PointF punto = new PointF(
                centro.X + (radioCirculoCroma * saturacion) * (float)Math.Cos(radianes),
                centro.Y + (radioCirculoCroma * saturacion) * (float)Math.Sin(radianes)
                );

            // Dibujar el punto ubicado
            using (Graphics g = Graphics.FromImage(copia))
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.FillEllipse(brush, punto.X - 5, punto.Y - 5, 10, 10);
                }
            }
            CirculoCromatico_pictureBox.Image = copia;

        }

        private void dibujarCirculoColor(Graphics gr, int ancho, int alto)
        {
            Rectangle rect = new Rectangle(0, 0, ancho, alto);
            GraphicsPath circulo_path = new GraphicsPath();
            circulo_path.AddEllipse(rect);
            circulo_path.Flatten();

            int num_pts = (circulo_path.PointCount - 1) / 3;
            Color[] surround_colors = new Color[circulo_path.PointCount];
            float r = 255, g = 0, b = 0;
            float dr, dg, db;
            dr = -255 / num_pts;
            db = 255 / num_pts;
            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[i] =
                    Color.FromArgb(255, (int)r, (int)g, (int)b);
                r += dr;
                b += db;
            }

            r = 0; g = 0; b = 255;
            dg = 255 / num_pts;
            db = -255 / num_pts;
            for (int i = num_pts; i < 2 * num_pts; i++)
            {
                surround_colors[i] =
                    Color.FromArgb(255, (int)r, (int)g, (int)b);
                g += dg;
                b += db;
            }

            r = 0; g = 255; b = 0;
            dr = 255 / (circulo_path.PointCount - 2 * num_pts);
            dg = -255 / (circulo_path.PointCount - 2 * num_pts);
            for (int i = 2 * num_pts; i < circulo_path.PointCount; i++)
            {
                surround_colors[i] =
                    Color.FromArgb(255, (int)r, (int)g, (int)b);
                r += dr;
                g += dg;
            }

            using (PathGradientBrush path_brush =
                new PathGradientBrush(circulo_path))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = surround_colors;

                radioCirculoCroma = ancho / 2f;

                gr.FillPath(path_brush, circulo_path);
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capture != null)
            {
                capture?.Dispose();
                capture = null;
                timer1.Stop();
            }
        }
    }
}
