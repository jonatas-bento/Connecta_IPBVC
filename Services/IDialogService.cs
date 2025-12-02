using System;
using System.Collections.Generic;
using System.Text;

namespace Connecta_IPBVC.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string title, string message, string buttonText = "Ok");
    }

}
