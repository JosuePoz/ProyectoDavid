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
    public partial class FormMunicipio : Form
    {
        string id = "";
        public FormMunicipio()
        {
            InitializeComponent();
        }

        private void FormMunicipio_Load(object sender, EventArgs e)
        {
            LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio();
            this.dataGridView1.DataSource = Logica.Listar();
            this.dataGridView1.Refresh();
            obtenerDataComboBox(comboBox1);
            obtenerDataComboBox(comboBox2);
            DesactivarEdicion();
        }
        private void obtenerDataComboBox(ComboBox cmb)
        {
            LogicaConsultas Logica = new LogicaConsultas();
            cmb.DataSource = Logica.ListarDepartamentos();
            cmb.DisplayMember = "nombre_departamento";
            cmb.ValueMember = "DepartamentoId";
        }
        private void DesactivarEdicion()
        {
            textBox2.Enabled = false;
            comboBox2.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void ReActivarEdicion()
        {
            textBox2.Enabled = true;
            comboBox2.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio();
            this.dataGridView1.DataSource = Logica.Buscar(textBox3.Text);
            this.dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio(); string resp;
                resp = Logica.Registrar(textBox1.Text, ((int)comboBox1.SelectedValue).ToString());
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.Listar();
                    dataGridView1.Refresh();
                    textBox1.Text = "";
                }
                else
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Se necesita llenar todos los campos", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    textBox2.Text = selectedRow.Cells[1].Value.ToString();
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(selectedRow.Cells[2].Value.ToString());
                    if (!button2.Enabled)
                        ReActivarEdicion();
                }
                else if (button2.Enabled)
                {
                    id = "";
                    DesactivarEdicion();
                    textBox2.Text = "";
                }
            }
            else if (button2.Enabled)
            {
                id = "";
                DesactivarEdicion();
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio(); string resp;
                resp = Logica.Editar(id, textBox2.Text, ((int)comboBox2.SelectedValue).ToString());
                if (resp.ToUpper().Contains("ÉXITO"))
                {
                    MessageBox.Show("Se ha grabado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = Logica.Listar();
                    dataGridView1.Refresh();
                    textBox2.Text = "";
                    DesactivarEdicion();
                }
                else
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Se necesita llenar todos los campos", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogicaConsultasMunicipio Logica = new LogicaConsultasMunicipio(); string resp;
            resp = Logica.Eliminar(id);
            if (resp.ToUpper().Contains("ÉXITO"))
            {
                MessageBox.Show("Se ha eliminado con éxito", resp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = Logica.Listar();
                dataGridView1.Refresh();
                textBox2.Text = "";
                DesactivarEdicion();
                id = "";
            }
            else
                MessageBox.Show(resp, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
