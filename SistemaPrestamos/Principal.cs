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
    public partial class Principal : Form
    {
        //Declaramos las variables externas que pasamos por parámetros.

        string extNombre, extEmail, extContrasena;
        bool extYaRegistrado;

        public Principal(bool yaRegistrado, string nombre, string email, string contrasena)
        {
            InitializeComponent();
            inicioFrmPrincipal(yaRegistrado, nombre, email, contrasena);
        }

        //Inicio de los métodos.

        //Inicia el frm Principal en caso de que el usuario cerre la sesión guardando el correo y contraseña, además
        //de los otros parámetros que se usan más adelante.
        public void inicioFrmPrincipal(bool yaRegistrado, string nombre, string email, string contrasena)
        {
            this.extYaRegistrado = yaRegistrado;
            this.extNombre = nombre;
            this.extEmail = email;
            this.extContrasena = contrasena;
            if (this.extYaRegistrado == true)
            {
                btnIrRegistro.Visible = false;
                btnIngresar.Visible = true;
            }
        }

        //Fin de los métodos.

        private void btnIrRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro registro = new Registro();
            registro.Show();
        }

        private void label1_Click(object sender, EventArgs e){}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Abandonar sistema de préstamos", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingreso ingreso = new Ingreso(this.extNombre, this.extEmail, this.extContrasena);
            ingreso.Show();
        }
    }
}
