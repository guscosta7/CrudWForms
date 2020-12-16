using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWForms.Classes;

namespace CrudWForms.Cadastro
{
    public partial class frmCadastroCliente : Form
    {

        public frmCadastroCliente()
        {
            InitializeComponent();
            preencheGrid();
        }

        public static frmCadastroCliente Instance()
        {
            if (frmCliente == null)
            {
                frmCliente = new frmCadastroCliente();
            }
            return frmCliente;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.ID = Convert.ToInt32(txtCodigo.Text);
            cliente.Nome = txtNome.Text;

            try
            {
                AcessoFB.fb_InserirDados(cliente);
                MessageBox.Show("Cliente inserido com sucesso !", "Inserir", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void preencheGrid()
        {
            try
            {
                dgvClientes.DataSource = AcessoFB.fb_GetDados().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
