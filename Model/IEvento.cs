public interface IEvento
{
    event EventHandler<Llamada> CallRecive; //Se declara un evento que transportara un dato de tipo llamada

    void escuchar();
    
}
