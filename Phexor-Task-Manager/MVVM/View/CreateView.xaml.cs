using System.Windows.Controls;

namespace Phexor_Task_Manager.MVVM.View;

public partial class CreateView : UserControl
{
    public CreateView()
    {
        InitializeComponent();
        // Bind CreateView to its ViewModel
        this.DataContext = new Phexor_Task_Manager.MVVM.ViewModel.CreateViewModel();
    }
}