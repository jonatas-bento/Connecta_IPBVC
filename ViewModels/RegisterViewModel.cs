using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;

namespace Connecta_IPBVC.ViewModels
{
	public class RegisterViewModel : BindableObject
	{
		private readonly AuthService _auth;
		public RegisterViewModel(AuthService auth)
		{
			_auth = auth;
		}

		public string NomeCompleto { get; set; }
		public string Celular { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public ICommand RegisterCommand => new Command(async () => await DoRegister());

		private async Task DoRegister()
		{
			var dto = new RegisterDTO
			{
				Nome = NomeCompleto,
				//Celular = Celular,
				Email = Email,
				Password = Password
			};

			var token = await _auth.RegisterAsync(dto);

			if (token == null)
			{
				await App.Current.MainPage.DisplayAlert("Erro", "Não foi possível registrar.", "OK");
				return;
			}

			await SecureStorage.SetAsync("jwt", token);

			await App.Current.MainPage.DisplayAlert("Sucesso", "Conta criada com sucesso!", "OK");

			await App.Current.MainPage.Navigation.PushAsync(new HomePage());
		}
	}
}
