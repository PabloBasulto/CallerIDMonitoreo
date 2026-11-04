
public class LlamadaService
{
    private readonly DBService _dbService;

    public LlamadaService(DBService dbService)
    {
        _dbService = dbService;
    }

    public async Task<List<Cuenta>> ProcesarLlamadaAsync(string telefono)
    {
        // 1. Validar que exista un numero para buscar
        //Si no exite un numero  se regresa una lista vacia
        if (string.IsNullOrWhiteSpace(telefono))
        {
            return new List<Cuenta>();
        }

        // 2. Consultar la base de datos.
        List<Cuenta> cuentas = await _dbService.BuscarCuentasPorTelefono(telefono.Trim());

        // 3. Retornar todas las cuentas encontradas.
        return cuentas;
    }
}
