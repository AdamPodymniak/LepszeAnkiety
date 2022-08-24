using LepszeAnkiety.Repository.Entities;
using LepszeAnkiety.WebApp.Models;
using LepszeAnkiety.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LepszeAnkiety.WebApp.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }
        [Route("Index/{key}")]
        public IActionResult Index(Guid key)
        {
            FieldsWithNameModel model = new FieldsWithNameModel();
            model.Form = _formService.GetFormByKey(key);
            model.fields = _formService.GetAllFields(key).OrderBy(d => d.Sort).ToList();
            model.types = _formService.GetTypes();
            return View(model);
        }
        [HttpPost]
        [Route("Index/{key}")]
        public IActionResult Index(Guid key, IEnumerable<FormResultField> Results)
        {
            Guid formResultKey = Guid.NewGuid();
            FormResult formResult = new FormResult();
            formResult.Key = formResultKey;
            formResult.FormGuid = key;
            _formService.AddFormResult(formResult);
            var fields = _formService.GetAllFields(key);
            foreach(var r in Results)
            {
                foreach(var f in fields)
                {
                    if(f.ID == r.FormFieldID)
                    {
                        if (f.Required && r.Value == "")
                        {
                            _formService.DeleteResultByKey(formResultKey);
                            return RedirectToAction("Index", new { key = key });
                        }
                        if (f.Unique)
                        {
                            var uniqueResults = _formService.GetAllResultsByKey(key);
                            foreach (var ur in uniqueResults)
                            {
                                if (ur.Value == r.Value)
                                {
                                    _formService.DeleteResultByKey(formResultKey);
                                    return RedirectToAction("Index", new { key = key });
                                }
                            }
                        }
                    }
                }
                r.FormKey = key;
                r.FormResultKey = formResultKey;
                _formService.AddResult(r);
            }
            return RedirectToAction("Thanks");
        }
        public IActionResult Thanks()
        {
            return View();
        }
        [Route("Edit/{key}")]
        public IActionResult Edit(Guid key)
        {
            FieldsWithNameModel model = new FieldsWithNameModel();
            var form = _formService.GetFormByKey(key);
            model.Form = form;
            var data = _formService.GetAllFields(key);
            model.fields = data.OrderBy(d => d.Sort).ToList();
            model.key = key;
            model.types = _formService.GetTypes();
            return View(model);
        }
        [HttpPost]
        [Route("Edit/{key}")]
        public IActionResult Edit(Guid key, string FormName, IEnumerable<FormField> Fields, int FormID)
        {
            _formService.DeleteResultByFormKey(key);
            Form f = new Form();
            f.ID = FormID;
            f.Name = FormName;
            f.FormKey = key;
            _formService.UpdateForm(f);
            foreach(var field in Fields)
            {
                if (field.Required != false) field.Required = true;
                else field.Required = false;
                if (field.Unique != false) field.Unique = true;
                else field.Unique = false;
                field.FormKey = key;
                _formService.UpdateFormField(field);
            }
            return RedirectToAction("Edit", new { key = key });
        }
        [Route("Add/{key}")]
        public IActionResult Add(Guid key)
        {
            var types = _formService.GetTypes();
            return View(types);
        }
        [HttpPost]
        [Route("Add/{key}")]
        public IActionResult Add(FormField e, Guid key)
        {
            if(e.Name != "")
            {
                e.FormKey = key;
                _formService.AddField(e);
            }
            return RedirectToAction("Edit", new {key = key});
        }
        [Route("Delete/{id:int}/{key}")]
        public IActionResult Delete(int id, Guid key)
        {
            _formService.DeleteField(id);
            return RedirectToAction("Edit", new { key = key });
        }
        [Route("Result/{key}")]
        public IActionResult Result(Guid key)
        {
            ResultModel model = new ResultModel();
            model.FormResult = _formService.GetFormResult(key);
            model.Results = _formService.GetAllResults();
            model.Fields = _formService.GetAllFields(key);
            model.Form = _formService.GetFormByKey(key);
            return View(model);
        }
        [Route("DeleteResult/{key}/{formkey}")]
        public IActionResult DeleteResult(Guid key, Guid formkey)
        {
            _formService.DeleteResultByKey(formkey);
            return RedirectToAction("Result", new { key = key });
        }
    }
}
