using AppGasolinerasExamen.Models;
using AppGasolinerasExamen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGasolinerasExamen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GasStationsDetailPage : ContentPage
    {
        public GasStationsDetailPage()
        {
            InitializeComponent();

            BindingContext = new GasStationsDetailViewModel();
        }

        public GasStationsDetailPage(GasStationModel gasStationSelected)
        {
            InitializeComponent();

            BindingContext = new GasStationsDetailViewModel(gasStationSelected);
        }
    }
}