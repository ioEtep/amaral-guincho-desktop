using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Amaral_Guincho_Software.Acessos
{
    class acessoAuditoria
    {
        int logId, funcinario;
        String acao, hora;




        Criptografia cripto = new Criptografia("ETEP");

        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        #region Variaveis Encapsuladas
        public int LogId
        {
            get
            {
                return logId;
            }

            set
            {
                logId = value;
            }
        }

        public int Funcinario
        {
            get
            {
                return funcinario;
            }

            set
            {
                funcinario = value;
            }
        }

        public string Acao
        {
            get
            {
                return acao;
            }

            set
            {
                acao = value;
            }
        }

        public string Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }
        #endregion

        // método private de acesso ao BD
        private void carregar_tabela(string comando)
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

        public void inserir( int codFunc, String acao, String hora)
        {
            acao = cripto.Encrypt(acao);
            hora = cripto.Encrypt(hora);

            carregar_tabela("Insert into userlog values(0, '" + codFunc + "', '" + acao + "', '" + hora + "')");
        }

        public DataTable listarTudo()
        {
            DataTable tabelaTemp = new DataTable();

            tabelaTemp.Columns.Add("logId",typeof(int));
            tabelaTemp.Columns.Add("funcinario",typeof(int));
            tabelaTemp.Columns.Add("acao",typeof(String));
            tabelaTemp.Columns.Add("hora",typeof(String));

            carregar_tabela("select * from userlog");

            for(int i=0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["logId"] = tabela_memoria.Rows[i]["logId"].ToString();
                linha["funcinario"] = tabela_memoria.Rows[i]["funcinario"].ToString(); 
                linha["acao"] = cripto.Decrypt( tabela_memoria.Rows[i]["acao"].ToString()); 
                linha["hora"] = cripto.Decrypt( tabela_memoria.Rows[i]["hora"].ToString());

                tabelaTemp.Rows.Add(linha);
            }
            return tabelaTemp;

        }
        public DataTable pesq(String query)
        {
            DataTable temp = new DataTable();


            carregar_tabela("select * from userlog u innerjoin funcionario f on f.id_func = u.funcionario ");
            
            temp.Columns.Add("funcionario", typeof(int));
            temp.Columns.Add("acao", typeof(String));
            temp.Columns.Add("hora", typeof(String));

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["logId"] = tabela_memoria.Rows[i]["logId"].ToString();
                linha["funcionario"] = tabela_memoria.Rows[i]["funcionario"].ToString();
                linha["acao"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao"].ToString());
                linha["hora"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora"].ToString());
                temp.Rows.Add(linha);
            }

            DataView tmp = new DataView(temp);

            tmp.RowFilter = query;

            return tmp.ToTable();
        }


    }
}
