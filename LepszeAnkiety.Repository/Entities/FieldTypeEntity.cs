using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LepszeAnkiety.Repository.Entities
{
    public class FieldType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
    }
}
