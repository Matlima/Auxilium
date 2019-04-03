using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crud2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Crud2.Repository
{
    public class TelefoneRepository
    {

        string Con;

        public TelefoneRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(TelefoneModel telefone)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tb_telefone(telefone, fk_usuario_tel) VALUES (?telefone,?fk_usuario_tel)";
            Com.Parameters.AddWithValue("?telefone", telefone.telefone);
            Com.Parameters.AddWithValue("?fk_usuario_tel", telefone.usuario.Idusuario);
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


        public void Update(TelefoneModel telefone)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "UPDATE tb_telefone SET telefone=?telefone WHERE id_telefone=?id_telefone";
            Com.Parameters.AddWithValue("?telefone", telefone.telefone);
            Com.Parameters.AddWithValue("?id_telefone", telefone.idtelefone);
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

        public void Delete(TelefoneModel telefone)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "DELETE FROM tb_telefone WHERE id_telefone=?id_telefone";
            Com.Parameters.AddWithValue("?id_telefone", telefone.idtelefone);
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

        public TelefoneModel SelectId(TelefoneModel telefone)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tb_telefone WHERE id_telefone=?id_telefone";
            Com.Parameters.AddWithValue("?id_telefone", telefone.idtelefone);
            try
            {
                TelefoneModel telefoneaux = new TelefoneModel();
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    telefoneaux.idtelefone = Convert.ToInt32(dr["id_telefone"]);
                    telefoneaux.telefone = Convert.ToInt32(dr["telefone"]);
                    telefoneaux.usuario.Idusuario = Convert.ToInt32(dr["fk_usuario_tel"]);
                }
                return telefoneaux;
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

        public List<TelefoneModel> SelectAll()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tb_telefone";
            List<TelefoneModel> listaTelefones = new List<TelefoneModel>();
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    TelefoneModel telefoneaux = new TelefoneModel();
                    telefoneaux.idtelefone = Convert.ToInt32(dr["id_telefone"]);
                    telefoneaux.telefone = Convert.ToInt32(dr["telefone"]);
                    telefoneaux.usuario.Idusuario = Convert.ToInt32(dr["fk_usuario_tel"]);
                    listaTelefones.Add(telefoneaux);
                }
                return listaTelefones;
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

        public DataTable SelectAllDt()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tb_telefone";
            MySqlDataAdapter da;
            try
            {
                CN.Open();
                Com = new MySqlCommand(Com.CommandText, CN);
                da = new MySqlDataAdapter(Com);
                DataTable telefones = new DataTable();
                da.Fill(telefones);
                return telefones;
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