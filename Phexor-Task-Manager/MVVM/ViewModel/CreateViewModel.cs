using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Phexor_Task_Manager.MVVM.View;

namespace Phexor_Task_Manager.MVVM.ViewModel;

public class CreateViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime TargetDate { get; set; } = DateTime.Today;
    public bool IsDone { get; set; }
    public ICommand CreateCommand { get; }
    public ICommand CancelCreateCommand { get; }
    
    public CreateViewModel()
    {
        CreateCommand = new RelayCommand(Create);
        CancelCreateCommand = new RelayCommand(Cancel);
    }

    private void Create()
    {
        Model.Datenbank.AddTask(Title, Description, StartDate, TargetDate, IsDone);
        var mainView = new MainView();
        mainView.DataContext = new MainViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(mainView);
    }

    private void Cancel()
    {
        var mainView = new MainView();
        mainView.DataContext = new MainViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(mainView);
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}