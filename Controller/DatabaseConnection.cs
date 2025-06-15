using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Data;

namespace Kinar_Bakery.Controller
{
    public class DatabaseConnection : DatabaseConnectionAbstrak
    {
        public override NpgsqlConnection GetConnection()
        {
            try
            {
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal membuka koneksi ke database: " + ex.Message);
            }
        }

        public override DataTable ExecuteQuery(string query, NpgsqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                try
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        if (parameters != null) command.Parameters.AddRange(parameters);
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Gagal menjalankan query: " + ex.Message);
                }
            }
            return dataTable;
        }

        public override int ExecuteNonQuery(string query, NpgsqlParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        if (parameters != null) command.Parameters.AddRange(parameters);
                        return command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Gagal menjalankan perintah: " + ex.Message);
                }
            }
        }
    }
}