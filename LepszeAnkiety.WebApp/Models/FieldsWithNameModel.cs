using LepszeAnkiety.Repository.Entities;

namespace LepszeAnkiety.WebApp.Models
{
    public class FieldsWithNameModel
    {
        public Form Form { get; set; }
        public IEnumerable<FormField> fields { get; set; }
        public IEnumerable<FieldType> types { get; set; }
        public Guid key { get; set; }
    }
}
