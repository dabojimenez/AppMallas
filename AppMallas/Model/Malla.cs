using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMallas.Model
{
    public class Malla
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CodigoBarras { get; set; }
    }
}
