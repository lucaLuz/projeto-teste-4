﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Teste_Wakke.Models
{
    public class Banco
    {
        string path = "BancoWakke.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\BancoWakke.db";

        SQLiteDataReader dr;

        public List<Usuario> data_show(frm_inicio inicio)
        {
            List<Usuario> list_u = new List<Usuario>();
            var con = new SQLiteConnection(cs);

            con.Open();

            string stm = "SELECT id, nome, ativo, sobrenome, altura, datanascimento  FROM usuario";
            var cmd = new SQLiteCommand(con);
            cmd.CommandText = stm;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Usuario u = new Usuario();
                u.Txdcid = dr.GetValue(0).ToString();
                u.Txtnome = dr.GetValue(1).ToString();
                u.Rbativo = dr.GetValue(2).ToString();
                u.Txtsobrenome = dr.GetValue(3).ToString();
                u.Txtaltura = dr.GetValue(4).ToString();
                u.Txtdata = dr.GetValue(5).ToString();

                list_u.Add(u);
            }

            return list_u;
        }


        public void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS usuario (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ativo BOOLEAN NOT NULL CHECK (true || false), nome STRING NOT NULL, sobrenome STRING NOT NULL, datanascimento DATE NOT NULL, altura DECIMAL NOT NULL)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS usuario (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ativo BOOLEAN NOT NULL CHECK (true || false), nome STRING NOT NULL, sobrenome STRING NOT NULL, datanascimento DATE NOT NULL, altura DECIMAL NOT NULL)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Database criada");
                return;
            }
        }

        public void Add(Usuario u)
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            try
            {
                var data = u.Txtdata.Split('/');
                cmd.CommandText = $"INSERT INTO usuario( ativo, nome, sobrenome, datanascimento, altura) values ( {int.Parse(u.Rbativo)}, '{u.Txtnome}', '{u.Txtsobrenome}', '{data[2]}{data[1]}{data[0]}',{decimal.Parse(u.Txtaltura).ToString("N2").Replace(",",".")})";

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                Console.WriteLine("Cadastro concluido");
                return;
            }

        }

        public void Update()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                Usuario cadastro = new Usuario();

                cmd.CommandText = "UPDATE usuario SET ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura WHERE ID =@ID";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ID", cadastro.Txdcid);
                cmd.Parameters.AddWithValue("@ativo", cadastro.Rbativo);
                cmd.Parameters.AddWithValue("@nome", cadastro.Txtnome);
                cmd.Parameters.AddWithValue("@sobrenome", cadastro.Txtsobrenome);
                cmd.Parameters.AddWithValue("@data de nascimento", cadastro.Txtdata);
                cmd.Parameters.AddWithValue("@altura", cadastro.Txtaltura);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                Console.WriteLine("Atualização concluida");
                return;
            }
        }


        public void delete(Usuario u)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "DELETE FROM usuario WHERE ID=ID, ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ID", u.Txdcid);
                cmd.Parameters.AddWithValue("@ativo", u.Rbativo);
                cmd.Parameters.AddWithValue("@nome", u.Txtnome);
                cmd.Parameters.AddWithValue("@sobrenome", u.Txtsobrenome);
                cmd.Parameters.AddWithValue("@data de nascimento", u.Txtdata);
                cmd.Parameters.AddWithValue("@altura", u.Txtaltura);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Exluido");
                return;
            }
        }

    }
}
