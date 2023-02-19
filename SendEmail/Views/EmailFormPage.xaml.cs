using SendEmail.ViewModels;

namespace SendEmail.Views;

public partial class EmailFormPage : ContentPage
{
	public EmailFormPage(EmailViewModel emailViewModel)
	{
		InitializeComponent();
		BindingContext = emailViewModel;
	}
}