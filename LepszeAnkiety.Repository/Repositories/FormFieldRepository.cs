using Dapper;
using LepszeAnkiety.Repository.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepszeAnkiety.Repository.Repositories
{
    public interface IFormFieldRepository : IGenericRepository<FormField>
    {
        IEnumerable<FormField> GetListByKey(Guid key);
        void DeleteByKey(Guid key);
    }
    public class FormFieldRepository : IFormFieldRepository
    {
        private readonly string dbConnection = "Host=localhost;Username=postgres;Password=pasztet14;Database=lepszeankiety";
        public void Add(FormField obj)
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
                connection.Delete<FormField>(ID);
            }
        }

		public void DeleteByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<FormField>(new {FormKey = key});
            }
        }

		public FormField Get(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var field = connection.Get<FormField>(ID);
                return field;
            }
        }

        public IEnumerable<FormField> GetList()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var fields = connection.GetList<FormField>();
                return fields;
            }
        }

        public IEnumerable<FormField> GetListByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var fields = connection.GetList<FormField>(new {FormKey = key});
                return fields;
            }
        }

        public void Update(FormField obj)
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
