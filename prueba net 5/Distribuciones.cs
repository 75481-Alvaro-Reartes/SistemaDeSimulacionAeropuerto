using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_net_5
{
    public class Distribuciones
    {
        public static double N1 { get; set; }
        public static double N2 { get; set; }
        public static int ingreso { get; set; } = 0;
        public static double CalcularExponencial(double media, double random)
        {
            return Math.Round(((-media) * Math.Log(1 - random)), 10);
        }

        public static double CalcularNormal(double media, double desviacion, double rnd1, double rnd2)
        {     
            if (ingreso == 0) // ingreso impar o el primero de todos, calculo y devuelvo
            {
                double n1 = Math.Abs(Math.Round((((Math.Sqrt(-2 * Math.Log(rnd1)) * Math.Cos(2 * Math.PI * rnd2)) * desviacion) + media), 10));
                double n2 = Math.Abs(Math.Round((((Math.Sqrt(-2 * Math.Log(rnd1)) * Math.Sin(2 * Math.PI * rnd2)) * desviacion) + media), 10));
                N1 = n1;
                N2 = n2;
                ingreso++;
                return N1;
            }
            else
            {
                ingreso--; // decremento para hacerlo par otra vez y recalcular valores normales
                return N2;
            }           
        }
    }
}
