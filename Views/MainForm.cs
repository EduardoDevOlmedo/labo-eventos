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


        //cambio
        private void LoadDataForRole()
        {
          MessageBox.Show(_role == "admin" ? "admin" : _role== "operador" ? "operador ahora ");
        }
    }
}
