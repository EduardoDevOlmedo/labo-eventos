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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)eventosGridView).BeginInit();
            SuspendLayout();
            // 
            // eventosGridView
            // 
            eventosGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            eventosGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            eventosGridView.Location = new Point(18, 58);
            eventosGridView.Margin = new Padding(3, 2, 3, 2);
            eventosGridView.Name = "eventosGridView";
            eventosGridView.RowHeadersWidth = 51;
            eventosGridView.Size = new Size(511, 141);
            eventosGridView.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(18, 16);
            label1.Name = "label1";
            label1.Size = new Size(191, 30);
            label1.TabIndex = 1;
            label1.Text = "Eventos realizados";
            // 
            // goBackBtn
            // 
            goBackBtn.Location = new Point(18, 241);
            goBackBtn.Margin = new Padding(3, 2, 3, 2);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new Size(511, 22);
            goBackBtn.TabIndex = 2;
            goBackBtn.Text = "Volver a tablas del centro";
            goBackBtn.UseVisualStyleBackColor = true;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(18, 204);
            button1.Name = "button1";
            button1.Size = new Size(511, 23);
            button1.TabIndex = 3;
            button1.Text = "Actualizar...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Eventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 274);
            Controls.Add(button1);
            Controls.Add(goBackBtn);
            Controls.Add(label1);
            Controls.Add(eventosGridView);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button button1;
    }
}