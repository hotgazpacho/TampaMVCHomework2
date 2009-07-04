using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Homework2.Models
{
    public class Customer : Entity, ICustomer
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(200, ErrorMessage = "Email must be 200 characters or less.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Valid Email Address is required.")]
        public string Email { get; set; }

        #region ActiveRecord

        public static IEnumerable<Customer> FetchAll()
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

        public static Customer FetchById(long id)
        {
            var database = Database.Create();

            string query = "Select id, name, email FROM Customers where id = @id";
            var command = database.CreateCommand(query);
            database.AddInParameter(command, "id", id);

            Customer customer = null;

            using (var reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                    customer = Create(reader);
            }

            return customer;
        }

        public void Save()
        {
            if (Id == 0)
                Insert();
            else
                Update();
        }

        protected virtual void Insert()
        {
            var database = Database.Create();

            string query =
                "INSERT INTO Customers (name,email) VALUES (@name,@email); SELECT last_insert_rowid() AS RecordID";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "name", Name);
            database.AddInParameter(command, "email", Email);

            Id = (long)database.ExecuteScalar(command);
        }

        protected virtual void Update()
        {
            var database = Database.Create();

            string query =
                "Update Customers set name = @name, email = @email where id = @id";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "name", Name);
            database.AddInParameter(command, "email", Email);
            database.AddInParameter(command, "id", Id);

            database.ExecuteNonQuery(command);
        }

        public static void DeleteById(long id)
        {
            var database = Database.Create();

            string query = "Delete FROM Customers where id = @id";

            var command = database.CreateCommand(query);
            database.AddInParameter(command, "id", id);

            database.ExecuteNonQuery(command);
        }

        private static Customer Create(IDataReader dr)
        {
            return new Customer
                       {
                           Id = (long)dr["id"],
                           Name = (string)dr["name"],
                           Email = (string)dr["email"]
                       };
        }

        #endregion
    }
}