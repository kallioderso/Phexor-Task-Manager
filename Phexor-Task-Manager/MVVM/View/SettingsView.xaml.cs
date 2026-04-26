using System.Windows.Controls;

namespace Phexor_Task_Manager.MVVM.View;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        // Bind SettingsView to its ViewModel
        this.DataContext = new Phexor_Task_Manager.MVVM.ViewModel.SettingsViewModel();
    }
}