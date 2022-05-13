using AppGasolinerasExamen.Models;
using AppGasolinerasExamen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppGasolinerasExamen.ViewModels
{
    public class GasStationsListViewModel : BaseViewModel
    {
        //Variables
        static GasStationsListViewModel instance;

        //Commandos
        private Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        //Propiedades
        private List<GasStationModel> _GasStations;
        public List<GasStationModel> GasStations
        {
            get => _GasStations;
            set => SetProperty(ref _GasStations, value);
        }

        private GasStationModel _GasStationSelected;
        public GasStationModel GasStationSelected
        {
            get => _GasStationSelected;
            set
            {
                if(SetProperty(ref _GasStationSelected, value))
                {
                    SelectGasStationAction();
                }
            }
        }


        //Constructores 
        public GasStationsListViewModel()
        {
            instance = this;

            //Cargamos las tareas de inicio
            LoadGasStations();
        }

        //Métodos
        public static GasStationsListViewModel GetInstance()
        {
            //rgeresamos la instancia de esta misma clase (this)
            return instance;
        }

        public async void LoadGasStations()
        {
            //Bindeamos todas las tareas
            GasStations = await App.GasStationDatabase.GetAllGasStationsAsync();
        }

        private void NewAction(object obj)
        {
            //Abrimos la pagina de detalle en modalidad de crear
            Application.Current.MainPage.Navigation.PushAsync(new GasStationsDetailPage());
        }

        private void SelectGasStationAction()
        {   
            //Abrimos la pagina de detella en modaludad de abrir una tarea existente
            Application.Current.MainPage.Navigation.PushAsync(new GasStationsDetailPage(GasStationSelected));
        }
    }
}
