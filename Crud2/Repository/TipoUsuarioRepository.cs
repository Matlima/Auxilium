using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crud2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Crud2.Repository
{
    public class TipoUsuarioRepository
    {
        string Con;

        public TipoUsuarioRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(TipoUsuarioModel tipo)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tipo_usuario(descricao) VALUES (?descricao)";
            Com.Parameters.AddWithValue("?descricao", tipo.Descricao);
            try
            {
                CN.Open();
                int registroAfetados = Com.ExecuteNonQuery();
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

        public List<TipoUsuarioModel> SelectAllList()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<TipoUsuarioModel> listaTipo = new List<TipoUsuarioModel>();
            Com.CommandText = "SELECT * FROM tipo_usuario";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    TipoUsuarioModel tipoaux = new TipoUsuarioModel();
                    tipoaux.Idtipousuario = Convert.ToInt32(dr["id"]);
                    tipoaux.Descricao = (String)dr["descricao"];
                    listaTipo.Add(tipoaux);
                }
                return listaTipo;
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

        public TipoUsuarioModel SelectId(TipoUsuarioModel tipo)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tipo_usuario WHERE id=@id";
            Com.Parameters.AddWithValue("@id", tipo.Idtipousuario);
            TipoUsuarioModel tipoaux = new TipoUsuarioModel();
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    tipoaux.Idtipousuario = Convert.ToInt32(dr["id"]);
                    tipoaux.Descricao = (String)dr["descricao"];
                }
                return tipoaux;
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