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
    public partial class InformacionPrestamo : Form
    {
        //Declaramos todas las variables necesarias para este formulario junto con sus variables externas pasadas
        //por parámetros.

        public string extNombre, extMontoPrestamo, extPlazoMeses;
        public int numeroDePagos;
        public decimal cantidadPagoMensual, intereses, sueldo;

        //Inicio de los métodos.

        //Método encargado de generar el contenido en el DataGridView llamado tablaAmortizacion.
        public void tablaAmortizacion(string nombre, string montoPrestamo, string plazoMeses)
        {
            this.extNombre = nombre;
            this.extMontoPrestamo = montoPrestamo;
            this.extPlazoMeses = plazoMeses;
            this.numeroDePagos = Convert.ToInt32(plazoMeses);

            //Sacamos la cantidad del pago mensual y le cortamos sus decimales a 00.00
            this.cantidadPagoMensual = Math.Truncate((Convert.ToDecimal(extMontoPrestamo) / numeroDePagos) * 100) / 100;

            //Sacamos los intereses del MontoPrestamo.
            this.intereses = (Convert.ToDecimal(cantidadPagoMensual)) * 0.20M;

            this.sueldo = Convert.ToDecimal(extMontoPrestamo);

            //Añadimos sus respectivas columnas.
            dgvTablaAmortizacion.Columns.Add("numeroDePago", "Número de pago");
            dgvTablaAmortizacion.Columns.Add("cantidadAPagar", "Cantidad a pagar");
            dgvTablaAmortizacion.Columns.Add("intereses", "Intereses");
            dgvTablaAmortizacion.Columns.Add("capital", "Capital");
            dgvTablaAmortizacion.Columns.Add("saldo", "Saldo");

            //Creamos un for encargado de generar cada fila según el plazo. Ej: Si es 6 meses generará 6 filas con sus
            //respectivos valores.
            for (int i = 0; i < numeroDePagos; i++)
            {
                //Variable que irá decrementando según la cantidad de pagos que se realicen y el plazo que se solicitó.
                this.sueldo -= this.cantidadPagoMensual;

                dgvTablaAmortizacion.Rows.Add(
                        (i + 1).ToString(), //Numero de pago.
                        (cantidadPagoMensual + intereses).ToString(), //Cantidad a pagar.
                        intereses.ToString(), //Intereses.
                        cantidadPagoMensual.ToString(), //Capital.
                        sueldo.ToString() //Sueldo.
                    );
            }
        }

        //Fin de los métodos.

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            this.Hide();
            SolicitarPrestamo solicitarPrestamo = new SolicitarPrestamo(this.extNombre);
            solicitarPrestamo.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTablaAmortizacion_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        public InformacionPrestamo(string nombre, string montoPrestamo, string plazoMeses)
        {
            InitializeComponent();
            tablaAmortizacion(nombre, montoPrestamo, plazoMeses);
        }

        private void InformacionPrestamo_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = extNombre;
            lblMontoPrestado.Text = extMontoPrestamo;
            lblPlazoMeses.Text = extPlazoMeses;
        }
    }
}
