using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
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
            string query = "INSERT INTO recursos (nombreRecurso, Cantidad, ubicacion) VALUES (@nombreRecurso, @cantidadRecurso, @ubicacion)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreRecurso", nombreRecurso);
                        command.Parameters.AddWithValue("@cantidadRecurso", cantidadRecurso);
                        command.Parameters.AddWithValue("@ubicacion", ubicacion);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Recurso agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    recursosUbicacionTxt.Clear();
                    agregarRecursoTxt.Clear();
                    cantidadTxt.Clear();

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
            string query = "INSERT INTO Donacion (nombreDonacion, proveedor, ubicacion) VALUES (@nombreDonacion, @proveedor, @ubicacion)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreDonacion", nombreDonacion);
                        command.Parameters.AddWithValue("@proveedor", proveedor);
                        command.Parameters.AddWithValue("@ubicacion", ubicacion);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Donación agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nombreDonacionTxt.Clear();
                    proveedorTxt.Clear();
                    donacionesUbicacionTxt.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar la donación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void verTablasBtn_Click(object sender, EventArgs e)
        {
            Operador operador = new Operador();
            operador.Show();
        }
    }
}
