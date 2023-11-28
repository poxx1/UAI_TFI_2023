using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class SolicitudRepository
    {
        public List<InterpretacionModel> listSolicitudes()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            List<InterpretacionModel> list = new List<InterpretacionModel>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from Interpretaciones";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InterpretacionModel mm = new InterpretacionModel();
                    mm.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    mm.Name = reader.GetString(reader.GetOrdinal("Nombre"));
                    mm.Fecha = reader.GetString(reader.GetOrdinal("Fecha"));
                    mm.Description = reader.GetString(reader.GetOrdinal("Descripcion"));
                    var test = (reader.GetBoolean(reader.GetOrdinal("Aprobada")));
                    //mm.isApproved = bool.Parse(reader.GetString(reader.GetOrdinal("Aprobada")));
                    mm.isApproved = reader.GetBoolean(reader.GetOrdinal("Aprobada"));

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
        public bool createSolicitud(InterpretacionModel interpretacion)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into Interpretaciones
                            ([Nombre]
                            ,[Descripcion]
                            ,[ID_user]
                            ,[Aprobada]
                            ,[Fecha])            
                        VALUES
                            ( @Nombre
                            , @Descripcion
                            , @ID_user
                            , @Aprobada
                            , @Fecha
                            )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Nombre", interpretacion.Name));
                cmd.Parameters.Add(new SqlParameter("Descripcion", interpretacion.Description));
                cmd.Parameters.Add(new SqlParameter("ID_user", interpretacion.ID_user));
                cmd.Parameters.Add(new SqlParameter("Aprobada", interpretacion.isApproved));
                cmd.Parameters.Add(new SqlParameter("Fecha", interpretacion.Fecha));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteSolicitud(InterpretacionModel interpretacion)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"delete from Interpretaciones where ID = @ID";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("ID", interpretacion.ID));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Approve(InterpretacionModel interpretacion)
        {
            try
            {
                //FALTA hacer este update para que apruebe la solicitud
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"UPDATE Interpretaciones SET Aprobada = 1 where ID = @ID";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("ID", interpretacion.ID));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}