using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class MBTableVM : BaseViewModel
    {
        private ApiService _api;
        public ObservableCollection<MB> MBs { get; set; } = new ObservableCollection<MB>();
        public ICommand AddMBCommand { get; }

        public MBTableVM()
        {
            _api = new ApiService();
            AddMBCommand = new Command(OnAddMB);
            //LoadMB();
        }

        private void OnAddMB()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddMBPage());
        }

        public async void LoadMB()
        {
            try
            {
                var mbs = await _api.GetAsync<List<MB>>("MB");
                foreach (var m in mbs)
                {
                    MBs.Add(m);
                }
            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("خطاء", "خطاء اثناء تحميل ال MB", "موافق");
            }
        }
    }
}
