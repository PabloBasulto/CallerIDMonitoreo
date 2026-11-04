using System;

namespace CIDVista;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        //Se genera un objeto de caracter MainPageViewModel para 
        _viewModel = viewModel;

         //Enlace de las propiedades visuales con los atributos de viewmodel
        BindingContext = _viewModel;

        // Se suscribe la vista al evento de alertas del view model
        _viewModel.AlertaRequerida += async (titulo, mensaje, boton) => 
        {
            await DisplayAlert(titulo, mensaje, boton);
        };

        Loaded += MainPage_Loaded; //Se registra la llamada
    }

    private void MainPage_Loaded(object? sender, EventArgs e)
    {
        _viewModel.Inicializar();
    }
}
