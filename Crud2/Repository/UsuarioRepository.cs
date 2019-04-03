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
    public class UsuarioRepository
    {
        string Con;

        public UsuarioRepository()
        {
            Con = ConfigurationSettings.AppSettings["ConexaoDB"];
        }

        public void Add(UsuarioModel usuario)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "INSERT INTO tb_usuario(nome, login, senha, email, fk_instituicao_ensino, data_nascimento, fk_tipo_usuario, fk_endereco)" +
                "VALUES (?nome,?login,?senha,?email,?fk_instituicao_ensino,?data_nascimento,?fk_tipo_usuario,?fk_endereco)";
            Com.Parameters.AddWithValue("?nome", usuario.Nome);
            Com.Parameters.AddWithValue("?login", usuario.Login);
            Com.Parameters.AddWithValue("?senha", usuario.Senha);
            Com.Parameters.AddWithValue("?email", usuario.Email);
            Com.Parameters.AddWithValue("?fk_instituicao_ensino", usuario.InstituicaoEnsino.idinstituicaoEnsino);
            Com.Parameters.AddWithValue("?data_nascimento", usuario.DataNascimento);
            Com.Parameters.AddWithValue("?fk_tipo_usuario", usuario.TipoUsuario.Idtipousuario);
            Com.Parameters.AddWithValue("?fk_endereco", usuario.Endereco.Idendereco);
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

        public void Update(UsuarioModel usuario)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "UPDATE tb_usuario SET nome=?nome, login=?login, senha=?senha, email=?email, fk_instituicao_ensino=?fk_instituicao_ensino, data_nascimento=?data_nascimento, fk_tipo_usuario=?fk_tipo_usuario, fk_endereco=?fk_endereco WHERE id_usuario=?id_usuario";
            Com.Parameters.AddWithValue("?nome", usuario.Nome);
            Com.Parameters.AddWithValue("?login", usuario.Login);
            Com.Parameters.AddWithValue("?senha", usuario.Senha);
            Com.Parameters.AddWithValue("?email", usuario.Email);
            Com.Parameters.AddWithValue("?fk_instituicao_ensino", usuario.InstituicaoEnsino.idinstituicaoEnsino);
            Com.Parameters.AddWithValue("?data_nascimento", usuario.DataNascimento);
            Com.Parameters.AddWithValue("?fk_tipo_usuario", usuario.TipoUsuario.Idtipousuario);
            Com.Parameters.AddWithValue("?fk_endereco", usuario.Endereco.Idendereco);
            Com.Parameters.AddWithValue("?id_usuario", usuario.Idusuario);
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

        public void Delete(UsuarioModel usuario)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            Com.CommandText = "DELETE FROM tb_usuario WHERE id_usuario=@id_usuario";
            Com.Parameters.AddWithValue("@id_usuario", usuario.Idusuario);
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

        public List<UsuarioModel> SelectAll()
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            Com.CommandText = "SELECT * FROM tb_usuario";
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    UsuarioModel usuarioaux = new UsuarioModel();
                    usuarioaux.Idusuario = Convert.ToInt32(dr["id_usuario"]);
                    usuarioaux.Nome = (String)dr["nome"];
                    usuarioaux.Login = (String)dr["login"];
                    usuarioaux.Senha = (String)dr["senha"];
                    usuarioaux.Email = (String)dr["email"];
                    usuarioaux.DataNascimento = (DateTime)dr["data_nascimento"];
                    usuarioaux.InstituicaoEnsino.idinstituicaoEnsino = Convert.ToInt32(dr["fk_instituicao_ensino"]);
                    usuarioaux.TipoUsuario.Idtipousuario = Convert.ToInt32(dr["fk_tipo_usuario"]);
                    usuarioaux.Endereco.Idendereco = Convert.ToInt32(dr["?fk_endereco"]);
                    listaUsuarios.Add(usuarioaux);
                }
                return listaUsuarios;
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

        public UsuarioModel SelectId(UsuarioModel usuario)
        {
            MySqlConnection CN = new MySqlConnection(Con);
            MySqlCommand Com = CN.CreateCommand();
            UsuarioModel usuarioaux = new UsuarioModel(); ;
            Com.CommandText = "SELECT * FROM tb_usuario WHERE id_usuario=@id_usuario";
            Com.Parameters.AddWithValue("@id_usuario", usuario.Idusuario);
            try
            {
                MySqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    usuarioaux.Idusuario = Convert.ToInt32(dr["id_usuario"]);
                    usuarioaux.Nome = (String)dr["nome"];
                    usuarioaux.Login = (String)dr["login"];
                    usuarioaux.Senha = (String)dr["senha"];
                    usuarioaux.Email = (String)dr["email"];
                    usuarioaux.DataNascimento = (DateTime)dr["data_nascimento"];
                    usuarioaux.InstituicaoEnsino.idinstituicaoEnsino = Convert.ToInt32(dr["fk_instituicao_ensino"]);
                    usuarioaux.TipoUsuario.Idtipousuario = Convert.ToInt32(dr["fk_tipo_usuario"]);
                    usuarioaux.Endereco.Idendereco = Convert.ToInt32(dr["?fk_endereco"]);
                }
                return usuarioaux;
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