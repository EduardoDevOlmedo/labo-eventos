using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventos.Views
{
    public partial class MainForm : Form
    {
        private string _role;

        public MainForm(string role)
        {
            InitializeComponent();
            _role = role;

            LoadDataForRole();
        }

        private void LoadDataForRole()
        {
            if (_role == "admin")
            {
                MessageBox.Show("admin");
            }
            else if (_role == "operador")
            {
                MessageBox.Show("operador ahora");
            }
        }
    }
}
