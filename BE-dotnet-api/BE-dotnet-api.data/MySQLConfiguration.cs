using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_dotnet_api.data
{
    public class MySQLConfiguration(string connectionString)
    {
        public string CadenaConexionMySql { get; set; } = connectionString;
    }
}
