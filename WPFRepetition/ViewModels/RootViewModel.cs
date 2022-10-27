using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;

namespace WPFRepetition.ViewModels
{
    class RootViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataManager _dataManager;

        public IRelayCommand NavigateLeftCommand { get; }
        public IRelayCommand NavigateRightCommand { get; }
        public IRelayCommand NavigateCenterCommand { get; }


        public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;
        
        public RootViewModel(NavigationManager navigationManager, DataManager dataManager)
        {
            _navigationManager = navigationManager;
            _dataManager = dataManager;

            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataManager.DataModel));
            NavigateCenterCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataManager.DataModel));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RightViewModel(_dataManager.DataModel));

            _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;
        }


        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
    }
}
