using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CursosRepository
    {
        public List<CursosModel> listCursos()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            List<CursosModel> list = new List<CursosModel>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from Courses";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CursosModel mm = new CursosModel();
                    mm.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    mm.Name = reader.GetString(reader.GetOrdinal("Name"));
                    mm.Description = reader.GetString(reader.GetOrdinal("Description"));
                    mm.Price = float.Parse(reader.GetString(reader.GetOrdinal("Precio")));

                    list.Add(mm);
                }

                reader.Close();
                connection.Close();

                return list;
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }
        public bool addCurso(CursosModel curso)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into Courses
                            ([Name]
                            ,[Description]
                            ,[Precio])            
                        VALUES
                            ( @Name
                            , @Descripcion
                            , @Precio
                            )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Name", curso.Name));
                cmd.Parameters.Add(new SqlParameter("Descripcion", curso.Description));
                cmd.Parameters.Add(new SqlParameter("Precio", curso.Price));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteCurso(CursosModel curso)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"delete from Courses where ID = @ID";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("ID", curso.ID));
                
                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateCurso(CursosModel curso)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"UPDATE Courses SET Name=@Name,Description=@Description,Precio=@Precio where ID = @ID";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("ID", curso.ID));
                cmd.Parameters.Add(new SqlParameter("Name", curso.Name));
                cmd.Parameters.Add(new SqlParameter("Description", curso.Description));
                cmd.Parameters.Add(new SqlParameter("Precio", curso.Price));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}