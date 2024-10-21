using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using eventos.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eventos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); // Inicializar los componentes del formulario.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; // Obtener el nombre de usuario.
            string password = txtPassword.Text; // Obtener la contraseña.

            // Verificar si los campos están vacíos.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa tanto el usuario como la contraseña.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener ejecución si faltan datos.
            }

            // Cadena de conexión a la base de datos.
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";
            string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password"; // Consulta SQL.

            // Establecer la conexión con SQL Server.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Abrir la conexión.

                    // Crear y preparar el comando SQL.
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros a la consulta.
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        // Ejecutar la consulta y obtener el resultado.
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString()!; // Convertir el resultado a string.

                            // Verificar el rol del usuario.
                            if (role == "admin")
                            {
                                Admin admin = new Admin(); // Abrir la vista de administrador.
                                admin.Show();
                            }
                            else
                            {
                                Operador operador = new Operador(); // Abrir la vista de operador.
                                operador.Show();
                            }

                            this.Hide(); // Ocultar el formulario de login.
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores de conexión.
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cerrar la aplicación al hacer clic en el botón "SALIR".
        }
    }
}
