using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class LeftViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;

        public IRelayCommand CountDownCommand { get; }

        public int Counter
        {
            get => _dataModel.Counter;
            set
            {
                _dataModel.Counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public LeftViewModel(DataModel dataModel)
        {
            _dataModel = dataModel;
            CountDownCommand = new RelayCommand(() => Counter--);
        }
    }
}
