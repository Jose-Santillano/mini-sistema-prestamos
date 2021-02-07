using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPrestamos
{
    public partial class MenuCliente : Form
    {
        //Declaramos las variables externas que se transfieren de form en form.

        public string extNombre, extEmail, extContrasena;

        public MenuCliente(string nombre, string email, string contrasena)
        {
            InitializeComponent();
            this.extNombre = nombre;
            this.extEmail = email;
            this.extContrasena = contrasena;
        }

        private void MenuCliente_Load(object sender, EventArgs e)
        {
            //Carga del MenuCliente.

            lblUsuario.Text = extNombre;
        }

        private void button2_Click(object sender, EventArgs e){}

        private void btnSolicitarPrestamo_Click(object sender, EventArgs e)
        {
            //Solicitar préstamo.

            this.Hide();
            SolicitarPrestamo solicitarPrestamo = new SolicitarPrestamo(this.extNombre);
            solicitarPrestamo.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cerrar la sesión?", "Cerrar sesión", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Principal principal = new Principal(true, this.extNombre, this.extEmail, this.extContrasena);
                principal.Show();
            }
        }
    }
}
