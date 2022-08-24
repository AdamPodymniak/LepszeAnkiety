using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepszeAnkiety.Repository.Entities
{
    public class Form
    {
        [Key]
        public int ID { get; set; }
        public Guid FormKey { get; set; }
        public string Name { get; set; }
    }
}
