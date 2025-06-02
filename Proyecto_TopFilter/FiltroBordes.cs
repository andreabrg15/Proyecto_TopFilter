using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TopFilter
{
    public class FiltroBordes : ConvolucionBase
    {
        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        // Matriz laplaciana para detectar los bordes
        // Se detectan las zonas donde hay cambios pronunciados
        private double[,] filtroMatriz =
            new double[,] { { -1, -1, -1, -1, -1, },
                            { -1, -1, -1, -1, -1, },
                            { -1, -1, 24, -1, -1, },
                            { -1, -1, -1, -1, -1, },
                            { -1, -1, -1, -1, -1  } };
        public override double[,] FiltroMatriz
        {
            get { return filtroMatriz; }
        }
    }
}
