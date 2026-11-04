public class Llamada : EventArgs {

    public string Numero { get; }


    public Llamada(string numero)
    {
        Numero = numero;
    }
 
}