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
    public partial class SolicitarPrestamo : Form
    {
        //Declaramos una variable externa y las otras serán utilizadas en este form.

        public string extNombre, montoPrestamo, plazoMeses;

        public SolicitarPrestamo(string nombre)
        {
            InitializeComponent();
            this.extNombre = nombre;
        }

        //Inicio de los métodos.

        public void cancelar()
        {
            this.txtMonto.Clear();
            this.txtMonto.Focus();
            this.cbPlazoMeses.Text = "6";
        }

        //Esta función simplemente realiza el préstamo y nos manda a la tabla de amortización con sus
        //respectivos valores.
        public void realizar()
        {
            if (!this.txtMonto.Equals(""))
            {
                this.montoPrestamo = txtMonto.Text;
                this.plazoMeses = cbPlazoMeses.Text;

                MessageBox.Show("La solicitud de préstamo se ha realizado.");

                this.Hide();
                InformacionPrestamo informacionPrestamo = new InformacionPrestamo(this.extNombre, this.montoPrestamo, this.plazoMeses);
                informacionPrestamo.Show();
            }
        }

        //Fin de los métodos.

        private void SolicitarPrestamo_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = extNombre;
            this.txtMonto.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Salir de solicitud de préstamo",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                MenuCliente menuCliente = new MenuCliente(this.extNombre, "", "");
                menuCliente.Show();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cancelar?", "Cancelar solicitud de préstamo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cancelar();
                this.txtMonto.Focus();
            }
        }

        private void label7_Click(object sender, EventArgs e){}


        //Evento que va tecla por tecla analizando si se introduce un número, en caso de que se detecte una letra
        //este lanzará una advertencia PD: No pude implementarlo en un método.
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    MessageBox.Show("Solo se permiten numeros en el campo Monto", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        //Evento que va tecla por tecla analizando si se introduce un número, en caso de que se detecte una letra
        //este lanzará una advertencia PD: No pude implementarlo en un método.
        private void cbPlazoMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Solo se permiten numeros en el campo Plazo", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            realizar();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e){}
    }
}
