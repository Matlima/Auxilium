using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crud2.Models;
using Crud2.Models;
using System.Configuration;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Crud2.Repository
{
    public class InstituicaoEnsinoRepository
    {
        string Con;


        public InstituicaoEnsinoRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(InstituicaoEnsinoModel instituicaoEnsino)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tb_instituicao_ensino(nome) Values(?nome)";
            Com.Parameters.AddWithValue("?nome", instituicaoEnsino.nome);
            try
            {
                CN.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }
        }

        public DataTable SelectAll()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            MySqlDataAdapter da;
            Com.CommandText = "SELECT * from tb_instituicao_ensino";
            try
            {
                CN.Open();
                Com = new MySqlCommand(Com.CommandText, CN);
                da = new MySqlDataAdapter(Com);
                DataTable Instituicoes = new DataTable();
                da.Fill(Instituicoes);
                return Instituicoes;
            }catch(MySqlException ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }
        }











        private Exception MySqlException(Func<string> toString)
        {
            throw new NotImplementedException();
        }
    }
}