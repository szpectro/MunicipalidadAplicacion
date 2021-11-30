using System;
using System.Collections.Generic;

#nullable disable

namespace MySqlDotnetCore.Models
{
    public partial class Tabladocumento
    {
        public int Iddocumento { get; set; }
        public string Nombredocumento { get; set; }
        public string Tipocontenido { get; set; }
        public byte[] Archivo { get; set; }
    }
}
