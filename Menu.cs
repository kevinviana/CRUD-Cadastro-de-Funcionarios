using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Cadastro_de_Funcionarios
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios add = new Funcionarios();
            add.ShowDialog();

        }
    }
}
