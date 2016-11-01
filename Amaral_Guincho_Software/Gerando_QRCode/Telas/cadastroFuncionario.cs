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
    public partial class cadastroFuncionario : Form
    {
        String password;
        String nome, sobrenome, dataNasc, cep, cpf, dataCont, sx, tel, email ,residencia;
        String bairro, uf, cid;

        acessoFuncionário func = new acessoFuncionário();
        SenhaAleatoria senha = new SenhaAleatoria();
        acessoCEP CEP = new acessoCEP();
        Email em = new Email();


        public cadastroFuncionario()
        {
            InitializeComponent();
        }
        #region CEP MSK
        private void mskCep_TextChanged(object sender, EventArgs e)
        {
            if (mskCep.MaskFull == false)
                vlCEP.Visible = true;
            else
                vlCEP.Visible = false;

            if (mskCep.MaskFull == true && mskCep.Text != "00.000-000")
            {
                if(CEP.buscaEndereco(limparCEP(mskCep.Text)) == true)
                {
                    txtBairro.Text = CEP.Bairro;
                    txtUf.Text = CEP.Uf;
                    txtCidade.Text = CEP.Cidade;
                    txtResidencia.Text = CEP.Logradouro;
                }
                else
                {
                    // limCep();
                }
            }
            else
            {
                //cep zona rural
                if(mskCep.Text != "  .   -" && mskCep.Text != "00.000-000")
                {
                    if(CEP.buscaEndereco(limparCEP(mskCep.Text))== true)
                    {
                        txtResidencia.Text = CEP.Logradouro;
                        txtCidade.Text = CEP.Cidade;
                        txtBairro.Text = CEP.Bairro;
                        txtUf.Text = CEP.Uf;
                        mskCep.Text = "00.000-000";
                        dadosCEP.ZonaRural = "Z";
                    }
                    else
                    {
                        // limCep();
                    }
                }
            }

        }
        #endregion
        private void btnCadastrar_Click(object sender, EventArgs e)
        { 
            try
            {
                #region Validation

                foreach (object obj in this.Controls)
                {
                    if(Validation.isOK(obj))
                    {
                        MessageBox.Show("Complete os campos vazios");
                        return;
                    }
                }

                #endregion

                cpf = mskCpf.Text;

                #region CPF

                if(!Validation.ValidateCPF(cpf))
                {
                    MessageBox.Show("Cpf não existe");
                    return;
                }

                #endregion

                email = txtEmail.Text;

                #region Email

                if(!Validation.ValidateEmail(email))
                {
                    MessageBox.Show("Email inválido");
                    return;
                }

                #endregion

                dataNasc = mskDataNascimento.Text;

                #region Data Nascimento

                try
                {
                    Convert.ToDateTime(dataNasc);
                }
                catch
                {
                    MessageBox.Show("Data incorreta");
                    return;
                }
                if(Convert.ToDateTime(dataNasc) > DateTime.Today)
                {
                    MessageBox.Show("Data inválida");
                    return;
                }
                #endregion

                password = senha.CreatePassword(5);

                nome = txtNome.Text;
                cep = mskCep.Text;
                


            }
            catch
            {
                MessageBox.Show("Erro ao cadastrar o funcionário");
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login log = new Login();
            log.ShowDialog();
        }

        public String limparCEP(string cep)
        {
            String tmp;

            tmp = cep.Remove(2, 1);

            tmp = tmp.Remove(5, 1);

            return tmp;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
