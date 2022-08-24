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
    public interface IFormResultRepository : IGenericRepository<FormResult>
    {
        IEnumerable<FormResult> GetAllByKey(Guid key);
        void DeleteByKey(Guid key);
        void DeleteByFormKey(Guid key);
    }
    public class FormResultRepository : IFormResultRepository
    {
        private readonly string dbConnection = "Host=localhost;Username=postgres;Password=pasztet14;Database=lepszeankiety";
        public void Add(FormResult obj)
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
                connection.Delete<FormResult>(ID);
            }
        }

		public void DeleteByFormKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<FormResult>(new { FormGuid = key });
            }
        }

		public void DeleteByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.DeleteList<FormResult>(new {Key = key});
            }
        }

		public FormResult Get(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var result = connection.Get<FormResult>(ID);
                return result;
            }
        }

		public IEnumerable<FormResult> GetAllByKey(Guid key)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var results = connection.GetList<FormResult>(new {FormGuid = key});
                return results;
            }
        }

		public IEnumerable<FormResult> GetList()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var results = connection.GetList<FormResult>();
                return results;
            }
        }

        public void Update(FormResult obj)
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
