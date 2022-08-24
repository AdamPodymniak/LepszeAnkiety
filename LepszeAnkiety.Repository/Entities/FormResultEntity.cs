using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LepszeAnkiety.Repository.Entities
{
    public class FormResult
    {
        public int ID { get; set; }
        public Guid FormGuid { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid Key { get; set; }
    }
}
