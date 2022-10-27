using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class RightViewModel : ObservableObject
    {
        private readonly DataModel _dataModel;

        public IRelayCommand CountUpCommand { get; }

        public int Counter
        {
            get => _dataModel.Counter;
            set
            {
                _dataModel.Counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public RightViewModel(DataModel dataModel)
        {
            _dataModel = dataModel;
            CountUpCommand = new RelayCommand(() => Counter++);
        }
    }
}
