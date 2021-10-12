using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioPOOVisual
{
    public partial class FormControl : Form
    {
        static String dir = Directory.GetCurrentDirectory();
        String serializationFile = Path.Combine(dir, "usuarios.bin");
        public FormControl()
        {
            InitializeComponent();
            MostrarAlAbrir();
        }

        public void MostrarAlAbrir()
        {
            
            listView1.Items.Clear();
            
            try
            {
                using (Stream stream = File.Open(serializationFile, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    Implementación imp = Implementación.Instance;
                    imp.setUsuarios((List<Usuario>)bformatter.Deserialize(stream));
                }                

                foreach (Usuario us in Implementación.Instance.GetUsuarios())
                {
                    ListViewItem filita = new ListViewItem(us.GetId().ToString());
                    filita.SubItems.Add(us.getNombre().ToString());
                    filita.SubItems.Add(us.getSexo());
                    filita.SubItems.Add(us.getEdad().ToString());
                    listView1.Items.Add(filita);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Archivo vacio");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Usuario> uses = new List<Usuario>();
            foreach (ListViewItem lv in listView1.SelectedItems)
            {
                String id_ = lv.Text;
                foreach (Usuario us in Implementación.Instance.GetUsuarios())
                {
                    if (us.GetId().ToString().Equals(id_))
                    {
                        uses.Add(us);

                    }
                }

            }
            foreach (Usuario usss in uses)
            {
                Implementación.Instance.GetUsuarios().Remove(usss);
            }
            Implementación.Instance.GuardarUsuarios();
            MostrarAlAbrir();
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
            panel1.Controls.Clear();
            AbrirFormEnPanel(new Menu1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AbrirFormEnPanel(new FormRegistrar());
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            foreach (ListViewItem lv in listView1.SelectedItems)
            {
                listView2.Items.Clear();
                String id_ = lv.Text;

                foreach (Usuario us in Implementación.Instance.GetUsuarios())
                {
                    if (us.GetId().ToString().Equals(id_))
                    {
                        foreach (Cuenta cuen in us.GetCuentas())
                        {
                            ListViewItem filita2 = new ListViewItem(cuen.DineroInvertido.ToString());
                            filita2.SubItems.Add(cuen.DineroGanado.ToString());
                            filita2.SubItems.Add(cuen.DineroPerdido.ToString());
                            filita2.SubItems.Add(cuen.GetDineroTotal().ToString());
                            listView2.Items.Add(filita2);
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lv in listView1.SelectedItems)
                {
                    String id_ = lv.Text;
                    foreach (Usuario us in Implementación.Instance.GetUsuarios())
                    {
                        if (us.GetId().ToString().Equals(id_))
                        {
                            panel1.Controls.Clear();
                            Implementación.Instance.SetUsuarioTemp(us);
                            AbrirFormEnPanel(new FormCrearCuenta());

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SLDocument sl = new SLDocument(openFileDialog1.FileName);
                    int iRow = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        try
                        {
                            int id = sl.GetCellValueAsInt32(iRow, 1);
                            string nombre = sl.GetCellValueAsString(iRow, 2);
                            string sexo = sl.GetCellValueAsString(iRow, 3);
                            int edad = sl.GetCellValueAsInt32(iRow, 4);
                            Usuario us = new Usuario(id, 0, nombre, sexo, edad);

                            List<Cuenta> cuentas = new List<Cuenta>();
                            for (int i = 2; i < 14; i++)
                            {
                                double dineroInvertido = sl.GetCellValueAsDouble(i, 5);
                                double dineroPerdido = sl.GetCellValueAsDouble(i, 6);
                                double dineroGanado = sl.GetCellValueAsDouble(i, 7);
                                Cuenta cuenta = new Cuenta(dineroInvertido);
                                cuenta.DineroPerdido = dineroPerdido;
                                cuenta.DineroGanado = dineroGanado;
                                cuenta.calcularDineroTotal();
                                cuentas.Add(cuenta);
                            }
                            us.SetCuentas(cuentas);
                            Implementación.Instance.addUsuario(us);
                            iRow++;
                        }
                        catch(Exception exe)
                        {
                            MessageBox.Show(exe.Message);
                        }
                    }
                    Implementación.Instance.GuardarUsuarios();
                    MostrarAlAbrir();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
