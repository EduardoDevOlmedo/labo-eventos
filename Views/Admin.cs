using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    public partial class Admin : Form
    {
        // Instancia de la clase Operador, utilizada para manejar ciertas operaciones en la interfaz de usuario.
        private Operador operador;

        // Constructor de la clase Admin.
        public Admin()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            operador = new Operador(); // Inicializa la instancia de Operador.
        }

        // Evento que se activa al hacer clic en el botón para agregar un recurso.
        private void AgregarRecursoBtn_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los campos de texto.
            string nombreRecurso = agregarRecursoTxt.Text;
            string ubicacion = recursosUbicacionTxt.Text;
            int cantidadRecurso;

            // Verifica si la cantidad es un número válido.
            if (!int.TryParse(cantidadTxt.Text, out cantidadRecurso))
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sale del método si la cantidad no es válida.
            }

            // Verifica que el nombre del recurso no esté vacío.
            if (string.IsNullOrEmpty(nombreRecurso))
            {
                MessageBox.Show("Por favor, ingresa el nombre del recurso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sale del método si el nombre del recurso es nulo o vacío.
            }

            // Cadena de conexión a la base de datos.
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

            // Consulta SQL para insertar el recurso y el evento asociado.
            string query = "INSERT INTO recursos (nombreRecurso, Cantidad, ubicacion, activo) VALUES (@nombreRecurso, @cantidadRecurso, @ubicacion, @activo)";
            string eventosQuery = "INSERT INTO Eventos(nombreEvento, tipoEvento) VALUES(@nombreEvento, @tipoEvento)";

            // Se establece la conexión con la base de datos.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Abre la conexión.

                    // Inicia una transacción para garantizar la integridad de los datos.
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserta el recurso en la base de datos.
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombreRecurso", nombreRecurso);
                                command.Parameters.AddWithValue("@cantidadRecurso", cantidadRecurso);
                                command.Parameters.AddWithValue("@ubicacion", ubicacion);
                                command.Parameters.AddWithValue("@activo", 1);
                                command.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            // Inserta el evento asociado en la tabla de eventos.
                            using (SqlCommand eventCommand = new SqlCommand(eventosQuery, connection, transaction))
                            {
                                eventCommand.Parameters.AddWithValue("@nombreEvento", $"RECURSO: {nombreRecurso}");
                                eventCommand.Parameters.AddWithValue("@tipoEvento", "Agregar");
                                eventCommand.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            transaction.Commit(); // Confirma la transacción.

                            // Muestra un mensaje de éxito y limpia los campos de texto.
                            MessageBox.Show("Recurso y evento agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            recursosUbicacionTxt.Clear();
                            agregarRecursoTxt.Clear();
                            cantidadTxt.Clear();
                            operador.RefrescarInfo(); // Refresca la información en la interfaz.
                        }
                        catch (Exception ex)
                        {
                            // En caso de error, se revierte la transacción.
                            transaction.Rollback();
                            MessageBox.Show($"Error al insertar el recurso o evento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja los errores de conexión.
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento que se activa al hacer clic en el botón para agregar una donación.
        private void AgregarDonacionBtn_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los campos de texto.
            string nombreDonacion = nombreDonacionTxt.Text;
            string proveedor = proveedorTxt.Text;
            string ubicacion = donacionesUbicacionTxt.Text;

            // Verifica que los campos no estén vacíos.
            if (string.IsNullOrEmpty(nombreDonacion) || string.IsNullOrEmpty(proveedor))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la donación y el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sale del método si algún campo está vacío.
            }

            // Cadena de conexión a la base de datos.
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

            // Consulta SQL para insertar la donación y el evento asociado.
            string donacionQuery = "INSERT INTO Donacion (nombreDonacion, proveedor, ubicacion, activo) VALUES (@nombreDonacion, @proveedor, @ubicacion, @activo)";
            string eventosQuery = "INSERT INTO Eventos(nombreEvento, tipoEvento) VALUES(@nombreEvento, @tipoEvento)";

            // Se establece la conexión con la base de datos.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Abre la conexión.

                    // Inicia una transacción para garantizar la integridad de los datos.
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserta la donación en la base de datos.
                            using (SqlCommand command = new SqlCommand(donacionQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombreDonacion", nombreDonacion);
                                command.Parameters.AddWithValue("@proveedor", proveedor);
                                command.Parameters.AddWithValue("@ubicacion", ubicacion);
                                command.Parameters.AddWithValue("@activo", 1);// El recurso se marca como activo
                                command.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            // Inserta el evento asociado en la tabla de eventos.
                            using (SqlCommand eventCommand = new SqlCommand(eventosQuery, connection, transaction))
                            {
                                eventCommand.Parameters.AddWithValue("@nombreEvento", $"DONACION: {nombreDonacion}");
                                eventCommand.Parameters.AddWithValue("@tipoEvento", "Agregar");
                                eventCommand.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            transaction.Commit(); // Confirma la transacción.

                            // Muestra un mensaje de éxito y limpia los campos de texto.
                            MessageBox.Show("Donación y evento agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nombreDonacionTxt.Clear();
                            proveedorTxt.Clear();
                            donacionesUbicacionTxt.Clear();
                            operador.RefrescarInfo(); // Refresca la información en la interfaz.
                        }
                        catch (Exception ex)
                        {
                            // En caso de error, se revierte la transacción.
                            transaction.Rollback();
                            MessageBox.Show($"Error al agregar la donación o evento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja los errores de conexión.
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Muestra la ventana de operador para ver tablas.
        private void verTablasBtn_Click(object sender, EventArgs e)
        {
            if (operador == null || operador.IsDisposed)
            {
                operador = new Operador();
            }
            operador.Show(); // Muestra la ventana de operador.
        }

        // Muestra la ventana de eventos.
        private void verTablasEventosBtn_Click(object sender, EventArgs e)
        {
            Eventos eventos = new Eventos();
            eventos.Show(); // Muestra la ventana de eventos.
        }

        // Evento para agregar una solicitud con diferentes niveles de urgencia.
        private void agregarSolicitud_Click(object sender, EventArgs e)
        {
            string namesolicitud = nameSolicitor.Text;
            string especificaciones = especificacionesSolicitud.Text;
            int value = 1;

            // Determina el nivel de prioridad.
            if (bajaPrioridad.Checked)
            {
                value = 1;
            }
            if (mediaPrioridad.Checked)
            {
                value = 2;
            }
            if (altaPrioridad.Checked)
            {
                value = 3;
            }

            // Verifica que los campos no estén vacíos.
            if (string.IsNullOrEmpty(namesolicitud) || string.IsNullOrEmpty(especificaciones))
            {
                MessageBox.Show("Por favor, ingrese todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int atendida = 0; // Estado inicial de la solicitud (no atendida).

            // Cadena de conexión a la base de datos.
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

            // Consulta SQL para insertar la solicitud y el evento asociado.
            string donacionQuery = "INSERT INTO Solicitudes (nombreSolicitor, nivelUrgencia, atendida, especificacion) VALUES (@namesolicitud, @value, @atendida, @especificaciones)";
            string eventosQuery = "INSERT INTO Eventos(nombreEvento, tipoEvento) VALUES(@nombreEvento, @tipoEvento)";

            // Se establece la conexión con la base de datos.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Abre la conexión.

                    // Inicia una transacción para garantizar la integridad de los datos.
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserta la solicitud en la base de datos.
                            using (SqlCommand command = new SqlCommand(donacionQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@namesolicitud", namesolicitud);
                                command.Parameters.AddWithValue("@value", value);
                                command.Parameters.AddWithValue("@atendida", atendida);
                                command.Parameters.AddWithValue("@especificaciones", especificaciones);
                                command.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            // Inserta el evento asociado en la tabla de eventos.
                            using (SqlCommand eventCommand = new SqlCommand(eventosQuery, connection, transaction))
                            {
                                eventCommand.Parameters.AddWithValue("@nombreEvento", $"SOLICITUD: {namesolicitud}");
                                eventCommand.Parameters.AddWithValue("@tipoEvento", "Agregar");
                                eventCommand.ExecuteNonQuery(); // Ejecuta el comando.
                            }

                            transaction.Commit(); // Confirma la transacción.

                            // Muestra un mensaje de éxito y limpia los campos de texto.
                            MessageBox.Show("Solicitud y evento agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nameSolicitor.Clear();
                            especificacionesSolicitud.Clear();
                            operador.RefrescarInfo(); // Refresca la información en la interfaz.
                        }
                        catch (Exception ex)
                        {
                            // En caso de error, se revierte la transacción.
                            transaction.Rollback();
                            MessageBox.Show($"Error al agregar la solicitud o evento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja los errores de conexión.
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;// Sale del método para evitar continuar con la ejecución si los campos no son válidos
                }
            }
        }
    }
}
