using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection
{
    public class DatabaseManager
    {
        private readonly string connectionString;
        
        // se obtiene cadena de conexion.
        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
        // para guardar en el data set en especifico cuando esperamos que se devuelvan datos y no solo se ejecute un Procedimiento Almacenado.
        public DataSet ExecuteSelectQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                // Se abre la conexion.
                try
                {
                    connection.Open();
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta SELECT: " + ex.Message);
                }

                return dataSet;
            }
        }

        // se ejecuta cualquier SP sin la intencion de que se devuelvan datos solo el mensaje de filas afectadas.
        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                int rowsAffected = 0;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }

                return rowsAffected;
            }
        }

        // se obtienen las filas afectadas.
        public int GetRowCount(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                int rowCount = 0;

                try
                {
                    connection.Open();
                    rowCount = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta de conteo de filas: " + ex.Message);
                }

                return rowCount;
            }
        }
    }
}
