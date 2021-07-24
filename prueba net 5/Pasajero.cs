using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_net_5
{
    public  class Pasajero
    {
        //se podria agregar in id de pasajero? creo que si
        public string estado;
        public double H_I_S;
        public double H_I_E_I; //hora ingreso espera en inspeccion
        public int id_maquina; //maquina que los esta tendiendo
        public int id_inspector; //inspector que lo atiende

        public double fin_ctrl_RX; //estos atributos nose si son necesario veremos
        public double fin_inspeccion;

        public Pasajero() { }

        public Pasajero(string estado, double H_I_S, double H_I_E_I, int id_maquina, int id_inspector, double fin_ctrl_RX, double fin_inspeccion) 
        {
            this.estado = estado;
            this.H_I_S = H_I_S;
            this.H_I_E_I = H_I_E_I;
            this.id_maquina = id_maquina;/**
                                          * 0- ninguno, 1- maquina 1, 2- maquina 2, 3- maquina 3, 4- maquina  4
                                          */
            this.id_inspector = id_inspector;/**
                                          * 0- ninguno, 1- maquina 1, 2- maquina 2, 3- maquina 3, 4- maquina  4
                                          */
            this.fin_ctrl_RX = fin_ctrl_RX;
            this.fin_inspeccion = fin_inspeccion;
        }

        public void SetEstado(string estado)
        {
            this.estado = estado;
        }

        public void setFinCtrlRX(double finControlRX)
        {
            this.fin_ctrl_RX = finControlRX;
        }

        public bool SiendoAtendidoPorAlgunaMaquina()
        {
            if (this.id_maquina != 0) return true;
            return false;   
        }

        public void setIdMaquina(int v)
        {
            this.id_maquina = v;
        }

        public int IdMaquinaQueTeAtiende()
        {
            return this.id_maquina;
        }

        internal int IdInspectorQueTeAtiende()
        {
            return this.id_inspector;
        }

        public void SetFinInspeccion(double fin_inspeccion)
        {
            this.fin_inspeccion = fin_inspeccion;
        }

        public void setIdInspector(int idInspectorLibre)
        {
            this.id_inspector = idInspectorLibre;
        }
    }
}
