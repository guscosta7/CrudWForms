using CrudWForms.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWForms
{
    public partial class frmPrincipal : Form
    {
        private static frmCadastroCliente frmCadastroCliente = null;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCliente = frmCadastroCliente.Instance();
            frmCadastroCliente.MdiParent = this;
            frmCadastroCliente.Show();
            frmCadastroCliente.Activate();
        }
    }
}
