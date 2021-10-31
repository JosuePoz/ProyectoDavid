using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace IU
{
    public partial class FormPaquetes : Form
    {
        string id = "";
        public FormPaquetes()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (validateFormCrear())
            {
                LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3(); string resp;
                resp = Logica.GuardarPaquetes(((int)comboBox1.SelectedValue).ToString(), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.ListarPaquetes();
                    dataGridView1.Refresh();
                    resetFormCrear();
                }
                else
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Verificar que todos los campos esten llenos", "algunos campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void resetFormCrear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private bool validateFormCrear()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                return false;
            return true;
        }

        private bool validateFormEditar()
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                return false;
            return true;
        }

        private void FormPaquetes_Load(object sender, EventArgs e)
        {
            LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3();
            this.dataGridView1.DataSource = Logica.ListarPaquetes();
            this.dataGridView1.Refresh();
            obtenerDataComboBox(comboBox1);
            obtenerDataComboBox(comboBox2);
            DesactivarEdicion();
        }

        private void obtenerDataComboBox(ComboBox cmb)
        {
            LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio();
            cmb.DataSource = Logica.Listar();
            cmb.DisplayMember = "nombre_municipio";
            cmb.ValueMember = "MunicipioId";
        }
        private void DesactivarEdicion()
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            comboBox2.Enabled = false;
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3();
            this.dataGridView1.DataSource = Logica.BuscarPaquetes(textBox9.Text);
            this.dataGridView1.Refresh();
        }

        public void activedFormEdicion()
        {
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox2.Enabled = true;
            button2.Enabled = true;

        }

        public void resetFormEdicion()
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string valor = selectedRow.Cells[0].Value.ToString();
                if (valor != "")
                {
                    id = selectedRow.Cells[0].Value.ToString();
                    comboBox2.SelectedIndex = comboBox1.FindStringExact(selectedRow.Cells[1].Value.ToString());
                    textBox5.Text = selectedRow.Cells[2].Value.ToString();
                    textBox6.Text = selectedRow.Cells[4].Value.ToString();
                    textBox7.Text = selectedRow.Cells[5].Value.ToString();
                    textBox8.Text = selectedRow.Cells[3].Value.ToString().Replace(',', '.');
                    if (!button2.Enabled)
                        activedFormEdicion();
                }
                else if (button2.Enabled)
                {
                    id = "";
                    DesactivarEdicion();
                    resetFormEdicion();
                }
            }
            else if (button2.Enabled)
            {
                id = "";
                DesactivarEdicion();
                resetFormEdicion();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateFormEditar())
            {
                LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3(); string resp;
                resp = Logica.EditarPaquetes(Convert.ToInt32(id), ((int)comboBox2.SelectedValue).ToString(), textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.ListarPaquetes();
                    dataGridView1.Refresh();
                    resetFormEdicion();
                    DesactivarEdicion();
                }
                else
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Se necesita llenar todos los campos", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
