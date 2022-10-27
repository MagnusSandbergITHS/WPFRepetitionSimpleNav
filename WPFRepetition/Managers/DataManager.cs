using WPFRepetition.Models;

namespace WPFRepetition.Managers
{
    class DataManager
    {
        private DataModel _dataModel = new DataModel();

        public DataModel DataModel => _dataModel;
    }
}