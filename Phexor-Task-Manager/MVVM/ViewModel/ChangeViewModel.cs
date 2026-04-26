using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Phexor_Task_Manager.MVVM.Model;
using Phexor_Task_Manager.MVVM.View;

namespace Phexor_Task_Manager.MVVM.ViewModel;

public class ChangeViewModel
{
    public int Id { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime TargetDate { get; set; }
    public bool Status { get; set; }

    public ICommand BackCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SaveCommand { get; }
    
    public ChangeViewModel(int id, string titel, string description, DateTime startDate, DateTime targetDate, bool status)
    {
        Id = id;
        Title = titel;
        Description = description;
        StartDate = startDate;
        TargetDate = targetDate;
        Status = status;

        BackCommand = new RelayCommand(Cancel);
        DeleteCommand = new RelayCommand(DeleteTask);
        SaveCommand = new RelayCommand(UpdateTask);
    }

    private void Cancel()
    {
        var mainView = new MainView();
        mainView.DataContext = new MainViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(mainView);
    }

    private void DeleteTask()
    {
        Datenbank.RemoveTask(Id);
        var mainView = new MainView();
        mainView.DataContext = new MainViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(mainView);
    }

    private void UpdateTask()
    {
        Datenbank.ChangeTask(Id, Title, Description, StartDate, TargetDate, Status);
        var mainView = new MainView();
        mainView.DataContext = new MainViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(mainView);
    }
}