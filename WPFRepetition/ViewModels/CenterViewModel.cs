using System;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class CenterViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;
        private readonly NavigationManager _navigationManager;

        public IRelayCommand ResetCounterCommand { get; }
        public IRelayCommand NavigateLeftCommand { get; }
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

        public CenterViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;
            ResetCounterCommand = new RelayCommand(() => Counter = 0);
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, navigationManager));
        }
    }
}