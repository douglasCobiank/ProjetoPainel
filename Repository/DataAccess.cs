using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA._000.RetornaCarteirasAPI.Repository
{
    public class DataAccess
    {

        public static NpgsqlConnection MakeConnection()
        {
            var conexao = new NpgsqlConnection("Server=10.20.11.141;Port=5432;User ID=plcp001-user;Password=pieso3suW9huK3Leidia;Database=plcp001;CommandTimeout=0;");
            return conexao;
        }

        public static void ExecuteVoidSQL(NpgsqlCommand command)
        {
            using (var connection = MakeConnection())
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public static void ExecuteSQLStrategy(Action<NpgsqlConnection> strategy)
        {
            using (var connection = MakeConnection())
            {
                connection.Open();
                strategy(connection);

            }
        }
    }
}
