using System;
using System.Data;
using Crud2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        public List<InstituicaoEnsinoModel> SelectAllList()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<InstituicaoEnsinoModel> listaInstituicoes = new List<InstituicaoEnsinoModel>();
            Com.CommandText = "SELECT * FROM tb_instituicao_ensino";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    InstituicaoEnsinoModel instituicaoaux = new InstituicaoEnsinoModel();
                    instituicaoaux.idinstituicaoEnsino = Convert.ToInt32(dr["id_instituicao_ensino"]);
                    instituicaoaux.nome = (String)dr["nome"];
                    listaInstituicoes.Add(instituicaoaux);
                }
                return listaInstituicoes;                
            }
            catch (MySqlException ex)
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