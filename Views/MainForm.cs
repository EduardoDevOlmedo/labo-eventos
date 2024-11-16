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
        private string _role; // Variable para almacenar el rol del usuario.

        public MainForm(string role)
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            _role = role; // Asigna el rol recibido al campo privado.

            LoadDataForRole(); // Cargar datos en función del rol.
        }

        // Método que carga información dependiendo del rol del usuario.
        private void LoadDataForRole()
        {
            
          MessageBox.Show(_role == "admin" ? "admin" : _role== "operador" ? "operador ahora ");
        

        }
    }
}
