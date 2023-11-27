using Interfaces;
using System;
using System.Collections.Generic;
using Component = Modelos.Component;

namespace Model
{
    public class UserModel : IDVEntity
    {
        public UserModel()
        {
            _Permissions = new List<Component>();
        }
        private List<Component> _Permissions;
        public Int32 Id { get; set; }
        public String Dni { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Nickname { get; set; }
        public String Password { get; set; }
        public String Mail { get; set; }
        public String Phone { get; set; }
        public String Adress { get; set; }
        public int Tries { get; set; }
        public bool Blocked { get; set; }
        public List<Component> Permissions
        {
            get
            {
                return _Permissions;
            }
        }
        public int Language { get; set; }
        //public Language Language { get; set; }
        public string dvh { get; set; }
    }
}