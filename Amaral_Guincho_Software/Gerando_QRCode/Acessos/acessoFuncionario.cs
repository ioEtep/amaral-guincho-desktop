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

        public void inserir(int cargo ,String nome, String sobrenome, String dtnasc , String cep, String cpf, String dtcont, String sx, String tel, String email, String residencia, String bairro, String uf, String cid)
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


            carregar_tabela("INSERT INTO funcionario VALUES(0,'"+cargo+"' ,'" + nome + "', '" + sobrenome + "', '" + dtnasc + "', '" + cep + "', '" + cpf + "', '" + dtcont + "', '" + sx + "', '" + tel + "', '" + email + "', '" + residencia + "', '" + bairro + "', '" + uf + "', '" + cid + "',null);");

        }
    

        public bool pesqFunc (String codFuncionario)
        {
            carregar_tabela("Select * from funcionario f, cargo c where c.id_cargo = f.id_cargo and f.id_func = '"+codFuncionario+"'");

            try
            {

                Id_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                Id_cargo = Convert.ToInt32(tabela_memoria.Rows[0]["id_cargo"].ToString());
                Nome_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome_func"].ToString());
                Sobrenome_func = cripto.Decrypt(tabela_memoria.Rows[0]["sobrenome_func"].ToString());
                Dtnasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dtnasc_func"].ToString()));
                Cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                Dtcont_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dtcont_func"].ToString()));
                Sx_func = cripto.Decrypt(tabela_memoria.Rows[0]["sx_func"].ToString());
                Tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                Email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                Residencia_func = cripto.Decrypt(tabela_memoria.Rows[0]["residencia_func"].ToString());
                Bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                Uf_func = cripto.Decrypt(tabela_memoria.Rows[0]["uf_func"].ToString());
                Cid_func = cripto.Decrypt(tabela_memoria.Rows[0]["cid_func"].ToString());
                return true;
            } catch { return false; }

        }

        public bool pesqId(String email)
        {
            carregar_tabela("Select id_func from funcionario where email_func'" + email + "'");

            try
            {
                id_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                return true;
            } catch { return false; }

        }
    }
}
