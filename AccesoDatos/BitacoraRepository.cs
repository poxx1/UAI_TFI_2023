using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;
using Servicios;

namespace DataAccess
{
    public class BitacoraRepository
    {
        public List<LogModel> listLogs()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            List<LogModel> list = new List<LogModel>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from Bitacora";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LogModel mm = new LogModel();
                    mm.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                    mm.Usuario = reader.GetString(reader.GetOrdinal("UserName"));
                    mm.Fecha = reader.GetString(reader.GetOrdinal("Date"));
                    mm.Hora = reader.GetString(reader.GetOrdinal("Time"));
                    mm.Info = reader.GetString(reader.GetOrdinal("Info"));
                    mm.Details = reader.GetString(reader.GetOrdinal("Activity"));
                    mm.Priority = reader.GetString(reader.GetOrdinal("Priority"));

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
        public bool saveLog(LogModel log)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into Bitacora
                            ([UserName]
                            ,[Date]
                            ,[Time]
                            ,[Info]
                            ,[Activity]
                            ,[Priority])            
                        VALUES
                            ( @UserName
                            , @Date
                            , @Time
                            , @Info
                            , @Activity    
                            , @Priority
                            )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("UserName", log.Usuario));
                cmd.Parameters.Add(new SqlParameter("Date", log.Fecha));
                cmd.Parameters.Add(new SqlParameter("Time", log.Hora));
                cmd.Parameters.Add(new SqlParameter("Info", log.Info));
                cmd.Parameters.Add(new SqlParameter("Activity", log.Details));
                cmd.Parameters.Add(new SqlParameter("Priority", log.Priority));

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
