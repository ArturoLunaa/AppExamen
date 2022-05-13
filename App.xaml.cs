using AppGasolinerasExamen.Data;
using AppGasolinerasExamen.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGasolinerasExamen
{
    public partial class App : Application
    {
        //Propiedad estática para instanciar y regresar la variable de SQLite
        private static GasStationDatabase gasStationDatabase;

        public static GasStationDatabase GasStationDatabase
        {
            get
            {
                if (gasStationDatabase == null) gasStationDatabase = new GasStationDatabase();
                return gasStationDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            NavigationPage nav = new NavigationPage(new GasStationsListPage());
            nav.BarBackground = (Color)App.Current.Resources["BackgroundColor"];
            nav.BarTextColor = (Color)App.Current.Resources["BarTextColor"];
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
