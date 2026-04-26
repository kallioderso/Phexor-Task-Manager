using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Phexor_Task_Manager.MVVM.Model;
using Phexor_Task_Manager.MVVM.View;

namespace Phexor_Task_Manager.MVVM.ViewModel;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime TargetDate { get; set; }

    private bool _isDone;

    public bool IsDone
    {
        get => _isDone;
        set
        {
            if (_isDone == value) return;
            _isDone = value;
            Datenbank.ChangeTask(Id, Title, Description, StartDate, TargetDate, _isDone);
        }
    }
}

public class MainViewModel : INotifyPropertyChanged
{
    public bool IsDarkMode { get; set; }
    public TaskModel? SelectedTask { get; set; }
    
    public ObservableCollection<TaskModel> Tasks { get; } = new();
    
    public ICommand OpenCreateCommand { get; }
    public ICommand OpenChangeCommand { get; }

    public MainViewModel()
    {
        OpenCreateCommand = new RelayCommand(CreateTask);
        OpenChangeCommand = new RelayCommand(OpenChange);
        LoadTasks();
    }

    private void CreateTask()
    {
        var createView = new CreateView();
        createView.DataContext = new CreateViewModel();
        ((MainWindow)Application.Current.MainWindow).ShowView(createView);
    }


    private void OpenChange()
    {
        if (SelectedTask == null)
            return;

        var changeView = new ChangeView(SelectedTask.Id, SelectedTask.Title, SelectedTask.Description, SelectedTask.StartDate, SelectedTask.TargetDate, SelectedTask.IsDone);
        ((MainWindow)Application.Current.MainWindow).ShowView(changeView);
    }
    
    private void LoadTasks()
    {
        Tasks.Clear();

        var allTasks = Datenbank.ReadTasks();

        foreach (var task in allTasks)
        {
            Tasks.Add(new TaskModel()
            {
                Id = task.id,
                Title = task.title,
                Description = task.description,
                StartDate = task.created_at,
                TargetDate = task.due_date,
                IsDone = task.status
            });
        }
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