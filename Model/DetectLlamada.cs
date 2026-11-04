
using System;

namespace CIDVista;

public class DetectLlamada : IEvento
{
    public event EventHandler<Llamada>? CallRecive;

    // Indica si hay una llamada disponible.
    public bool banderaLlamada { get; private set; }

    // Evita notificar repetidamente la misma llamada.
    private bool _escuchando;

    public void escuchar()
    {
        // Evitar iniciar varias veces el detector.
        if (_escuchando)
            return;

        _escuchando = true;

        //Insertar proceso de escucha
    }

    // Consultar si hay una llamada disponible.
    public bool esLlamada()
    {
        return banderaLlamada;
    }

    // Crear una llamada de prueba.
    public Llamada nuevaLlamada()
    {
        string numero = "9999424970";

        return new Llamada(numero);
    }

    // Registrar una llamada y notificar a los suscriptores.
    public void RegistrarLlamada(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            return;

        Llamada llamada = new Llamada(numero);

        banderaLlamada = true;


        //Se envia la llamada mediante la generacion del evento 
        CallRecive?.Invoke(this, llamada);
    }

    // Marcar la llamada como atendida por el flujo de la aplicación.
    public void LimpiarLlamada()
    {
        banderaLlamada = false;
    }
}

