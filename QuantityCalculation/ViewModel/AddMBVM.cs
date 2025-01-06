using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class AddMBVM : BaseViewModel
    {
        private ApiService _api;

        private string name;

        public string Name
        {
            get => name;
            set { SetProperty(ref name, value); }
        }

        public ICommand AddMBCommand { get; }

        public AddMBVM()
        {
            _api = new ApiService();
            AddMBCommand = new Command(OnAddMB);
        }

        private async void OnAddMB()
        {
            var response = await _api.PostAsync<ApiResponse>("MB", new MB { Name = name });
            if (response.Success)
            {
                Application.Current.MainPage.DisplayAlert("ناجح", response.Message, "موافق");
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.Navigation.PushAsync(new MBTablePage());
            }
            else
                Application.Current.MainPage.DisplayAlert("خطاء", response.Message, "موافق");
        }
    }
}
