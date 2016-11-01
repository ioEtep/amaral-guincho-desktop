using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Amaral_Guincho_Software
{
    class acessoLogin
    {
        int id_login, id_func;
        String username_login, password_login;
        #region Variaveis

        public int Id_login
        {
            get
            {
                return id_login;
            }

            set
            {
                id_login = value;
            }
        }

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

        public string Username_login
        {
            get
            {
                return username_login;
            }

            set
            {
                username_login = value;
            }
        }

        public string Password_login
        {
            get
            {
                return password_login;
            }

            set
            {
                password_login = value;
            }
        }
        #endregion

        Criptografia cripto = new Criptografia("ETEP");
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        private void carregar_tabela(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public Boolean pesquisarId(String pesq)
        {
            cripto.Encrypt(pesq);
            carregar_tabela("Select * from login l inner join funcionario f on l.id_func = f.id_func where username_login = '" + pesq + "' ");

            try
            {
                Id_login = Convert.ToInt32(tabela_memoria.Rows[0]["id_login"].ToString());
                Username_login = cripto.Decrypt(tabela_memoria.Rows[0]["username_login"].ToString());
                Password_login = cripto.Decrypt(tabela_memoria.Rows[0]["password_login"].ToString());
                Id_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                return true;
            }
            catch { return false; }
        }
    }
}