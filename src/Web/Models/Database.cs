using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Web;
using System.Web.Configuration;

namespace Homework2.Models
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = "data source=" + connectionString;
        }

        public DbCommand CreateCommand(string query)
        {
            return new SQLiteCommand(query);
        }

        public void AddInParameter(DbCommand command, string parameterName, object value)
        {
            var parameter = command.CreateParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName = "@" + parameterName;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }

        public IDataReader ExecuteReader(string query)
        {
            var command = CreateCommand(query);
            return ExecuteReader(command);
        }

        public IDataReader ExecuteReader(DbCommand command)
        {
            var connection = new SQLiteConnection(_connectionString);
            command.Connection = connection;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void ExecuteNonQuery(string query)
        {
            var command = CreateCommand(query);
            ExecuteNonQuery(command);
        }

        public void ExecuteNonQuery(DbCommand command)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                command.Connection = connection;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query)
        {
            var command = CreateCommand(query);
            return ExecuteScalar(command);
        }

        public object ExecuteScalar(DbCommand command)
        {
            object value;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                command.Connection = connection;

                connection.Open();
                value = command.ExecuteScalar();
            }

            return value;
        }

        public static Database Create()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string filePath = HttpContext.Current.Server.MapPath(connectionString);

            return new Database(filePath);
        }
    }
}