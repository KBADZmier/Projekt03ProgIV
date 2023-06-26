using CommunityToolkit.Mvvm.Input;
using ProgramowanieProj3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ProgramowanieProj3.ViewModel
{
    partial class SkladkiModel : BaseModel
    {
        //   private DBContext context = new DBContext();

        private ObservableCollection<Skladki> skladki;
        public ObservableCollection<Skladki> Skladki
        {
            get { return skladki; }
            set
            {
                skladki = value;
                onPropertyChanged(nameof(Skladki));
            }
        }



        public ICommand addSkladkiC { get; set; }
        public ICommand updateSkladkiC { get; set; }
        public ICommand deleteSkladkiC { get; set; }

        public SkladkiModel()
        {
            Skladki = new ObservableCollection<Skladki>(context.Skladki.ToList());
            deleteSkladkiC = new RelayCommand<Skladki>((param) => deleteSkladki(param));
            updateSkladkiC = new RelayCommand<Skladki>((param) => updateSkladki(param));
            addSkladkiC = new RelayCommand(addSkladki);
        }




        private int _SelectedSkladkiId;
        public int SelectedSkladkiId
        {
            get { return _SelectedSkladkiId; }
            set
            {
                _SelectedSkladkiId = value;
                onPropertyChanged(nameof(_SelectedSkladkiId));
            }
        }





        private int _IdSkladki;
        public int IdSkladki
        {
            get { return _IdSkladki; }
            set
            {
                _IdSkladki = value;
                onPropertyChanged(nameof(_IdSkladki));
            }
        }

        private int _IdPlace;
        public int IdPlace
        {
            get { return _IdPlace; }

            set
            {
                _IdPlace = value;
                onPropertyChanged(nameof(_IdPlace));
            }

        }

        private string _Rodzaj;
        public string Rodzaj
        {
            get { return _Rodzaj; }
            set
            {
                _Rodzaj = value;
                onPropertyChanged(nameof(_Rodzaj));
            }
        }

        private double _Stawka;
        public double Stawka
        {
            get { return _Stawka; }
            set
            {
                _Stawka = value;
                onPropertyChanged(nameof(_Stawka));
            }
        }

        void addSkladki()
        {

            var skladki = new Skladki()
            {
                IdSkladki = _IdSkladki,
                IdPlace = _IdPlace,
                Rodzaj = _Rodzaj,
                Stawka = _Stawka,


            };

            context.Skladki.Add(skladki);
            context.SaveChanges();

            Rodzaj = string.Empty;

            MessageBox.Show("Skladka została dodana.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }

        private void updateSkladki(Skladki param)
        {

            Skladki SkladkaToUpdate = Skladki.FirstOrDefault(e => e.IdSkladki == _SelectedSkladkiId);

            SkladkaToUpdate.IdPlace = _IdPlace;
            SkladkaToUpdate.Rodzaj = _Rodzaj;
            SkladkaToUpdate.Stawka = _Stawka;

            context.SaveChanges();
            Rodzaj = string.Empty;



            MessageBox.Show("Skladka została zaktualizowana", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }

        private void deleteSkladki(Skladki param)
        {
            int skladkiId = _SelectedSkladkiId;

            Skladki SkladkaToRemove = Skladki.FirstOrDefault(e => e.IdSkladki == skladkiId);

            context.Skladki.Remove(SkladkaToRemove);
            SelectedSkladkiId = 0;
            context.SaveChanges();

            MessageBox.Show("Składka została usunieta.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
    }
}
