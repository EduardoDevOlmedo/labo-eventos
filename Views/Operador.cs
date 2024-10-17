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
        public Operador()
        {
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable1.GetChanges() != null)
                {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable2.GetChanges() != null)
                {
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

        private void Operador_Load(object sender, EventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=CENTRO_ACOPIO;Integrated Security=True;";
            string query = "SELECT * FROM donacion";
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
                query = "SELECT * FROM recursos";
                sqlDataAdapter2 = new SqlDataAdapter(query, sqlConnection);
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
    }
}