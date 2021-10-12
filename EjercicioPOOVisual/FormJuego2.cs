using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioPOOVisual
{
    public partial class FormJuego2 : Form
    {
        Juego juego;
        Implementación imp;
        int numCuenta;
        public FormJuego2()
        {
            this.juego = new Juego();
            InitializeComponent();
            this.imp = Implementación.Instance;
            this.numCuenta = imp.getNumCuenta();
            Double dinero = imp.GetUsuarioActual().getCantidad();                
            this.dineroGanar.Text = (dinero + dinero / 2).ToString();
            this.dineroPerder.Text = (dinero).ToString();
            juego.ObtenerGatosParticipantes();
            this.btnC1.Text = juego.GetGato1();
            this.btnC2.Text = juego.GetGato2();
            this.btnC3.Text = juego.GetGato3();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormEnPanel(Object Formhijo)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            fh.Show();
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            if (juego.Jugar(imp.GetUsuarioActual().getCantidad(), imp.GetUsuarioActual().GetCuentas().ElementAt(numCuenta), 1))
            {
                VisibleFalse();
                VisibleTrue();
                this.lblGano.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad() + imp.GetUsuarioActual().getCantidad() / 2).ToString();
            }
            else
            {
                VisibleFalse();
                VisibleTrue();
                this.lblPerdio.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad()).ToString();
            }

            imp.GuardarUsuarios();

        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            if (juego.Jugar(imp.GetUsuarioActual().getCantidad(), imp.GetUsuarioActual().GetCuentas().ElementAt(numCuenta), 2))
            {
                VisibleFalse();
                VisibleTrue();
                this.lblGano.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad() + imp.GetUsuarioActual().getCantidad() / 2).ToString();
            }
            else
            {
                VisibleFalse();
                VisibleTrue();
                this.lblPerdio.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad()).ToString();
            }
            imp.GuardarUsuarios();
        }

        private void VisibleFalse()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label4.Visible = false;
            this.dineroGanar.Visible = false;
            this.dineroPerder.Visible = false;
            this.btnC1.Visible = false;
            this.btnC2.Visible = false;
            this.btnC3.Visible = false;
        } 

        private void VisibleTrue()
        {
            this.lblGatoGanador.Visible = true;
            this.lblGanador.Visible = true;
            this.lblDinero.Visible = true;
            this.btnJugar.Visible = true;
            //this.btnVerEstadoCuenta.Visible = true;
            this.btnSalir.Visible = true;
            this.lblGatoSelec.Visible = true;
            this.lblSelec.Visible = true;
            this.lblGatoSelec.Text = juego.GetGanador();
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
            if (juego.Jugar(imp.GetUsuarioActual().getCantidad(), imp.GetUsuarioActual().GetCuentas().ElementAt(numCuenta), 3))
            {
                VisibleFalse();
                VisibleTrue();
                this.lblGano.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad()).ToString();
            }
            else {
                VisibleFalse();
                VisibleTrue();
                this.lblPerdio.Visible = true;
                this.lblGatoGanador.Text = juego.GetGanador();
                this.lblDinero.Text = (imp.GetUsuarioActual().getCantidad() + imp.GetUsuarioActual().getCantidad() / 2).ToString();
            }
            imp.GuardarUsuarios();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AbrirFormEnPanel(new FormJuego());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AbrirFormEnPanel(new Menu1());
        }
    }
}
