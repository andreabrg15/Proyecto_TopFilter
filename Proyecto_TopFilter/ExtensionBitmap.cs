using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TopFilter
{
    public static class ExtensionBitmap
    {
        public static Bitmap ConvolucionFiltro<T>(this Bitmap bitmapOriginal, T filtro, bool escalaGrises = false)
            where T : ConvolucionBase
        {
            // Prevenir que el Bitmap no cambie su ubicación en memoria
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0, 0,
                bitmapOriginal.Width, bitmapOriginal.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Buffers del tamaño del bitmap
            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];
            byte[] resultadoBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            bitmapOriginal.UnlockBits(datosOriginal);

            // Si queremos aplicar un filtro que requiere escala de grises, primero se hace esa conversion
            if (escalaGrises == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    // Se aplican los calculos para obtener el valor de gris que tendran los pixeles (rgb)
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = (byte)rgb;
                    pixelBuffer[k + 2] = (byte)rgb;
                    pixelBuffer[k + 3] = 255;
                }
            }

            double azul = 0.0;
            double verde = 0.0;
            double rojo = 0.0;

            // Ancho y alto de la matriz filtro
            int filtroAncho = filtro.FiltroMatriz.GetLength(1);
            int filtroAlto = filtro.FiltroMatriz.GetLength(0);

            // Calcula el indice de los pixeles vecinos
            int filtroOffset = (filtroAncho - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            // Se recorren todos los pixeles vecinos
            for (int offsetY = filtroOffset; offsetY < bitmapOriginal.Height - filtroOffset; offsetY++)
            {
                for (int offsetX = filtroOffset; offsetX < bitmapOriginal.Width - filtroOffset; offsetX++)
                {
                    azul = 0;
                    verde = 0;
                    rojo = 0;

                    // Definir el pixel vecino actual
                    byteOffset = offsetY * datosOriginal.Stride + offsetX * 4;

                    // Se recorre toda la matriz
                    for (int filtroY = -filtroOffset; filtroY <= filtroOffset; filtroY++)
                    {
                        for (int filtroX = -filtroOffset; filtroX <= filtroOffset; filtroX++)
                        {
                            calcOffset = byteOffset + (filtroX * 4) + (filtroY * datosOriginal.Stride);

                            // Cada espacio de color de cada pixel se multiplica por la matriz del filtro

                            azul += (double)(pixelBuffer[calcOffset]) *
                                filtro.FiltroMatriz[filtroY + filtroOffset, filtroX + filtroOffset];

                            verde += (double)(pixelBuffer[calcOffset + 1]) *
                                filtro.FiltroMatriz[filtroY + filtroOffset, filtroX + filtroOffset];

                            rojo += (double)(pixelBuffer[calcOffset + 2]) *
                                filtro.FiltroMatriz[filtroY + filtroOffset, filtroX + filtroOffset];
                        }
                    }

                    azul = filtro.Factor * azul + filtro.Bias;
                    verde = filtro.Factor * verde + filtro.Bias;
                    rojo = filtro.Factor * rojo + filtro.Bias;

                    if (azul > 255)
                    { azul = 255; }
                    else if (azul < 0)
                    { azul = 0; }


                    if (verde > 255)
                    { verde = 255; }
                    else if (verde < 0)
                    { verde = 0; }


                    if (rojo > 255)
                    { rojo = 255; }
                    else if (rojo < 0)
                    { rojo = 0; }

                    resultadoBuffer[byteOffset] = (byte)(azul);
                    resultadoBuffer[byteOffset + 1] = (byte)(verde);
                    resultadoBuffer[byteOffset + 2] = (byte)(rojo);
                    resultadoBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);

            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0, resultado.Width, resultado.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultadoBuffer, 0, datosResultado.Scan0, resultadoBuffer.Length);

            resultado.UnlockBits(datosResultado);

            return resultado;
        }

        public static Bitmap Contraste(this Bitmap bitmapOriginal, int umbral)
        {
            // Prevenir que el Bitmap no cambie su ubicación en memoria
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0, 0,
                                        bitmapOriginal.Width, bitmapOriginal.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            bitmapOriginal.UnlockBits(datosOriginal);


            double nivelContraste = Math.Pow((100.0 + umbral) / 100.0, 2);

            double azul = 0;
            double verde = 0;
            double rojo = 0;

            // Se recorre cada byte de pixel buffer y sus espacios de color RGBA
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                // Aplicacion de la formula para cambiar el contraste de un pixel

                azul = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            nivelContraste) + 0.5) * 255.0;


                verde = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            nivelContraste) + 0.5) * 255.0;


                rojo = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            nivelContraste) + 0.5) * 255.0;


                if (azul > 255)
                { azul = 255; }
                else if (azul < 0)
                { azul = 0; }


                if (verde > 255)
                { verde = 255; }
                else if (verde < 0)
                { verde = 0; }


                if (rojo > 255)
                { rojo = 255; }
                else if (rojo < 0)
                { rojo = 0; }


                pixelBuffer[k] = (byte)azul;
                pixelBuffer[k + 1] = (byte)verde;
                pixelBuffer[k + 2] = (byte)rojo;
            }


            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);


            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, datosResultado.Scan0, pixelBuffer.Length);
            resultado.UnlockBits(datosResultado);


            return resultado;
        }

        public static Bitmap Ruido(this Bitmap bitmapOriginal, int porcentaje, int rangoMin, int rangoMax)
        {
            // Prevenir que el Bitmap no cambie su ubicación en memoria
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0, 0,
                                        bitmapOriginal.Width, bitmapOriginal.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            bitmapOriginal.UnlockBits(datosOriginal);

            Random rnd = new Random();

            // Se recorre cada byte de pixel buffer y sus espacios de color RGBA
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                // Si el pixel esta dentro del porcentaje aleatorio
                if (rnd.Next(1,100) <= porcentaje)
                {
                    // Se le genera un color aleatorio dentro del rango establecido
                    pixelBuffer[k] = (byte)rnd.Next(rangoMin, rangoMax);
                    pixelBuffer[k + 1] = (byte)rnd.Next(rangoMin, rangoMax);
                    pixelBuffer[k + 2] = (byte)rnd.Next(rangoMin, rangoMax);
                    pixelBuffer[k + 3] = 255;
                }
            }

            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);


            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, datosResultado.Scan0, pixelBuffer.Length);
            resultado.UnlockBits(datosResultado);


            return resultado;
        }

        public static Bitmap Invertir(this Bitmap bitmapOriginal)
        {
            // Prevenir que el Bitmap no cambie su ubicación en memoria
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0, 0,
                                        bitmapOriginal.Width, bitmapOriginal.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            bitmapOriginal.UnlockBits(datosOriginal);

            // Se recorre cada byte de pixel buffer y sus espacios de color RGBA
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                pixelBuffer[k] = (byte)(255 - pixelBuffer[k]);
                pixelBuffer[k + 1] = (byte)(255 - pixelBuffer[k + 1]);
                pixelBuffer[k + 2] = (byte)(255 - pixelBuffer[k + 2]);
                pixelBuffer[k + 3] = 255;
            }


            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);


            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, datosResultado.Scan0, pixelBuffer.Length);
            resultado.UnlockBits(datosResultado);


            return resultado;
        }

        public static Bitmap TinteColor(this Bitmap bitmapOriginal, bool rojo, bool verde, bool azul)
        {
            // Prevenir que el Bitmap no cambie su ubicación en memoria
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0, 0,
                                        bitmapOriginal.Width, bitmapOriginal.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            bitmapOriginal.UnlockBits(datosOriginal);

            // Se recorre cada byte de pixel buffer y sus espacios de color RGBA
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                if (rojo)
                {
                    pixelBuffer[k] = 0;
                    pixelBuffer[k + 1] = 0;
                    pixelBuffer[k + 2] = (byte)(pixelBuffer[k + 2]);
                    pixelBuffer[k + 3] = 255;

                }
                else if (verde)
                {
                    pixelBuffer[k] = 0;
                    pixelBuffer[k + 1] = (byte)(pixelBuffer[k + 1]);
                    pixelBuffer[k + 2] = 0;
                    pixelBuffer[k + 3] = 255;
                }
                else if (azul)
                {
                    pixelBuffer[k] = (byte)(pixelBuffer[k]);
                    pixelBuffer[k + 1] = 0;
                    pixelBuffer[k + 2] = 0;
                    pixelBuffer[k + 3] = 255;
                }

            }

            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);


            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, datosResultado.Scan0, pixelBuffer.Length);
            resultado.UnlockBits(datosResultado);


            return resultado;
        }

        public static Bitmap Pixelado(this Bitmap bitmapOriginal, int mosaico)
        {
            BitmapData datosOriginal = bitmapOriginal.LockBits(new Rectangle(0,0,
                                       bitmapOriginal.Width, bitmapOriginal.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];
            byte[] resultadoBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            bitmapOriginal.UnlockBits(datosOriginal);

            for (int y = 0; y < bitmapOriginal.Height; y += mosaico)
            {
                for (int x = 0; x < bitmapOriginal.Width; x += mosaico)
                {
                    // En este caso, se toma el color del primer pixel del mosaico para pintarlo por completo
                    int primerPixel = y * datosOriginal.Stride + x * 3;
                    byte azul = pixelBuffer[primerPixel];
                    byte verde = pixelBuffer[primerPixel + 1];
                    byte rojo = pixelBuffer[primerPixel + 2];

                    // Pintamos cada pixel del mosaico
                    for (int ym = 0; ym < mosaico && (y + ym) < bitmapOriginal.Height; ym++)
                    {
                        for (int xm = 0; xm < mosaico && (x + xm) < bitmapOriginal.Width; xm++)
                        {
                            int pixel = (y + ym) * datosOriginal.Stride + (x + xm) * 3;
                            resultadoBuffer[pixel] = azul;
                            resultadoBuffer[pixel + 1] = verde;
                            resultadoBuffer[pixel + 2] = rojo;
                        }
                    }
                }
            }

            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);

            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            Marshal.Copy(resultadoBuffer, 0, datosResultado.Scan0, resultadoBuffer.Length);
            resultado.UnlockBits(datosResultado);

            return resultado;
        }

        public static Bitmap EfectoCaricaturizar(this Bitmap bitmapOriginal, int umbral = 0)
        {
            // Primero se aplica un filtro de suavizado
            ConvolucionBase gaussiano = (ConvolucionBase)(new FiltroGaussiano());
            Bitmap bmpSuavizado = bitmapOriginal.ConvolucionFiltro(gaussiano);

            // Y luego se trabaja con ese bitmap
            BitmapData datosOriginal = bmpSuavizado.LockBits(new Rectangle(0, 0,
                                       bmpSuavizado.Width, bmpSuavizado.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];
            byte[] resultadoBuffer = new byte[datosOriginal.Stride * datosOriginal.Height];

            // Copia los datos del bitmap a pixelbuffer
            Marshal.Copy(datosOriginal.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            bmpSuavizado.UnlockBits(datosOriginal);

            int byteOffset = 0;
            int gradienteAzul = 0, gradienteVerde = 0, gradienteRojo = 0;
            double azul = 0.0, verde = 0.0, rojo = 0.0;

            bool excedeUmbral = false;

            for (int offsetY = 1; offsetY < bmpSuavizado.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX < bmpSuavizado.Width - 1; offsetX++)
                {
                    // Definir el pixel vecino actual
                    byteOffset = offsetY * datosOriginal.Stride + offsetX * 4;

                    gradienteAzul = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                    gradienteAzul += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                        pixelBuffer[byteOffset + datosOriginal.Stride]);

                    // pasamos al verde
                    byteOffset++;

                    gradienteVerde = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                    gradienteVerde += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                        pixelBuffer[byteOffset + datosOriginal.Stride]);

                    // pasamos al rojo
                    byteOffset++;

                    gradienteRojo = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                    gradienteRojo += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                        pixelBuffer[byteOffset + datosOriginal.Stride]);

                    if (gradienteAzul + gradienteVerde + gradienteRojo > umbral)
                    {
                        excedeUmbral = true;
                    }
                    else
                    {
                        // si no se excedio el umbral antes, se revisa con los pixeles vecinos de forma vertical
                        byteOffset -= 2;

                        gradienteAzul = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        // pasamos al verde
                        byteOffset++;

                        gradienteVerde = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        // pasamos al rojo
                        byteOffset++;

                        gradienteRojo = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        if (gradienteAzul + gradienteVerde + gradienteRojo > umbral)
                        {
                            excedeUmbral = true;
                        }
                        else
                        {
                            // si no se excedio el umbral antes, se revisa con los pixeles vecinos
                            // de forma horizontal
                            byteOffset -= 2;

                            gradienteAzul = Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                                pixelBuffer[byteOffset + datosOriginal.Stride]);

                            // pasamos al verde
                            byteOffset++;

                            gradienteVerde = Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                                pixelBuffer[byteOffset + datosOriginal.Stride]);

                            // pasamos al rojo
                            byteOffset++;

                            gradienteRojo = Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride] -
                                pixelBuffer[byteOffset + datosOriginal.Stride]);

                            if (gradienteAzul + gradienteVerde + gradienteRojo > umbral)
                            {
                                excedeUmbral = true;
                            }
                            else
                            {
                                // si no se excedio el umbral antes, se revisa con los pixeles vecinos
                                // dentro de las diagonales
                                byteOffset -= 2;

                                gradienteAzul = Math.Abs(pixelBuffer[byteOffset - 4 - datosOriginal.Stride] -
                                    pixelBuffer[byteOffset + 4 + datosOriginal.Stride]);

                                gradienteAzul += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride + 4] -
                                    pixelBuffer[byteOffset + datosOriginal.Stride - 4]);

                                // pasamos al verde
                                byteOffset++;

                                gradienteVerde = Math.Abs(pixelBuffer[byteOffset - 4 - datosOriginal.Stride] -
                                    pixelBuffer[byteOffset + 4 + datosOriginal.Stride]);

                                gradienteVerde += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride + 4] -
                                    pixelBuffer[byteOffset + datosOriginal.Stride - 4]);

                                // pasamos al rojo
                                byteOffset++;

                                gradienteRojo = Math.Abs(pixelBuffer[byteOffset - 4 - datosOriginal.Stride] -
                                    pixelBuffer[byteOffset + 4 + datosOriginal.Stride]);

                                gradienteRojo += Math.Abs(pixelBuffer[byteOffset - datosOriginal.Stride + 4] -
                                    pixelBuffer[byteOffset + datosOriginal.Stride - 4]);

                                if (gradienteAzul + gradienteVerde + gradienteRojo > umbral)
                                {
                                    excedeUmbral = true;
                                }
                                else
                                {
                                    excedeUmbral = false;
                                }
                            }
                        }
                    }

                    byteOffset -= 2;

                    if (excedeUmbral)
                    {
                        azul = 0;
                        verde = 0;
                        rojo = 0;
                    }
                    else
                    {
                        azul = pixelBuffer[byteOffset];
                        verde = pixelBuffer[byteOffset + 1];
                        rojo = pixelBuffer[byteOffset + 2];
                    }

                    if (azul > 255)
                    { azul = 255; }
                    else if (azul < 0)
                    { azul = 0; }


                    if (verde > 255)
                    { verde = 255; }
                    else if (verde < 0)
                    { verde = 0; }


                    if (rojo > 255)
                    { rojo = 255; }
                    else if (rojo < 0)
                    { rojo = 0; }

                    resultadoBuffer[byteOffset] = (byte)azul;
                    resultadoBuffer[byteOffset + 1] = (byte)verde;
                    resultadoBuffer[byteOffset + 2] = (byte)rojo;
                    resultadoBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultado = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height);

            BitmapData datosResultado = resultado.LockBits(new Rectangle(0, 0,
                                        resultado.Width, resultado.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultadoBuffer, 0, datosResultado.Scan0, resultadoBuffer.Length);
            resultado.UnlockBits(datosResultado);


            return resultado;
        }

    }
}
