using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eventos.Views
{
    // La clase Eventos hereda de Form, lo que indica que representa una ventana en la aplicación.
    public partial class Eventos : Form
    {
        // Adaptador para manejar la transferencia de datos entre la base de datos y la aplicación.
        private SqlDataAdapter eventosAdapter;
        
        // DataTable para almacenar los datos de la tabla de eventos.
        public DataTable eventosTable;
        
        // Conexión a la base de datos.
        private SqlConnection sqlConnection;

        // Cadena de conexión para la base de datos, indicando el servidor, la base de datos y el uso de seguridad integrada.
        private string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";

        // Constructor de la clase Eventos.
        public Eventos()
        {
            InitializeComponent(); // Inicializa los componentes de la interfaz gráfica.
            sqlConnection = new SqlConnection(connectionString); // Inicializa la conexión con la cadena de conexión.
            LoadEventos(); // Carga los eventos desde la base de datos.
        }

        // Evento que se ejecuta al hacer clic en el botón de "Go Back".
        private void goBackBtn_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario "Operador" y lo muestra.
            Operador operador = new Operador();
            operador.Show();
            
            // Oculta la ventana actual para no cerrar la aplicación.
            this.Hide();
        }

        // Método para cargar los eventos desde la base de datos.
        private void LoadEventos()
        {
            // Comando SQL para seleccionar todos los registros de la tabla "eventos".
            using (SqlCommand command = new SqlCommand("SELECT * FROM eventos", sqlConnection))
            {
                try
                {
                    sqlConnection.Open(); // Abre la conexión a la base de datos.
                    eventosAdapter = new SqlDataAdapter(command); // Inicializa el adaptador con el comando SQL.
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(eventosAdapter); // Crea un constructor de comandos para facilitar las operaciones de actualización.
                    eventosTable = new DataTable(); // Crea un nuevo DataTable para almacenar los datos.
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
                    // Muestra un mensaje de error en caso de que ocurra una excepción.
                    MessageBox.Show($"Error xd: {ex.Message}");
                }
                finally
                {
                    // Cierra la conexión a la base de datos, asegurándose de liberar los recursos.
                    sqlConnection.Close();
                }
            }
        }

        // Evento que se ejecuta al hacer clic en el botón de actualización.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpia el contenido del DataTable.
                eventosTable.Clear();
                
                // Vuelve a llenar el DataTable con los datos actualizados de la base de datos.
                eventosAdapter.Fill(eventosTable);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje con el detalle de la excepción en caso de error.
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
