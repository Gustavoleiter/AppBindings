using AppBindings.ViewModels;

namespace AppBindings.Views;

public partial class UsuarioView : ContentPage
{
	public UsuarioView()
	{
		InitializeComponent();
		BindingContext = new UsuarioViewModel();
	}
}