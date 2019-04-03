using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Crud2.Models;

namespace Crud2.Repository
{
    public class FeedbackRepository
    {

        string Con;

        public FeedbackRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(FeedbackModel feedback)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO feedback(descricao, fk_aula) VALUES (?descricao,?fk_aula)";
            Com.Parameters.AddWithValue("?descricao", feedback.Descricao);
            Com.Parameters.AddWithValue("?fk_aula", feedback.Aula.Idaula);
            try
            {
                CN.Open();
                int registroAfetados = Com.ExecuteNonQuery();
            }catch(MySqlException ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }
        }

        public void Update(FeedbackModel feedback)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "UPDATE feedback SET descricao=@descricao WHERE id=@id";
            Com.Parameters.AddWithValue("@descricao", feedback.Descricao);
            Com.Parameters.AddWithValue("@id", feedback.Idfeedback);
            try
            {
                CN.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
            }catch(MySqlException ex)
            {
                throw MySqlException(ex.ToString);
            }
            finally
            {
                CN.Close();
            }
        }

        public void Delete(FeedbackModel feedback)
        {

            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "DELETE FROM feedback WHERE id_feedback=@id_feedback";
            Com.Parameters.AddWithValue("@id_feedback", feedback.Idfeedback);
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


        public List<FeedbackModel> selectAllList()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<FeedbackModel> listasFeedback = new List<FeedbackModel>();
            Com.CommandText = "SELECT * FROM feedback";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    FeedbackModel feedbackaux = new FeedbackModel();
                    feedbackaux.Idfeedback = Convert.ToInt32(dr["id_feedback"]);
                    feedbackaux.Descricao = (String)dr["descricao"];
                    feedbackaux.Aula.Idaula = Convert.ToInt32(dr["id_aula"]);
                    listasFeedback.Add(feedbackaux);
                }
                return listasFeedback;
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

        public FeedbackModel selectId(FeedbackModel feedback)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            FeedbackModel feedbackaux = new FeedbackModel();
            Com.CommandText = "SELECT * FROM feedback WHERE id_feedback=@id_feedback";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    feedbackaux.Idfeedback = Convert.ToInt32(dr["id_feedback"]);
                    feedbackaux.Descricao = (String)dr["descricao"];
                    feedbackaux.Aula.Idaula = Convert.ToInt32(dr["fk_aula"]);
                }
                return feedbackaux;
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