using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class MaterialTableVM : BaseViewModel
    {
        private ApiService _api;
        public ObservableCollection<Material> Materials { get; set; } = new ObservableCollection<Material>();
        public ICommand AddMaterialCommand { get; }

        public MaterialTableVM()
        {
            _api = new ApiService();
            AddMaterialCommand = new Command(OnAddMaterial);
            //LoadMaterial();
        }
        private void OnAddMaterial()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddMaterialPage());
        }

        public async void LoadMaterial()
        {
            try
            {
                var materials = await _api.GetAsync<List<Material>>("Material");
                foreach (var m in materials)
                {
                    Materials.Add(m);
                }
            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("خطاء", "خطاء اثناء تحميل الخامات", "موافق");
            }
        }
    }
}
