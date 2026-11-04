public class Cuenta
{
    public int _Id { get; set; }
    public string _Nombre { get; set; }
    public string _NumeroTelefono { get; set; }


    public Cuenta(int Id, string Nombre, string NumeroTelefono){
        _Id = Id;
        _Nombre = Nombre;
        _NumeroTelefono = NumeroTelefono;
        

    } 
}