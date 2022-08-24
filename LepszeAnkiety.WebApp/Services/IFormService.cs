using LepszeAnkiety.Repository.Entities;

namespace LepszeAnkiety.WebApp.Services
{
    public interface IFormService
    {
        IEnumerable<Form> GetAllForms();
        IEnumerable<FormField> GetAllFields(Guid key);
        IEnumerable<FormResultField> GetAllResults();
        IEnumerable<FormResultField> GetAllResultsByKey(Guid key);
        IEnumerable<FieldType> GetTypes();
        IEnumerable<FormResult> GetFormResult(Guid key);
        Form GetFormByKey(Guid key);
        void AddForm(Form form);
        void AddFormResult(FormResult formResult);
        void AddField(FormField e);
        void AddResult(FormResultField r);
        void UpdateForm(Form f);
        void UpdateFormField(FormField f);
        void DeleteField(int ID);
        void DeleteFieldByKey(Guid key);
        void DeleteResultByKey(Guid key);
        void DeleteResultByFormKey(Guid key);
        void DeleteForm(Guid key);
    }
}
