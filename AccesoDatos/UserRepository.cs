using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Servicios;
using Model;
using System.Linq;
using System.Text;
using DigitosVerificadoresLib;
using DigitosVerificadoresLib.services;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class UserRepository : IDVDAO<UserModel>
    {
        PermissionRepository permisosRepository;
        //LanguageRepository languageRepository;
        private string tableName = "Users";

        public UserRepository()
        {
            permisosRepository = new PermissionRepository();
            //languageRepository = new LanguageRepository();
        }
        public void save(UserModel user)
        { //FALTA agregar el idioma aca
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd;
                try
                {
                    cmd = new SqlCommand();//[Id] el id wtf
                    cmd.CommandText = $@"INSERT INTO [dbo].[Users] 
                                    ([Dni]
                                    ,[Name]
                                    ,[LastName]
                                    ,[NickName]
                                    ,[Password]
                                    ,[Email]
                                    ,[Phone]
                                    ,[Address]
                                    ,[dvh]
                                    ,[Language_Id]
                                    ,[Tries]
                                    ,[Blocked]
                                    )
                                    VALUES
                                    (@Dni
                                    ,@Name
                                    ,@LastName
                                    ,@NickName
                                    ,@Password
                                    ,@Email
                                    ,@Phone
                                    ,@Address
                                    ,@dvh
                                    ,1
                                    ,0
                                    ,0
                                    )";

                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new SqlParameter("Dni", user.Dni));
                    cmd.Parameters.Add(new SqlParameter("Name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("LastName", user.LastName)); 
                    cmd.Parameters.Add(new SqlParameter("NickName", user.Nickname));
                    cmd.Parameters.Add(new SqlParameter("Password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("Email", user.Mail)); 
                    cmd.Parameters.Add(new SqlParameter("Phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("Address", user.Adress));
                    //cmd.Parameters.Add(new SqlParameter("dvh", "testdelcalculodeldigitoverficador"));
                    cmd.Parameters.Add(new SqlParameter("dvh", calculateDVH(user)));

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    connection.Close();

                    //savePermissions(user);

                    updateDVV();
                }
                catch
                {
                    transaction.Rollback();
                    connection.Close();
                    throw;
                }


            }
            catch
            {
                throw;
            }
        }
        public UserModel get(String Nic)
        {
            UserModel user = null;
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"select * from Users where Nickname = @Nickname;";
                cmd.Parameters.Add(new SqlParameter("Nickname", Nic));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new UserModel
                    {
                        Id = int.Parse(reader.GetValue(reader.GetOrdinal("Id")).ToString()),
                        Nickname = reader.GetValue(reader.GetOrdinal("Nickname")).ToString(),
                        Password = reader.GetValue(reader.GetOrdinal("Password")).ToString(),
                        Mail = reader.GetValue(reader.GetOrdinal("Email")).ToString(),
                        LastName = reader.GetValue(reader.GetOrdinal("LastName")).ToString(),
                        Name = reader.GetValue(reader.GetOrdinal("Name")).ToString(),
                        Adress = reader.GetValue(reader.GetOrdinal("Address")).ToString(),
                        Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString(),
                        Dni = reader.GetValue(reader.GetOrdinal("Dni")).ToString(),
                        Blocked = reader.GetBoolean(reader.GetOrdinal("Blocked")),
                        Tries = int.Parse(reader.GetValue(reader.GetOrdinal("Tries")).ToString()),
                        dvh = reader.GetValue(reader.GetOrdinal("dvh")).ToString(),
                        Language = int.Parse(reader.GetValue(reader.GetOrdinal("Language_Id")).ToString())
                    };
                    //idLanguaje = int.Parse(reader.GetValue(reader.GetOrdinal("key_idioma")).ToString());
                }

                reader.Close();
                connection.Close();

                if (user != null)
                {
                    permisosRepository.FillUserComponents(user);
                    //user.Language = languageRepository.GetLanguage(idLanguaje);
                }

                return user;
            }
            catch(Exception ex)
            {
                //return false;
                MessageBox.Show("El usuario no tiene permisos","Error en la base de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw ex;
            }
        }
        public UserModel get(int id)
        {
            UserModel user = null;
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"select * from usuarios u inner join usuario_data ud on u.id_usuario = ud.id_usuario  where ud.id_usuario = @id ;";
                cmd.Parameters.Add(new SqlParameter("id", id));

                SqlDataReader reader = cmd.ExecuteReader();

                int idLanguaje = 0;
                while (reader.Read())
                {
                    user = new UserModel
                    {
                        Id = int.Parse(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString()),
                        Nickname = reader.GetValue(reader.GetOrdinal("Nickname")).ToString(),
                        Password = reader.GetValue(reader.GetOrdinal("password")).ToString(),
                        Mail = reader.GetValue(reader.GetOrdinal("mail")).ToString(),
                        LastName = reader.GetValue(reader.GetOrdinal("apellido")).ToString(),
                        Name = reader.GetValue(reader.GetOrdinal("nombre")).ToString(),
                        Adress = reader.GetValue(reader.GetOrdinal("direccion")).ToString(),
                        Phone = reader.GetValue(reader.GetOrdinal("telefono")).ToString(),
                        Dni = reader.GetValue(reader.GetOrdinal("dni")).ToString(),
                        Blocked = reader.GetBoolean(reader.GetOrdinal("bloqueado")),
                        Tries = int.Parse(reader.GetValue(reader.GetOrdinal("intentos")).ToString()),
                        dvh = reader.GetValue(reader.GetOrdinal("dvh")).ToString(),
                        Language = int.Parse(reader.GetValue(reader.GetOrdinal("Language_Id")).ToString())
                    };
                    idLanguaje = int.Parse(reader.GetValue(reader.GetOrdinal("key_idioma")).ToString());
                }

                reader.Close();
                connection.Close();

                if (user != null)
                {
                    //permisosRepository.FillUserComponents(user);
                    //user.Language = languageRepository.GetLanguage(idLanguaje);
                }

                return user;
            }
            catch
            {
                throw;
            }
        }
        public bool delete(string Nick) {
            UserModel user = null;
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"delete from Users where NickName = @NickName;";
                cmd.Parameters.Add(new SqlParameter("Nickname", Nick));

                SqlDataReader reader = cmd.ExecuteReader();

                //Still need to confirm if the user was deleted or not

                reader.Close();
                connection.Close();

                if (user != null)
                {
                    permisosRepository.FillUserComponents(user);
                    //user.Language = languageRepository.GetLanguage(idLanguaje);
                }

                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }
        public UserModel getByDni(int dni)
        {
            UserModel user = null;
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"select * from usuarios u inner join usuario_data ud on u.id_usuario = ud.id_usuario  where ud.dni = @dni ;";
                cmd.Parameters.Add(new SqlParameter("dni", dni));

                SqlDataReader reader = cmd.ExecuteReader();

                int idLanguaje = 0;
                while (reader.Read())
                {
                    user = new UserModel
                    {
                        Id = int.Parse(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString()),
                        Nickname = reader.GetValue(reader.GetOrdinal("Nickname")).ToString(),
                        Password = reader.GetValue(reader.GetOrdinal("password")).ToString(),
                        Mail = reader.GetValue(reader.GetOrdinal("mail")).ToString(),
                        LastName = reader.GetValue(reader.GetOrdinal("apellido")).ToString(),
                        Name = reader.GetValue(reader.GetOrdinal("nombre")).ToString(),
                        Adress = reader.GetValue(reader.GetOrdinal("direccion")).ToString(),
                        Phone = reader.GetValue(reader.GetOrdinal("telefono")).ToString(),
                        Dni = reader.GetValue(reader.GetOrdinal("dni")).ToString(),
                        Blocked = reader.GetBoolean(reader.GetOrdinal("bloqueado")),
                        Tries = int.Parse(reader.GetValue(reader.GetOrdinal("intentos")).ToString()),
                        dvh = reader.GetValue(reader.GetOrdinal("dvh")).ToString()
                    };
                    idLanguaje = int.Parse(reader.GetValue(reader.GetOrdinal("key_idioma")).ToString());
                }

                reader.Close();
                connection.Close();

                if (user != null)
                {
                    permisosRepository.FillUserComponents(user);
                    //user.Language = languageRepository.GetLanguage(idLanguaje);
                }

                return user;
            }
            catch
            {
                throw;
            }
        }
        public List<UserModel> getAll()
        {
            //los usuarios no tienen los idiomas 
            SqlConnection connection = ConnectionSingleton.getConnection();
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;

            //var sql = $@"select * from usuarios u left join usuario_data ud on ud.id_usuario = u.id_usuario;";
            var sql = $@"select * from Users";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<UserModel>();

            while (reader.Read())
            {
                UserModel user = new UserModel()
                {
                    Id = int.Parse(reader.GetValue(reader.GetOrdinal("Id")).ToString()),
                    Nickname = reader.GetValue(reader.GetOrdinal("Nickname")).ToString(),
                    Password = reader.GetValue(reader.GetOrdinal("Password")).ToString(),
                    Mail = reader.GetValue(reader.GetOrdinal("Email")).ToString(),
                    LastName = reader.GetValue(reader.GetOrdinal("LastName")).ToString(),
                    Name = reader.GetValue(reader.GetOrdinal("Name")).ToString(),
                    Adress = reader.GetValue(reader.GetOrdinal("Address")).ToString(),
                    Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString(),
                    Dni = reader.GetValue(reader.GetOrdinal("Dni")).ToString(),
                    Blocked = reader.GetBoolean(reader.GetOrdinal("Blocked")),
                    Tries = int.Parse(reader.GetValue(reader.GetOrdinal("Tries")).ToString()),
                    dvh = reader.GetValue(reader.GetOrdinal("dvh")).ToString(),
                    Language = int.Parse(reader.GetValue(reader.GetOrdinal("Language_Id")).ToString())
                    //Language = new Models.language.Language() { ID = int.Parse(reader.GetValue(reader.GetOrdinal("key_idioma")).ToString()) }
                };
                lista.Add(user);
            }

            reader.Close();
            connection.Close();

            //vinculo los usuarios con las patentes y familias que tiene configuradas.
            foreach (var user in lista)
            {
                permisosRepository.FillUserComponents(user);
            }

            return lista;
        }
        public void savePermissions(UserModel user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = $@"delete from User_Permission where ID_User=@id;";
                cmd.Parameters.Add(new SqlParameter("id", user.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in user.Permissions)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = connection;
                    //FIX THIS SHIT
                    cmd.CommandText = $@"insert into User_Permission (ID_User,ID_Permission) values (@id_usuario,@id_permiso) "; ;
                    cmd.Parameters.Add(new SqlParameter("id_usuario", user.Id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso", item.Id));

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                //return true
            }
            catch (Exception)
            {
                //Mensaje de error
                //return false;
            }
        }
        public void updatePassword(UserModel user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update usuarios set password = @password where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));
                cmd.Parameters.Add(new SqlParameter("password", user.Password));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
            user = get(user.Nickname);
            update(user);


            //updateDVV();
        }
        public bool update(UserModel user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();

            SqlTransaction transaction;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd;

                    string query = $@"UPDATE [dbo].[Users]
                                       SET   [Dni] = @Dni
                                            ,[Name] = @Name
                                            ,[LastName] = @LastName
                                            ,[Nickname] = @Nickname
                                            ,[Password] = @Password
                                            ,[Email] = @Email
                                            ,[Phone] = @Phone
                                            ,[Address] = @Address
                                            ,[dvh] = @dvh
                                            ,[Tries] = @Tries
                                            ,[Blocked] = @Blocked
                                          where Id = @Id
                                        ";

                    cmd = new SqlCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.Parameters.Add(new SqlParameter("Id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("Dni", user.Dni));
                    cmd.Parameters.Add(new SqlParameter("Name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("Nickname", user.Nickname));
                    cmd.Parameters.Add(new SqlParameter("Password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("Email", user.Mail));
                    cmd.Parameters.Add(new SqlParameter("Phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("Address", user.Adress));
                    cmd.Parameters.Add(new SqlParameter("Tries", user.Tries));
                    cmd.Parameters.Add(new SqlParameter("Blocked", user.Blocked));
                    cmd.Parameters.Add(new SqlParameter("dvh", calculateDVH(user)));
                    //cmd.Parameters.Add(new SqlParameter("idioma", user.Language.ID));

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
           
                    connection.Close();

                    updateDVV();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                    throw;
                }
               
            }
            catch
            {
                connection.Close();
                return false;
                throw;
            }
        }
        public string calculateDVH(UserModel user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(user.Name);
            sb.Append(user.Password);
            sb.Append(user.Blocked.ToString());
            sb.Append(user.Dni);
            sb.Append(user.Mail);
            sb.Append(user.Phone);
            sb.Append(user.Nickname);
            sb.Append(user.Tries.ToString());

            return DVService.getDV(sb.ToString());
        }
        public string calculateDVV(List<UserModel> list)
        {
            return list.Aggregate<UserModel, String>("", (a, b) => DVService.getDV(a + b.dvh));
        }
        public string getDVV()
        {
            try
            {
                String dvv = "";
                SqlConnection connection = ConnectionSingleton.getConnection();

                if (connection.State != ConnectionState.Open) connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                        SELECT  dvv
                            FROM dvv 
                            where tablename = @tablename
                    ";

                    IDbDataParameter tablename = command.CreateParameter();
                    tablename.ParameterName = "tablename";
                    tablename.Value = tableName;
                    command.Parameters.Add(tablename);

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dvv = reader.GetValue(reader.GetOrdinal("dvv")).ToString();
                    }
                }
                connection.Close();
                return dvv;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw ex;
            }
        }
        public void updateDVV()
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();

                String dvvString = calculateDVV(getAll());
                if (connection.State != ConnectionState.Open) connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $@"
                                             UPDATE [tfi].[dbo].[dvv]
		                                        SET [dvv] = @dvv
		                                        WHERE [tablename] = @tablename ;
                                           ";

                    IDbDataParameter dvv = command.CreateParameter();
                    dvv.ParameterName = "dvv";
                    dvv.Value = dvvString;
                    command.Parameters.Add(dvv);

                    IDbDataParameter tablename = command.CreateParameter();
                    tablename.ParameterName = "tablename";
                    tablename.Value = tableName;
                    command.Parameters.Add(tablename);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                //                connection.Close();
            }
            catch (Exception ex)
            {
                // TODO: ver como hacemos el handle de este error
                Console.Write(ex.ToString());
                throw ex;
            }
        }
        public void UpdateAllDV()
        {
            List<UserModel> list = getAll();
            list.ForEach(user =>
            {
                update(user);
            });
        }
        void IDVDAO<UserModel>.update(UserModel obj)
        {
            throw new NotImplementedException();
        }
    }
}