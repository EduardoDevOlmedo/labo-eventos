using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            // esta es la url por defecto de sqlote
            string connectionString = @"Server=.\SQLEXPRESS;Database=Libros;Integrated Security=True;";
            string query = "SELECT idAutor, primerNombre, apellidoPaterno FROM Autores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                 
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();

              
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
