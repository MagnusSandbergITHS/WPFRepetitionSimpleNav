using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class LeftViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;
        private readonly NavigationManager _navigationManager;

        public IRelayCommand CountDownCommand { get; }
        public IRelayCommand NavigateCenterCommand { get; }  
        public IRelayCommand NavigateRightCommand { get; }

        public int Counter
        {
            get => _dataModel.Counter;
            set
            {
                _dataModel.Counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public LeftViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;
            CountDownCommand = new RelayCommand(() => Counter--);
            NavigateCenterCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, navigationManager));
        }
    }
}
