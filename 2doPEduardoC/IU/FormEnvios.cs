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
    public partial class FormEnvios : Form
    {

        string id = "";
        public FormEnvios()
        {
            InitializeComponent();
        }

        private void FormEnvios_Load(object sender, EventArgs e)
        {

            LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3();
            this.dataGridView1.DataSource = Logica.ListarEnvios();
            this.dataGridView1.Refresh();
            obtenerDataClienteComboBox(comboBox1);
            obtenerDataPaquetesComboBox(comboBox2);
            obtenerDataClienteComboBox(comboBox3);
            obtenerDataPaquetesComboBox(comboBox4);
            obtenerDataClienteComboBox(comboBox5);
            obtenerDataPaquetesComboBox(comboBox6);
            DesactivarEdicion();

        }

        private void obtenerDataClienteComboBox(ComboBox cmb)
        {
            LogicaConsultas Logica = new LogicaConsultas();
            cmb.DataSource = Logica.ListarClientes();
            cmb.DisplayMember = "nombre_completo";
            cmb.ValueMember = "ClienteId";
        }

        private void obtenerDataPaquetesComboBox(ComboBox cmb)
        {
            LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3();
            cmb.DataSource = Logica.ListarPaquetes();
            cmb.DisplayMember = "nombre_destinatario";
            cmb.ValueMember = "PaqueteId";
        }

        private void DesactivarEdicion()
        {
            monthCalendar2.Enabled = false;
            textBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            button2.Enabled = false;
        }
        public void activedFormEdicion()
        {
            monthCalendar2.Enabled = true;
            textBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            button2.Enabled = true;

        }

        public void resetFormEdicion()
        {
            textBox2.Text = "";
        }

        private bool validateFormCrear()
        {
            if (textBox1.Text == "")
                return false;
            return true;
        }
        private bool validateFormEditar()
        {
            if (textBox2.Text == "")
                return false;
            return true;
        }

        private void resetFormCrear()
        {
            textBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateFormCrear())
            {
                LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3(); string resp;
                resp = Logica.GuardarEnvios(((int)comboBox1.SelectedValue).ToString(), ((int)comboBox2.SelectedValue).ToString(), monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"), textBox1.Text, (Convert.ToInt32(checkBox1.Checked)).ToString());
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.ListarEnvios();
                    dataGridView1.Refresh();
                    resetFormCrear();
                }
                else
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Verificar que todos los campos esten llenos", "algunos campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogicaConsultasExamen3 Logica = new LogicaConsultasExamen3();
            this.dataGridView1.DataSource = Logica.BuscarEnvios(comboBox5.Text, comboBox6.Text);
            this.dataGridView1.Refresh();
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
                    comboBox3.SelectedIndex = comboBox1.FindStringExact(selectedRow.Cells[1].Value.ToString());
                    comboBox4.SelectedIndex = comboBox2.FindStringExact(selectedRow.Cells[2].Value.ToString());
                    monthCalendar2.SelectionStart = (DateTime)selectedRow.Cells[3].Value;
                    textBox2.Text = selectedRow.Cells[4].Value.ToString().Replace(',', '.');
                    checkBox2.Checked = (Boolean)selectedRow.Cells[5].Value;
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
                resp = Logica.EditarEnvios(Convert.ToInt32(id), ((int)comboBox3.SelectedValue).ToString(), ((int)comboBox4.SelectedValue).ToString(), monthCalendar2.SelectionStart.ToString("yyyy-MM-dd"), textBox2.Text, (Convert.ToInt32(checkBox2.Checked)).ToString());
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.ListarEnvios();
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
