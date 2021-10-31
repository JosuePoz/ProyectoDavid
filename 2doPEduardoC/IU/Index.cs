using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormClientes fclientes = new FormClientes();
            fclientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FDepartamento fDepartamento = new FDepartamento();
            fDepartamento.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMunicipio fMunicipio = new FormMunicipio();
            fMunicipio.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormPaquetes formPaquetes = new FormPaquetes();
            formPaquetes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormEnvios formEnvios = new FormEnvios();
            formEnvios.Show();
        }
    }
}
