using System;
using System.Collections.Generic;
using System.Text;

namespace Connecta_IPBVC.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string title, string message, string buttonText = "Ok")
        {
            return Shell.Current.DisplayAlert(title, message, buttonText);
        }
    }

}
