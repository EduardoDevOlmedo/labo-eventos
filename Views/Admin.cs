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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    operador.GuardarInfo();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreRecurso", nombreRecurso);
                        command.Parameters.AddWithValue("@cantidadRecurso", cantidadRecurso);
                        command.Parameters.AddWithValue("@ubicacion", ubicacion);
                        command.Parameters.AddWithValue("@activo", 1);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Recurso agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    recursosUbicacionTxt.Clear();
                    agregarRecursoTxt.Clear();
                    cantidadTxt.Clear();
                    operador.RefrescarInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el recurso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string query = "INSERT INTO Donacion (nombreDonacion, proveedor, ubicacion, activo) VALUES (@nombreDonacion, @proveedor, @ubicacion, @activo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    operador.GuardarInfo();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreDonacion", nombreDonacion);
                        command.Parameters.AddWithValue("@proveedor", proveedor);
                        command.Parameters.AddWithValue("@ubicacion", ubicacion);
                        command.Parameters.AddWithValue("@activo", 1);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Donación agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nombreDonacionTxt.Clear();
                    proveedorTxt.Clear();
                    donacionesUbicacionTxt.Clear();
                    operador.RefrescarInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar la donación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void verTablasBtn_Click(object sender, EventArgs e)
        {
            operador.Show();
        }
    }
}
