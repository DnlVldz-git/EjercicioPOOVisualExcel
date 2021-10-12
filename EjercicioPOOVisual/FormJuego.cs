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
    public partial class FormJuego : Form
    {
        public FormJuego()
        {
            InitializeComponent();
            Implementación imp = Implementación.Instance;

            foreach (Cuenta cuenta in imp.GetUsuarioActual().GetCuentas())
            {
                comboBox1.Items.Add(cuenta.GetDineroTotal());
            }    

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelDinero_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {


                try
                {
                    Implementación imp = Implementación.Instance;
                    String textDin = this.textBox1.Text;
                    double dinero = Double.Parse(textDin);
                    imp.setNumCuenta(comboBox1.SelectedIndex);
                    if ((dinero < 0) || (imp.GetUsuarioActual().GetCuentas().ElementAt(comboBox1.SelectedIndex).GetDineroTotal() < dinero))
                    {
                        MessageBox.Show("Número inválido", "Entrada no válida",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }
                    else
                    {
                        imp.GetUsuarioActual().setCantidad(dinero);
                        panel1.Controls.Clear();
                        AbrirFormEnPanel(new FormJuego2());
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Entrada inválida", "Entrada no válida",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning); 
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cuenta", "Warning",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning); ;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AbrirFormEnPanel(new Menu1());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double dinero = Implementación.Instance.GetUsuarioActual().GetCuentas().ElementAt(comboBox1.SelectedIndex).GetDineroTotal();

            labelDinero.Text = dinero.ToString();
        }
    }
}
