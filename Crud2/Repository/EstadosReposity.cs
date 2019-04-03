using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Crud2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Crud2.Repository
{
    public class EstadosReposity
    {
        String Con;

        public EstadosReposity()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];                
        }

        public DataTable SelectAll()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            MySqlDataAdapter da;
            Com.CommandText = "SELECT * from tb_estados";
            try
            {
                CN.Open();
                Com = new MySqlCommand(Com.CommandText, CN);
                da = new MySqlDataAdapter(Com);
                DataTable Estados = new DataTable();
                da.Fill(Estados);
                return Estados;
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

        public List<EstadosModel> SelectAllList()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<EstadosModel> listaEstados = new List<EstadosModel>();
            Com.CommandText = "SELECT * FROM tb_estados";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    EstadosModel estadoaux = new EstadosModel();
                    estadoaux.idestado = Convert.ToInt32(dr["id_estados"]);
                    estadoaux.sigla = Convert.ToString(dr["sigla"]);
                    estadoaux.descricao = Convert.ToString(dr["descricao"]);
                    listaEstados.Add(estadoaux);
                }
                return listaEstados;
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


        public EstadosModel SelectId(EstadosModel estados)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "SELECT * FROM tb_estados WHERE id_estado=@id_estado";
            EstadosModel estadoaux = new EstadosModel();
            Com.Parameters.AddWithValue("@id_estado", estados.idestado);
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    estadoaux.idestado = Convert.ToInt32(dr["id_estado"]);
                    estadoaux.sigla = (String)dr["sigla"];
                    estadoaux.descricao = (String)dr["descricao"];
                }
                return estadoaux;
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