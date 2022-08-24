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
    public interface IFormResultFieldRepository : IGenericRepository<FormResultField>
    {
        IEnumerable<FormResultField> GetAllByKey(Guid key);
        void DeleteByKey(Guid key);
        void DeleteByFormKey(Guid key);
    }
    public class FormResultFieldRepository : IFormResultFieldRepository
    {
        private readonly string dbConnection = "Host=localhost;Username=postgres;Password=pasztet14;Database=lepszeankiety";
        public void Add(FormResultField obj)
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
                connection.Delete(ID);
            }
        }

		public void DeleteByFormKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<FormResultField>(new { FormKey = key });
            }
        }

		public void DeleteByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<FormResultField>(new {FormResultKey = key});
            }
        }

		public FormResultField Get(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var resultField = connection.Get<FormResultField>(ID);
                return resultField;
            }
        }

        public IEnumerable<FormResultField> GetAllByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var resultFields = connection.GetList<FormResultField>(new {FormKey = key});
                return resultFields;
            }
        }

        public IEnumerable<FormResultField> GetList()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var resultFields = connection.GetList<FormResultField>();
                return resultFields;
            }
        }

        public void Update(FormResultField obj)
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
