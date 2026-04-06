using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "server=localhost;database=cimala2018;user=root;password=d0cuc!@$$;";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Conectado a MySQL ✅");

                string query = @"SELECT ticket_id, number, created 
                                 FROM ost_ticket 
                                 ORDER BY created DESC 
                                 LIMIT 10;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ticket_id"]} - Número: {reader["number"]} - Fecha: {reader["created"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}