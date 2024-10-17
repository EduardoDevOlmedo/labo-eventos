namespace eventos.Views
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            nombreDonacionTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            proveedorTxt = new TextBox();
            agregarDonactionBtn = new Button();
            agregarRecursoBtn = new Button();
            cantidadTxt = new TextBox();
            label5 = new Label();
            agregarRecursoTxt = new TextBox();
            label6 = new Label();
            label7 = new Label();
            recursosUbicacionTxt = new TextBox();
            label8 = new Label();
            donacionesUbicacionTxt = new TextBox();
            verTablasBtn = new Button();
            tablasBtn = new Button();
            eventosBtn = new Button();
            label9 = new Label();
            label10 = new Label();
            nameSolicitor = new TextBox();
            especificacionesSolicitud = new TextBox();
            label11 = new Label();
            bajaPrioridad = new RadioButton();
            mediaPrioridad = new RadioButton();
            altaPrioridad = new RadioButton();
            label12 = new Label();
            agregarSolicitud = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(25, 14);
            label1.Name = "label1";
            label1.Size = new Size(174, 30);
            label1.TabIndex = 1;
            label1.Text = "Agregar Recurso";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(25, 240);
            label2.Name = "label2";
            label2.Size = new Size(189, 30);
            label2.TabIndex = 2;
            label2.Text = "Agregar Donacion";
            // 
            // nombreDonacionTxt
            // 
            nombreDonacionTxt.Location = new Point(25, 297);
            nombreDonacionTxt.Margin = new Padding(3, 2, 3, 2);
            nombreDonacionTxt.Name = "nombreDonacionTxt";
            nombreDonacionTxt.Size = new Size(438, 23);
            nombreDonacionTxt.TabIndex = 4;
            nombreDonacionTxt.Text = "  ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 280);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 5;
            label3.Text = "Nombre de donacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 325);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 7;
            label4.Text = "Proveedor";
            // 
            // proveedorTxt
            // 
            proveedorTxt.Location = new Point(25, 342);
            proveedorTxt.Margin = new Padding(3, 2, 3, 2);
            proveedorTxt.Name = "proveedorTxt";
            proveedorTxt.Size = new Size(438, 23);
            proveedorTxt.TabIndex = 6;
            // 
            // agregarDonactionBtn
            // 
            agregarDonactionBtn.Location = new Point(25, 428);
            agregarDonactionBtn.Margin = new Padding(3, 2, 3, 2);
            agregarDonactionBtn.Name = "agregarDonactionBtn";
            agregarDonactionBtn.Size = new Size(438, 22);
            agregarDonactionBtn.TabIndex = 8;
            agregarDonactionBtn.Text = "Agregar";
            agregarDonactionBtn.UseVisualStyleBackColor = true;
            agregarDonactionBtn.Click += AgregarDonacionBtn_Click;
            // 
            // agregarRecursoBtn
            // 
            agregarRecursoBtn.Location = new Point(25, 198);
            agregarRecursoBtn.Margin = new Padding(3, 2, 3, 2);
            agregarRecursoBtn.Name = "agregarRecursoBtn";
            agregarRecursoBtn.Size = new Size(438, 22);
            agregarRecursoBtn.TabIndex = 9;
            agregarRecursoBtn.Text = "Agregar";
            agregarRecursoBtn.UseVisualStyleBackColor = true;
            agregarRecursoBtn.Click += AgregarRecursoBtn_Click;
            // 
            // cantidadTxt
            // 
            cantidadTxt.Location = new Point(25, 116);
            cantidadTxt.Margin = new Padding(3, 2, 3, 2);
            cantidadTxt.Name = "cantidadTxt";
            cantidadTxt.Size = new Size(438, 23);
            cantidadTxt.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 53);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 11;
            label5.Text = "Nombre de recurso";
            // 
            // agregarRecursoTxt
            // 
            agregarRecursoTxt.Location = new Point(25, 70);
            agregarRecursoTxt.Margin = new Padding(3, 2, 3, 2);
            agregarRecursoTxt.Name = "agregarRecursoTxt";
            agregarRecursoTxt.Size = new Size(438, 23);
            agregarRecursoTxt.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 98);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 13;
            label6.Text = "Cantidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 146);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 15;
            label7.Text = "Ubicacion";
            // 
            // recursosUbicacionTxt
            // 
            recursosUbicacionTxt.Location = new Point(25, 163);
            recursosUbicacionTxt.Margin = new Padding(3, 2, 3, 2);
            recursosUbicacionTxt.Name = "recursosUbicacionTxt";
            recursosUbicacionTxt.Size = new Size(438, 23);
            recursosUbicacionTxt.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 374);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 17;
            label8.Text = "Ubicacion";
            // 
            // donacionesUbicacionTxt
            // 
            donacionesUbicacionTxt.Location = new Point(27, 392);
            donacionesUbicacionTxt.Margin = new Padding(3, 2, 3, 2);
            donacionesUbicacionTxt.Name = "donacionesUbicacionTxt";
            donacionesUbicacionTxt.Size = new Size(438, 23);
            donacionesUbicacionTxt.TabIndex = 16;
            // 
            // verTablasBtn
            // 
            verTablasBtn.Location = new Point(0, 0);
            verTablasBtn.Name = "verTablasBtn";
            verTablasBtn.Size = new Size(75, 23);
            verTablasBtn.TabIndex = 0;
            // 
            // tablasBtn
            // 
            tablasBtn.Location = new Point(27, 464);
            tablasBtn.Margin = new Padding(3, 2, 3, 2);
            tablasBtn.Name = "tablasBtn";
            tablasBtn.Size = new Size(436, 22);
            tablasBtn.TabIndex = 18;
            tablasBtn.Text = "Ver tablas del centro";
            tablasBtn.UseVisualStyleBackColor = true;
            tablasBtn.Click += verTablasBtn_Click;
            // 
            // eventosBtn
            // 
            eventosBtn.Location = new Point(29, 500);
            eventosBtn.Margin = new Padding(3, 2, 3, 2);
            eventosBtn.Name = "eventosBtn";
            eventosBtn.Size = new Size(436, 22);
            eventosBtn.TabIndex = 19;
            eventosBtn.Text = "Ver tabla de eventos";
            eventosBtn.UseVisualStyleBackColor = true;
            eventosBtn.Click += verTablasEventosBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16F);
            label9.Location = new Point(622, 75);
            label9.Name = "label9";
            label9.Size = new Size(180, 30);
            label9.TabIndex = 20;
            label9.Text = "Agregar Solicitud";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(491, 125);
            label10.Name = "label10";
            label10.Size = new Size(115, 15);
            label10.TabIndex = 22;
            label10.Text = "Nombre del solicitor";
            // 
            // nameSolicitor
            // 
            nameSolicitor.Location = new Point(491, 142);
            nameSolicitor.Margin = new Padding(3, 2, 3, 2);
            nameSolicitor.Name = "nameSolicitor";
            nameSolicitor.Size = new Size(438, 23);
            nameSolicitor.TabIndex = 21;
            // 
            // especificacionesSolicitud
            // 
            especificacionesSolicitud.Location = new Point(491, 199);
            especificacionesSolicitud.Multiline = true;
            especificacionesSolicitud.Name = "especificacionesSolicitud";
            especificacionesSolicitud.Size = new Size(438, 125);
            especificacionesSolicitud.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(491, 181);
            label11.Name = "label11";
            label11.Size = new Size(93, 15);
            label11.TabIndex = 24;
            label11.Text = "Especificaciones";
            // 
            // bajaPrioridad
            // 
            bajaPrioridad.AutoSize = true;
            bajaPrioridad.Checked = true;
            bajaPrioridad.Location = new Point(491, 377);
            bajaPrioridad.Name = "bajaPrioridad";
            bajaPrioridad.Size = new Size(47, 19);
            bajaPrioridad.TabIndex = 25;
            bajaPrioridad.TabStop = true;
            bajaPrioridad.Text = "Baja";
            bajaPrioridad.UseVisualStyleBackColor = true;
            // 
            // mediaPrioridad
            // 
            mediaPrioridad.AutoSize = true;
            mediaPrioridad.Location = new Point(681, 377);
            mediaPrioridad.Name = "mediaPrioridad";
            mediaPrioridad.Size = new Size(58, 19);
            mediaPrioridad.TabIndex = 26;
            mediaPrioridad.Text = "Media";
            mediaPrioridad.UseVisualStyleBackColor = true;
            // 
            // altaPrioridad
            // 
            altaPrioridad.AutoSize = true;
            altaPrioridad.Location = new Point(883, 377);
            altaPrioridad.Name = "altaPrioridad";
            altaPrioridad.Size = new Size(46, 19);
            altaPrioridad.TabIndex = 27;
            altaPrioridad.Text = "Alta";
            altaPrioridad.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(491, 351);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 28;
            label12.Text = "Prioridad";
            // 
            // agregarSolicitud
            // 
            agregarSolicitud.Location = new Point(491, 413);
            agregarSolicitud.Margin = new Padding(3, 2, 3, 2);
            agregarSolicitud.Name = "agregarSolicitud";
            agregarSolicitud.Size = new Size(438, 22);
            agregarSolicitud.TabIndex = 29;
            agregarSolicitud.Text = "Agregar";
            agregarSolicitud.UseVisualStyleBackColor = true;
            agregarSolicitud.Click += agregarSolicitud_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 531);
            Controls.Add(agregarSolicitud);
            Controls.Add(label12);
            Controls.Add(altaPrioridad);
            Controls.Add(mediaPrioridad);
            Controls.Add(bajaPrioridad);
            Controls.Add(label11);
            Controls.Add(especificacionesSolicitud);
            Controls.Add(label10);
            Controls.Add(nameSolicitor);
            Controls.Add(label9);
            Controls.Add(eventosBtn);
            Controls.Add(tablasBtn);
            Controls.Add(label8);
            Controls.Add(donacionesUbicacionTxt);
            Controls.Add(label7);
            Controls.Add(recursosUbicacionTxt);
            Controls.Add(label6);
            Controls.Add(cantidadTxt);
            Controls.Add(label5);
            Controls.Add(agregarRecursoTxt);
            Controls.Add(agregarRecursoBtn);
            Controls.Add(agregarDonactionBtn);
            Controls.Add(label4);
            Controls.Add(proveedorTxt);
            Controls.Add(label3);
            Controls.Add(nombreDonacionTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Admin";
            Text = "AGREGANDO - ADMIN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button verTablasBtn;
        private Label label1;
        private Label label2;
        private TextBox nombreDonacionTxt;
        private Label label3;
        private Label label4;
        private TextBox proveedorTxt;
        private Button agregarDonactionBtn;
        private Button agregarRecursoBtn;
        private TextBox cantidadTxt;
        private Label label5;
        private TextBox agregarRecursoTxt;
        private Label label6;
        private Label label7;
        private TextBox recursosUbicacionTxt;
        private Label label8;
        private TextBox donacionesUbicacionTxt;
        private Button tablaEventosBtn;
        private Button tablasBtn;
        private Button eventosBtn;
        private Label label9;
        private Label label10;
        private TextBox nameSolicitor;
        private TextBox especificacionesSolicitud;
        private Label label11;
        private RadioButton bajaPrioridad;
        private RadioButton mediaPrioridad;
        private RadioButton altaPrioridad;
        private Label label12;
        private Button agregarSolicitud;
    }
}