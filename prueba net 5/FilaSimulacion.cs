using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_net_5
{
    public class FilaSimulacion
    {
        public static double conta_pasajeros = 0;
        public static double N1= 0;
        public static double N2 = 0;
        public static double primer_ingreso = 0;

        public double nro_simulacion;
        public double reloj;
        public String evento;

        //Llegada pasajeros
        public double rnd_llegada;
        public double tiempo_entre_llegadas;
        public double proxima_llegada;

        //fin Control RX
        public double rnd_control_RX;
        public double tiempo_Control_RX;
        //public double fin_Crtl_RX_1;
        //public double fin_Crtl_RX_2;//quizas con uno generico va, pero no se por el hecho de pasar objetos maquinas con sus fin
        //public double fin_Crtl_RX_3;
        public double fin_Ctrl_RX;
        //a Inspeccion el cliente?
        public double rnd_objetivo;
        public String a_inspeccion; // SI o NO

        //Fin inspeccion
        public double rnd_1;
        public double rnd_2;
        public double tiempo_inspeccion;
        //public double fin_inspecion_1; //quizas con uno generico va, pero no se por el hecho de pasar objetos inspectores con sus fin
        //public double fin_inspecion_2;
        //public double fin_inspecion_3;
        public double fin_inspeccion;
        //Maquinas
        public MaquinaRX[] maquinas; // aqui creo que manejo todos los estado
        public double cola_maquina;

        //Inspectores
        public Inspector[] inspectores;
        public double cola_inspectores;

        //Acumuladores
        public double ACT_en_sistema;
        public double contador_pasajeros_out;

        public List<Pasajero> pasajeros = new List<Pasajero>();

        Dictionary<String, double> prob_a_inspeccionar = new Dictionary<string, double>();

        public FilaSimulacion() { }

        //politica de fila A
        public FilaSimulacion(double nro_simulacion, double reloj, string evento, double rnd_llegada, double tiempo_entre_llegadas, double proxima_llegada,
            double rnd_control_RX, /*double Fin_Control_RX */double fin_Crtl_RX_1, double fin_Crtl_RX_2, double fin_Crtl_RX_3, double rnd_objetivo, string a_inspeccion,
            double rnd_1, double rnd_2, double tiempo_inspeccion,/*double Fin_inspeccion */ double fin_inspecion_1, double fin_inspecion_2, double fin_inspecion_3,
            MaquinaRX[] maquinas, double cola_maquina, Inspector[] inspectores, double cola_inspectores, 
            double ACT_en_sistema, double contador_pasajeros_out, List<Pasajero> pasajeros, double x) //los eventos fin de ctrl RX y el de fin de inspeccion son manejados por los servidores
        {
            this.nro_simulacion = nro_simulacion;
            this.reloj = reloj;
            this.evento = evento;
            this.rnd_llegada = rnd_llegada;
            this.tiempo_entre_llegadas = tiempo_entre_llegadas;
            this.proxima_llegada = proxima_llegada;
            this.rnd_control_RX = rnd_control_RX;
            //this.fin_Crtl_RX_1 = fin_Crtl_RX_1;
            //this.fin_Crtl_RX_2 = fin_Crtl_RX_2;
            //this.fin_Crtl_RX_3 = fin_Crtl_RX_3;
            //this.fin_control_RX = Fin_Control_RX; ESTO PÔDRIA IR PARA HACERLO VARIABLE SEGUN SERVIDORES
            this.rnd_objetivo = rnd_objetivo;
            this.a_inspeccion = a_inspeccion;
            this.rnd_1 = rnd_1;
            this.rnd_2 = rnd_2;
            this.tiempo_inspeccion = tiempo_inspeccion;
            //this.fin_inspecion_1 = fin_inspecion_1;
            //this.fin_inspecion_2 = fin_inspecion_2;
            //this.fin_inspecion_3 = fin_inspecion_3;
            //this.Fin_inspeccion = Fin_inspeccion;
            this.maquinas = maquinas; //aca manejo los tiempos de fin de ctrl y estados
            this.cola_maquina = cola_maquina;
            this.inspectores = inspectores;//aca manejo estado y fin ispeccion
            this.cola_inspectores = cola_inspectores;
            this.ACT_en_sistema = ACT_en_sistema;
            this.contador_pasajeros_out = contador_pasajeros_out;

            prob_a_inspeccionar.Add("SI", x);
            prob_a_inspeccionar.Add("NO", 1.00);
        }

        public void CalcularProximaLlegada(Random ran_llegada, double media_llegada)
        {
            do
            {
                this.rnd_llegada = Math.Round(ran_llegada.NextDouble(), 10);
            } while (this.rnd_llegada == 0 || this.rnd_llegada == 1); //si es uno o cero sigue calculando

            this.tiempo_entre_llegadas = Math.Round(Distribuciones.CalcularExponencial(media_llegada, this.rnd_llegada), 10); //calcula tiempo entre llegadas y setea el atributo en fila
            this.proxima_llegada = Math.Round(this.tiempo_entre_llegadas + this.reloj, 10) + 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone(); //Que hace este metodo????
        }

        public void LimpiarVector() //que hace exactante el metodo? Creo que pone en cero randoms y entre tiempos y objetivos
        { 
            this.rnd_llegada = 0;
            this.tiempo_entre_llegadas = 0;

            this.rnd_control_RX = 0;
            this.tiempo_Control_RX = 0;

            this.rnd_objetivo = 0;
            this.a_inspeccion = "";

            this.rnd_1 = 0;
            this.rnd_2 = 0;
            this.tiempo_inspeccion = 0; //se calcula con distr normal PORQUE ACUMULADORES NO, entiendo porque no podes poner a cero eso cada vuelta
        }

        public void EjecutarEvento(Random ran_1, double media_llegada, double media_Ctrl_rx, double media_inspeccion, double desv_inspecccion)
        {
            if (this.evento.Equals("Llegada Pasajero_" + conta_pasajeros))
            {
                CalcularProximaLlegada(ran_1, media_llegada);
                GenerarFilaLlegadaPasajero(ran_1,media_Ctrl_rx);
            }
            else if (this.evento.Equals("Fin Control RX (1)") || this.evento.Equals("Fin Control RX (2)") || this.evento.Equals("Fin Control RX (3)") || this.evento.Equals("Fin Control RX (4)")) //se podria resolver con otro metodo que recorre cantidad de servidores
            {
                for (int i = 0; i < this.maquinas.Length; i++)
                {
                    if (this.evento.Equals("Fin Control RX ("+ (i+1) +")"))
                    {
                        this.maquinas[i].finControlRX = 0;
                    }
                } //porque lo seteo a cero a este valor
                GenerarFilaFinCtrlRX(ran_1, media_Ctrl_rx, media_inspeccion, desv_inspecccion);
            }
            else if (this.evento.Equals("Fin Inspeccion (1)") || this.evento.Equals("Fin Inspeccion (2)") || this.evento.Equals("Fin Inspeccion (3)") || this.evento.Equals("Fin Inspeccion (4)"))
            {
                for (int i = 0; i < this.inspectores.Length; i++)
                {
                    if (this.evento.Equals("Fin Inspeccion ("+ (i+1) +")"))
                    {
                        this.inspectores[i].fin_inspeccion = 0;
                    }
                }
                GenerarFilaFinInspeccion(ran_1, media_inspeccion, desv_inspecccion);
            }
        }

        public void GenerarFilaFinInspeccion(Random ran_1, double media_inspeccion, double desv_inspecccion)
        {
            var pasajero_actual = this.pasajeros.Where(x => x.fin_inspeccion == this.reloj).FirstOrDefault(); //busco la persona que detono el evento
            int idInspectorPasajeroActual = pasajero_actual.IdInspectorQueTeAtiende() - 1; //id inspector atendia a la persona

            pasajero_actual.SetFinInspeccion(0); //como ya termino si inspeccion lo pongo en cero
            pasajero_actual.setIdInspector(0);  //ningun inspector ya lo atiende
            pasajero_actual.SetEstado("Accedio Al Vuelo"); //su estado pasa a accedio al vuelo
             

            this.contador_pasajeros_out++; //el fin de inspeccion saca una persona simepre
            this.ACT_en_sistema = Math.Round(this.ACT_en_sistema + this.reloj - pasajero_actual.H_I_S, 2); //como sale debo acumular el timepo en el sistema

            this.pasajeros.Remove(pasajero_actual); //remuevo el pasajero de la lista para hacer reuso de columnas y no se clave el programa
            //ahora yo deberia mirar la cola de inpectores si hay alguien, esa persona pasa a esperar con hora inicio de espera, 

            if (cola_inspectores != 0) //hay gente en la cola de inspectores, por ende todos ocupados hay que buscar el siguiente en la cola de inspectores
                //y calcular su fin de inscpeecion y asginarle ese inpector y 
            {
                DescontarColaInspector();
                Pasajero pasajero_siguiente = BuscarPersonaMayorEsperaEnColaInspectores();
                pasajero_siguiente.setIdInspector(idInspectorPasajeroActual + 1); //le seteo si inspector a la persona que estaba primera en fila de inspeccion
                CalcularFinInspeccion(ran_1, pasajero_siguiente, media_inspeccion, desv_inspecccion, idInspectorPasajeroActual);
                this.inspectores[idInspectorPasajeroActual].estado = "Ocupado";


            }
            else //la cola no tiene gente
            {
                inspectores[idInspectorPasajeroActual].estado = "Libre";
                this.inspectores[idInspectorPasajeroActual].GetEstado();
                //pasajero_actual.estado = "Accedio al vuelo";

            }
        }

        private Pasajero BuscarPersonaMayorEsperaEnColaInspectores()
        {
            Pasajero elegido;

            List<Pasajero> pasajeros_en_espera_Inspeccion = new List<Pasajero>();
            foreach (var pasajero in pasajeros)
            {
                if (pasajero.estado == "EAI")
                {
                    pasajeros_en_espera_Inspeccion.Add(pasajero);
                }
            }
            if (pasajeros_en_espera_Inspeccion.Count != 0)
            {

            }
            elegido = pasajeros_en_espera_Inspeccion.First();
            foreach (var pasajero in pasajeros_en_espera_Inspeccion)
            {

                if (pasajero.H_I_E_I < elegido.H_I_E_I)
                {
                    elegido = pasajero;
                }
            }
            return elegido;
        }

        private void DescontarColaInspector()
        {
            if (cola_inspectores != 0)
            {
                this.cola_inspectores--;
                return;
            }
            return;
        }

        public void GenerarFilaFinCtrlRX(Random ran_1, double media_Ctrl_rx, double media_inspeccion, double desviacionInspeccion)
        {
            var pasajero_actual = this.pasajeros.Where(x => x.fin_ctrl_RX == this.reloj && x.SiendoAtendidoPorAlgunaMaquina()).FirstOrDefault(); //que hace el ultimo metodo
            int idMaquinaPasajeroActual = pasajero_actual.IdMaquinaQueTeAtiende() - 1;  //maquina que lo atendio
            CalcularMontecarloProbabilidad(ran_1,pasajero_actual);
            pasajero_actual.setFinCtrlRX(0); //como ya termino su ctrl lo pongo a cero
            pasajero_actual.setIdMaquina(0); //ninguna maquina ya lo atiende
            
            //debo poner libre la maquina si no hay nadie en la cola

            if (this.a_inspeccion == "NO")
            {
                //DescontarColaMaquina();
                this.contador_pasajeros_out++;
                this.ACT_en_sistema = Math.Round(this.ACT_en_sistema + this.reloj - pasajero_actual.H_I_S, 2);
                
                //si la cola es cero, no hay gente para controlar, debo setear libre a la maquina q se libero y ponerlo en la fila
                if (this.cola_maquina == 0)
                {
                    //seteo libre la quee staba y libre en el evento
                    maquinas[idMaquinaPasajeroActual].SetEstado("Libre");
                    this.maquinas[idMaquinaPasajeroActual].GetEstado();
                    pasajero_actual.estado = "Accedio Al Vuelo";
                    this.pasajeros.Remove(pasajero_actual);
                }

                else //en la cola hay alguien deberia primero ver el que hace menos tiempo ingreso al sistema, generar rnd ctrl rx, entre tiempo setearlo a la maquina liberada, setear la nueva
                //persona con el fin de control y el id de la maquina q lo atiende y el estado siendo atendido SACRX(id) se quedara ocupada la maquina ya que no le seteo el estado
                {
                    DescontarColaMaquina();
                    pasajero_actual.estado = "Accedio al vuelo";
                    this.pasajeros.Remove(pasajero_actual);

                    Pasajero pasajero_siguiente = BuscarPersonaMayorEsperaEnColaRX();
                    pasajero_siguiente.setIdMaquina(idMaquinaPasajeroActual + 1); //le seteo la maquina q se libero recien
                    CalcularFinCtrlRX(ran_1, media_Ctrl_rx, pasajero_siguiente, idMaquinaPasajeroActual);
                    this.maquinas[idMaquinaPasajeroActual].estado = "Ocupado"; //deteo la ocupacion de la maquina
                }
            }

            else  //Si es "SI" va venir por aca! si hay gente en la cola de la maquina se calcula nuev fon de inspeccion, si no hay nadie se descuneta y se pone libre la maq
            //maquina - aparte si no hay gente en la cola de inpectores se asigna el primer inpector al pasajero - si hay gente en cola de inspectores
            //debo poner esa persona en espera y sumar en uno la cola de inspectores
            {
                if (this.cola_maquina == 0) 
                {
                    maquinas[idMaquinaPasajeroActual].SetEstado("Libre");
                    if (cola_inspectores == 0)
                    {
                        int idInspectorLibre = GetIdInspectorLibre();
                        if (idInspectorLibre != -1) //hay uno libre se pude hacer calculo de fin inspeccion
                        {
                            CalcularFinInspeccion(ran_1, pasajero_actual, media_inspeccion, desviacionInspeccion, idInspectorLibre);
                            pasajero_actual.setIdInspector(idInspectorLibre  + 1);
                            this.inspectores[idInspectorLibre].estado = "Ocupado"; //ocupo el inspector
                        }
                        else //no hay inspector libre
                        {
                            pasajero_actual.estado = "EAI";
                            pasajero_actual.H_I_E_I = this.reloj; //esto lo hago para saber quien esta primero en la cola de espera de inspeccion
                            this.cola_inspectores++;
                        }
                        
                    }
                    else //la cola de inspectores es mayor a 1 debo sumar la cola de inspectores, 
                    {
                        this.cola_inspectores++;
                        pasajero_actual.estado = "EAI";
                        pasajero_actual.H_I_E_I = this.reloj;
                    }
                }
                else //la cola de la maquina tiene gente atiendo al que sigue, seteo si idmaquina, calculo su fin control y la maquina seguira ocuapada
                //luego veo a cola de inspecotres para el pasajerp actual y hago la misma logica anterior
                {
                    DescontarColaMaquina();

                    Pasajero pasajero_siguiente = BuscarPersonaMayorEsperaEnColaRX();
                    pasajero_siguiente.setIdMaquina(idMaquinaPasajeroActual + 1);
                    CalcularFinCtrlRX(ran_1, media_Ctrl_rx, pasajero_siguiente, idMaquinaPasajeroActual);
                    this.maquinas[idMaquinaPasajeroActual].estado = "Ocupado";

                    if (cola_inspectores == 0)
                    {
                        int idInspectorLibre = GetIdInspectorLibre();
                        if (idInspectorLibre != -1) //hay uno libre se pude hacer calculo de fin inspeccion
                        {
                            CalcularFinInspeccion(ran_1, pasajero_actual, media_inspeccion, desviacionInspeccion, idInspectorLibre);
                            pasajero_actual.setIdInspector(idInspectorLibre + 1);
                            this.inspectores[idInspectorLibre].estado = "Ocupado"; //ocupo el inspector
                        }
                        else //no hay inspector libre
                        {
                            pasajero_actual.estado = "EAI";
                            pasajero_actual.H_I_E_I = this.reloj; //esto lo hago para saber quien esta primero en la cola de espera de inspeccion
                            this.cola_inspectores++;
                        }

                    }
                    else //la cola de inspectores es mayor a 1 debo sumar la cola de inspectores, 
                    {
                        this.cola_inspectores++;
                        pasajero_actual.estado = "EAI";
                        pasajero_actual.H_I_E_I = this.reloj;
                    }


                }
            }
            


        }

        private int GetIdInspectorLibre()
        {
            int inspector_libre = -1;
            for (int i = 0; i < this.inspectores.Length; i++)
            {
                if (this.inspectores[i].GetEstado() == "Libre")
                    return i;
            }
            return inspector_libre;
        }

        public void CalcularFinInspeccion(Random ran_1, Pasajero pasajero_actual, double media_inspeccion, double desviacionInspeccion, int id_inspector_libre)
        {
            //quizas alla que agregar ingreso par e impar para no recalcular los randoms
            double randon_Inspeccion_1;
            double randon_Inspeccion_2;
            if (primer_ingreso == 0)
            {
                primer_ingreso++;
                randon_Inspeccion_1 = ran_1.NextDouble();
                randon_Inspeccion_2 = ran_1.NextDouble();
                N1 = randon_Inspeccion_1;
                N2 = randon_Inspeccion_2;
                
                //aca obtengo los dos randoms para el calculp de fin isnpeccion
                this.rnd_1 = Math.Round(N1, 10);
                this.rnd_2 = Math.Round(N2, 10);

                this.tiempo_inspeccion = Math.Round(Distribuciones.CalcularNormal(media_inspeccion, desviacionInspeccion, N1, N2),10);

                int redondeo = 10;
                /*if (id_inspector_libre == 1)
                {
                    redondeo = 9;
                }
                if (id_inspector_libre == 2)
                {
                    redondeo = 7;
                }
                if (id_inspector_libre == 3)
                {
                    redondeo = 8;
                }*/

                this.inspectores[id_inspector_libre].fin_inspeccion = Math.Round(this.reloj + this.tiempo_inspeccion, redondeo);

                pasajero_actual.SetEstado("SAI");
                pasajero_actual.SetFinInspeccion(this.inspectores[id_inspector_libre].fin_inspeccion);

                /*for (int i = 0; i < inspectores.Length; i++)
                {
                    if (this.inspectores[id_inspector_libre].fin_inspeccion == this.inspectores[i].fin_inspeccion && id_inspector_libre != i)
                    {
                        this.inspectores[id_inspector_libre].fin_inspeccion += 0.0080000000001;
                        pasajero_actual.SetFinInspeccion(this.inspectores[id_inspector_libre].fin_inspeccion);
                    }
                }*/
            }
            else
            {
                primer_ingreso--;
                this.rnd_1 = Math.Round(N1, 10);
                this.rnd_2 = Math.Round(N2, 10);

                this.tiempo_inspeccion = Math.Round(Distribuciones.CalcularNormal(media_inspeccion, desviacionInspeccion, N1, N2),10);

                int redondeo = 10;
                /*if (id_inspector_libre == 1)
                {
                    redondeo = 9;
                }
                if (id_inspector_libre == 2)
                {
                    redondeo = 7;
                }
                if (id_inspector_libre == 3)
                {
                    redondeo = 8;
                }*/
                this.inspectores[id_inspector_libre].fin_inspeccion = Math.Round(this.reloj + this.tiempo_inspeccion, redondeo);

                pasajero_actual.SetEstado("SAI");
                pasajero_actual.SetFinInspeccion(this.inspectores[id_inspector_libre].fin_inspeccion);

                /*for (int i = 0; i < inspectores.Length; i++)
                {
                    if (this.inspectores[id_inspector_libre].fin_inspeccion == this.inspectores[i].fin_inspeccion && id_inspector_libre != i)
                    {
                        this.inspectores[id_inspector_libre].fin_inspeccion += 0.0080000000001;
                        pasajero_actual.SetFinInspeccion(this.inspectores[id_inspector_libre].fin_inspeccion);
                    }
                }*/

                
            }
            
             
        }

        private Pasajero BuscarPersonaMayorEsperaEnColaRX()
        {
            Pasajero elegido;
            
            List<Pasajero> pasajeros_en_esperaRX = new List<Pasajero>();
            foreach (var pasajero in pasajeros)
            {
                if(pasajero.estado == "EACRX" )
                {
                    pasajeros_en_esperaRX.Add(pasajero);
                }
            }
            if (pasajeros_en_esperaRX.Count != 0)
            {

            }
            elegido = pasajeros_en_esperaRX.First();
            foreach (var pasajero in pasajeros_en_esperaRX)
            {
                
                if (pasajero.H_I_S < elegido.H_I_S)
                {
                    elegido = pasajero;
                }
            }
            return elegido;
        }

        private void DescontarColaMaquina()
        {
            if (cola_maquina != 0)
            {
                this.cola_maquina--;
                return;
            }
            return;
        }

        public void CalcularMontecarloProbabilidad(Random ran_1, Pasajero pasajero)
        {
            do
            {
                this.rnd_objetivo = Math.Round(ran_1.NextDouble(), 2);
            } while (this.rnd_objetivo == 0 || this.rnd_objetivo == 1);

            foreach (var item in prob_a_inspeccionar)
            {
                if (this.rnd_objetivo < item.Value)
                {
                    this.a_inspeccion = item.Key;
                    
                    break;
                }
            }
        }

        public void ActualizarConteoPasajeroOut(FilaSimulacion anterior)
        {
            
        }

        public void ActualizarACTTiemposPasajeroSistema(FilaSimulacion anterior)
        {
            
        }

        public void GenerarFilaLlegadaPasajero(Random ran_1, double media_Ctrl_rx)
        {
            int id_maquina = HayMaquinaLibre(); //-1 si no hay y si hay lo trae
            if (this.cola_maquina == 0 && id_maquina != -1) //cola en cero y maquinas libre
            {
                this.maquinas[id_maquina].estado = "Ocupado";
                Pasajero pasajero = new Pasajero("", this.reloj, 0, id_maquina +1 , 0, 0, 0); // 0 es ninguno, 0 en ingreso a cola de inpectores no significa nada, esto camvbiara
                CalcularFinCtrlRX(ran_1, media_Ctrl_rx, pasajero, id_maquina);
                pasajeros.Add(pasajero);
            }
            else if (this.cola_maquina > 0 || id_maquina == -1)
            {
                this.cola_maquina++;
                Pasajero pasajero = new Pasajero("EACRX", this.reloj, 0, id_maquina+1 , 0, 0, 0);
                pasajero.setFinCtrlRX(0);
                pasajeros.Add(pasajero);
            }
        }

        public void CalcularFinCtrlRX(Random rnd_1, double media_Ctrl_rx, Pasajero pasajero, int id_maquina)
        {
            double random_Ctrl_RX = rnd_1.NextDouble();
            this.rnd_control_RX = Math.Round(random_Ctrl_RX,10);
            this.tiempo_Control_RX = Math.Round(Distribuciones.CalcularExponencial(media_Ctrl_rx, random_Ctrl_RX), 10);
            
            int redondeo = 10;
            /*if (id_maquina == 1)
                 redondeo = 9;
            if (id_maquina == 2)
                redondeo = 8;
            if (id_maquina == 3)
                redondeo = 7;*/

            this.maquinas[id_maquina].finControlRX = Math.Round(this.reloj + this.tiempo_Control_RX, redondeo);

            pasajero.SetEstado("SACRX");
            pasajero.setFinCtrlRX(this.maquinas[id_maquina].finControlRX); //este setado guarda

            /*for (int i = 0; i < maquinas.Length; i++)
            {
                if (this.maquinas[id_maquina].finControlRX == this.maquinas[i].finControlRX && id_maquina != i)
                {
                    this.maquinas[id_maquina].finControlRX += 0.0000000000001;
                    pasajero.setFinCtrlRX(this.maquinas[id_maquina].finControlRX);
                }
            }*/
        }

        private int HayMaquinaLibre()
        {
            int maquina_libre = -1;
            for (int i = 0; i < this.maquinas.Length; i++)
            {
                if (this.maquinas[i].GetEstado() == "Libre")
                    return i;
            }
            return maquina_libre;
        }

        public void ObtenerProximoEvento(FilaSimulacion anterior) //ojo que hay veces que tenes mas de un servidor y no tres, resolver con ciclo for de ultima
        {
            this.nro_simulacion++;

            List<double> tiemposDisparadoresEventos = new List<double>();
            //busca todos aqueeloos tiempos distintos a ceros para luego sacar el minimo
            if (anterior.proxima_llegada != 0) tiemposDisparadoresEventos.Add(anterior.proxima_llegada);
            for (int i = 0; i < maquinas.Length; i++)
            {
                if (anterior.maquinas[i].finControlRX != 0) tiemposDisparadoresEventos.Add(anterior.maquinas[i].finControlRX);
            }
            for (int i = 0; i < inspectores.Length; i++)
            {
                if (anterior.inspectores[i].fin_inspeccion != 0) tiemposDisparadoresEventos.Add(anterior.inspectores[i].fin_inspeccion);
            }

            this.reloj = Math.Round(tiemposDisparadoresEventos.Min(), 10);

            if (this.reloj == anterior.proxima_llegada) { conta_pasajeros++; this.evento = "Llegada Pasajero_" + conta_pasajeros; }
                
            
            //pensar como hacer para saber el numero de pasajero, hacer propiedad nueva q vaya contadno cuando entre a este if puede ser
            for (int i = 0; i < maquinas.Length; i++)
            {
                if (this.reloj == anterior.maquinas[i].finControlRX) this.evento = "Fin Control RX (" + (i+1) + ")"; //ver la forma de saber que pasajero fue el que disparo el evento
            }
            for (int i = 0; i < inspectores.Length; i++)
            {
                if (this.reloj == anterior.inspectores[i].fin_inspeccion) this.evento = "Fin Inspeccion (" + (i+1) + ")";
            }


        }
    }
}
