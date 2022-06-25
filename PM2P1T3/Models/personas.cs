using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2P1T3.Models
{
    public class personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }
        public String Correo { get; set; }
        public String Direccion { get; set; }
    }
}
