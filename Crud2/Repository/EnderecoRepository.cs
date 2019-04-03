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
    public class EnderecoRepository
    {
        string Con;

        public EnderecoRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(EnderecoModel endereco)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tb_endereco(endereco, numero, bairro, cidade, CEP, fk_estados) VALUES(?endereco,?numero,?bairro,?cidade,?CEP,?fk_estados)";
            Com.Parameters.AddWithValue("?endereco", endereco.Endereco);
            Com.Parameters.AddWithValue("?numero", endereco.Numero);
            Com.Parameters.AddWithValue("?bairro", endereco.Bairro);
            Com.Parameters.AddWithValue("?cidade", endereco.Cidade);
            Com.Parameters.AddWithValue("?CEP", endereco.Cep);
            Com.Parameters.AddWithValue("?fk_estados", endereco.Estado.idestado);
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

        public void Update(EnderecoModel endereco)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "UPDATE tb_endereco SET endereco=?endereco, numero=?numero, bairro=?bairro, cidade=?cidade, CEP=?CEP, fk_estados=?fk_estados";
            Com.Parameters.AddWithValue("?endereco", endereco.Endereco);
            Com.Parameters.AddWithValue("?numero", endereco.Numero);
            Com.Parameters.AddWithValue("?bairro", endereco.Bairro);
            Com.Parameters.AddWithValue("?cidade", endereco.Cidade);
            Com.Parameters.AddWithValue("?CEP", endereco.Cep);
            Com.Parameters.AddWithValue("?fk_estados", endereco.Estado.idestado);
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










        private Exception MySqlException(Func<string> toString)
        {
            throw new NotImplementedException();
        }
    }
}