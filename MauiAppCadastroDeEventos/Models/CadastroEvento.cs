using MauiAppCadastroDeEventos.Views;
using System.ComponentModel;
using System.Windows.Input;

public class CadastroEventoViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private Evento _evento;
    public Evento Evento
    {
        get => _evento;
        set
        {
            _evento = value;
            OnPropertyChanged(nameof(Evento));
        }
    }

    public ICommand CadastrarEventoCommand { get; }

    public CadastroEventoViewModel()
    {
        Evento = new Evento();
        CadastrarEventoCommand = new Command(OnCadastrarEvento);
    }

    private async void OnCadastrarEvento()
    {
        // Navegar para a página de resumo do evento
        await Application.Current.MainPage.Navigation.PushAsync(new ResumoEventoPage(Evento));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
