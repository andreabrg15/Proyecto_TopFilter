using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TopFilter
{
    public abstract class ConvolucionBase
    {
        public abstract double Factor { get; }
        public abstract double Bias { get; }
        public abstract double[,] FiltroMatriz { get; }
    }
}
