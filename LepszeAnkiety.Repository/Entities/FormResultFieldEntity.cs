using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LepszeAnkiety.Repository.Entities
{
    public class FormResultField
    {
        public int ID { get; set; }
        public Guid FormResultKey { get; set; }
        public int FormFieldID { get; set; }
        public string Value { get; set; }
        public Guid FormKey { get; set; }
    }
}
