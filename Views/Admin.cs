using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    public partial class Admin : Form
    {
        private Operador operador;
        public Admin()
        {
            InitializeComponent();
            operador = new Operador();
        }

        private void AgregarRecursoBtn_Click(object sender, EventArgs e)
        {
            string nombreRecurso = agregarRecursoTxt.Text;
            string ubicacion = recursosUbicacionTxt.Text;
            int cantidadRecurso;

            if (!int.TryParse(cantidadTxt.Text, out cantidadRecurso))
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(nombreRecurso))
            {
                MessageBox.Show("Por favor, ingresa el nombre del recurso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

            string query = "INSERT INTO recursos (nombreRecurso, Cantidad, ubicacion, activo) VALUES (@nombreRecurso, @cantidadRecurso, @ubicacion, @activo)";
            string eventosQuery = "INSERT INTO Eventos(nombreEvento, tipoEvento) VALUES(@nombreEvento, @tipoEvento)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombreRecurso", nombreRecurso);
                                command.Parameters.AddWithValue("@cantidadRecurso", cantidadRecurso);
                                command.Parameters.AddWithValue("@ubicacion", ubicacion);
                                command.Parameters.AddWithValue("@activo", 1);
                                command.ExecuteNonQuery();
                            }

                            using (SqlCommand eventCommand = new SqlCommand(eventosQuery, connection, transaction))
                            {
                                eventCommand.Parameters.AddWithValue("@nombreEvento", $"RECURSO: {nombreRecurso}"); 
                                eventCommand.Parameters.AddWithValue("@tipoEvento", "Agregar");  
                                eventCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Recurso y evento agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            recursosUbicacionTxt.Clear();
                            agregarRecursoTxt.Clear();
                            cantidadTxt.Clear();
                            operador.RefrescarInfo();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error al insertar el recurso o evento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void AgregarDonacionBtn_Click(object sender, EventArgs e)
        {
            string nombreDonacion = nombreDonacionTxt.Text;
            string proveedor = proveedorTxt.Text;
            string ubicacion = donacionesUbicacionTxt.Text;

            if (string.IsNullOrEmpty(nombreDonacion) || string.IsNullOrEmpty(proveedor))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la donación y el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

            string donacionQuery = "INSERT INTO Donacion (nombreDonacion, proveedor, ubicacion, activo) VALUES (@nombreDonacion, @proveedor, @ubicacion, @activo)";
            string eventosQuery = "INSERT INTO Eventos(nombreEvento, tipoEvento) VALUES(@nombreEvento, @tipoEvento)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand command = new SqlCommand(donacionQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombreDonacion", nombreDonacion);
                                command.Parameters.AddWithValue("@proveedor", proveedor);
                                command.Parameters.AddWithValue("@ubicacion", ubicacion);
                                command.Parameters.AddWithValue("@activo", 1);
                                command.ExecuteNonQuery();
                            }

                            using (SqlCommand eventCommand = new SqlCommand(eventosQuery, connection, transaction))
                            {
                                eventCommand.Parameters.AddWithValue("@nombreEvento", $"DONACION: {nombreDonacion}");
                                eventCommand.Parameters.AddWithValue("@tipoEvento", "Agregar"); 
                                eventCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Donación y evento agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            nombreDonacionTxt.Clear();
                            proveedorTxt.Clear();
                            donacionesUbicacionTxt.Clear();
                            operador.RefrescarInfo();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error al agregar la donación o evento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void verTablasBtn_Click(object sender, EventArgs e)
        {
            if (operador == null || operador.IsDisposed)
            {
                operador = new Operador();
            }

            operador.Show();
        }

        private void verTablasEventosBtn_Click(object sender, EventArgs e)
        {
            if (operador != null)
            {
                operador.Hide();
            }

            Eventos eventos = new Eventos();
            eventos.Show();
        }
    }
}
