using System.Windows.Controls;

namespace Phexor_Task_Manager.MVVM.View;

public partial class ChangeView : UserControl
{
    public ChangeView(int id, string titel, string description, DateTime startDate, DateTime targetDate, bool status)
    {
        InitializeComponent();
        // Bind ChangeView to its ViewModel
        this.DataContext = new Phexor_Task_Manager.MVVM.ViewModel.ChangeViewModel(id, titel, description, startDate, targetDate, status);
    }
}