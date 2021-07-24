using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_net_5
{
    public class MaquinaRX
    {
        //*************** Atributos ************
        public int id_maquina;
        public String estado;
        public double finControlRX;

        public MaquinaRX(int id_maquina, string estado_maquina, double finControlRX)
        {
            this.id_maquina = id_maquina;
            this.estado = estado_maquina;
            this.finControlRX = finControlRX;
        }

        public string GetEstado()
        {
            return estado;
        }

        public void SetEstado(string v)
        {
            this.estado = v;
        }
    }
}
