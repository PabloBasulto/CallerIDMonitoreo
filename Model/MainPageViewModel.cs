using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CIDVista;

public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly LlamadaService _llamadaService;
    private readonly DetectLlamada _detector;

    private bool _inicializado;
    private bool _procesandoLlamada;

    // Respaldos de propiedades 
    private string _numeroActual = string.Empty;
    private string _totalCuentasTexto = string.Empty;
    private List<Cuenta> _cuentasVinculadas = new();

    // Propiedades que se enviaran al xaml
    public string NumeroActual
    {
        get => _numeroActual;
        set => SetProperty(ref _numeroActual, value);
    }

    public string TotalCuentasTexto
    {
        get => _totalCuentasTexto;
        set => SetProperty(ref _totalCuentasTexto, value);
    }

    public List<Cuenta> CuentasVinculadas
    {
        get => _cuentasVinculadas;
        set => SetProperty(ref _cuentasVinculadas, value);
    }

    // Evento para notifcar las alertas a la interfaz
    public event Func<string, string, string, Task>? AlertaRequerida;

    //Constructor
    public MainPageViewModel(LlamadaService llamadaService)
    {
        _llamadaService = llamadaService;
        _detector = new DetectLlamada();

        //  Sucrbibir Detector_CallRecive al evento  Call Recive en _detector
        _detector.CallRecive += Detector_CallRecive;
    }

    // Reemplaza al MainPage_Loaded
    public void Inicializar()
    {
        if (_inicializado)
            return;

        _inicializado = true;
        _detector.escuchar();

        // Simulación temporal de una llamada
        _detector.RegistrarLlamada("9999001128");
    }

     //El atributo llamada se genera cuando sucede el evento y se lo pasa a Detector_CallRecive
    private async void Detector_CallRecive(object? sender, Llamada llamada) 
    {

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (_procesandoLlamada)
                return;

            _procesandoLlamada = true;

            try
            { 
                NumeroActual = llamada.Numero; 

                //Mecanismo de busqueda

                List<Cuenta> cuentas = await _llamadaService.ProcesarLlamadaAsync(llamada.Numero);

                TotalCuentasTexto = $"Cuentas vinculadas: {cuentas.Count}";
                CuentasVinculadas = cuentas;
            }
            catch (Exception ex)
            {
                TotalCuentasTexto = "Error al consultar las cuentas.";
                
                // Disparamos el evento para que la Vista muestre la alerta nativa
                if (AlertaRequerida != null)
                {
                    await AlertaRequerida.Invoke("Error", ex.Message, "Aceptar");
                }
            }
            finally
            {
                _detector.LimpiarLlamada();
                _procesandoLlamada = false;
            }
        });
    }

    #region Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    #endregion
}
