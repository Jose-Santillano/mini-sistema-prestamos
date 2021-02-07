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
    public partial class Registro : Form
    {
        public string nombre, direccion, email, telefono, contrasena;

        public Registro()
        {
            InitializeComponent();
        }

        //Inicio de métodos.

        public void cancelar()
        {
            //Cancelamos y limpiamos todo.

            this.txtNombre.Clear();
            this.txtDireccion.Clear();
            this.txtEmail.Clear();
            this.txtTelefono.Clear();
            this.pbImagen.Image = Properties.Resources._default; //Regresamos a la imagen default.
        }

        public void guardar()
        {
            //Verificamos si los campos estan llenos.

            if(!this.txtNombre.Text.Equals("") && !this.txtDireccion.Text.Equals("") && !this.txtEmail.Text.Equals("")
                && !this.txtTelefono.Text.Equals("") && !this.txtContrasena.Text.Equals(""))
            {
                this.email = this.txtEmail.Text;
                
                //Verificamos si el correo esta en su formato correcto.

                if (validarEmail(this.email))
                {
                    this.nombre = this.txtNombre.Text;
                    this.direccion = this.txtDireccion.Text;
                    this.telefono = this.txtTelefono.Text;
                    this.contrasena = this.txtContrasena.Text;

                    //Guardamos imagen, pero no la utilizamos.

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();

                    MessageBox.Show("Se ha registrado exitosamente.");

                    //Limpiamos de nuevo todo y hacemos focus a txtNombre.

                    cancelar();
                    txtNombre.Focus();

                    //Declaramos que ya esta registrado y abrimos form MenuCliente .

                    this.Hide();
                    MenuCliente menuCliente = new MenuCliente(this.nombre, this.email, this.contrasena);
                    menuCliente.Show();
                }
                else
                {
                    MessageBox.Show("Rellena el campo correo de manera correcta.");
                }
            }
            else
            {
                MessageBox.Show("Por favor rellena todos los campos.");
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

        //Fin de métodos.

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Mostramos un dialogo en donde pedimos que ingresen la imagen.

            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pbImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Abandonar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Principal principal = new Principal(false, "", "", "");
                principal.Show();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras en el campo Nombre", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e){}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cancelar?","Cancelar registro",MessageBoxButtons.YesNo) == DialogResult.Yes){
                cancelar();
                txtNombre.Focus();
            }
        }

        private void pbImagen_Click(object sender, EventArgs e){}
    }
}
