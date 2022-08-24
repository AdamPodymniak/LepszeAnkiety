using LepszeAnkiety.Repository.Entities;

namespace LepszeAnkiety.WebApp.Models
{
    public class ResultModel
    {
        public IEnumerable<FormResult> FormResult { get; set; }
        public IEnumerable<FormResultField> Results { get; set; }
        public IEnumerable<FormField> Fields { get; set; }
        public Form Form { get; set; }
    }
}
