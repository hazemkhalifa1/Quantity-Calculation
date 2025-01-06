using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class AddColorVM : BaseViewModel
    {
        private ApiService _api;

        private string name;

        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

        public ICommand AddColorCommand { get; }

        public AddColorVM()
        {
            _api = new ApiService();
            AddColorCommand = new Command(OnAddColor);
        }

        private async void OnAddColor()
        {
            var response = await _api.PostAsync<ApiResponse>("Color", new Models.Colors { Name = name });
            if (response.Success)
            {
                Application.Current.MainPage.DisplayAlert("ناجح", response.Message, "موافق");
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.Navigation.PushAsync(new ColorTablePage());
            }
            else
                Application.Current.MainPage.DisplayAlert("خطاء", response.Message, "موافق");
        }
    }
}
