using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Homework2.Models
{
    public class CustomerRepository : IRepository<Customer>
    {
        #region IRepository<Customer> Members

        public IEnumerable<Customer> FindAll()
        {
            string query = "Select id, name, email FROM Customers";

            var database = Database.Create();

            var customers = new List<Customer>();

            using (var reader = database.ExecuteReader(query))
            {
                while (reader.Read())
                    customers.Add(Create(reader));
            }

            return customers;
        }

        public Customer FindById(long Id)
        {
            var database = Database.Create();

            string query = "Select id, name, email FROM Customers where id = @id";
            var command = database.CreateCommand(query);
            database.AddInParameter(command, "id", Id);

            Customer customer = null;

            using (var reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                    customer = Create(reader);
            }

            return customer;
        }

        public void Insert(Customer entity)
        {
            var database = Database.Create();

            string query =
                "INSERT INTO Customers (name,email) VALUES (@name,@email); SELECT last_insert_rowid() AS RecordID";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "name", entity.Name);
            database.AddInParameter(command, "email", entity.Email);

            entity.Id = (long)database.ExecuteScalar(command);
        }

        public void Update(Customer entity)
        {
            var database = Database.Create();

            string query =
                "Update Customers set name = @name, email = @email where id = @id";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "name", entity.Name);
            database.AddInParameter(command, "email", entity.Email);
            database.AddInParameter(command, "id", entity.Id);

            database.ExecuteNonQuery(command);
        }

        public void Delete(Customer entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(long Id)
        {
            var database = Database.Create();

            string query = "Delete FROM Customers where id = @id";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "id", Id);

            database.ExecuteNonQuery(command);
        }

        #endregion

        private Customer Create(IDataReader dr)
        {
            return new Customer
            {
                Id = (long)dr["id"],
                Name = (string)dr["name"],
                Email = (string)dr["email"]
            };
        }
    }
}
