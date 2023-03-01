using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Shop.Infrastructure.Persistence
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext()
        {
            _connectionString = "Server=DESKTOP-DPAV33N;Database=ShopTrainingDB;Trusted_Connection=True;TrustServerCertificate=True";
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
