using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prueba_net_5
{
    public partial class FrmPrincipal : Form
    {
        public static double Cola_Maxima_Maquina = 0;
        public static double Cola_Maxima_Inspectores = 0;
        public static double contador_pasajeros_a_mostrar_limite = 0;
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            contador_pasajeros_a_mostrar_limite = 0;
            Cola_Maxima_Maquina = 0;
            Cola_Maxima_Inspectores = 0;
            LimpiarTabla();
            FilaSimulacion.conta_pasajeros = 0;
            
            tablaInspeccion.DataSource = null;
            bool resultado = ValidarCampos();
            if (resultado)
            {
                int nro_simulaciones = GetIteraciones();
                int desde = GetMostrarDesde();
                int hasta = GetCantidadAMostrar();
                tablaInspeccion.DataSource = generarSimulacion(nro_simulaciones, desde, hasta); 
            }
            else
            {
                MessageBox.Show("Corrija los valores porfavor");
                LimpiarCampos();
            }
        }

        private DataTable generarSimulacion(int nro_simulaciones, int desde, int hasta)
        {
            Distribuciones.N1 = 0;
            Distribuciones.N2 = 0;
            Distribuciones.ingreso = 0;
            FilaSimulacion.primer_ingreso = 0;
            //valores de ingreso por parametro para calculos de timjepos de fin o llegadas
            double media_llegada = GetMediaLlegada();
            double media_Ctrl_rx = GetMediaCtrlRX();
            double media_inspeccion = GetMediaInspeccion();
            double desv_inspecccion = GetDesviacionInspeccion();

            Random ran_1 = new Random(); //randoms a usarse en el calculo de la normal o cual
            Random ran_2 = new Random();

            DataTable tabla_simulacion = CargarTabla();

            MaquinaRX maquina_1 = new MaquinaRX(1, "Libre", 0); //set id,estado,sufindecontrolRX
            MaquinaRX maquina_2 = new MaquinaRX(2, "Libre", 0);
            MaquinaRX maquina_3 = new MaquinaRX(3, "Libre", 0);
            int cantidad_maquinas = 3;
            if (chkAgregarMaquinaRX.Checked)
            {
                cantidad_maquinas = 4;
            }
            MaquinaRX[] maquinas = new MaquinaRX[cantidad_maquinas];
            if (chkAgregarMaquinaRX.Checked)
            {
                MaquinaRX maquina_4 = new MaquinaRX(4, "Libre", 0);
                maquinas[0] = maquina_1;
                maquinas[1] = maquina_2;
                maquinas[2] = maquina_3;
                maquinas[3] = maquina_4;
            }
            else
            {
                maquinas[0] = maquina_1;
                maquinas[1] = maquina_2;
                maquinas[2] = maquina_3;
            }
            
            // arreglo de maquinas que estas. se podria ver si chk est activo para agregar una maquina mas a este array

            Inspector inspector_1 = new Inspector(1, "Libre", 0); //set id estado fin inspeccion
            Inspector inspector_2 = new Inspector(2, "Libre", 0);
            Inspector inspector_3 = new Inspector(3, "Libre", 0); //ver del chk si agrego uno mas o no QUIZAS EN LA FILA SIMULACION ALLAN VARIOS CONSTRUCTORES DEBIDO A ESTO O USAR LISTAS
            int cantiInspectores = 3;
            if (chkAgregarInspector.Checked)
            {
                cantiInspectores = 4;
            }
            Inspector[] inspectores = new Inspector[cantiInspectores];
            if (chkAgregarInspector.Checked)
            {
                Inspector inspector_4 = new Inspector(4, "Libre", 0);
                inspectores[0] = inspector_1;
                inspectores[1] = inspector_2;
                inspectores[2] = inspector_3;
                inspectores[3] = inspector_4;
            }
            else
            {
                inspectores[0] = inspector_1;
                inspectores[1] = inspector_2;
                inspectores[2] = inspector_3;
            }

            List<Pasajero> pasajeros = new List<Pasajero>();

            //se crea una fila anterior para usar valores ede la fila anterior y jugar con eso
            FilaSimulacion anterior = new FilaSimulacion();
            double prob_inspeccion = 0.1;
            if (chkQuitarInspeccion.Checked) //quito la probabilidad de que alguien pase x inspeccion ya que no hay servidores que atiendan ahi
            {
                prob_inspeccion = 0;
            }
            //este sera la primer fila de la simulacion evento inicial
            FilaSimulacion actual = new FilaSimulacion(0,0,"Inicializacion",0, //en el mismo orden y disposcion que en el constructor
                0,0,0,0,0,
                0,0,"",0,0,0,
                0,0,0,maquinas,0,
                inspectores,0,0,0,pasajeros,prob_inspeccion);

            actual.CalcularProximaLlegada(ran_1, media_llegada); //setea en la fila la primera llegada con la media y un random calculado
            if (desde == 0)
            {
                AgregarDatosATabla(actual, tabla_simulacion);
            }

            //aqui empeiza el juego
            
            int i = 1;

            while(i < nro_simulaciones + 1)
            {
                
                anterior = (FilaSimulacion)actual.Clone(); //Clona la fila anteorior, metodo que me da C#
                actual.LimpiarVector();
                actual.ObtenerProximoEvento(anterior); //me da el proximo evento y me setea la fila nueva

                actual.EjecutarEvento(ran_1, media_llegada, media_Ctrl_rx, media_inspeccion, desv_inspecccion ); //METODO PADRE
                ObtenerAcumuladores(actual, anterior);

                if (actual.cola_maquina > Cola_Maxima_Maquina)
                {
                    Cola_Maxima_Maquina = actual.cola_maquina;
                }
                if (actual.cola_inspectores > Cola_Maxima_Inspectores)
                {
                    Cola_Maxima_Inspectores = actual.cola_inspectores;
                }

                if ((i >= desde && i <= hasta) || i == nro_simulaciones) //esto muestra la ultima fila despues del or, eso explota los pasajeros traidos
                {
                   AgregarDatosATabla(actual, tabla_simulacion);
                   // if (actual.pasajeros.Count <= 100) //esto limita a mostrar 100 pasajeros
                    //{
                   AgregarPasajerosATabla(tabla_simulacion, actual.pasajeros);
                    
                        //contador_pasajeros_a_mostrar_limite++;
                    //}
                    //ESTA LISTOOOOOO
                }
                i++;  
            }

            CargarEstadisticas(actual);
            lblColaMaxima.Text = Cola_Maxima_Maquina.ToString();
            lblColaMaxInspectores.Text = Cola_Maxima_Inspectores.ToString();
            return tabla_simulacion;
        }

        private void CargarEstadisticas(FilaSimulacion actual)
        {
            if (actual.contador_pasajeros_out == 0)
            {
                MostrarExcepcion("No se puede dividir por cero, ingrese mas simulaciones");
                lblEspPasajero.Text = 0.ToString() + " Segundos";
                return;
            }
            lblEspPasajero.Text = Math.Round((actual.ACT_en_sistema / actual.contador_pasajeros_out),2).ToString() + " Segundos." + "\n" +
                Math.Round(((actual.ACT_en_sistema / actual.contador_pasajeros_out) / 60),2).ToString() + " Minutos.";
        }

        private void AgregarPasajerosATabla(DataTable tabla_simulacion, List<Pasajero> pasajeros) //faltaria como dejar en blanco el estado del pasajero y los tiempos de ingreso a las colas
        {
            //if (contador_pasajeros_a_mostrar_limite <= 100)
            //{
                int cant_objetos_soportados_tabla = (tabla_simulacion.Columns.Count - 29) / 3;
                if (chkAgregarMaquinaRX.Checked || chkAgregarInspector.Checked)
                {
                    cant_objetos_soportados_tabla = (tabla_simulacion.Columns.Count - 31) / 3;
                }

                int cant_objetos = pasajeros.Count;
                int cant_objetos_a_agregar = 0;

                if (cant_objetos_soportados_tabla < cant_objetos)
                {
                    cant_objetos_a_agregar = cant_objetos - cant_objetos_soportados_tabla;
                    for (int i = 1; i <= cant_objetos_a_agregar; i++)
                    {
                        tabla_simulacion.Columns.Add("Estado Pasajero " + (cant_objetos_soportados_tabla + i));
                        tabla_simulacion.Columns.Add("H.I.S " + (cant_objetos_soportados_tabla + i)); //hora ingreso al sistema
                        tabla_simulacion.Columns.Add("H.I.E.I " + (cant_objetos_soportados_tabla + i)); // hora ingreso espera inspeccion (se usa para saber cual pasajero sigue a inspeccion)
                                                                                                        //tabla_simulacion.Columns.Add("Usa Maquina nro " + (cant_objetos_soportados_tabla + i));

                    }
                }
                int ultima_fila = tabla_simulacion.Rows.Count - 1;
                int num_columna = 29;
                if (chkAgregarMaquinaRX.Checked || chkAgregarInspector.Checked) { num_columna = 31; };

                foreach (var pasajero in pasajeros)
                {
                    if (pasajero.estado == "SAI" || pasajero.estado == "EAI")
                    {
                    tabla_simulacion.Rows[ultima_fila][num_columna] = pasajero.estado + "(" + pasajero.id_inspector + ")";
                    }
                    else
                    {
                    tabla_simulacion.Rows[ultima_fila][num_columna] = pasajero.estado + "(" + pasajero.id_maquina + ")"; //cuando espera, este valor sera 0 osea no tiene a ninguno
                    }
                    
                    tabla_simulacion.Rows[ultima_fila][num_columna + 1] = pasajero.H_I_S;
                    tabla_simulacion.Rows[ultima_fila][num_columna + 2] = pasajero.H_I_E_I; //mienstars este valor sea cero hay que desestimarlo
                    num_columna += 3;
                }
                //contador_pasajeros_a_mostrar_limite++;
            //}
            //else
            //{
                return;
            //}

        }

        private void ObtenerAcumuladores(FilaSimulacion actual, FilaSimulacion anterior)
        {
            actual.ActualizarACTTiemposPasajeroSistema(anterior);
            actual.ActualizarConteoPasajeroOut(anterior);
        }

        private void AgregarDatosATabla(FilaSimulacion actual, DataTable tabla)
        {
            if (chkAgregarMaquinaRX.Checked)
            {
                tabla.Rows.Add(
                actual.nro_simulacion,
                actual.evento,
                actual.reloj,

                actual.rnd_llegada > 0 ? actual.rnd_llegada : "",
                actual.tiempo_entre_llegadas > 0 ? actual.tiempo_entre_llegadas : "",
                actual.proxima_llegada > 0 ? actual.proxima_llegada : "",

                actual.rnd_control_RX > 0 ? actual.rnd_control_RX : "",
                actual.tiempo_Control_RX > 0 ? actual.tiempo_Control_RX : "", //hasta aca esta bien

                actual.maquinas[0].finControlRX > 0 ? actual.maquinas[0].finControlRX : "",
                actual.maquinas[1].finControlRX > 0 ? actual.maquinas[1].finControlRX : "",
                actual.maquinas[2].finControlRX > 0 ? actual.maquinas[2].finControlRX : "",
                actual.maquinas[3].finControlRX > 0 ? actual.maquinas[3].finControlRX : "",


                //actual.fin_Crtl_RX_1 > 0 ? actual.fin_Crtl_RX_1 : "", //ESTO PODRIA SER UNO SOLO?????
                //actual.fin_Crtl_RX_2 > 0 ? actual.fin_Crtl_RX_2 : "", 
                //actual.fin_Crtl_RX_3 > 0 ? actual.fin_Crtl_RX_3 : "",
                actual.rnd_objetivo > 0 ? actual.rnd_objetivo : "",
                actual.a_inspeccion.Equals("") ? "" : actual.a_inspeccion,

                actual.rnd_1 > 0 ? actual.rnd_1 : "",
                actual.rnd_2 > 0 ? actual.rnd_2 : "",
                actual.tiempo_inspeccion > 0 ? actual.tiempo_inspeccion : "",

                actual.inspectores[0].fin_inspeccion > 0 ? actual.inspectores[0].fin_inspeccion : "",
                actual.inspectores[1].fin_inspeccion > 0 ? actual.inspectores[1].fin_inspeccion : "",
                actual.inspectores[2].fin_inspeccion > 0 ? actual.inspectores[2].fin_inspeccion : "",

                actual.maquinas[0].estado,
                actual.maquinas[1].estado,
                actual.maquinas[2].estado,
                actual.maquinas[3].estado,
                actual.cola_maquina,

                actual.inspectores[0].estado,
                actual.inspectores[1].estado,
                actual.inspectores[2].estado,
                actual.cola_inspectores,


                actual.ACT_en_sistema,
                actual.contador_pasajeros_out
                );
                return;
            }
            if (chkAgregarInspector.Checked)
            {
                tabla.Rows.Add(
                actual.nro_simulacion,
                actual.evento,
                actual.reloj,

                actual.rnd_llegada > 0 ? actual.rnd_llegada : "",
                actual.tiempo_entre_llegadas > 0 ? actual.tiempo_entre_llegadas : "",
                actual.proxima_llegada > 0 ? actual.proxima_llegada : "",

                actual.rnd_control_RX > 0 ? actual.rnd_control_RX : "",
                actual.tiempo_Control_RX > 0 ? actual.tiempo_Control_RX : "", //hasta aca esta bien

                actual.maquinas[0].finControlRX > 0 ? actual.maquinas[0].finControlRX : "",
                actual.maquinas[1].finControlRX > 0 ? actual.maquinas[1].finControlRX : "",
                actual.maquinas[2].finControlRX > 0 ? actual.maquinas[2].finControlRX : "",


                //actual.fin_Crtl_RX_1 > 0 ? actual.fin_Crtl_RX_1 : "", //ESTO PODRIA SER UNO SOLO?????
                //actual.fin_Crtl_RX_2 > 0 ? actual.fin_Crtl_RX_2 : "", 
                //actual.fin_Crtl_RX_3 > 0 ? actual.fin_Crtl_RX_3 : "",
                actual.rnd_objetivo > 0 ? actual.rnd_objetivo : "",
                actual.a_inspeccion.Equals("") ? "" : actual.a_inspeccion,

                actual.rnd_1 > 0 ? actual.rnd_1 : "",
                actual.rnd_2 > 0 ? actual.rnd_2 : "",
                actual.tiempo_inspeccion > 0 ? actual.tiempo_inspeccion : "",

                actual.inspectores[0].fin_inspeccion > 0 ? actual.inspectores[0].fin_inspeccion : "",
                actual.inspectores[1].fin_inspeccion > 0 ? actual.inspectores[1].fin_inspeccion : "",
                actual.inspectores[2].fin_inspeccion > 0 ? actual.inspectores[2].fin_inspeccion : "",
                actual.inspectores[3].fin_inspeccion > 0 ? actual.inspectores[3].fin_inspeccion : "",

                actual.maquinas[0].estado,
                actual.maquinas[1].estado,
                actual.maquinas[2].estado,
                actual.cola_maquina,

                actual.inspectores[0].estado,
                actual.inspectores[1].estado,
                actual.inspectores[2].estado,
                actual.inspectores[3].estado,
                actual.cola_inspectores,


                actual.ACT_en_sistema,
                actual.contador_pasajeros_out
                );
                return;
            }
            tabla.Rows.Add(
                actual.nro_simulacion,
                actual.evento,
                actual.reloj,
                
                actual.rnd_llegada > 0 ? actual.rnd_llegada : "",
                actual.tiempo_entre_llegadas > 0 ? actual.tiempo_entre_llegadas : "",
                actual.proxima_llegada > 0 ? actual.proxima_llegada : "",

                actual.rnd_control_RX > 0 ? actual.rnd_control_RX : "",
                actual.tiempo_Control_RX > 0 ? actual.tiempo_Control_RX : "", //hasta aca esta bien

                actual.maquinas[0].finControlRX > 0 ? actual.maquinas[0].finControlRX : "",
                actual.maquinas[1].finControlRX > 0 ? actual.maquinas[1].finControlRX : "",
                actual.maquinas[2].finControlRX > 0 ? actual.maquinas[2].finControlRX : "",


                //actual.fin_Crtl_RX_1 > 0 ? actual.fin_Crtl_RX_1 : "", //ESTO PODRIA SER UNO SOLO?????
                //actual.fin_Crtl_RX_2 > 0 ? actual.fin_Crtl_RX_2 : "", 
                //actual.fin_Crtl_RX_3 > 0 ? actual.fin_Crtl_RX_3 : "",
                actual.rnd_objetivo > 0 ? actual.rnd_objetivo : "",
                actual.a_inspeccion.Equals("") ? "" : actual.a_inspeccion,

                actual.rnd_1 > 0 ? actual.rnd_1 : "",
                actual.rnd_2 > 0 ? actual.rnd_2 : "",
                actual.tiempo_inspeccion > 0 ? actual.tiempo_inspeccion : "",

                actual.inspectores[0].fin_inspeccion > 0 ? actual.inspectores[0].fin_inspeccion : "",
                actual.inspectores[1].fin_inspeccion > 0 ? actual.inspectores[1].fin_inspeccion : "",
                actual.inspectores[2].fin_inspeccion > 0 ? actual.inspectores[2].fin_inspeccion : "",

                actual.maquinas[0].estado,
                actual.maquinas[1].estado,
                actual.maquinas[2].estado,
                actual.cola_maquina,
                
                actual.inspectores[0].estado,
                actual.inspectores[1].estado,
                actual.inspectores[2].estado,
                actual.cola_inspectores,
                

                actual.ACT_en_sistema,
                actual.contador_pasajeros_out
                );
        }

        private bool ValidarCampos()
        {
           bool resultado = true;

            if (GetIteraciones() <= 0) {
                MostrarExcepcion("La simulacion debe ser al menos de una fila");
                return false;
                }
            if (GetMostrarDesde() >= GetIteraciones() || GetMostrarDesde() == -1) {
                MostrarExcepcion("El mostrar debe ser menor a la cantidad de iteraciones, para poder mostrar algo" +
                    " o ingreso un Valor negativo o simplemente no ingreso valores");
                return false;

            }
            if (GetCantidadAMostrar() == -1 || GetCantidadAMostrar() > GetIteraciones() - GetMostrarDesde())
            {
                MostrarExcepcion("No ingreso valores en cantidad a mostrar o bien puso un valor que sobre pasa las iteraciones o valor negativo o cero");
            }
            if (GetMediaLlegada() <= 0 || GetMediaInspeccion() <= 0 || GetMediaCtrlRX() <= 0 || 
                (GetMediaInspeccion() == -1 || GetMediaCtrlRX() ==-1) || GetMediaLlegada() == -1) {
                MostrarExcepcion("Los tiempos de las medias deben ser positivos y en segundos o bien sucedio que no ingreso valores en las medias");
                return false;
            }

            if (GetDesviacionInspeccion() == -100000)
            {
                MostrarExcepcion("Debe ingresar un valor en la desviacion");
            }

            return resultado;
        }

        private DataTable CargarTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nro");
            tabla.Columns.Add("Evento");
            tabla.Columns.Add("Reloj (Segundos)");
            //llegada pasajeros
            tabla.Columns.Add("RND Llegada");
            tabla.Columns.Add("Tiempo Entre LLegadas");
            tabla.Columns.Add("Llegada Pasajero");
            //Fin Control Rayos X
            tabla.Columns.Add("RND Control RX");
            tabla.Columns.Add("Tiempo Fin Ctrl RX");
            tabla.Columns.Add("Fin Control RX 1");
            tabla.Columns.Add("Fin Control RX 2");
            tabla.Columns.Add("Fin Control RX 3");
            //podria poner if chk hay una maquina mas agrego la columna
            if (chkAgregarMaquinaRX.Checked == true)
            {
                tabla.Columns.Add("Fin Control RX 4");
            }

            //Tablita montecarlo determina si va a inscpeccion o no
            tabla.Columns.Add("RND Obj"); 
            tabla.Columns.Add("¿A Inspeccion?");

            //Fin Inspeccion
            tabla.Columns.Add("RND 1");
            tabla.Columns.Add("RND 2");
            tabla.Columns.Add("Tiempo Inspeccion");
            tabla.Columns.Add("Fin Inspeccion 1");
            tabla.Columns.Add("Fin Inspeccion 2");
            tabla.Columns.Add("Fin Inspeccion 3");
            //podria poner if chk hay un inspector mas agrego la columna
            if (chkAgregarInspector.Checked)
            {
                tabla.Columns.Add("Fin Inspeccion 4");
            }

            //Maquinas de Rayos x y su cola
            tabla.Columns.Add("Maquina 1 Estado");
            tabla.Columns.Add("Maquina 2 Estado");
            tabla.Columns.Add("Maquina 3 Estado");
            //if chk si agrego una maquina mas
            if (chkAgregarMaquinaRX.Checked)
            {
                tabla.Columns.Add("Maquina 4 Estado");
            }
            
            tabla.Columns.Add("Cola Pasajeros Maquina");

            //Inspectores y su cola
            tabla.Columns.Add("Inspector 1 Estado");
            tabla.Columns.Add("Inspector 2 Estado");
            tabla.Columns.Add("Inspector 3 Estado");
            //if chk si agrego un inspector mas
            if (chkAgregarInspector.Checked)
            {
                tabla.Columns.Add("Inspector 4 Estado");
            }
            tabla.Columns.Add("Cola Pasajeros Inspectores");

            //metricas
            tabla.Columns.Add("Acum Tiempo Pasajeros en Seguridad");
            tabla.Columns.Add("Acum Pasajeros Salen de seguridad");
            

            return tabla;

        }
        //******************Metodos que devuelven los valaores de entrada convertidos a double o entero segun corresponda ***********************************
        public double GetMediaLlegada()
        {
            if (txtMediaLlegadaPasaj.Text == "")
            {
                return -1;
            }
            return Convert.ToDouble(txtMediaLlegadaPasaj.Text);   
        }

        public double GetMediaCtrlRX()
        {
            if (txtMediaCtrlRx.Text == "")
            {
                return -1;
            }
            return Convert.ToDouble(txtMediaCtrlRx.Text);
        }
        public double GetMediaInspeccion()
        {
            if (txtMediaInspecciones.Text == "")
            {
                return -1;
            }
            return Convert.ToDouble(txtMediaInspecciones.Text);
        }
        public double GetDesviacionInspeccion()
        {
            if (txtIteraciones.Text == "")
            {
                return -100000;
            }

            return Convert.ToDouble(txtDesvEstInspecciones.Text);
        }
        public int GetIteraciones()
        {
            if (txtIteraciones.Text == "")
            {
                return -1;
            }
            return Convert.ToInt32(txtIteraciones.Text);
        }

        public int GetMostrarDesde()
        {
            if (txtDesde.Text == "" || Convert.ToInt32(txtDesde.Text) < 0)
            {
                return -1;
            }
            return Convert.ToInt32(txtDesde.Text);
        }

        public int GetCantidadAMostrar()
        {
            if (txtCantidadMostrar.Text == "" || Convert.ToInt32(txtCantidadMostrar.Text) <= 0)
            {
                return -1;
            }
            return Convert.ToInt32(txtCantidadMostrar.Text);
        }
        // *********************************************************************************************************************
        
        public void MostrarTabla(String [] fila)
        {
            tablaInspeccion.Rows.Add(fila);
        }

        public void MostrarColumnas(String nombre, string cabecera)
        {
            tablaInspeccion.Columns.Add(nombre, cabecera);
        }

        public void MostrarExcepcion(string excepcion)
        {
            MessageBox.Show(
                excepcion,
                "Ocurrio Un error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        public void LimpiarTabla()
        {
            tablaInspeccion.Columns.Clear();
            //tablaInspeccion.Rows.Clear();
        }

        public void MostrarResultado(string promedioEspera)
        {
            lblEspPasajero.Text = promedioEspera;
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            //gestor.Exportar();
            LimpiarCampos();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void LimpiarCampos()
        {
            txtCantidadMostrar.Text = "";
            txtDesde.Text = "";
            txtDesvEstInspecciones.Text = "";
            txtIteraciones.Text = "";
            txtMediaCtrlRx.Text = "";
            txtMediaInspecciones.Text = "";
            txtMediaLlegadaPasaj.Text = "";
            LimpiarTabla();
        }

        
    }
}
