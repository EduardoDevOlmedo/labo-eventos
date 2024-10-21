using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eventos.Views
{
    public partial class Operador : Form
    {
        // Definición de variables para las tablas y adaptadores de datos
        private DataTable dataTable1, dataTable2, dataTable3;
        private SqlDataAdapter sqlDataAdapter1, sqlDataAdapter2, sqlDataAdapter3;
        private SqlConnection sqlConnection; // Conexión a la base de datos
        private Eventos eventos; // Objeto para manejar eventos
        private BindingSource bindingSource0, bindingSource2, bindingSource3; // Fuentes de enlace para controles
        public Operador()
        {
            eventos = new Eventos(); // Inicializa el objeto Eventos
            InitializeComponent(); // Inicializa los componentes de la interfaz

        }
        // Método para guardar cambios en las tablas
        public void GuardarInfo()
        {
            // Verifica si las tablas están inicializadas
            if (dataTable1 == null || dataTable2 == null || dataTable3 == null)
            {
                return; // Salir si alguna tabla es nula
            }
            try
            {
                // Actualiza dataTable1 si hay cambios
                if (dataTable1.GetChanges() != null)
                {
                    sqlDataAdapter1.Update(dataTable1);
                    dataTable1.AcceptChanges();
                }
                // Actualiza dataTable2 si hay cambios
                if (dataTable2.GetChanges() != null)
                {
                    sqlDataAdapter2.Update(dataTable2);
                    dataTable2.AcceptChanges();
                }
                // Actualiza dataTable3 si hay cambios
                if (dataTable3.GetChanges() != null)
                {
                    sqlDataAdapter3.Update(dataTable3);
                    dataTable3.AcceptChanges(); // Acepta los cambios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }

        }
        // Método para refrescar la información en las tablas
        public void RefrescarInfo()
        {
            // Verifica si las tablas están inicializadas
            if (dataTable1 == null || dataTable2 == null || dataTable3 == null)
            {
                return; // Salir si alguna tabla es nula
            }
            try
            {
                // Limpia las tablas y vuelve a llenarlas desde la base de datos
                dataTable1.Clear();
                sqlDataAdapter1.Fill(dataTable1);
                dataTable2.Clear();
                sqlDataAdapter2.Fill(dataTable2);
                dataTable3.Clear();
                sqlDataAdapter3.Fill(dataTable3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }
        }
        // Evento click del botón para guardar cambios en dataTable2
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay cambios en dataTable2
                if (dataTable2.GetChanges() != null)
                {
                    PostEvent(dataTable2, "recurso"); // Llama a un método para manejar eventos

                    // Actualiza la base de datos y acepta los cambios
                    sqlDataAdapter2.Update(dataTable2);
                    dataTable2.AcceptChanges();
                    MessageBox.Show("Cambios a recursos guardados."); // Mensaje de éxito
                }
                else
                {
                    MessageBox.Show("No ha habido cambios."); // Mensaje si no hay cambios
                }
                dataTable2.Clear(); // Limpia dataTable2
                sqlDataAdapter2.Fill(dataTable2); // Rellena dataTable2 nuevamente
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay cambios en dataTable1
                if (dataTable1.GetChanges() != null)
                {
                    PostEvent(dataTable1, "donacion"); // Registra el evento de donación

                    // Actualiza la base de datos y acepta los cambios
                    sqlDataAdapter1.Update(dataTable1);
                    dataTable1.AcceptChanges();
                    MessageBox.Show("Cambios a donaciones guardados."); // Mensaje de éxito
                }
                else
                {
                    MessageBox.Show("No ha habido cambios."); // Mensaje si no hay cambios
                }
                dataTable1.Clear(); // Limpia dataTable1
                sqlDataAdapter1.Fill(dataTable1); // Rellena dataTable1 nuevamente
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }
        }
        // Método para registrar cambios en las filas de la tabla
        public void PostEvent(DataTable dataTable, string tipo)
        {
            foreach (DataRow row in dataTable.Rows) // Recorre cada fila de la tabla
            {
                if (row.RowState == DataRowState.Modified) // Verifica si la fila ha sido modificada
                {
                    foreach (DataColumn column in dataTable.Columns) // Recorre cada columna
                    {
                        string columnName = column.ColumnName;

                        // Verifica si el valor original es diferente al actual
                        if (!row[columnName, DataRowVersion.Original].Equals(row[columnName, DataRowVersion.Current]))
                        {
                            string currentValue = row[columnName, DataRowVersion.Current].ToString();
                            string eventMessage = $"{tipo.ToUpper()} {columnName} {currentValue}'"; // Mensaje del evento
                            RegistrarEvento(eventMessage, "Actualizar"); // Registra el evento
                        }
                    }
                }
            }
        }

        // Evento que se dispara al cargar el formulario
        private void Operador_Load(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";
            string query = "SELECT * FROM donacion"; // Consulta para donaciones
            string recursosQuery = "SELECT * FROM recursos"; // Consulta para recursos
            string solicitudesQuery = "SELECT * FROM solicitudes"; // Consulta para solicitudes
            sqlConnection = new SqlConnection(connectionString); // Inicializa la conexión


            try
            {
                sqlConnection.Open(); // Abre la conexión

                // Configuración del adaptador y la tabla para donaciones
                sqlDataAdapter1 = new SqlDataAdapter(query, sqlConnection);
                SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(sqlDataAdapter1);
                bindingSource0 = new BindingSource();
                bindingSource2 = new BindingSource();
                bindingSource3 = new BindingSource();
                dataTable1 = new DataTable();
                sqlDataAdapter1.Fill(dataTable1); // Llena la tabla
                dataGridView1.DataSource = dataTable1; // Asigna la tabla al DataGridView
                dataGridView1.Columns["idDonacion"].ReadOnly = true; // Hace la columna idDonacion de solo lectura
                dataGridView1.AllowUserToAddRows = false; // Deshabilita la adición de filas
                AddCheckedColumn(dataGridView1, dataTable1, "activo"); // Agrega columna de verificación

                // Configuración del adaptador y la tabla para recursos
                sqlDataAdapter2 = new SqlDataAdapter(recursosQuery, sqlConnection);
                SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(sqlDataAdapter2);
                dataTable2 = new DataTable();
                sqlDataAdapter2.Fill(dataTable2); // Llena la tabla
                dataGridView2.DataSource = dataTable2; // Asigna la tabla al DataGridView
                dataGridView2.Columns["idRecurso"].ReadOnly = true; // Hace la columna idRecurso de solo lectura
                dataGridView2.AllowUserToAddRows = false; // Deshabilita la adición de filas
                AddCheckedColumn(dataGridView2, dataTable2, "activo"); // Agrega columna de verificación

                // Configuración del adaptador y la tabla para solicitudes
                sqlDataAdapter3 = new SqlDataAdapter(solicitudesQuery, sqlConnection);
                SqlCommandBuilder commandbuilder3 = new SqlCommandBuilder(sqlDataAdapter3);
                dataTable3 = new DataTable();
                sqlDataAdapter3.Fill(dataTable3); // Llena la tabla
                dataGridView3.DataSource = dataTable3; // Asigna la tabla al DataGridView
                dataGridView3.Columns["idSolicitud"].ReadOnly = true; // Hace la columna idSolicitud de solo lectura

                dataGridView3.AllowUserToAddRows = false; // Deshabilita la adición de filas
                AddCheckedColumn(dataGridView3, dataTable3, "atendida"); // Agrega columna de verificación

                // Asigna eventos de inicio de edición
                dataGridView1.CellBeginEdit += DataGridView_CellBeginEdit;
                dataGridView2.CellBeginEdit += DataGridView_CellBeginEdit;
                dataGridView3.CellBeginEdit += DataGridView3_CellBeginEdit;

                // Asigna fuentes de datos a los binding sources
                bindingSource0.DataSource = dataTable1;
                bindingSource2.DataSource = dataTable2;
                bindingSource3.DataSource = dataTable3;
                dataGridView1.DataSource = bindingSource0;
                dataGridView2.DataSource = bindingSource2;
                dataGridView3.DataSource = bindingSource3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }
        }
        // Método para agregar una columna de verificación a un DataGridView
        private void AddCheckedColumn(DataGridView dataGridView, DataTable dataTable, string columnName)
        {
            // Crea una nueva columna de verificación
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = columnName;
            checkBoxColumn.DataPropertyName = columnName;
            checkBoxColumn.Name = columnName;
            dataGridView.Columns.Remove(columnName);
            dataGridView.Columns.Add(checkBoxColumn);
            foreach (DataRow row in dataTable.Rows)
            {
                row[columnName] = row[columnName];
            }
        }
        // Método para eliminar una fila de la base de datos
        private void DeleteRowFromDatabase(int id, string type)
        {
            string deleteQuery;

            // Define la consulta DELETE según el tipo proporcionado
            if (type.Equals("donacion", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM donacion WHERE idDonacion = @id";
            }
            else if (type.Equals("recurso", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM recursos WHERE idRecurso = @id";
            }
            else if (type.Equals("solicitud", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM solicitudes WHERE idSolicitud = @id";
            }
            else
            {
                MessageBox.Show("Tipo no valido"); // Mensaje para tipo no válido
                return;
            }

            // Ejecuta la consulta DELETE
            using (SqlCommand command = new SqlCommand(deleteQuery, sqlConnection))
            {
                command.Parameters.AddWithValue("@id", id); // Asigna el parámetro ID

                try
                {
                    command.ExecuteNonQuery(); // Ejecuta la consulta
                    RegistrarEvento($"{type.ToUpper()} Eliminado: ID {id}", "Eliminar"); // Registra el evento de eliminación
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el id: {ex.Message}"); // Muestra un mensaje de error
                }
            }
        }

        // Evento que se dispara al comenzar a editar una celda en el DataGridView
        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            // Si la columna es de verificación, no se cancela la edición
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) return;

            // Verifica si la fila es editable
            bool isEditable = (bool)dataGridView.Rows[e.RowIndex].Cells["activo"].Value;
            if (!isEditable)
            {
                e.Cancel = true; // Cancela la edición si no es editable
            }
        }
        // Evento que se dispara al comenzar a editar una celda en el tercer DataGridView
        private void DataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            // Si la columna es de verificación, no se cancela la edición
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) return;

            // Verifica si la fila es editable
            bool isEditable = (bool)dataGridView.Rows[e.RowIndex].Cells["atendida"].Value;
            if (!isEditable)
            {
                e.Cancel = true; // Cancela la edición si no es editable
            }
        }
        // Método para registrar eventos en la base de datos
        private void RegistrarEvento(string nombreEvento, string tipoEvento)
        {
            string queryEvento = "INSERT INTO Eventos (nombreEvento, tipoEvento) VALUES (@nombreEvento, @tipoEvento)";
            using (SqlCommand command = new SqlCommand(queryEvento, sqlConnection))
            {
                command.Parameters.AddWithValue("@nombreEvento", nombreEvento); // Asigna el nombre del evento
                command.Parameters.AddWithValue("@tipoEvento", tipoEvento); // Asigna el tipo del evento

                try
                {
                    command.ExecuteNonQuery(); // Ejecuta la consulta para registrar el evento
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar evento: {ex.Message}"); // Muestra un mensaje de error
                }
            }
        }

        // Método que se ejecuta al hacer clic en el botón de eliminación de donaciones
        private void removeDonaciones_Click(object sender, EventArgs e)
        {
            // Llama a un método para eliminar filas de la tabla de donaciones
            deleteRowsFromTable(dataGridView1, dataTable1, "idDonacion", "donacion");

        }
        // Método que se ejecuta al hacer clic en el botón para eliminar recursos
        private void removeRecursos_Click(object sender, EventArgs e)
        {
            deleteRowsFromTable(dataGridView2, dataTable2, "idRecurso", "recurso");
        }

        // Método para eliminar filas seleccionadas de un DataGridView y del DataTable asociado
        private void deleteRowsFromTable(DataGridView dataGridView, DataTable dataTable, string ceil, string type)
        {
            try
            {
                // Verifica si hay filas seleccionadas
                if (dataGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow selectedRow in dataGridView.SelectedRows)
                    {
                        // Asegura que no se esté tratando de eliminar una nueva fila
                        if (!selectedRow.IsNewRow)
                        {

                            // Obtiene el ID de la fila seleccionada
                            int id = (int)selectedRow.Cells[ceil].Value;

                            // Elimina la fila de la base de datos
                            DeleteRowFromDatabase(id, type);

                            // Elimina la fila del DataTable
                            dataTable.Rows.Remove(((DataRowView)selectedRow.DataBoundItem).Row);
                        }
                    }
                    MessageBox.Show("Las filas seleccionadas han sido eliminadas");
                }
                else
                {
                    MessageBox.Show("Selecciona al menos una fila para borrar."); // Mensaje si no hay filas seleccionadas
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje de error
            }
        }

        // Método que se ejecuta al hacer clic en el botón para eliminar solicitudes
        private void removeSolicitud_Click(object sender, EventArgs e)
        {
            deleteRowsFromTable(dataGridView3, dataTable3, "idSolicitud", "solicitud");
        }

        // Método que se ejecuta al hacer clic en un botón para guardar cambios en solicitudes
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay cambios en el DataTable de solicitudes
                if (dataTable3.GetChanges() != null)
                {
                    PostEvent(dataTable3, "solicitud"); // Llama a PostEvent

                    // Actualiza el DataTable en la base de datos
                    sqlDataAdapter3.Update(dataTable3);
                    dataTable3.AcceptChanges(); // Acepta los cambios
                    MessageBox.Show("Cambios a solicitudes guardados.");
                }
                else
                {
                    MessageBox.Show("No ha habido cambios."); // Mensaje si no hay cambios
                }
                dataTable3.Clear(); // Limpia el DataTable
                sqlDataAdapter3.Fill(dataTable3); // Rellena nuevamente el DataTable
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "1"); // Muestra un mensaje de error
            }
        }

        // Método para aplicar filtros a los recursos
        private void AplicarFiltro1()
        {
            string nombreRecurso = textBoxNombreRecursoFilter.Text.Trim();
            string cantidad = textBoxCantidadFilter.Text.Trim();
            string ubicacion = textBoxUbicacionFilter.Text.Trim();
            string filterString = "";

            // Construye la cadena de filtro según los valores ingresados
            if (!string.IsNullOrEmpty(nombreRecurso))
            {
                filterString += $"nombreRecurso LIKE '%{nombreRecurso}%'";
            }
            if (!string.IsNullOrEmpty(cantidad) && int.TryParse(cantidad, out _))
            {
                if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                filterString += $"cantidad = {cantidad}";
            }
            if (!string.IsNullOrEmpty(ubicacion))
            {
                if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                filterString += $"ubicacion LIKE '%{ubicacion}%'";
            }
            // Aplica el filtro al BindingSource
            bindingSource2.Filter = filterString;
        }
        // Método para aplicar filtros a las donaciones
        private void AplicarFiltro2()
        {
            string nombreDonacion = textBoxNombreDonacionFilter.Text.Trim();
            string ubicacion = textBoxUbicacion1Filter.Text.Trim();
            string proveedor = textBoxProveedorFilter.Text.Trim();
            string filterString = "";

            // Construye la cadena de filtro según los valores ingresados
            if (!string.IsNullOrEmpty(nombreDonacion))
            {
                filterString += $"nombreDonacion LIKE '%{nombreDonacion}%'";
            }
            if (!string.IsNullOrEmpty(ubicacion))
            {
                if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                filterString += $"ubicacion LIKE '%{ubicacion}%'";
            }
            if (!string.IsNullOrEmpty(proveedor))
            {
                if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                filterString += $"proveedor LIKE '%{proveedor}%'";
            }
            // Aplica el filtro al BindingSource
            bindingSource0.Filter = filterString;
        }
        // Método para aplicar filtros a las solicitudes
        private void AplicarFiltro3()
        {
            string nombreSolicitor = textBoxNombreSolicitorFilter.Text.Trim();
            string urgencia = textBoxUrgenciaFilter.Text.Trim();
            string filterString = "";

            // Agrega filtros según los valores ingresados
            if (!string.IsNullOrEmpty(nombreSolicitor))
            {
                filterString += $"nombreSolicitor LIKE '%{nombreSolicitor}%'";
            }
            if (!string.IsNullOrEmpty(urgencia) && int.TryParse(urgencia, out _))
            {
                if (urgencia.Equals("1") || urgencia.Equals("2") || urgencia.Equals("3"))
                {
                    if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                    filterString += $"nivelUrgencia = {urgencia}";
                }
            }
            // Aplica el filtro al BindingSource de solicitudes
            bindingSource3.Filter = filterString;
        }
        // Método que se ejecuta al hacer clic en el botón para aplicar filtro a recursos
        private void button3_Click(object sender, EventArgs e)
        {
            AplicarFiltro1(); // Llama a AplicarFiltro1
        }

        // Método que se ejecuta al hacer clic en el botón para limpiar filtros de recursos
        private void button5_Click(object sender, EventArgs e)
        {
            // Limpia los campos de texto y resetea el filtro
            textBoxCantidadFilter.Clear();
            textBoxNombreRecursoFilter.Clear();
            textBoxUbicacionFilter.Clear();
            bindingSource2.Filter = ""; // Resetea el filtro
        }

        // Método que se ejecuta al hacer clic en el botón para aplicar filtro a donaciones

        private void button7_Click(object sender, EventArgs e)
        {
            AplicarFiltro2(); // Llama a AplicarFiltro2
        }

        // Método que se ejecuta al hacer clic en el botón para limpiar filtros de donaciones
        private void button6_Click(object sender, EventArgs e)
        {
            // Limpia los campos de texto y resetea el filtro
            textBoxUbicacion1Filter.Clear();
            textBoxNombreDonacionFilter.Clear();
            textBoxProveedorFilter.Clear();
            bindingSource0.Filter = ""; // Resetea el filtro
        }

        // Método que se ejecuta al hacer clic en el botón para aplicar filtro a solicitudes
        private void button9_Click(object sender, EventArgs e)
        {
            AplicarFiltro3(); // Llama a AplicarFiltro3
        }

        // Método que se ejecuta al hacer clic en el botón para limpiar filtros de solicitudes
        private void button8_Click(object sender, EventArgs e)
        {
            // Limpia los campos de texto y resetea el filtro
            textBoxUrgenciaFilter.Clear();
            textBoxNombreSolicitorFilter.Clear();
            bindingSource3.Filter = ""; // Resetea el filtro
        }

        // Método para generar un PDF de recursos
        private void button10_Click(object sender, EventArgs e)
        {
            string title = "Reporte de recursos";
            GenerarPDF pdf = new GenerarPDF(title, dataTable2);
            pdf.CrearPDF(); // Crea el PDF
        }

        // Método para generar un PDF de donaciones
        private void button11_Click(object sender, EventArgs e)
        {

            string title = "Reporte de donaciones";
            GenerarPDF pdf = new GenerarPDF(title, dataTable1);
            pdf.CrearPDF(); // Crea el PDF
        }

        // Método para generar un PDF de solicitudes

        private void button12_Click(object sender, EventArgs e)
        {
            string title = "Reporte de solicitudes";
            GenerarPDF pdf = new GenerarPDF(title, dataTable3);
            pdf.CrearPDF(); // Crea el PDF
        }

        // Método para generar un PDF de eventos

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable table = eventos.eventosTable; // Obtiene la tabla de eventos
            GenerarPDF pdfEventos = new GenerarPDF("Reporte de eventos", table);
            pdfEventos.generarPDFEventos(); // Crea el PDF de eventos
        }

        // Método para salir de la aplicación
        private void salir(object sender, EventArgs e){
            Application.Exit(); // Cierra la aplicación
        }

        // Método para mostrar la ventana de integrantes
        private void mostrarIntegrantes(object sender, EventArgs e)
        {
            Integrantes integrantes = new Integrantes(); // Crea una nueva instancia de la clase Integrantes
            integrantes.Show(); // Muestra la ventana de integrantes
        }
    }
}