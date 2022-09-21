using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Teste_Wakke.Models;

namespace Teste_Wakke
{
    public partial class frm_inicio : Form
    {

        public frm_inicio()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            Banco banco = new Banco();
            banco.Create_db();
            insert_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Banco banco = new Banco();
            Usuario usuario = new Usuario();

            banco.Delete(usuario);
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            frm_cadastro cadastro = new frm_cadastro();
            cadastro.ShowDialog();
            dt_formulario.Rows.Clear();
            insert_grid();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            frm_cadastro cadastro = new frm_cadastro();
            cadastro.ShowDialog();
        }

        private void Lbl_titulo_Click(object sender, EventArgs e)
        {

        }

        public void insert_grid()
        {
            Banco banco = new Banco();
            var list_u = banco.data_show(null);

            for (var i = 0; i < list_u.Count; i++)
            {
                dt_formulario.Rows.Insert(i, list_u[i].Txdcid, list_u[i].Rbativo, list_u[i].Txtnome, list_u[i].Txtsobrenome, list_u[i].Txtdata, list_u[i].Txtaltura);
            }
        }

        public void delete_grid()
        {
            var id = Convert.ToInt32(dt_formulario.Rows[dt_formulario.CurrentCell.RowIndex].Index);
            frm_inicio inicio = new frm_inicio();
        }
        /*public void delete_grid()
        {
            Banco banco = new Banco();
            var lista_u = banco.data_show(null);
            dt_formulario.Rows.Clear();
            Usuario u = new Usuario();
            banco.delete(u);

            while (lista_u.Count > 0)
            {
                dt_formulario.Rows.RemoveAt(lista_u.Count - 1);
            }

                    List<Usuario> list_u = new List<Usuario>();

            foreach (Usuario v in list_u)
            {
                var id = Convert.ToInt32(dt_formulario.Rows[dt_formulario.CurrentCell.RowIndex].Index);
                dt_formulario.Rows.RemoveAt(id);
            }
        }*/

        private void dt_formulario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dt_formulario.Rows[e.RowIndex].IsNewRow)
            {
                Usuario usuario = new Usuario();
                DataGridViewRow row = dt_formulario.Rows[e.RowIndex];
                usuario = new Usuario();

                usuario.Rbativo = Convert.ToString(row.Cells[1].Value);
                usuario.Txtnome = row.Cells[2].Value.ToString();
                usuario.Txtsobrenome = row.Cells[3].Value.ToString();
                usuario.Txtdata = Convert.ToString(row.Cells[4].Value);
                usuario.Txtaltura = Convert.ToString(row.Cells[5].Value);
            }
        }
    }
}
