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
    public partial class PracownikModel : BaseModel
    {
        //private DBContext context = new DBContext();

        private ObservableCollection<Pracownicy> pracownik;
        public ObservableCollection<Pracownicy> Pracownik
        {
            get { return pracownik; }
            set
            {
                pracownik = value;
                onPropertyChanged(nameof(Pracownik));
            }
        }

        public ObservableCollection<Place> Place { get; set; }


        public ICommand addPracownikC { get; set; }
        public ICommand updatePracownikC { get; set; }
        public ICommand deletePracownikC { get; }

        public PracownikModel()
        {

          
            Pracownik = new ObservableCollection<Pracownicy>(context.Pracownik.ToList());
            deletePracownikC = new RelayCommand<Pracownicy>((param) => deletePracownik(param));
            updatePracownikC = new RelayCommand<Pracownicy>((param) => updatePracownik(param));
            addPracownikC = new RelayCommand(addPracownik);

        }


        private int _SelectedEmployeeId;
        public int SelectedEmployeeId
        {
            get { return _SelectedEmployeeId; }
            set
            {
                _SelectedEmployeeId = value;
                onPropertyChanged(nameof(_SelectedEmployeeId));
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


        private string _Imie;
        public string Imie
        {
            get { return _Imie; }
            set
            {
                _Imie = value;
                onPropertyChanged(nameof(_Imie));
            }
        }

        private string _Nazwisko;
        public string Nazwisko
        {
            get { return _Nazwisko; }
            set
            {
                _Nazwisko = value;
                onPropertyChanged(nameof(_Nazwisko));
            }
        }

        private string _Plec;
        public string Plec
        {
            get { return _Plec; }
            set
            {
                _Plec = value;
                onPropertyChanged(nameof(_Plec));
            }
        }

        private string _Adres;
        public string Adres
        {
            get { return _Adres; }
            set
            {
                _Adres = value;
                onPropertyChanged(nameof(_Adres));
            }
        }



        private string _NrKonta;
        public string NrKonta
        {
            get { return _NrKonta; }
            set
            {
               _NrKonta = value;
                onPropertyChanged(nameof(_NrKonta));
            }
        }


        private string _TelefonKontaktowy;
        public string TelefonKontaktowy
        {
            get { return _TelefonKontaktowy; }
            set
            {
                _TelefonKontaktowy = value;
                onPropertyChanged(nameof(_TelefonKontaktowy));
            }
        }


      




        void addPracownik()
        {


            var pracownik = new Pracownicy()
            {
                IdPracownika = _IdPracownika,
                Imie = _Imie,
                Nazwisko = _Nazwisko,
                Plec = _Plec,
                Adres = _Adres,
                NrKonta = _NrKonta,
                TelefonKontaktowy = _TelefonKontaktowy

            };

            context.Pracownik.Add(pracownik);
            context.SaveChanges();

            Imie = string.Empty;
            Nazwisko = string.Empty;
            Plec = string.Empty;
            Adres = string.Empty;

            NrKonta = string.Empty;
            TelefonKontaktowy = string.Empty;

            MessageBox.Show("Pracownik został dodany.", "Succes", MessageBoxButton.OK);



        }

        private void updatePracownik(Pracownicy param)
        {


            Pracownicy employeeToUpdate = Pracownik.FirstOrDefault(e => e.IdPracownika == _SelectedEmployeeId);


            employeeToUpdate.Imie = _Imie;
            employeeToUpdate.Nazwisko = _Nazwisko;
            employeeToUpdate.Plec = _Plec;
            employeeToUpdate.Adres = _Adres;
            employeeToUpdate.NrKonta = _NrKonta;
            employeeToUpdate.TelefonKontaktowy = _TelefonKontaktowy;
            context.SaveChanges();
            Imie = string.Empty;
            Nazwisko = string.Empty;
            Plec = string.Empty;
            Adres = string.Empty;

            NrKonta = string.Empty;
            TelefonKontaktowy = string.Empty;
            MessageBox.Show("Pracownik został zaktualizowany", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void deletePracownik(Pracownicy param)
        {

            int employeeId = _SelectedEmployeeId;

            Pracownicy employeeToRemove = Pracownik.FirstOrDefault(e => e.IdPracownika == employeeId);
           
                context.Pracownik.Remove(employeeToRemove);
                SelectedEmployeeId = 0;
                context.SaveChanges();
            


            MessageBox.Show("Pracownik został usuniety", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);


        }





    }
}
