using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class ColorTableVM : BaseViewModel
    {
        private ApiService _api;
        public ObservableCollection<Models.Colors> Colors { get; set; } = new ObservableCollection<Models.Colors>();
        public ICommand AddColorCommand { get; }

        public ColorTableVM()
        {
            _api = new ApiService();
            AddColorCommand = new Command(OnAddColor);
            //LoadColors();
        }

        private void OnAddColor()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddColorPage());
        }

        public async void LoadColors()
        {
            try
            {
                var colors = await _api.GetAsync<List<Models.Colors>>("Color");
                foreach (var c in colors)
                {
                    Colors.Add(c);
                }
            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("خطاء", "خطاء اثناء تحميل الالوان", "موافق");
            }
        }
    }
}
