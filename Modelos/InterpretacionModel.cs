using System;

namespace Modelos
{
    [Serializable]

    public class InterpretacionModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_user { get; set; }
        public bool isApproved { get; set; }
        public string Fecha { get; set; }
    }
}