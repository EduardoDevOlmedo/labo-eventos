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
        private DataTable dataTable1, dataTable2, dataTable3;
        private SqlDataAdapter sqlDataAdapter1, sqlDataAdapter2, sqlDataAdapter3;
        private SqlConnection sqlConnection;
        private Eventos eventos;
        private BindingSource bindingSource0, bindingSource2, bindingSource3;
        public Operador()
        {
            eventos = new Eventos();
            InitializeComponent();

        }
        public void GuardarInfo()
        {
            if (dataTable1 == null || dataTable2 == null || dataTable3 == null)
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
                if (dataTable3.GetChanges() != null)
                {
                    sqlDataAdapter3.Update(dataTable3);
                    dataTable3.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void RefrescarInfo()
        {
            if (dataTable1 == null || dataTable2 == null || dataTable3 == null)
            {
                return;
            }
            try
            {
                dataTable1.Clear();
                sqlDataAdapter1.Fill(dataTable1);
                dataTable2.Clear();
                sqlDataAdapter2.Fill(dataTable2);
                dataTable3.Clear();
                sqlDataAdapter3.Fill(dataTable3);
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
            string solicitudesQuery = "SELECT * FROM solicitudes";
            sqlConnection = new SqlConnection(connectionString);


            try
            {
                sqlConnection.Open();
                sqlDataAdapter1 = new SqlDataAdapter(query, sqlConnection);
                SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(sqlDataAdapter1);
                bindingSource0 = new BindingSource();
                bindingSource2 = new BindingSource();
                bindingSource3 = new BindingSource();
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
                sqlDataAdapter3 = new SqlDataAdapter(solicitudesQuery, sqlConnection);
                SqlCommandBuilder commandbuilder3 = new SqlCommandBuilder(sqlDataAdapter3);
                dataTable3 = new DataTable();
                sqlDataAdapter3.Fill(dataTable3);
                dataGridView3.DataSource = dataTable3;
                dataGridView3.Columns["idSolicitud"].ReadOnly = true;
                dataGridView3.AllowUserToAddRows = false;
                AddCheckedColumn(dataGridView3, dataTable3, "atendida");
                dataGridView1.CellBeginEdit += DataGridView_CellBeginEdit;
                dataGridView2.CellBeginEdit += DataGridView_CellBeginEdit;
                dataGridView3.CellBeginEdit += DataGridView3_CellBeginEdit;
                bindingSource0.DataSource = dataTable1;
                bindingSource2.DataSource = dataTable2;
                bindingSource3.DataSource = dataTable3;
                dataGridView1.DataSource = bindingSource0;
                dataGridView2.DataSource = bindingSource2;
                dataGridView3.DataSource = bindingSource3;
                //comboBoxActivoFilter.Items.Add(new { Text = "Activa", Value = 1 });
                //comboBoxActivoFilter.Items.Add(new { Text = "Inactiva", Value = 0 });
                //comboBoxActivoFilter.DisplayMember = "Text";
                //comboBoxActivoFilter.ValueMember = "Value";
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
            else if (type.Equals("solicitud", StringComparison.OrdinalIgnoreCase))
            {
                deleteQuery = "DELETE FROM solicitudes WHERE idSolicitud = @id";
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
        private void DataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) return;
            bool isEditable = (bool)dataGridView.Rows[e.RowIndex].Cells["atendida"].Value;
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

        private void removeSolicitud_Click(object sender, EventArgs e)
        {
            deleteRowsFromTable(dataGridView3, dataTable3, "idSolicitud", "solicitud");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable3.GetChanges() != null)
                {
                    PostEvent("nombreSolicitor", dataTable3, "solicitud");


                    sqlDataAdapter3.Update(dataTable3);
                    dataTable3.AcceptChanges();
                    MessageBox.Show("Cambios a solicitudes guardados.");
                }
                else
                {
                    MessageBox.Show("No ha habido cambios.");
                }
                dataTable3.Clear();
                sqlDataAdapter3.Fill(dataTable3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "1");
            }
        }

        private void AplicarFiltro1()
        {
            string nombreRecurso = textBoxNombreRecursoFilter.Text.Trim();
            string cantidad = textBoxCantidadFilter.Text.Trim();
            string ubicacion = textBoxUbicacionFilter.Text.Trim();
            //bool? activo = comboBoxActivoFilter.SelectedValue as bool?;
            string filterString = "";
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
            /*if (activo.HasValue)
            {
                if (!string.IsNullOrEmpty(filterString)) filterString += " AND ";
                if (activo.Value) filterString += "activo = 1";
                else filterString += "activo = 0";
            }*/
            bindingSource2.Filter = filterString;
        }
        private void AplicarFiltro2()
        {
            string nombreDonacion = textBoxNombreDonacionFilter.Text.Trim();
            string ubicacion = textBoxUbicacion1Filter.Text.Trim();
            string proveedor = textBoxProveedorFilter.Text.Trim();
            string filterString = "";
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
            bindingSource0.Filter = filterString;
        }
        private void AplicarFiltro3()
        {
            string nombreSolicitor = textBoxNombreSolicitorFilter.Text.Trim();
            string urgencia = textBoxUrgenciaFilter.Text.Trim();
            string filterString = "";
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
            bindingSource3.Filter = filterString;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AplicarFiltro1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxCantidadFilter.Clear();
            textBoxNombreRecursoFilter.Clear();
            textBoxUbicacionFilter.Clear();
            bindingSource2.Filter = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AplicarFiltro2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxUbicacion1Filter.Clear();
            textBoxNombreDonacionFilter.Clear();
            textBoxProveedorFilter.Clear();
            bindingSource0.Filter = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AplicarFiltro3();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxUrgenciaFilter.Clear();
            textBoxNombreSolicitorFilter.Clear();
            bindingSource3.Filter = "";
        }
    }
}