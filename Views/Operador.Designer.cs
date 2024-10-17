using System.Windows.Forms;

namespace eventos.Views
{
    partial class Operador
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            removeRecursos = new Button();
            removeDonaciones = new Button();
            label3 = new Label();
            dataGridView3 = new DataGridView();
            removeSolicitud = new Button();
            button4 = new Button();
            textBoxNombreRecursoFilter = new TextBox();
            textBoxCantidadFilter = new TextBox();
            textBoxUbicacionFilter = new TextBox();
            button3 = new Button();
            button5 = new Button();
            textBoxUbicacion1Filter = new TextBox();
            textBoxProveedorFilter = new TextBox();
            textBoxNombreDonacionFilter = new TextBox();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            textBoxNombreSolicitorFilter = new TextBox();
            textBoxUrgenciaFilter = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 361);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(592, 213);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(305, 271);
            button1.Name = "button1";
            button1.Size = new Size(298, 23);
            button1.TabIndex = 1;
            button1.Text = "Guardar Cambios Recursos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(312, 580);
            button2.Name = "button2";
            button2.Size = new Size(292, 23);
            button2.TabIndex = 2;
            button2.Text = "Guardar Cambios Donaciones";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 66);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(592, 199);
            dataGridView2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 4;
            label1.Text = "Recursos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 305);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 5;
            label2.Text = "Donaciones";
            // 
            // removeRecursos
            // 
            removeRecursos.Location = new Point(12, 271);
            removeRecursos.Name = "removeRecursos";
            removeRecursos.Size = new Size(296, 23);
            removeRecursos.TabIndex = 6;
            removeRecursos.Text = "Eliminar recursos seleccionados";
            removeRecursos.UseVisualStyleBackColor = true;
            removeRecursos.Click += removeRecursos_Click;
            // 
            // removeDonaciones
            // 
            removeDonaciones.Location = new Point(10, 580);
            removeDonaciones.Name = "removeDonaciones";
            removeDonaciones.Size = new Size(304, 23);
            removeDonaciones.TabIndex = 7;
            removeDonaciones.Text = "Eliminar donaciones seleccionadas";
            removeDonaciones.UseVisualStyleBackColor = true;
            removeDonaciones.Click += removeDonaciones_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(12, 616);
            label3.Name = "label3";
            label3.Size = new Size(103, 25);
            label3.TabIndex = 8;
            label3.Text = "Solicitudes";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(10, 667);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Size = new Size(592, 213);
            dataGridView3.TabIndex = 9;
            // 
            // removeSolicitud
            // 
            removeSolicitud.Location = new Point(10, 886);
            removeSolicitud.Name = "removeSolicitud";
            removeSolicitud.Size = new Size(298, 23);
            removeSolicitud.TabIndex = 10;
            removeSolicitud.Text = "Eliminar solicitudes seleccionadas";
            removeSolicitud.UseVisualStyleBackColor = true;
            removeSolicitud.Click += removeSolicitud_Click;
            // 
            // button4
            // 
            button4.Location = new Point(305, 886);
            button4.Name = "button4";
            button4.Size = new Size(292, 23);
            button4.TabIndex = 11;
            button4.Text = "Guardar Solicitudes Donaciones";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBoxNombreRecursoFilter
            // 
            textBoxNombreRecursoFilter.Location = new Point(134, 37);
            textBoxNombreRecursoFilter.Name = "textBoxNombreRecursoFilter";
            textBoxNombreRecursoFilter.Size = new Size(100, 23);
            textBoxNombreRecursoFilter.TabIndex = 13;
            // 
            // textBoxCantidadFilter
            // 
            textBoxCantidadFilter.Location = new Point(253, 37);
            textBoxCantidadFilter.Name = "textBoxCantidadFilter";
            textBoxCantidadFilter.Size = new Size(100, 23);
            textBoxCantidadFilter.TabIndex = 14;
            // 
            // textBoxUbicacionFilter
            // 
            textBoxUbicacionFilter.Location = new Point(378, 37);
            textBoxUbicacionFilter.Name = "textBoxUbicacionFilter";
            textBoxUbicacionFilter.Size = new Size(100, 23);
            textBoxUbicacionFilter.TabIndex = 15;
            // 
            // button3
            // 
            button3.Location = new Point(621, 103);
            button3.Name = "button3";
            button3.Size = new Size(75, 41);
            button3.TabIndex = 17;
            button3.Text = "Aplicar Filtro";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(621, 170);
            button5.Name = "button5";
            button5.Size = new Size(75, 42);
            button5.TabIndex = 18;
            button5.Text = "Limpiar Filtros";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBoxUbicacion1Filter
            // 
            textBoxUbicacion1Filter.Location = new Point(378, 332);
            textBoxUbicacion1Filter.Name = "textBoxUbicacion1Filter";
            textBoxUbicacion1Filter.Size = new Size(100, 23);
            textBoxUbicacion1Filter.TabIndex = 21;
            // 
            // textBoxProveedorFilter
            // 
            textBoxProveedorFilter.Location = new Point(259, 332);
            textBoxProveedorFilter.Name = "textBoxProveedorFilter";
            textBoxProveedorFilter.Size = new Size(100, 23);
            textBoxProveedorFilter.TabIndex = 20;
            // 
            // textBoxNombreDonacionFilter
            // 
            textBoxNombreDonacionFilter.Location = new Point(134, 332);
            textBoxNombreDonacionFilter.Name = "textBoxNombreDonacionFilter";
            textBoxNombreDonacionFilter.Size = new Size(100, 23);
            textBoxNombreDonacionFilter.TabIndex = 19;
            // 
            // button6
            // 
            button6.Location = new Point(621, 479);
            button6.Name = "button6";
            button6.Size = new Size(75, 42);
            button6.TabIndex = 23;
            button6.Text = "Limpiar Filtros";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(621, 412);
            button7.Name = "button7";
            button7.Size = new Size(75, 41);
            button7.TabIndex = 22;
            button7.Text = "Aplicar Filtro";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(621, 781);
            button8.Name = "button8";
            button8.Size = new Size(75, 42);
            button8.TabIndex = 25;
            button8.Text = "Limpiar Filtros";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(621, 714);
            button9.Name = "button9";
            button9.Size = new Size(75, 41);
            button9.TabIndex = 24;
            button9.Text = "Aplicar Filtro";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // textBoxNombreSolicitorFilter
            // 
            textBoxNombreSolicitorFilter.Location = new Point(134, 638);
            textBoxNombreSolicitorFilter.Name = "textBoxNombreSolicitorFilter";
            textBoxNombreSolicitorFilter.Size = new Size(100, 23);
            textBoxNombreSolicitorFilter.TabIndex = 26;
            // 
            // textBoxUrgenciaFilter
            // 
            textBoxUrgenciaFilter.Location = new Point(296, 638);
            textBoxUrgenciaFilter.Name = "textBoxUrgenciaFilter";
            textBoxUrgenciaFilter.Size = new Size(100, 23);
            textBoxUrgenciaFilter.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 620);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 28;
            label4.Text = "Nombre del solicitor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(296, 620);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 29;
            label5.Text = "Nivel de urgencia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(137, 313);
            label6.Name = "label6";
            label6.Size = new Size(120, 15);
            label6.TabIndex = 30;
            label6.Text = "Nombre de donación";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(399, 313);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 31;
            label7.Text = "Ubicación";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(279, 313);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 32;
            label8.Text = "Proveedor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(122, 17);
            label9.Name = "label9";
            label9.Size = new Size(112, 15);
            label9.TabIndex = 33;
            label9.Text = "Nombre del recurso";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(283, 19);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 34;
            label10.Text = "Cantidad";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(399, 17);
            label11.Name = "label11";
            label11.Size = new Size(60, 15);
            label11.TabIndex = 35;
            label11.Text = "Ubicación";
            // 
            // Operador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 916);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxUrgenciaFilter);
            Controls.Add(textBoxNombreSolicitorFilter);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(textBoxUbicacion1Filter);
            Controls.Add(textBoxProveedorFilter);
            Controls.Add(textBoxNombreDonacionFilter);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(textBoxUbicacionFilter);
            Controls.Add(textBoxCantidadFilter);
            Controls.Add(textBoxNombreRecursoFilter);
            Controls.Add(button4);
            Controls.Add(removeSolicitud);
            Controls.Add(dataGridView3);
            Controls.Add(label3);
            Controls.Add(removeDonaciones);
            Controls.Add(removeRecursos);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Operador";
            Text = "Operador";
            Load += Operador_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label2;
        private Button removeRecursos;
        private Button removeDonaciones;
        private Label label3;
        private DataGridView dataGridView3;
        private Button removeSolicitud;
        private Button button4;
        private BindingSource bindingSource1;
        private TextBox textBoxNombreRecursoFilter;
        private TextBox textBoxCantidadFilter;
        private TextBox textBoxUbicacionFilter;
        private ComboBox comboBoxActivoFilter;
        private Button button3;
        private Button button5;
        private TextBox textBoxUbicacion1Filter;
        private TextBox textBoxProveedorFilter;
        private TextBox textBoxNombreDonacionFilter;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBoxNombreSolicitorFilter;
        private TextBox textBoxUrgenciaFilter;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}