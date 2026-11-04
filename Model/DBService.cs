
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public class DBService
{
    private readonly string connectionString =
        "Server=192.168.213.181;Database=BASE_DATOS;User Id=Administrador;Password=Pts5830E;TrustServerCertificate=True;";

    public async Task<List<Cuenta>> BuscarCuentasPorTelefono(string telefono)
    {
        var cuentas = new List<Cuenta>();

        try
        {
            // 1. Establecer la conexión con SQL Server
            using SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            // 2. Preparar la consulta SQL
            string query = @"
                SELECT
                    cue_ncuenta,
                    cue_cnombre,
                    cue_ctelefono
                FROM [_Datos].[dbo].[m_cuentas]
                WHERE LTRIM(RTRIM(cue_ctelefono)) = @telefono;";

            // 3. Crear el comando SQL
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@telefono", telefono);

            // 4. Ejecutar la consulta
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            // 5. Leer los resultados
            while (await reader.ReadAsync())
            {
                cuentas.Add(new Cuenta
                (
                    reader.GetInt32(0),
                    reader.IsDBNull(1)
                        ? string.Empty
                        : reader.GetString(1),
                   reader.IsDBNull(2)
                        ? string.Empty
                        : reader.GetString(2)
                ));
            }

            Debug.WriteLine(
                $"Búsqueda completada. Cuentas encontradas: {cuentas.Count}");
        }
        catch (SqlException ex)
        {
            // Errores específicos de SQL Server:
            // conexión, autenticación, consulta, permisos, etc.
            Debug.WriteLine($"Error de SQL Server: {ex.Message}");
            Debug.WriteLine($"Código del error SQL: {ex.Number}");
        }
        catch (TimeoutException ex)
        {
            // Tiempo de espera agotado
            Debug.WriteLine($"Tiempo de espera agotado: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            // Operación inválida sobre la conexión o el comando
            Debug.WriteLine($"Error de operación: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Cualquier otro error inesperado
            Debug.WriteLine($"Error inesperado: {ex}");
        }

        // Si ocurre un error, se devuelve la lista disponible.
        // Si no se encontraron cuentas, también estará vacía.
        return cuentas;
    }
}
