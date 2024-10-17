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
        private DataTable dataTable1, dataTable2;
        private SqlDataAdapter sqlDataAdapter1, sqlDataAdapter2;
        private SqlConnection sqlConnection;
        private Eventos eventos;
        public Operador()
        {
            eventos = new Eventos();
            InitializeComponent();

        }
        public void GuardarInfo()
        {
            if (dataTable1 == null || dataTable2 == null)
            {
                return;
            }
            try
            {
                if (dataTable1.GetChanges() != null)
                {
                    sqlDataAdapter1.Update(dataTable1);
                    dataTable1.AcceptChanges();
                }
                if (dataTable2.GetChanges() != null)
                {
                    sqlDataAdapter2.Update(dataTable2);
                    dataTable2.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void RefrescarInfo()
        {
            if (dataTable1 == null || dataTable2 == null)
            {
                return;
            }
            try
            {
                dataTable1.Clear();
                sqlDataAdapter1.Fill(dataTable1);
                dataTable2.Clear();
                sqlDataAdapter2.Fill(dataTable2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable2.GetChanges() != null)
                {
                    PostEvent("nombreRecurso", dataTable2, "recurso");

                    sqlDataAdapter2.Update(dataTable2);
                    dataTable2.AcceptChanges();
                    MessageBox.Show("Cambios a recursos guardados.");
                }
                else
                {
                    MessageBox.Show("No ha habido cambios.");
                }
                dataTable2.Clear();
                sqlDataAdapter2.Fill(dataTable2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable1.GetChanges() != null)
                {
                    PostEvent("nombreDonacion", dataTable1, "donacion");


                    sqlDataAdapter1.Update(dataTable1);
                    dataTable1.AcceptChanges();
                    MessageBox.Show("Cambios a donaciones guardados.");
                }
                else
                {
                    MessageBox.Show("No ha habido cambios.");
                }
                dataTable1.Clear();
                sqlDataAdapter1.Fill(dataTable1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PostEvent(string columnName, DataTable dataTable, string tipo)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    if (row[columnName, DataRowVersion.Original].ToString() != row[columnName, DataRowVersion.Current].ToString())
                    {
                        string columnValue = row[columnName].ToString();
                        RegistrarEvento($"{tipo.ToUpper()} Actualizado: {columnValue}", "Actualizar");
                    }
                }
            }
        }


        private void Operador_Load(object sender, EventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";
            string query = "SELECT * FROM donacion";
            string recursosQuery = "SELECT * FROM recursos";
            sqlConnection = new SqlConnection(connectionString);


            try
            {
                sqlConnection.Open();
                sqlDataAdapter1 = new SqlDataAdapter(query, sqlConnection);
                SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(sqlDataAdapter1);
                dataTable1 = new DataTable();
                sqlDataAdapter1.Fill(dataTable1);
                dataGridView1.DataSource = dataTable1;
                dataGridView1.Columns["idDonacion"].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                AddCheckedColumn(dataGridView1, dataTable1, "activo");
                sqlDataAdapter2 = new SqlDataAdapter(recursosQuery, sqlConnection);
                SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(sqlDataAdapter2);
                dataTable2 = new DataTable();
                sqlDataAdapter2.Fill(dataTable2);
                dataGridView2.DataSource = dataTable2;
                dataGridView2.Columns["idRecurso"].ReadOnly = true;
                dataGridView2.AllowUserToAddRows = false;
                AddCheckedColumn(dataGridView2, dataTable2, "activo");
                dataGridView1.CellBeginEdit += DataGridView_CellBeginEdit;
                dataGridView2.CellBeginEdit += DataGridView_CellBeginEdit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddCheckedColumn(DataGridView dataGridView, DataTable dataTable, string columnName)
        {
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
        private void DeleteRowFromDatabase(int id, string type)
        {
            string deleteQuery;

            if (type.Equals("donacion", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM donacion WHERE idDonacion = @id";
            }
            else if (type.Equals("recurso", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM recursos WHERE idRecurso = @id";
            }
            else
            {
                MessageBox.Show("Tipo no valido");
                return;
            }

            using (SqlCommand command = new SqlCommand(deleteQuery, sqlConnection))
            {
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    command.ExecuteNonQuery();
                    RegistrarEvento($"{type.ToUpper()} Eliminado: ID {id}", "Eliminar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el id: {ex.Message}");
                }
            }
        }

        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) return;
            bool isEditable = (bool)dataGridView.Rows[e.RowIndex].Cells["activo"].Value;
            if (!isEditable)
            {
                e.Cancel = true;
            }
        }
        private void RegistrarEvento(string nombreEvento, string tipoEvento)
        {
            string queryEvento = "INSERT INTO Eventos (nombreEvento, tipoEvento) VALUES (@nombreEvento, @tipoEvento)";
            using (SqlCommand command = new SqlCommand(queryEvento, sqlConnection))
            {
                command.Parameters.AddWithValue("@nombreEvento", nombreEvento);
                command.Parameters.AddWithValue("@tipoEvento", tipoEvento);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar evento: {ex.Message}");
                }
            }
        }

        
        private void removeDonaciones_Click(object sender, EventArgs e)
        {
            deleteRowsFromTable(dataGridView1, dataTable1, "idDonacion", "donacion");

        }
        private void removeRecursos_Click(object sender, EventArgs e)
        {
            deleteRowsFromTable(dataGridView2, dataTable2, "idRecurso", "recurso");
        }

        private void deleteRowsFromTable(DataGridView dataGridView, DataTable dataTable, string ceil, string type)
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow selectedRow in dataGridView.SelectedRows)
                    {
                        if (!selectedRow.IsNewRow)
                        {

                            int id = (int)selectedRow.Cells[ceil].Value;

                            DeleteRowFromDatabase(id, type);

                            dataTable.Rows.Remove(((DataRowView)selectedRow.DataBoundItem).Row);
                        }
                    }
                    MessageBox.Show("Las filas seleccionadas han sido eliminadas");
                }
                else
                {
                    MessageBox.Show("Selecciona al menos una fila para borrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}