using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; //Libreria para expresión Regex usara para validar Email.

namespace SistemaPrestamos
{
    public partial class Ingreso : Form
    {
        string extNombre, extEmail, extContrasena;

        public Ingreso(string nombre, string email, string contrasena)
        {
            InitializeComponent();
            this.extNombre = nombre;
            this.extEmail = email;
            this.extContrasena = contrasena;
        }

        //Inicio de los métodos.

        public void ingresar()
        {
            if (!this.txtEmail.Text.Equals("") && !this.txtContrasena.Text.Equals(""))
            {
                //Validamos que el la estructura del Email este bien.
                if (validarEmail(this.txtEmail.Text))
                {
                    if (this.txtEmail.Text == this.extEmail && this.txtContrasena.Text == this.extContrasena)
                    {
                        this.Hide();
                        MenuCliente menuCliente = new MenuCliente(this.extNombre, this.extEmail, this.extContrasena);
                        menuCliente.Show();
                    }
                    else
                    {
                        MessageBox.Show("Los campos no coinciden con el correo registrado o contraseña registrada.");
                    }
                }
                else
                {
                    MessageBox.Show("Rellena el campo correo de manera correcta.");
                }
                
            }
            else
            {
                MessageBox.Show("Por favor rellena los campos.");
            }
        }

        //Método encargado de verificar que el correo este bien escrito.

        private Boolean validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Fin de los métodos.

        private void Ingreso_Load(object sender, EventArgs e){}

        private void label7_Click(object sender, EventArgs e){}

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e){}

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Salir de ingreso",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Principal principal = new Principal(true, this.extNombre, this.extEmail, this.extContrasena);
                principal.Show();
            }      
        }
    }
}
