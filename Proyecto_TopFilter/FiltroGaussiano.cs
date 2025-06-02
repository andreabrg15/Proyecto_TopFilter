using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TopFilter
{
    public class FiltroGaussiano : ConvolucionBase
    {
        private double factor = 1.0 / 136.0;
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filtroMatriz =
            new double[,]   { { 2, 04, 05, 04, 2 },
                            { 4, 09, 12, 09, 4 },
                            { 5, 12, 15, 12, 5 },
                            { 4, 09, 12, 09, 4 },
                            { 2, 04, 05, 04, 2 }, };

        // Para Mayor intensidad:
        //{ { 1,  1,  2,  2,  2,  1,  1, },
        //{ 1,  2,  2,  4,  2,  2,  1, },
        //{ 2,  2,  4,  8,  4,  2,  2, },
        //{ 2,  4,  8, 16,  8,  4,  2, },
        //{ 2,  2,  4,  8,  4,  2,  2, },
        //{ 1,  2,  2,  4,  2,  2,  1, },
        //{ 1,  1,  2,  2,  2,  1,  1, }, };
        public override double[,] FiltroMatriz
        {
            get { return filtroMatriz; }
        }
    }
}
