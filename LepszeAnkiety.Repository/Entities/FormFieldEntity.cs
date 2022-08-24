using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LepszeAnkiety.Repository.Entities
{
    public class FormField
    {
        public int ID { get; set; }
        public Guid FormKey { get; set; }
        public int FieldTypeID { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public bool Unique { get; set; }
        public int Sort { get; set; }
    }
}
