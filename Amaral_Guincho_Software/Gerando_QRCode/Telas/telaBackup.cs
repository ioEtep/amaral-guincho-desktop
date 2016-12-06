using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;



namespace Amaral_Guincho_Software.Telas
{
    public partial class telaBackup : Form
    {
        Acessos.acessoAuditoria audit = new Acessos.acessoAuditoria();
        

        public telaBackup()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                //quando executar fara o codigo seguinte

                //exemplo do path
                string path = "C:\\Users\\aluno\\Documents\\";

                MysqlBackup_Restore(path, "backup");

                //corre uma thread com o processo que faz o backup ou restore
                Thread t = new Thread(delegate () { MySqlProcess(path); });
                t.Start();

                audit.inserir(Classes.funcLogado.Id_func, "Fez Backup", DateTime.Now.ToString());
                
                MessageBox.Show("Backup realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Erro ao realizar o backup!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private static void MysqlBackup_Restore(string path, string type)
        {

            String nomeArq = "Backup" + DateTime.Now.Day + " " + DateTime.Now.Month.ToString();

            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.1/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            if (type == "backup")
            {
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -pALUNOS --databases amaralguincho > " + path + "\\MySqlbackup.sql\"");
            }
            else
            {
                //se for restore
                sw.WriteLine("mysql.exe -uroot -pALUNOS < \"" + path + "\\MySqlbackup.sql\"");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path)
        {
            //cria o processo a correr o MySqlbackup.cmd
            Process.Start(Path + "\\MySqlbackup.cmd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //quando executar fara o codigo seguinte

                //exemplo do path
                string path = "C:\\Users\\aluno\\Documents\\";

                MysqlBackup_Restore(path, "restore");

                //corre uma thread com o processo que faz o backup ou restore
                Thread t = new Thread(delegate () { MySqlProcess(path); });
                t.Start();

                audit.inserir(Classes.funcLogado.Id_func, "Restaurou Backup", DateTime.Now.ToString());

                MessageBox.Show("Backup restaurado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Erro ao restaurar o backup", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.informacoesUsuario usu = new informacoesUsuario();
            usu.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.Auditoria au = new Telas.Auditoria();
            au.ShowDialog();
        }
    }
}
