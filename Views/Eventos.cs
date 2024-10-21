using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    
    public partial class Eventos : Form
    {
        // Adaptador para manejar la transferencia de datos entre la base de datos y la aplicación.
        private SqlDataAdapter eventosAdapter;
        
        
        public DataTable eventosTable;
        
        
        private SqlConnection sqlConnection;

        // Cadena de conexión para la base de datos, indicando el servidor, la base de datos y el uso de seguridad integrada.
        private string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

   
        public Eventos()
        {
            InitializeComponent(); 
            sqlConnection = new SqlConnection(connectionString); // Inicializa la conexión con la cadena de conexión.
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
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(eventosAdapter); // Crea un constructor de comandos para facilitar las operaciones de actualización.
                    eventosTable = new DataTable(); 
                    eventosAdapter.Fill(eventosTable); // Llena el DataTable con los datos obtenidos de la base de datos.
                    eventosGridView.DataSource = eventosTable; // Asigna el DataTable como fuente de datos para el DataGridView.

                    // Establece todas las columnas del DataGridView como de solo lectura.
                    foreach (DataGridViewColumn column in eventosGridView.Columns)
                    {
                        column.ReadOnly = true; // Hace que la columna no sea editable.
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                eventosTable.Clear();
                
                // Vuelve a llenar el DataTable con los datos actualizados de la base de datos.
                eventosAdapter.Fill(eventosTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
