using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TopFilter
{
    public class FiltroRelieve : ConvolucionBase
    {
        private double factor = 1.0;

        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 128.0;

        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filtroMatriz =
            new double[,] { { 2, 0, 0 },
                            { 0, -1, 0 },
                            { 0, 0, -1 } };

        public override double[,] FiltroMatriz
        {
            get { return filtroMatriz; }
        }
    }
}
