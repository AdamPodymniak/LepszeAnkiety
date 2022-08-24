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
    public interface IFieldTypeRepository : IGenericRepository<FieldType>
    {

    }
    public class FieldTypeRepository : IFieldTypeRepository
    {
        private readonly string dbConnection = "Host=localhost;Username=postgres;Password=pasztet14;Database=lepszeankiety";
        public void Add(FieldType obj)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Insert<FieldType>(obj);
            }
        }

        public void Delete(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Delete<FieldType>(ID);
            }
        }

        public FieldType Get(int ID)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var type = connection.Get<FieldType>(ID);
                return type;
            }
        }

        public IEnumerable<FieldType> GetList()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                var types = connection.GetList<FieldType>();
                return types;
            }
        }

        public void Update(FieldType obj)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
                connection.Open();
                connection.Update<FieldType>(obj);
            }
        }
    }
}
