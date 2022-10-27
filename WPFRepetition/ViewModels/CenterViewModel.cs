using System;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class CenterViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;
        public IRelayCommand ResetCounterCommand { get; }

        public int Counter
        {
            get => _dataModel.Counter;
            set
            {
                _dataModel.Counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public CenterViewModel(DataModel dataModel)
        {
            _dataModel = dataModel;
            ResetCounterCommand = new RelayCommand(() => Counter = 0);
        }
    }
}