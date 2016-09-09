using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Marketplace.Pages
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            grdLoading.IsVisible = true;
            carregandoModal.IsVisible = true;
            carregandoModal.IsRunning = true;
        }
    }
}
