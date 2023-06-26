using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProgramowanieProj3.Models;
using ProgramowanieProj3.View;
using Place = ProgramowanieProj3.Models.Place;

namespace ProgramowanieProj3.ViewModel
{
    partial class PlaceModel : BaseModel
    { 


        private ObservableCollection<Place> place;
        public ObservableCollection<Place> Place
        {
            get { return place; }
            set
            {
                place = value;
                onPropertyChanged(nameof(place));
            }
        }


        public ICommand deletePlaceC { get; set; }
        public ICommand addPlaceC { get; set; }
        public ICommand updatePlaceC { get; set; }
        public ICommand RefreshPlace { get; set; }
        public PlaceModel()
        {
            place = new ObservableCollection<Place>(context.Place.ToList());
            deletePlaceC = new RelayCommand<Place>((param) => deletePlace(param));
            updatePlaceC = new RelayCommand<Place>((param) => updatePlace(param));
            addPlaceC = new RelayCommand(addPlace);
            RefreshPlace = new RelayCommand(PlaceViewSet); 

        }




        private int _SelectedPlaceId;
        public int SelectedPlaceId
        {
            get { return _SelectedPlaceId; }
            set
            {
                _SelectedPlaceId = value;
                onPropertyChanged(nameof(_SelectedPlaceId));
            }
        }


        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged();
            }
        }

     


        public void PlaceViewSet()
        {
            currentView = new PlaceModel();
            MessageBox.Show("Odświeżono", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }


        private int _IdPlac;
        public int IdPlac
        {
            get { return _IdPlac; }
            set
            {
                _IdPlac = value;
                onPropertyChanged(nameof(_IdPlac));
            }
        }


        private int _IdPracownika;
        public int IdPracownika
        {
            get { return _IdPracownika; }
            set
            {
                _IdPracownika = value;
                onPropertyChanged(nameof(_IdPracownika));
            }
        }

        private double _StawkaGodzinowa;
        public double StawkaGodzinowa
        {
            get { return _StawkaGodzinowa; }
            set
            {
                _StawkaGodzinowa = value;
                onPropertyChanged(nameof(_StawkaGodzinowa));
            }
        }


        private int _IloscGodzin;
        public int IloscGodzin
        {
            get { return _IloscGodzin; }
            set
            {
                _IloscGodzin = value;
                onPropertyChanged(nameof(_IloscGodzin));
            }
        }



        private double _WyplataNetto;
        public double WyplataNetto
        {
            get { return _WyplataNetto; }
            set
            {
                _WyplataNetto = value;
                onPropertyChanged(nameof(_WyplataNetto));
            }
        }

        private double _WyplataBrutto;
        public double WyplataBrutto
        {
            get { return _WyplataBrutto; }
            set
            {
                _WyplataBrutto = value;
                onPropertyChanged(nameof(_WyplataBrutto));
            }
        }

   


        private void deletePlace(Place param)
        {
            int PlaceId = _SelectedPlaceId;
            Place placeToRemove = Place.FirstOrDefault(e => e.IdPracownika == PlaceId);
            context.Place.Remove(placeToRemove);
            context.SaveChanges();

            MessageBox.Show("Place Usuniete", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void addPlace()
        {


            var place = new Place()
            {
                IdPlac = _IdPlac,
                IdPracownika = _IdPracownika,
                StawkaGodzinowa = _StawkaGodzinowa,
                WyplataBrutto = _WyplataBrutto,
                WyplataNetto = _WyplataNetto,
                IloscGodzin = _IloscGodzin
            };

            context.Place.Add(place);
            context.SaveChanges();


           

            MessageBox.Show("Placa dodana", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);




        }
        private void updatePlace(Place param)
        {


            Place PlaceToUpdate = Place.FirstOrDefault(e => e.IdPlac == _SelectedPlaceId);


            PlaceToUpdate.IdPracownika = _IdPracownika;
            PlaceToUpdate.StawkaGodzinowa = _StawkaGodzinowa;
            PlaceToUpdate.WyplataBrutto = _WyplataBrutto;
            PlaceToUpdate.WyplataNetto = _WyplataNetto;
            PlaceToUpdate.IloscGodzin = _IloscGodzin;

                context.SaveChanges();

                MessageBox.Show("Place zaktualizowane", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            
         

        }

    
        }


    }

