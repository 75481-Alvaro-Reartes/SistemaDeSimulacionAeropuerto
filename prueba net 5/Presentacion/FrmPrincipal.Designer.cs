
namespace prueba_net_5
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblColaMaxima = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAgregarInspector = new System.Windows.Forms.CheckBox();
            this.chkAgregarMaquinaRX = new System.Windows.Forms.CheckBox();
            this.chkQuitarInspeccion = new System.Windows.Forms.CheckBox();
            this.lblEspPasajero = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tablaInspeccion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMediaLlegadaPasaj = new System.Windows.Forms.TextBox();
            this.txtMediaCtrlRx = new System.Windows.Forms.TextBox();
            this.txtMediaInspecciones = new System.Windows.Forms.TextBox();
            this.txtDesvEstInspecciones = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSimular = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.txtCantidadMostrar = new System.Windows.Forms.TextBox();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblColaMaxInspectores = new System.Windows.Forms.Label();
            this.pnlTopBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaInspeccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 1);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(16, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(48)))));
            this.pnlTopBar.Controls.Add(this.lblTitulo);
            this.pnlTopBar.Location = new System.Drawing.Point(129, 1);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1044, 106);
            this.pnlTopBar.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(64, 20);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "EXAMEN FINAL SIM EJ 292\r\nReartes Alvaro - 75481\r\n";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblColaMaxInspectores);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblColaMaxima);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.chkQuitarInspeccion);
            this.panel2.Controls.Add(this.lblEspPasajero);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(0, 741);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 117);
            this.panel2.TabIndex = 3;
            // 
            // lblColaMaxima
            // 
            this.lblColaMaxima.AutoSize = true;
            this.lblColaMaxima.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblColaMaxima.ForeColor = System.Drawing.Color.White;
            this.lblColaMaxima.Location = new System.Drawing.Point(235, 81);
            this.lblColaMaxima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColaMaxima.Name = "lblColaMaxima";
            this.lblColaMaxima.Size = new System.Drawing.Size(73, 19);
            this.lblColaMaxima.TabIndex = 29;
            this.lblColaMaxima.Text = "Col Max";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(13, 81);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 19);
            this.label14.TabIndex = 28;
            this.label14.Text = "Cola Maxima Maquinas: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAgregarInspector);
            this.panel1.Controls.Add(this.chkAgregarMaquinaRX);
            this.panel1.Location = new System.Drawing.Point(740, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 80);
            this.panel1.TabIndex = 27;
            // 
            // chkAgregarInspector
            // 
            this.chkAgregarInspector.AutoSize = true;
            this.chkAgregarInspector.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkAgregarInspector.ForeColor = System.Drawing.Color.White;
            this.chkAgregarInspector.Location = new System.Drawing.Point(12, 41);
            this.chkAgregarInspector.Name = "chkAgregarInspector";
            this.chkAgregarInspector.Size = new System.Drawing.Size(167, 23);
            this.chkAgregarInspector.TabIndex = 9;
            this.chkAgregarInspector.Text = "Agregar Inspector";
            this.chkAgregarInspector.UseVisualStyleBackColor = true;
            // 
            // chkAgregarMaquinaRX
            // 
            this.chkAgregarMaquinaRX.AutoSize = true;
            this.chkAgregarMaquinaRX.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkAgregarMaquinaRX.ForeColor = System.Drawing.Color.Transparent;
            this.chkAgregarMaquinaRX.Location = new System.Drawing.Point(12, 15);
            this.chkAgregarMaquinaRX.Name = "chkAgregarMaquinaRX";
            this.chkAgregarMaquinaRX.Size = new System.Drawing.Size(192, 23);
            this.chkAgregarMaquinaRX.TabIndex = 8;
            this.chkAgregarMaquinaRX.Text = "Agregar Maquina RX";
            this.chkAgregarMaquinaRX.UseVisualStyleBackColor = true;
            // 
            // chkQuitarInspeccion
            // 
            this.chkQuitarInspeccion.AutoSize = true;
            this.chkQuitarInspeccion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkQuitarInspeccion.ForeColor = System.Drawing.Color.White;
            this.chkQuitarInspeccion.Location = new System.Drawing.Point(966, 21);
            this.chkQuitarInspeccion.Name = "chkQuitarInspeccion";
            this.chkQuitarInspeccion.Size = new System.Drawing.Size(206, 23);
            this.chkQuitarInspeccion.TabIndex = 10;
            this.chkQuitarInspeccion.Text = "Quitar Area Inspeccion";
            this.chkQuitarInspeccion.UseVisualStyleBackColor = true;
            // 
            // lblEspPasajero
            // 
            this.lblEspPasajero.AutoSize = true;
            this.lblEspPasajero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspPasajero.ForeColor = System.Drawing.Color.White;
            this.lblEspPasajero.Location = new System.Drawing.Point(424, 19);
            this.lblEspPasajero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspPasajero.Name = "lblEspPasajero";
            this.lblEspPasajero.Size = new System.Drawing.Size(258, 19);
            this.lblEspPasajero.TabIndex = 24;
            this.lblEspPasajero.Text = "Valor Promedio espera pasajero";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(13, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(402, 19);
            this.label13.TabIndex = 23;
            this.label13.Text = "Promedio espera por pasajero en llegar a su vuelo:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tablaInspeccion);
            this.panel3.Location = new System.Drawing.Point(4, 111);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1169, 630);
            this.panel3.TabIndex = 4;
            // 
            // tablaInspeccion
            // 
            this.tablaInspeccion.AllowUserToAddRows = false;
            this.tablaInspeccion.AllowUserToDeleteRows = false;
            this.tablaInspeccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaInspeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaInspeccion.Location = new System.Drawing.Point(0, 0);
            this.tablaInspeccion.Name = "tablaInspeccion";
            this.tablaInspeccion.ReadOnly = true;
            this.tablaInspeccion.Size = new System.Drawing.Size(1169, 630);
            this.tablaInspeccion.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1249, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valores Iniciales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1181, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Llegada Pasajeros (Distr. Exp Neg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1181, 297);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Media:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1181, 373);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Control Rayos X (Distr. Exp Neg)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1181, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Media:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1181, 513);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Inspecciones (Distr. Normal)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1181, 581);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Media:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1181, 640);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Desviacion est.:";
            // 
            // txtMediaLlegadaPasaj
            // 
            this.txtMediaLlegadaPasaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtMediaLlegadaPasaj.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMediaLlegadaPasaj.ForeColor = System.Drawing.Color.White;
            this.txtMediaLlegadaPasaj.Location = new System.Drawing.Point(1373, 293);
            this.txtMediaLlegadaPasaj.Margin = new System.Windows.Forms.Padding(4);
            this.txtMediaLlegadaPasaj.Name = "txtMediaLlegadaPasaj";
            this.txtMediaLlegadaPasaj.Size = new System.Drawing.Size(74, 27);
            this.txtMediaLlegadaPasaj.TabIndex = 4;
            this.txtMediaLlegadaPasaj.Text = "9";
            // 
            // txtMediaCtrlRx
            // 
            this.txtMediaCtrlRx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtMediaCtrlRx.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMediaCtrlRx.ForeColor = System.Drawing.Color.White;
            this.txtMediaCtrlRx.Location = new System.Drawing.Point(1373, 432);
            this.txtMediaCtrlRx.Margin = new System.Windows.Forms.Padding(4);
            this.txtMediaCtrlRx.Name = "txtMediaCtrlRx";
            this.txtMediaCtrlRx.Size = new System.Drawing.Size(74, 27);
            this.txtMediaCtrlRx.TabIndex = 5;
            this.txtMediaCtrlRx.Text = "24";
            // 
            // txtMediaInspecciones
            // 
            this.txtMediaInspecciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtMediaInspecciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMediaInspecciones.ForeColor = System.Drawing.Color.White;
            this.txtMediaInspecciones.Location = new System.Drawing.Point(1373, 581);
            this.txtMediaInspecciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtMediaInspecciones.Name = "txtMediaInspecciones";
            this.txtMediaInspecciones.Size = new System.Drawing.Size(74, 27);
            this.txtMediaInspecciones.TabIndex = 6;
            this.txtMediaInspecciones.Text = "240";
            // 
            // txtDesvEstInspecciones
            // 
            this.txtDesvEstInspecciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtDesvEstInspecciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDesvEstInspecciones.ForeColor = System.Drawing.Color.White;
            this.txtDesvEstInspecciones.Location = new System.Drawing.Point(1373, 637);
            this.txtDesvEstInspecciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesvEstInspecciones.Name = "txtDesvEstInspecciones";
            this.txtDesvEstInspecciones.Size = new System.Drawing.Size(74, 27);
            this.txtDesvEstInspecciones.TabIndex = 7;
            this.txtDesvEstInspecciones.Text = "120";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 106);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSimular
            // 
            this.btnSimular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.btnSimular.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSimular.ForeColor = System.Drawing.Color.White;
            this.btnSimular.Location = new System.Drawing.Point(1190, 741);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(291, 39);
            this.btnSimular.TabIndex = 17;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = false;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.btnExportar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(1190, 789);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(291, 39);
            this.btnExportar.TabIndex = 18;
            this.btnExportar.Text = "Limpar Campos";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1181, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(249, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Simulacion (en Segundos)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1182, 191);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 19);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mostrar Hasta Iterac.:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1182, 155);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Mostrar Desde Iterac.:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1182, 122);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Iteraciones:";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtIteraciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIteraciones.ForeColor = System.Drawing.Color.White;
            this.txtIteraciones.Location = new System.Drawing.Point(1373, 118);
            this.txtIteraciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(74, 27);
            this.txtIteraciones.TabIndex = 1;
            this.txtIteraciones.Text = "1000";
            // 
            // txtCantidadMostrar
            // 
            this.txtCantidadMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtCantidadMostrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCantidadMostrar.ForeColor = System.Drawing.Color.White;
            this.txtCantidadMostrar.Location = new System.Drawing.Point(1373, 186);
            this.txtCantidadMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadMostrar.Name = "txtCantidadMostrar";
            this.txtCantidadMostrar.Size = new System.Drawing.Size(74, 27);
            this.txtCantidadMostrar.TabIndex = 3;
            this.txtCantidadMostrar.Text = "200";
            // 
            // txtDesde
            // 
            this.txtDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.txtDesde.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDesde.ForeColor = System.Drawing.Color.White;
            this.txtDesde.Location = new System.Drawing.Point(1373, 151);
            this.txtDesde.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(74, 27);
            this.txtDesde.TabIndex = 2;
            this.txtDesde.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(344, 81);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(213, 19);
            this.label15.TabIndex = 30;
            this.label15.Text = "Cola Maxima Inspectores: ";
            // 
            // lblColaMaxInspectores
            // 
            this.lblColaMaxInspectores.AutoSize = true;
            this.lblColaMaxInspectores.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblColaMaxInspectores.ForeColor = System.Drawing.Color.White;
            this.lblColaMaxInspectores.Location = new System.Drawing.Point(575, 81);
            this.lblColaMaxInspectores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColaMaxInspectores.Name = "lblColaMaxInspectores";
            this.lblColaMaxInspectores.Size = new System.Drawing.Size(73, 19);
            this.lblColaMaxInspectores.TabIndex = 31;
            this.lblColaMaxInspectores.Text = "Col Max";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1529, 850);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.txtCantidadMostrar);
            this.Controls.Add(this.txtIteraciones);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnSimular);
            this.Controls.Add(this.txtDesvEstInspecciones);
            this.Controls.Add(this.txtMediaInspecciones);
            this.Controls.Add(this.txtMediaCtrlRx);
            this.Controls.Add(this.txtMediaLlegadaPasaj);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examen Final SIM Ej 292 - Reartes Alvaro 75481";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaInspeccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMediaLlegadaPasaj;
        private System.Windows.Forms.TextBox txtMediaCtrlRx;
        private System.Windows.Forms.TextBox txtMediaInspecciones;
        private System.Windows.Forms.TextBox txtDesvEstInspecciones;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.TextBox txtCantidadMostrar;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAgregarInspector;
        private System.Windows.Forms.CheckBox chkAgregarMaquinaRX;
        private System.Windows.Forms.CheckBox chkQuitarInspeccion;
        private System.Windows.Forms.Label lblEspPasajero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView tablaInspeccion;
        private System.Windows.Forms.Label lblColaMaxima;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblColaMaxInspectores;
        private System.Windows.Forms.Label label15;
    }
}

