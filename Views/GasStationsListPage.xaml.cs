using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGasolinerasExamen.ViewModels;

namespace AppGasolinerasExamen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GasStationsListPage : ContentPage
    {
        public GasStationsListPage()
        {
            InitializeComponent();

            BindingContext = new GasStationsListViewModel();
        }
    }
}