using Marketplace.AppServices;
using Marketplace.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Marketplace.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;
        AutenticarAppService autenticarService;

        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
        }

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            autenticarService = new AutenticarAppService();

            if (viewModel.PodeEntrar)
            {
                Task<bool> autenticarTask = autenticarService.AutenticarAsync(viewModel.Login, viewModel.Senha);
                carregandoModal.IsRunning = true;

                var autenticarResult = await autenticarTask;

                if (!autenticarResult)
                    await DisplayAlert("MarketPlace Mobile", "Usuário ou senha inválidos", "Ok");
            }
        }
    }
}
