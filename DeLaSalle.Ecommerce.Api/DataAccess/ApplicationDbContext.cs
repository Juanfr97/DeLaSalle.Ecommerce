using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using MySqlConnector;
using System.Data.Common;

namespace DeLaSalle.Ecommerce.Api.DataAccess
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private MySqlConnection _connection;
        private readonly string _connectionString = "";
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_connectionString);
                }
                return _connection;
            }
        }
        
        

    }
}
