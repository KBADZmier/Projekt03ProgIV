using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieProj3.ViewModel
{
    public class MainViewModel : BaseModel
    {

        public RelayCommand PracownikViewCommand
        {
            get { return new RelayCommand(PracownikViewSet); }
        }


        public RelayCommand PlaceViewCommand
        {
            get
            {
                return new RelayCommand(PlaceViewSet);
            }
        }

        public RelayCommand SkladkiViewCommand
        {
            get
            {
                return new RelayCommand(SkladkiViewSet);
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

        public void PracownikViewSet()
        {
            currentView = new PracownikModel();
        }




        public void PlaceViewSet()
        {
            currentView = new PlaceModel();
        }

        public void SkladkiViewSet()
        {
            currentView = new SkladkiModel();
        }

        public MainViewModel()
        {

        
        }
    }
}
