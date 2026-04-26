using System.Windows.Controls;

namespace Phexor_Task_Manager.MVVM.View;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        // Set ViewModel as DataContext so bindings resolve to the correct VM
        this.DataContext = new Phexor_Task_Manager.MVVM.ViewModel.MainViewModel();
    }
}