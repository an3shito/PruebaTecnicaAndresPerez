using System;
using System.Data;

namespace DatabaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo de uso
            string connectionString = "TuCadenaDeConexion";
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            // Ejemplo de SELECT
            string selectQuery = "SELECT * FROM MiTabla";
            DataSet dataSet = dbManager.ExecuteSelectQuery(selectQuery);
            // Aquí puedes manipular el DataSet obtenido según tus necesidades
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine(string.Join(", ", row.ItemArray));
                }
            }

            // Ejemplo de INSERT, UPDATE o DELETE
            string insertQuery = "INSERT INTO MiTabla (Campo1, Campo2) VALUES ('Valor1', 'Valor2')";
            int rowsInserted = dbManager.ExecuteNonQuery(insertQuery);
            Console.WriteLine("Filas afectadas por el INSERT: " + rowsInserted);

            // Ejemplo de contar el número de filas que devolvería un SELECT
            string countQuery = "SELECT COUNT(*) FROM MiTabla";
            int rowCount = dbManager.GetRowCount(countQuery);
            Console.WriteLine("Número de filas en MiTabla: " + rowCount);
        }
    }
}