//Install-Package ZXing.Net 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaral_Guincho_Software
{

    public partial class Form1 : Form
    {

        Criptografia cripto = new Criptografia("ETEP");
        String texto;
        Acessos.acessoAuditoria audit = new Acessos.acessoAuditoria();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerarQRCode_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text == string.Empty || txtLargura.Text == string.Empty && txtLargura.Text == string.Empty)
            {

                MessageBox.Show("Preencher Todos Os Campos");
                txtTexto.Focus();
                return;
            }

            try
            {
                texto = txtTexto.Text;
                cripto.Encrypt(texto);

                int largura = Convert.ToInt32(txtLargura.Text);
                int altura = Convert.ToInt32(txtAltura.Text);
                
                picQRCode.Image = GerarQRCode(largura, altura, texto);
                audit.inserir(Classes.funcLogado.Id_func, "GerarQRcode", DateTime.Now.ToString());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #region Gerando QRCode
        public Bitmap GerarQRCode(int width, int height, string text)
        {
            try
            {
                var bw = new ZXing.BarcodeWriter();
                var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultado = new Bitmap(bw.Write(text));
                return resultado;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        private void tlBtBackup_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.telaBackup bk = new Telas.telaBackup();
            bk.ShowDialog();
            
        }

        private void tBtUsuario_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.informacoesUsuario usu = new Telas.informacoesUsuario();
            usu.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Telas.Auditoria au = new Telas.Auditoria();
            au.ShowDialog();
        }
    }
}
