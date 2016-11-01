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
    }
}
