using LepszeAnkiety.Repository.Entities;
using LepszeAnkiety.Repository.Repositories;

namespace LepszeAnkiety.WebApp.Services
{
    public class FormService : IFormService
    {
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IFormRepository _formRepository;
        private readonly IFormFieldRepository _formFieldRepository;
        private readonly IFormResultRepository _formResultRepository;
        private readonly IFormResultFieldRepository _formResultFieldRepository;
        public FormService(IFormRepository formRepository, IFormResultRepository formResultRepository, IFieldTypeRepository fieldTypeRepository,
            IFormFieldRepository formFieldRepository, IFormResultFieldRepository formResultFieldRepository)
        {
            _fieldTypeRepository = fieldTypeRepository;
            _formRepository = formRepository;
            _formFieldRepository = formFieldRepository;
            _formResultRepository = formResultRepository;
            _formResultFieldRepository = formResultFieldRepository;
        }
        public IEnumerable<Form> GetAllForms()
        {
            var forms = _formRepository.GetList();
            return forms;
        }
        public void AddForm(Form form)
        {
            Guid g = Guid.NewGuid();
            form.FormKey = g;
            _formRepository.Add(form);
        }

        public Form GetFormByKey(Guid key)
        {
            Form field = new Form();
            var fields = _formRepository.GetByKey(key);
            foreach(var f in fields)
            {
                field = f;
            }
            return field;
        }

        public IEnumerable<FormField> GetAllFields(Guid key)
        {
            var fields = _formFieldRepository.GetListByKey(key);
            return fields;
        }

        public IEnumerable<FieldType> GetTypes()
        {
            var types = _fieldTypeRepository.GetList();
            return types;
        }

        public void AddField(FormField e)
        {
            int lp = 1;
            var fields = _formFieldRepository.GetListByKey(e.FormKey);
            foreach (var f in fields) lp++;
            e.Sort = lp;
            _formFieldRepository.Add(e);
        }

        public void DeleteField(int ID)
        {
            _formFieldRepository.Delete(ID);
        }

        public void UpdateForm(Form f)
        {
            _formRepository.Update(f);
        }

        public void UpdateFormField(FormField f)
        {
            _formFieldRepository.Update(f);
        }

        public IEnumerable<FormResultField> GetAllResults()
        {
            var results = _formResultFieldRepository.GetList();
            return results;
        }

        public void AddResult(FormResultField r)
        {
            _formResultFieldRepository.Add(r);
        }

        public void AddFormResult(FormResult formResult)
        {
            formResult.CreatedOn = DateTime.Now;
            _formResultRepository.Add(formResult);
        }

		public IEnumerable<FormResult> GetFormResult(Guid key)
		{
            var formResult = _formResultRepository.GetAllByKey(key);
            return formResult;
		}

		public IEnumerable<FormResultField> GetAllResultsByKey(Guid key)
        {
            var results = _formResultFieldRepository.GetAllByKey(key);
            return results;
        }

		public void DeleteResultByKey(Guid key)
		{
            _formResultFieldRepository.DeleteByKey(key);
            _formResultRepository.DeleteByKey(key);
		}

		public void DeleteForm(Guid key)
		{
            _formRepository.DeleteByKey(key);
		}

		public void DeleteFieldByKey(Guid key)
		{
            _formFieldRepository.DeleteByKey(key);
		}

		public void DeleteResultByFormKey(Guid key)
        {
            _formResultFieldRepository.DeleteByFormKey(key);
            _formResultRepository.DeleteByFormKey(key);
        }
	}
}
