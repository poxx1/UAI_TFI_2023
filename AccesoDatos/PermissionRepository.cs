using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Component = Modelos.Component;

namespace AccesoDatos
{
    public class PermissionRepository
    {
        public List<PermissionsEnum> GetAllPermission()
        {
            return Enum.GetValues(typeof(PermissionsEnum)).Cast<PermissionsEnum>().ToList();
        }
        public Component GuardarComponente(Component component, bool isFamily)
        {
            try
            {
                SqlConnection cnn = ConnectionSingleton.getConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                var sql = $@"insert into Permission (Name,Permission) values (@Name,@Permission);  SELECT ID AS LastID FROM Permission WHERE ID = @@Identity;       ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("Name", component.Nombre));


                if (isFamily)
                    cmd.Parameters.Add(new SqlParameter("Permission", DBNull.Value));

                else
                    cmd.Parameters.Add(new SqlParameter("Permission", component.Permiso.ToString()));

                var id = cmd.ExecuteScalar();
                component.Id = (int)id;
                cnn.Close();
                return component;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SaveFamily(Family family)
        {
            if (!IsValidFamily(family))
            {
                //throw new Exception("Familia Recursiva");
            }
            try
            {
                var cnn = ConnectionSingleton.getConnection();
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                var sql = $@"delete from Permission_Permission where ID_Permission_Father=@ID;";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("ID", family.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in family.Childs)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;


                    sql = $@"insert into Permission_Permission (ID_Permission_Father,ID_Permission_Child) values (@ID_Permission_Father,@ID_Permission_Child) ";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("ID_Permission_Father", family.Id));
                    cmd.Parameters.Add(new SqlParameter("ID_Permission_Child", item.Id));

                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch (Exception)
            {
                ConnectionSingleton.getConnection().Close();
                throw;
            }
        }
        private Boolean IsValidFamily(Family family)
        {
            try
            {
                bool toReturn = true;
                foreach (Component child in family.Childs)
                {
                    if (child.GetType() == typeof(Family))
                    {
                        if (family.Nombre.Equals(child.Nombre))
                        {
                            toReturn = false;
                        }
                        else
                        {
                            if (!ValidateFamilyRecursion((Family)child, family)) toReturn = false;
                        }
                    }
                }
                return toReturn;

            }
            catch(Exception) { return false; }
            }
        private Boolean ValidateFamilyRecursion(Family family, Family original)
        {
            bool toReturn = true;

            foreach (Component child in family.Childs)
            {
                if (child.GetType() == typeof(Family))
                {
                    if (original.Nombre.Equals(child.Nombre))
                    {
                        toReturn = false;
                    }
                    else
                    {
                        if (!ValidateFamilyRecursion((Family)child, family)) toReturn = false;
                    }
                }
            }
            return toReturn;
        }
        public List<Patent> GetAllPatents()
        {

            var cnn = ConnectionSingleton.getConnection();
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"select * from Permission listComponent where listComponent.Permission is not null;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            List<Patent> lista = new List<Patent>();

            while (reader.Read())
            {
                Patent c = new Patent();

                c.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                c.Nombre = reader.GetString(reader.GetOrdinal("Name"));
                c.Permiso = (PermissionsEnum)Enum.Parse(typeof(PermissionsEnum), reader.GetString(reader.GetOrdinal("Permission")));
                c.Description = reader.GetValue(reader.GetOrdinal("Description")).ToString();
                lista.Add(c);
            }
            reader.Close();
            cnn.Close();
            return lista;
        }
        public List<Family> GetAllFamilies()
        {

            var cnn = ConnectionSingleton.getConnection();
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"select * from Permission listComponent where listComponent.Permission is  null;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            List<Family> lista = new List<Family>();

            while (reader.Read())
            {

                var id = reader.GetInt32(reader.GetOrdinal("ID"));
                var nombre = reader.GetString(reader.GetOrdinal("Name"));

                Family c = new Family();

                c.Id = id;
                c.Nombre = nombre;
                lista.Add(c);

            }
            reader.Close();
            cnn.Close();

            return lista;
        }
        public List<Component> GetAll(string familia)
        {

            var where = "is NULL";

            if (!String.IsNullOrEmpty(familia))
            {
                where = familia;
            }

            SqlConnection cnn = ConnectionSingleton.getConnection();
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"with recursivo as (
                        select sp2.ID_Permission_Father, sp2.ID_Permission_Child  from Permission_Permission SP2
                        where sp2.ID_Permission_Father {where} 
                        UNION ALL
                        select sp.ID_Permission_Father, sp.ID_Permission_Child from Permission_Permission sp 
                        inner join recursivo r on r.ID_Permission_Child= sp.ID_Permission_Father
                        )
                        select r.ID_Permission_Father,r.ID_Permission_Child,listComponent.ID,listComponent.Name, listComponent.Permission
                        from recursivo r 
                        inner join Permission listComponent on r.ID_Permission_Child = listComponent.ID 
                        ";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            List<Component> lista = new List<Component>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["ID_Permission_Father"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("ID_Permission_Father"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("ID"));
                var nombre = reader.GetString(reader.GetOrdinal("Name"));

                var permiso = string.Empty;
                if (reader["Permission"] != DBNull.Value)
                    permiso = reader.GetString(reader.GetOrdinal("Permission"));


                Component c;

                if (string.IsNullOrEmpty(permiso))
                    c = new Family();

                else
                    c = new Patent();

                c.Id = id;
                c.Nombre = nombre;
                if (!string.IsNullOrEmpty(permiso))
                    c.Permiso = (PermissionsEnum)Enum.Parse(typeof(PermissionsEnum), permiso);

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AddChild(c);
                }
            }
            reader.Close();
            cnn.Close();

            return lista;
        }
        private Component GetComponent(int id, List<Component> lista)
        {
            Component component = lista != null ? lista.Where(listComponent => listComponent.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponent(id, c.Childs);
                    if (l != null && l.Id == id)
                    {
                        return l;
                    }
                    else
                    {
                        if (l != null)
                        {
                            return GetComponent(id, l.Childs);
                        }
                    }
                }
            }
            return component;
        }
        public void FillUserComponents(UserModel user)
        {
            var cnn = ConnectionSingleton.getConnection();
            cnn.Open();

            var cmd2 = new SqlCommand();
            cmd2.Connection = cnn;
            cmd2.CommandText = $@"select listComponent.* from User_Permission up inner join Permission listComponent on up.ID_Permission=listComponent.ID where ID_User=@ID;";
            cmd2.Parameters.AddWithValue("ID", user.Id);

            var reader = cmd2.ExecuteReader();
            user.Permissions.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("ID"));
                String nombre = reader.GetString(reader.GetOrdinal("Name"));
                String permiso = String.Empty;

                if (reader["Permission"] != DBNull.Value)
                    permiso = reader.GetString(reader.GetOrdinal("Permission"));

                Component componente;
                if (!String.IsNullOrEmpty(permiso))
                {
                    componente = new Patent();
                    componente.Id = id;
                    componente.Nombre = nombre;
                    componente.Permiso = (PermissionsEnum)Enum.Parse(typeof(PermissionsEnum), permiso);
                    user.Permissions.Add(componente);
                }
                else
                {
                    componente = new Family();
                    componente.Id = id;
                    componente.Nombre = nombre;
                    user.Permissions.Add(componente);
                }
            }
            reader.Close();
            cnn.Close();

            foreach (Component componente in user.Permissions)
            {
                if (componente is Family)
                {
                    List<Component> familias = GetAll("=" + componente.Id);

                    foreach (var familia in familias)
                    {
                        componente.AddChild(familia);
                    }
                }
            }
        }
        public void FillFamilyComponents(Family familia)
        {
            familia.ClearChilds();
            foreach (var item in GetAll("=" + familia.Id))
            {
                familia.AddChild(item);
            }
        }
        public Patent GetPatent(PermissionsEnum permissionsEnum)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            SqlCommand cmd = new SqlCommand();
            Patent permission = null;
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = $@"select * from Permission p where p.Permission = @Permission;";
                cmd.Parameters.Add(new SqlParameter("Permission", permissionsEnum.ToString()));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    permission = new Patent
                    {
                        Id = int.Parse(reader.GetValue(reader.GetOrdinal("ID")).ToString()),
                        Description = reader.GetValue(reader.GetOrdinal("Description")).ToString(),
                        Nombre = reader.GetValue(reader.GetOrdinal("Name")).ToString(),
                        Permiso = permissionsEnum
                    };
                }

                reader.Close();
                connection.Close();
                return permission;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
