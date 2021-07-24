using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_net_5
{
    public class Inspector
    {
        public int id_inspector;
        public String estado;
        public double fin_inspeccion;

        public Inspector(int id_inspector, string estado_Inspector, double fin_inspeccion)
        {
            this.id_inspector = id_inspector;
            this.estado = estado_Inspector;
            this.fin_inspeccion = fin_inspeccion;
        }

        public string GetEstado()
        {
            return this.estado;
        }
    }
}
