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
    public partial class Auditoria : Form
    {
        Acessos.acessoAuditoria audit = new Acessos.acessoAuditoria();
        String query;

        public Auditoria()
        {
            InitializeComponent();
        }

        private void carregarLog()
        {
            DataTable temp = audit.listarTudo();
            for(int i = 0; i<temp.Rows.Count; i++)
            {
                DataGridViewRow linha = new DataGridViewRow();
                linha.CreateCells(gvLog);
                linha.Cells[0].Value = temp.Rows[i]["funcionario"].ToString();
                linha.Cells[1].Value = temp.Rows[i]["acao"].ToString();
                linha.Cells[2].Value = temp.Rows[i]["hora"].ToString();
                gvLog.Rows.Add(linha);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            gvLog.DataSource = audit.listarTudo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 fr = new Form1();
            fr.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.informacoesUsuario usu = new informacoesUsuario();
            usu.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.telaBackup bk = new telaBackup();
            bk.ShowDialog();
        }
    }
}
