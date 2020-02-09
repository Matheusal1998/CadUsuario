using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teste_CRUD.Models;

namespace Teste_CRUD.DAL
{
    public class UsuarioDAL
    {
        string connectionString = @"Data Source=LAPTOP-K036DF09;Initial Catalog=CRUD_APSNETCORE;Integrated Security=True";

        public void AddUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"AdicionarUsuario";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Login", usuario.Login);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }

        public void DeleteUsuario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = ("delete from Usuario where Id =" + id);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Usuario GetUsuario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                Usuario usuario = new Usuario();

                string sql = ("Select *from Usuario where id=" + id);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    usuario.Id = Convert.ToInt32(rdr["Id"]);
                    usuario.NomeCompleto = rdr["NomeCompleto"].ToString();
                    usuario.Email = rdr["Email"].ToString();
                    usuario.DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]);
                    usuario.Login = rdr["Login"].ToString();
                    usuario.Senha = rdr["Senha"].ToString();


                }
                return usuario;
            }
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            List<Usuario> lsusuarios = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Usuario", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(rdr["Id"]);
                    usuario.NomeCompleto = rdr["NomeCompleto"].ToString();
                    usuario.Email = rdr["Email"].ToString();
                    usuario.DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]);
                    usuario.Login = rdr["Login"].ToString();
                    usuario.Senha = rdr["Senha"].ToString();

                    lsusuarios.Add(usuario);
                }
                con.Close();
            }
            return lsusuarios;
        }



        public void UpdateUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"EditarUsuario";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Login", usuario.Login);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
