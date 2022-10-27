using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class RightViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;
        private readonly NavigationManager _navigationManager;

        public IRelayCommand CountUpCommand { get; }
        public IRelayCommand NavigateCenterCommand { get; }
        public IRelayCommand NavigateLeftCommand { get; }

        public int Counter
        {
            get => _dataModel.Counter;
            set
            {
                _dataModel.Counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public RightViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;

            CountUpCommand = new RelayCommand(() => Counter++);
            NavigateCenterCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, navigationManager));
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, navigationManager));
        }
    }
}
