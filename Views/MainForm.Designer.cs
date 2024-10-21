namespace eventos.Views
{
    partial class MainForm
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
                components.Dispose(); // Liberar recursos si existen.
            }
            base.Dispose(disposing); // Llama a la base para limpiar.
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F); // Configura la escala automática del formulario.
            AutoScaleMode = AutoScaleMode.Font; // Define el modo de escala.
            ClientSize = new Size(800, 450); // Tamaño del formulario.
            Name = "MainForm"; // Nombre del formulario.
            Text = "MainForm"; // Título que aparece en la ventana.
            ResumeLayout(false); // Reanuda el diseño.
        }

        #endregion
    }
}
