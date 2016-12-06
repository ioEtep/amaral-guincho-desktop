using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Amaral_Guincho_Software.Classes
{
    abstract class funcLogado
    {
        private static int id_func, id_cargo;
        private static string nome_func, sobrenome_func, cep_func, cpf_func, sx_func, tel_func, email_func, residencia_func, bairro_func, uf_func, cid_func;
        private static DateTime dtnasc_func, dtcont_func;
        private static String email_logado, password_logado;

        #region Variaveis Encapsuladas
        public static int Id_func
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

        public static int Id_cargo
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

        public static string Nome_func
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

        public static string Sobrenome_func
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

        public static string Cep_func
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

        public static string Cpf_func
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

        public static string Sx_func
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

        public static string Tel_func
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

        public static string Email_func
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

        public static string Residencia_func
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

        public static string Bairro_func
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

        public static string Uf_func
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

        public static string Cid_func
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

        public static DateTime Dtnasc_func
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

        public static DateTime Dtcont_func
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

        public static string Email_logado
        {
            get
            {
                return email_logado;
            }

            set
            {
                email_logado = value;
            }
        }

        public static string Password_logado
        {
            get
            {
                return password_logado;
            }

            set
            {
                password_logado = value;
            }
        }
        #endregion

        private static Criptografia cripto = new Criptografia("ETEP");

        // variaveis para acessar o MySql
        private static MySqlDataAdapter comando_sql;
        private static MySqlCommandBuilder executar_comando;
        private static DataTable tabela_memoria;

        // método private de acesso ao BD
        private static void carregar_tabela(string comando)
        {
            // criar uma sacolinha vazia
            tabela_memoria = new DataTable();

            // converter um texto (string) para um comando SQL
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);

            // executar o comando SQL 
            executar_comando = new MySqlCommandBuilder(comando_sql);

            // resposta que será armazenada na sacolinha
            comando_sql.Fill(tabela_memoria);
        }

        public static void logar(String usuario, String senha)
        {
            usuario = cripto.Encrypt(usuario);
            senha = cripto.Encrypt(senha);

            carregar_tabela("select * from funcionario f innerjoin login l on f.id_func = l.id_func where f.email_func = '"+usuario+"' and l.password_login ='"+senha+"' ");

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
        }

     /*   public static void pesq(String usuario, String senha)
        {
            usuario = cripto.Encrypt(usuario);
            senha = cripto.Encrypt(senha);

            carregar_tabela("select * from funcionario f inner join login l on f.id_func = l.id_func where f.email_func = '" + usuario + "' and l.password_login= '" + senha + "'");

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                Id_func = Convert.ToInt32(tabela_memoria.Rows[i]["id_func"].ToString());
                Id_cargo = Convert.ToInt32(tabela_memoria.Rows[i]["id_cargo"].ToString());
                Nome_func = cripto.Decrypt(tabela_memoria.Rows[i]["nome_func"].ToString());
                Sobrenome_func = cripto.Decrypt(tabela_memoria.Rows[i]["sobrenome_func"].ToString());
                Dtnasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dtnasc_func"].ToString()));
                Cep_func = cripto.Decrypt(tabela_memoria.Rows[i]["cep_func"].ToString());
                Dtcont_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dtcont_func"].ToString()));
                Sx_func = cripto.Decrypt(tabela_memoria.Rows[i]["sx_func"].ToString());
                Tel_func = cripto.Decrypt(tabela_memoria.Rows[i]["tel_func"].ToString());
                Email_func = cripto.Decrypt(tabela_memoria.Rows[i]["email_func"].ToString());
                Residencia_func = cripto.Decrypt(tabela_memoria.Rows[i]["residencia_func"].ToString());
                Bairro_func = cripto.Decrypt(tabela_memoria.Rows[i]["bairro_func"].ToString());
                Uf_func = cripto.Decrypt(tabela_memoria.Rows[i]["uf_func"].ToString());
                Cid_func = cripto.Decrypt(tabela_memoria.Rows[i]["cid_func"].ToString());
            }

        }*/

        public static bool pesqId(String email)
        {
            email = cripto.Encrypt(email);

            carregar_tabela("select id_func from funcionario where email_func = '" + email + "'");

            try
            {
                Id_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                return true;
            }   
            catch { return false; }

        }

        public static bool pesqFunc(int id)
        {
            carregar_tabela("select * from funcionario where id_func = '" + id + "'");

            try
            {
                Id_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                Id_cargo = Convert.ToInt32(tabela_memoria.Rows[0]["id_cargo"].ToString());
                Nome_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome_func"].ToString());
                Sobrenome_func = cripto.Decrypt(tabela_memoria.Rows[0]["sobrenome_func"].ToString());
                Dtnasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dtnasc_func"].ToString()));
                Cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                Cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                Dtcont_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dtcont_func"].ToString()));
                Sx_func = cripto.Decrypt(tabela_memoria.Rows[0]["sx_func"].ToString());
                Tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                Email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                Residencia_func = cripto.Decrypt(tabela_memoria.Rows[0]["residencia_func"].ToString());
                Bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                Uf_func = cripto.Decrypt(tabela_memoria.Rows[0]["uf_func"].ToString());
                Cid_func = cripto.Decrypt(tabela_memoria.Rows[0]["cid_func"].ToString());
                return true;
            }
            catch { return false; }
        }
    }
}
