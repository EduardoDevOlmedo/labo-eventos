using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    public partial class Eventos : Form
    {
        private SqlDataAdapter eventosAdapter;
        private DataTable eventosTable;
        private SqlConnection sqlConnection;

        private string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

        public Eventos()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            LoadEventos();
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            Operador operador = new Operador();
            operador.Show();
            this.Hide();
        }

        private void LoadEventos()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM eventos", sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    eventosAdapter = new SqlDataAdapter(command);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(eventosAdapter);
                    eventosTable = new DataTable();
                    eventosAdapter.Fill(eventosTable);
                    eventosGridView.DataSource = eventosTable;
                    foreach (DataGridViewColumn column in eventosGridView.Columns)
                    {
                        column.ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error xd: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
