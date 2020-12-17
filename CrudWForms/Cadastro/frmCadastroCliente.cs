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
            try
            {
                AcessoFB.fb_InserirDados(preencherCliente());
                MessageBox.Show("Cliente inserido com sucesso !", "Inserir", MessageBoxButtons.OK);
                preencheGrid();
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNome.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void preencherTexts(Cliente cliente)
        {
            txtCodigo.Text = cliente.ID.ToString();
            txtNome.Text = cliente.Nome;

        }

        private Cliente preencherCliente()
        {
            Cliente cliente = new Cliente();
            cliente.ID = Convert.ToInt32(txtCodigo.Text);
            cliente.Nome = txtNome.Text;

            return cliente;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                AcessoFB.fb_AlterarDados(preencherCliente());
                MessageBox.Show("Cliente atualizado com sucesso !", "Atualizado", MessageBoxButtons.OK);
                preencheGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
