namespace eventos
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Liberar recursos si existen.
            }
            base.Dispose(disposing); // Llama a la base para completar la limpieza.
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox(); // Caja de texto para el nombre de usuario.
            txtPassword = new TextBox(); // Caja de texto para la contraseña.
            btnLogin = new Button(); // Botón para iniciar sesión.
            label1 = new Label(); // Etiqueta "USUARIO".
            label2 = new Label(); // Etiqueta con el título "CENTRO DE ACOPIO".
            label3 = new Label(); // Etiqueta "CONTRASEÑA".
            button1 = new Button(); // Botón "SALIR". 
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(38, 68);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(364, 23);
            txtUsername.TabIndex = 0; // Orden de tabulación.
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(38, 118);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*'; // Ocultar texto con asteriscos.
            txtPassword.Size = new Size(364, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ControlDark;
            btnLogin.Location = new Point(38, 164);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(363, 38);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "INICIAR SESION";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click; // Evento de clic para iniciar sesión.
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 51);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 3;
            label1.Text = "USUARIO"; // Texto para el campo de usuario.
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(107, 14);
            label2.Name = "label2";
            label2.Size = new Size(213, 30);
            label2.TabIndex = 4;
            label2.Text = "CENTRO DE ACOPIO"; // Título del formulario.
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 101);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "CONTRASEÑA"; // Texto para el campo de contraseña.
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Location = new Point(38, 206);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(363, 38);
            button1.TabIndex = 6;
            button1.Text = "SALIR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click; // Evento de clic para salir.
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 276);
            Controls.Add(button1); // Añadir botón salir al formulario.
            Controls.Add(label3);  // Añadir etiqueta contraseña.
            Controls.Add(label2);  // Añadir título.
            Controls.Add(label1);  // Añadir etiqueta usuario.
            Controls.Add(btnLogin); // Añadir botón iniciar sesión.
            Controls.Add(txtPassword); // Añadir campo contraseña.
            Controls.Add(txtUsername); // Añadir campo usuario.
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "INICIO DE SESION"; // Título de la ventana del formulario.
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername; // Campo de entrada para el nombre de usuario.
        private TextBox txtPassword; // Campo de entrada para la contraseña.
        private Button btnLogin; // Botón para iniciar sesión.
        private Label label1; // Etiqueta del campo usuario.
        private Label label2; // Etiqueta del título.
        private Label label3; // Etiqueta del campo contraseña.
        private Button button1; // Botón para salir de la aplicación.
    }
}
