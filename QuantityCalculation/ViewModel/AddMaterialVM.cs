using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class AddMaterialVM : BaseViewModel
    {
        private ApiService _api;

        private string name;

        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

        public ICommand AddMaterialCommand { get; }

        public AddMaterialVM()
        {
            _api = new ApiService();
            AddMaterialCommand = new Command(OnAddMaterial);
        }

        private async void OnAddMaterial()
        {
            var response = await _api.PostAsync<ApiResponse>("Material", new Material { Name = name });
            if (response.Success)
            {
                Application.Current.MainPage.DisplayAlert("ناجح", response.Message, "موافق");
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.Navigation.PushAsync(new MaterialTablePage());
            }
            else
                Application.Current.MainPage.DisplayAlert("خطاء", response.Message, "موافق");
        }
    }
}
