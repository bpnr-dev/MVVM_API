using MVVM_API_SampleProject.ViewModels;

namespace MVVM_API_SampleProject.Views;

public partial class TodoView : ContentPage
{
	public TodoView()
	{
		InitializeComponent();
		BindingContext = new TodoViewModel();
	}
}