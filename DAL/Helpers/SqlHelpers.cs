using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    // Esta clase proporciona métodos para interactuar con una base de datos SQL utilizando ADO.NET
    internal class SqlHelpers
    {
        internal static class SqlHelper
        {
            readonly static string conString;

            static SqlHelper()
            {
                // Configura la cadena de conexión desde app.config si aún no está configurada.
                conString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            }

            //Este método es útil cuando necesitas ejecutar consultas SQL que no devuelven datos
            public static Int32 ExecuteNonQuery(String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                // Verifica si los parámetros son nulos antes de usarlos.
                CheckNullables(parameters);

                // Crea una conexión a la base de datos con la cadena de conexión
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // Crea un comando SQL con el texto de la consulta y la conexión
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // Define el tipo de comando (puede ser StoredProcedure, Text o TableDirect)
                        cmd.CommandType = commandType;

                        // Agrega los parámetros proporcionados al comando
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        // Ejecuta la consulta y devuelve el número de filas afectadas
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            // Cuando trabajas con bases de datos SQL en C#, no puedes asignar directamente null a los parámetros de una consulta.
            // SQL usa NULL, y en C# eso se representa con DBNull.Value.
            // Si no se hace esta conversión, la base de datos podría generar un error al ejecutar la consulta.
            private static void CheckNullables(SqlParameter[] parameters)
            {
                // Recorre cada parámetro en el arreglo recibido
                foreach (SqlParameter item in parameters)
                {
                    // Si el valor del parámetro es null, lo cambia a DBNull.Value
                    if (item.SqlValue == null)
                    {
                        //Si el valor es null, lo cambia a DBNull.Value,
                        //que es el equivalente de null en bases de datos SQL
                        //(porque null en C# no es lo mismo que NULL en SQL).
                        item.SqlValue = DBNull.Value;
                    }
                }
            }

            // Este método es útil cuando necesitas ejecutar consultas SQL que devuelven un solo valor (Ej. Contar cuantos usuarios hay)
            public static Object ExecuteScalar(String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                // Crea y abre una conexión a la base de datos usando la cadena de conexión (conString)
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // Crea un comando SQL con el texto de la consulta y la conexión
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // Define el tipo de comando (puede ser StoredProcedure, Text o TableDirect)
                        cmd.CommandType = commandType;
                        // Agrega los parámetros proporcionados al comando
                        cmd.Parameters.AddRange(parameters);

                        // Abre la conexión a la base de datos
                        conn.Open();

                        // Ejecuta la consulta y devuelve el primer valor de la primera fila
                        return cmd.ExecuteScalar();
                    }
                }
            }

            // Este método es útil cuando necesitas ejecutar consultas SQL que devuelven un conjunto de resultados
            public static SqlDataReader ExecuteReader(String commandText,
                CommandType commandType, params SqlParameter[] parameters)
            {
                // Crea una conexión a la base de datos con la cadena de conexión
                SqlConnection conn = new SqlConnection(conString);

                // Crea un comando SQL con el texto de la consulta y la conexión
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // Define el tipo de comando (puede ser StoredProcedure, Text o TableDirect)
                    cmd.CommandType = commandType;
                    // Agrega los parámetros proporcionados al comando
                    cmd.Parameters.AddRange(parameters);

                    // Abre la conexión a la base de datos
                    conn.Open();

                    // Ejecuta la consulta y devuelve un SqlDataReader
                    // CommandBehavior.CloseConnection hace que la conexión se cierre automáticamente cuando se cierre el DataReader.
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return reader;
                }
            }
        }
    }
}
