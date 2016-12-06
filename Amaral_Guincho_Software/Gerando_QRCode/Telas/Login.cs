using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amaral_Guincho_Software
{
    public partial class Login : Form
    {
        int tentativas;
        acessoLogin login = new acessoLogin();
        acessoFuncionário func = new acessoFuncionário();

        public Login()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            cadastroFuncionario cad = new cadastroFuncionario();
            cad.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == String.Empty || txtSenha.Text == String.Empty)
            {
                tentativas++;
                MessageBox.Show("Preencher todos os campos", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (txtLogin.Text == String.Empty)
                {
                    txtLogin.BackColor = Color.Red;
                    txtLogin.Focus();
                }
                if (txtSenha.Text == String.Empty)
                {
                    txtSenha.BackColor = Color.Red;
                    txtSenha.Focus();
                }

            }
            else
            {
                login.pesquisarId(txtLogin.Text, txtSenha.Text);



                Classes.funcLogado.Email_logado = txtLogin.Text;
                Classes.funcLogado.Password_logado = txtSenha.Text;

                Classes.funcLogado.pesqId(txtLogin.Text);


                this.Visible = false;
                Form1 fr1 = new Form1();
                fr1.ShowDialog();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
        }

    }
    }

