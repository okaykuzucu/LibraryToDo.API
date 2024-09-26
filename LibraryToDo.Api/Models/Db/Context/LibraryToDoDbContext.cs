using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace  LibraryToDo.Models.Db.Context
{
	public class LibraryToDoDbContext
	{
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public LibraryToDoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        /// <summary>
        /// Create Db Connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}

