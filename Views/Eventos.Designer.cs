namespace eventos.Views
{
    partial class Eventos
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
            eventosGridView = new DataGridView();
            label1 = new Label();
            goBackBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)eventosGridView).BeginInit();
            SuspendLayout();
            // 
            // eventosGridView
            // 
            eventosGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            eventosGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            eventosGridView.Location = new Point(21, 78);
            eventosGridView.Name = "eventosGridView";
            eventosGridView.RowHeadersWidth = 51;
            eventosGridView.Size = new Size(584, 188);
            eventosGridView.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(236, 37);
            label1.TabIndex = 1;
            label1.Text = "Eventos realizados";
            // 
            // goBackBtn
            // 
            goBackBtn.Location = new Point(21, 298);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new Size(584, 29);
            goBackBtn.TabIndex = 2;
            goBackBtn.Text = "Volver a tablas del centro";
            goBackBtn.UseVisualStyleBackColor = true;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // Eventos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 366);
            Controls.Add(goBackBtn);
            Controls.Add(label1);
            Controls.Add(eventosGridView);
            Name = "Eventos";
            Text = "Eventos";
            ((System.ComponentModel.ISupportInitialize)eventosGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView eventosGridView;
        private Label label1;
        private Button goBackBtn;
    }
}