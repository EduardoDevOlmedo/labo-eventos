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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 453);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(676, 284);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(349, 361);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(341, 31);
            button1.TabIndex = 1;
            button1.Text = "Guardar Cambios Recursos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(356, 745);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(334, 31);
            button2.TabIndex = 2;
            button2.Text = "Guardar Cambios Donaciones";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(14, 73);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(676, 280);
            dataGridView2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 27);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 4;
            label1.Text = "Recursos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(14, 407);
            label2.Name = "label2";
            label2.Size = new Size(139, 32);
            label2.TabIndex = 5;
            label2.Text = "Donaciones";
            // 
            // removeRecursos
            // 
            removeRecursos.Location = new Point(14, 361);
            removeRecursos.Margin = new Padding(3, 4, 3, 4);
            removeRecursos.Name = "removeRecursos";
            removeRecursos.Size = new Size(338, 31);
            removeRecursos.TabIndex = 6;
            removeRecursos.Text = "Eliminar recursos seleccionados";
            removeRecursos.UseVisualStyleBackColor = true;
            removeRecursos.Click += removeRecursos_Click;
            // 
            // removeDonaciones
            // 
            removeDonaciones.Location = new Point(12, 745);
            removeDonaciones.Margin = new Padding(3, 4, 3, 4);
            removeDonaciones.Name = "removeDonaciones";
            removeDonaciones.Size = new Size(348, 31);
            removeDonaciones.TabIndex = 7;
            removeDonaciones.Text = "Eliminar donaciones seleccionadas";
            removeDonaciones.UseVisualStyleBackColor = true;
            removeDonaciones.Click += removeDonaciones_Click;
        // 
        // Operador
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 792);
            Controls.Add(removeDonaciones);
            Controls.Add(removeRecursos);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Operador";
            Text = "Operador";
            Load += Operador_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
    }
}