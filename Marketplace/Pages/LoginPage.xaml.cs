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
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (viewModel.PodeEntrar)
            {

            }
        }
    }
}
