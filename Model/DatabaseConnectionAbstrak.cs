using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Model
{
    public abstract class DatabaseConnectionAbstrak
    {
        protected readonly string connectionString;

        protected DatabaseConnectionAbstrak()
        {
            connectionString = "Host=localhost;Port=5432;Username=postgres;Password=a.1056.A;Database=Coba_Bakery_P";
        }

        public abstract NpgsqlConnection GetConnection();

        public abstract DataTable ExecuteQuery(string query, NpgsqlParameter[] parameters = null);

        public abstract int ExecuteNonQuery(string query, NpgsqlParameter[] parameters = null);
    }
}