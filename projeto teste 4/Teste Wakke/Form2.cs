using System;
using System.Windows.Forms;
using Teste_Wakke.Models;

namespace Teste_Wakke
{
    public partial class frm_cadastro : Form
    {

        public frm_cadastro()
        {
            InitializeComponent();
        }
            
        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_cnome_TextChanged(object sender, EventArgs e)
        {

        }

        public void Btn_salvar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            u.Txdcid = txd_id.Text;
            u.Txtnome = Txt_nome.Text;
            u.Rbativo = rb_ativo.Text;
            u.Txtdata = txd_cdata.Text;
            u.Txtaltura = Txt_altura.Text;
            u.Txtsobrenome = Txt_sobrenome.Text;
            u.Rbativo = "1";

            Banco banco = new Banco();
            banco.Add(u);

            Close();
        }

        public void Frm_cadastro_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();


            string rbativo = usuario.Rbativo;
            string rbinativo = usuario.Rbativo;
            string nome = usuario.Txtnome;
            string sobrenome = usuario.Txtsobrenome;
            string data = usuario.Txtdata;
            string altura = usuario.Txtaltura;


            usuario.Rbativo = rbativo;
            usuario.Txtnome = nome;
            usuario.Txtsobrenome = sobrenome;
            usuario.Txtdata = data;
            usuario.Txtaltura = altura;

            rb_ativo.Text = rbativo;
            rb_inativo.Text = rbinativo;
            Txt_nome.Text = nome;
            Txt_sobrenome.Text = sobrenome;
            txd_cdata.Text = data;
            Txt_altura.Text = altura;

        }

        private void Txd_cid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Txt_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txd_cdata_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Txt_sobrenome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_altura_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rb_ativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rb_inativo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
