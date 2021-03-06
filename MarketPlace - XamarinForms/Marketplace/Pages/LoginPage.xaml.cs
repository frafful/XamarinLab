﻿using Marketplace.AppServices;
using Marketplace.ViewModel;
using System;
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
                //carregandoModal.IsVisible = true;
                //carregandoModal.IsRunning = true;
                grdLoading.IsVisible = true;

                var autenticarResult = await autenticarTask;
                //carregandoModal.IsVisible = false;
                //carregandoModal.IsRunning = false;
                grdLoading.IsVisible = false;

                if (!autenticarResult)
                    await DisplayAlert("MarketPlace Mobile", "Usuário ou senha inválidos", "Ok");
            }
        }
    }
}
