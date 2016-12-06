using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amaral_Guincho_Software.Telas
{
    public partial class informacoesUsuario : Form
    {

        acessoFuncionário func = new acessoFuncionário();
        acessoCEP CEP = new acessoCEP();
        acessoLogin login = new acessoLogin();
        

        public informacoesUsuario()
        {
            InitializeComponent();
        }

        private void tlBtTelaQrCode_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }

        private void tlBtBackup_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.telaBackup bk = new telaBackup();
            bk.ShowDialog();
        }

        private void informacoesUsuario_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
            carregarInfo();
            Classes.funcLogado.pesqFunc(Classes.funcLogado.Id_func);

        }


        private void carregarInfo()
        {



            Classes.funcLogado.pesqFunc(Classes.funcLogado.Id_func);

            txtNome.Text = Classes.funcLogado.Nome_func;
            txtSobrenome.Text = Classes.funcLogado.Sobrenome_func;
            mskDataNascimento.Text = Classes.funcLogado.Dtnasc_func.ToString();
            mskCep.Text = Classes.funcLogado.Cep_func;
            mskCpf.Text = Classes.funcLogado.Cpf_func;
            mskDataContratacao.Text = Classes.funcLogado.Dtcont_func.ToString();
            txtSexo.Text = Classes.funcLogado.Sx_func;
            mskTelefone.Text = Classes.funcLogado.Tel_func;
            txtEmail.Text = Classes.funcLogado.Email_func;
            txtResidencia.Text = Classes.funcLogado.Residencia_func;
            txtBairro.Text = Classes.funcLogado.Bairro_func;
            txtUf.Text = Classes.funcLogado.Uf_func;
            txtCidade.Text = Classes.funcLogado.Cid_func;

            if(Classes.funcLogado.Id_cargo == 1)
            {
                txtCargo.Text = "Administrador";
            }

            if (Classes.funcLogado.Id_cargo == 2)
            {
                txtCargo.Text = "Secretaria";
            }

            if (Classes.funcLogado.Id_cargo == 3)
            {
                txtCargo.Text = "Motorista";
            }

            if (Classes.funcLogado.Id_cargo == 4)
            {
                txtCargo.Text = "outro";
            }

            /*login.pesquisarId(Classes.funcLogado.Email_logado, Classes.funcLogado.Password_logado);

            txtLogin.Text = login.Username_login;
            txtSenha.Text = login.Password_login;*/

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.Auditoria au = new Telas.Auditoria();
            au.ShowDialog();
        }
    }
}
