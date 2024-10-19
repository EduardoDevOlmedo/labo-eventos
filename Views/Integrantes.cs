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
    // Clase parcial 'Integrantes' que hereda de 'Form', representando una ventana de la aplicación.
    public partial class Integrantes : Form
    {
        // Constructor de la clase 'Integrantes'.
        public Integrantes()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
        }

        // Evento que se activa al hacer clic en 'button1'.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual.
        }
    }
}
