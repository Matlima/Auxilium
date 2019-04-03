using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using Crud2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Crud2.Repository
{
    public class AulaRepository
    {
        string Con;
        
        public AulaRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(AulaModel aula)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tb_aula(disciplina, assunto, descricao, data_solicitacao, local_aula, horario, data_realizacao, concluida) " +
                "Values(?disciplina,?assunto,?descricao,?data_solicitacao,?local_aula,?horario,?data_realizacao,?concluida)";
            Com.Parameters.AddWithValue("?disciplina", aula.Disciplina);
            Com.Parameters.AddWithValue("?assunto", aula.Assunto);
            Com.Parameters.AddWithValue("?descricao", aula.Descricao);
            Com.Parameters.AddWithValue("?data_solicitacao", aula.DataSolicitacao);
            Com.Parameters.AddWithValue("?local_aula", aula.LocalAula);
            Com.Parameters.AddWithValue("?horario", aula.Horario);
            Com.Parameters.AddWithValue("?data_realizacao", aula.DataRealizacao);
            Com.Parameters.AddWithValue("?concluida", aula.Concluida);
            try
            {
                CN.Open();              
                int registrosAfetados = Com.ExecuteNonQuery();
            }catch (MySqlException ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }
        }

        public void Update(AulaModel aula)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "UPDATE tb_aula SET disciplina=@disciplina, assunto=@assunto, descricao=@descricao, data_solicitacao=@data_solicitacao, local_aula=@local_aula, horario=@horario, data_realizacao=@data_realizacao, concluida=@concluida WHERE id_aula=@id_aula";
            Com.Parameters.AddWithValue("@disciplina", aula.Disciplina);
            Com.Parameters.AddWithValue("@assunto", aula.Assunto);
            Com.Parameters.AddWithValue("@descricao", aula.Descricao);
            Com.Parameters.AddWithValue("@data_solicitacao", aula.DataSolicitacao);
            Com.Parameters.AddWithValue("@local_aula", aula.LocalAula);
            Com.Parameters.AddWithValue("@horario", aula.Horario);
            Com.Parameters.AddWithValue("@data_realizacao", aula.DataRealizacao);
            Com.Parameters.AddWithValue("@concluida", aula.Concluida);
            Com.Parameters.AddWithValue("@id_aula", aula.Idaula);
            try
            {
                CN.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
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

        public void delete(AulaModel aula)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "DELETE FROM tb_aula WHERE id_aula=@id_aula";
            Com.Parameters.AddWithValue("@id_aula", aula.Idaula);
            try
            {
                CN.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
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

        public List<AulaModel> selectAll()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<AulaModel> listaAulas = new List<AulaModel>();
            Com.CommandText = "SELECT * FROM tb_aula";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();               
            
                while (dr.Read())
                {
                    AulaModel aulaaux = new AulaModel();
                    aulaaux.Idaula = Convert.ToInt32(dr["id_aula"]);
                    aulaaux.Assunto = (String)dr["assunto"];
                    aulaaux.Disciplina = (String)dr["disciplina"];
                    aulaaux.Descricao = (String)dr["descricao"];
                    aulaaux.DataSolicitacao = (DateTime)dr["data_solicitacao"];
                    aulaaux.DataRealizacao = (DateTime)dr["data_realizacao"];
                    aulaaux.LocalAula = (String)dr["local_aula"];
                    aulaaux.Horario = (DateTime)dr["horario"];
                    aulaaux.Concluida = (String)dr["concluido"];
                    listaAulas.Add(aulaaux);
                }
                return listaAulas;
            }catch(MySqlException ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }            
        }

        public AulaModel selectId(AulaModel aula)
        {

            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tb_aula WHERE id_aula=?id_aula";
            Com.Parameters.AddWithValue("?id_aula", aula.Idaula);
            AulaModel aulaaux = new AulaModel();
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    aulaaux.Idaula = Convert.ToInt32(dr["id_aula"]);
                    aulaaux.Assunto = (String)dr["assunto"];
                    aulaaux.Disciplina = (String)dr["disciplina"];
                    aulaaux.Descricao = (String)dr["descricao"];
                    aulaaux.DataSolicitacao = (DateTime)dr["data_solicitacao"];
                    aulaaux.DataRealizacao = (DateTime)dr["data_realizacao"];
                    aulaaux.LocalAula = (String)dr["local_aula"];
                    aulaaux.Horario = (DateTime)dr["horario"];
                    aulaaux.Concluida = (String)dr["concluido"];
                }
                return aulaaux;
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