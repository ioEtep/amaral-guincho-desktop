using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Amaral_Guincho_Software
{
    class acessoFuncionário
    {
        Criptografia cripto = new Criptografia("ETEP");
        int id_func, id_cargo;
        String nome_func, sobrenome_func, cep_func, cpf_func, sx_func, tel_func, email_func, residencia_func, bairro_func, uf_func, cid_func;
        DateTime dtnasc_func, dtcont_func;

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        #region Variaveis
        public int Id_func
        {
            get
            {
                return id_func;
            }

            set
            {
                id_func = value;
            }
        }

        public int Id_cargo
        {
            get
            {
                return id_cargo;
            }

            set
            {
                id_cargo = value;
            }
        }

        public string Nome_func
        {
            get
            {
                return nome_func;
            }

            set
            {
                nome_func = value;
            }
        }

        public string Sobrenome_func
        {
            get
            {
                return sobrenome_func;
            }

            set
            {
                sobrenome_func = value;
            }
        }

        public string Cep_func
        {
            get
            {
                return cep_func;
            }

            set
            {
                cep_func = value;
            }
        }

        public string Cpf_func
        {
            get
            {
                return cpf_func;
            }

            set
            {
                cpf_func = value;
            }
        }

        public string Sx_func
        {
            get
            {
                return sx_func;
            }

            set
            {
                sx_func = value;
            }
        }

        public string Tel_func
        {
            get
            {
                return tel_func;
            }

            set
            {
                tel_func = value;
            }
        }

        public string Email_func
        {
            get
            {
                return email_func;
            }

            set
            {
                email_func = value;
            }
        }

        public string Residencia_func
        {
            get
            {
                return residencia_func;
            }

            set
            {
                residencia_func = value;
            }
        }

        public string Bairro_func
        {
            get
            {
                return bairro_func;
            }

            set
            {
                bairro_func = value;
            }
        }

        public string Uf_func
        {
            get
            {
                return uf_func;
            }

            set
            {
                uf_func = value;
            }
        }

        public string Cid_func
        {
            get
            {
                return cid_func;
            }

            set
            {
                cid_func = value;
            }
        }

        public DateTime Dtnasc_func
        {
            get
            {
                return dtnasc_func;
            }

            set
            {
                dtnasc_func = value;
            }
        }

        public DateTime Dtcont_func
        {
            get
            {
                return dtcont_func;
            }

            set
            {
                dtcont_func = value;
            }
        }
        #endregion

        private void carregar_tabela(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void inserir(String nome, String sobrenome, String dtnasc , String cep, String cpf, String dtcont, String sx, String tel, String email, String residencia, String bairro, String uf, String cid)
        {
            nome = cripto.Encrypt(nome);
            sobrenome = cripto.Encrypt(sobrenome);
            dtnasc =  cripto.Encrypt(dtnasc);
            cep = cripto.Encrypt(cep);
            cpf = cripto.Encrypt(cpf);
            dtcont = cripto.Encrypt(dtcont);
            sx = cripto.Encrypt(sx);
            tel = cripto.Encrypt(tel);
            email = cripto.Encrypt(email);
            residencia = cripto.Encrypt(residencia);
            bairro = cripto.Encrypt(bairro);
            uf = cripto.Encrypt(uf);
            cid = cripto.Encrypt(cid);


            carregar_tabela("INSERT INTO FUNCIONARIO VALUES(0,'" + nome + "', '" + sobrenome + "', '" + dtnasc + "', '" + cep + "', '" + cpf + "', '" + dtcont + "', '" + sx + "', '" + tel + "', '"+email+"', '"+residencia+"', '"+bairro+"', '"+uf+"', '"+cid+"',null");

        }
        public void logar(String usuario, String senha)
        {
            usuario = cripto.Encrypt(usuario);
            senha = cripto.Encrypt(senha);
            //carregar_tabela("select * from funcionario where")

        }
    

    }
}
