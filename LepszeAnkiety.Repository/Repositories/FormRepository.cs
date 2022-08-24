using LepszeAnkiety.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace LepszeAnkiety.Repository.Repositories
{
    public interface IFormRepository : IGenericRepository<Form>
    {
        IEnumerable<Form> GetByKey(Guid key);
        void DeleteByKey(Guid key);
    }
    public class FormRepository : IFormRepository
    {
        private readonly string dbConnection = "Host=localhost;Username=postgres;Password=pasztet14;Database=lepszeankiety";
        public void Add(Form obj)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Insert(obj);
            }
        }

        public void Delete(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Delete<Form>(ID);
            }
        }

		public void DeleteByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<Form>(new {FormKey = key});
            }
        }

		public Form Get(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var form = connection.Get<Form>(ID);
                return form;
            }
        }

        public IEnumerable<Form> GetByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var form = connection.GetList<Form>(new {FormKey = key});
                return form.ToList();
            }
        }

        public IEnumerable<Form> GetList()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var forms = connection.GetList<Form>();
                return forms.ToList();
            }
        }

        public void Update(Form obj)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Update(obj);
            }
        }
    }

}
