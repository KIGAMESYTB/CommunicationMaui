using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SendEmail.Model;

namespace SendEmail.ViewModels
{
    public partial class EmailViewModel : ObservableObject
    {
        public Model.Email GetEmail { get; set; }

        public EmailViewModel() 
        {
            GetEmail= new Model.Email();
        }

        [RelayCommand]
        async void SendMail()
        {
            try
            {
                if(string.IsNullOrEmpty(GetEmail.Subject) || 
                   string.IsNullOrEmpty(GetEmail.Body) ||
                   string.IsNullOrEmpty(GetEmail.TO))
                {
                    await Shell.Current.DisplayAlert("Error", "Please fill in the required fields", "Ok");
                    return;
                }

                var message = new EmailMessage()
                {
                    Subject = GetEmail.Subject,
                    Body = GetEmail.Body,
                    To = new List<string>(GetEmail.TO.Split(';'))
                };

                if(GetEmail.CC.Length > 0)
                    message.Cc = new List<string>(GetEmail.CC.Split(';'));

                await Microsoft.Maui.ApplicationModel.Communication.Email.Default.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await Shell.Current.DisplayAlert("Error", fbsEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
