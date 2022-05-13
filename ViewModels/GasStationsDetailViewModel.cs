using AppGasolinerasExamen.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppGasolinerasExamen.ViewModels
{
    public class GasStationsDetailViewModel : BaseViewModel
    {
        //Variables

        //Comandos
        private Command _CancelCommand;
        public Command CancelCommand => _CancelCommand ?? (_CancelCommand = new Command(CancelAction));

        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        //Propiedades
        private GasStationModel _GasStationSelected;
        public GasStationModel GasStationSelected
        {
            get => _GasStationSelected;
            set => SetProperty(ref _GasStationSelected, value);
        }

        //Constructores

        public GasStationsDetailViewModel()
        {
            //Tarea nueva se instancia
            GasStationSelected = new GasStationModel();
        }

        public  GasStationsDetailViewModel(GasStationModel gasStationSelected)
        {
            //Tarea existente se carga
            GasStationSelected = gasStationSelected;
        }

        //Métodos
        private async void SaveAction()
        {
            //Se guarda en SQLite
            await App.GasStationDatabase.SaveGasStationAsync(GasStationSelected);

            //Refrescamos el listado
            GasStationsListViewModel.GetInstance().LoadGasStations();

            //Cerrar la página
            CancelAction();
        }

        private async void DeleteAction()
        {
            //Eliminar en SQLite
            await App.GasStationDatabase.DeleteGasStationAsync(GasStationSelected);

            //regresar el listado
            GasStationsListViewModel.GetInstance().LoadGasStations();

            //cerramos la página
            CancelAction();
        }

        private async void CancelAction()
        {
            //Regresa el listado
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
