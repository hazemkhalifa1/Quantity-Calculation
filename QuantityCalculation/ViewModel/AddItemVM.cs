using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class AddItemVM : BaseViewModel
    {
        private ApiService _api;
        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private Material selectedMaterial;

        public Material SelectedMaterial
        {
            get => selectedMaterial;
            set => SetProperty(ref selectedMaterial, value);
        }

        private Models.Colors selectedMaterialColor;

        public Models.Colors SelectedMaterialColor
        {
            get => selectedMaterialColor;
            set => SetProperty(ref selectedMaterialColor, value);
        }

        private double materialWeight;

        public double MaterialWeight
        {
            get => materialWeight;
            set => SetProperty(ref materialWeight, value);
        }

        private MB selectedMB;

        public MB SelectedMB
        {
            get => selectedMB;
            set => SetProperty(ref selectedMB, value);
        }

        private Models.Colors selectedMBColor;

        public Models.Colors SelectedMBColor
        {
            get => selectedMBColor;
            set => SetProperty(ref selectedMBColor, value);
        }

        private double mBWeight;

        public double MBWeight
        {
            get => mBWeight;
            set => SetProperty(ref mBWeight, value);
        }


        public ObservableCollection<MB> MBs { get; set; } = new ObservableCollection<MB>();
        public ObservableCollection<Material> Materials { get; set; } = new ObservableCollection<Material>();
        public ObservableCollection<Models.Colors> Colors { get; set; } = new ObservableCollection<Models.Colors>();
        public ObservableCollection<ItemComponent> ItemComponents { get; set; } = new ObservableCollection<ItemComponent>();
        public ICommand AddComponentCommand { get; set; }
        public ICommand SubmetCommand { get; set; }

        public AddItemVM()
        {
            _api = new ApiService();
            LoadMaterial();
            LoadColors();
            LoadMB();
            AddComponentCommand = new Command(OnAddComponent);
            SubmetCommand = new Command(OnSubmet);

        }

        private void OnAddComponent()
        {
            ItemComponents.Add(new ItemComponent { Name = String.Concat(SelectedMaterial.Name, " ", SelectedMaterialColor.Name), Weight = MaterialWeight });
            ItemComponents.Add(new ItemComponent { Name = String.Concat(SelectedMB.Name, " ", SelectedMBColor.Name), Weight = ((MBWeight / 100) * MaterialWeight) });
        }

        private async void OnSubmet()
        {
            if (ItemComponents is not null)
            {

                var TotalComponent = ItemComponents.GroupBy(c => c.Name).Select(g => new ItemComponent
                {
                    Name = g.Key,
                    Weight = g.Sum(c => c.Weight)
                }).ToList();
                var item = new Item { Name = Name, Components = TotalComponent };
                var respons = await _api.PostAsync<ApiResponse>("Item", item);
                if (respons.Success)
                {
                    Application.Current.MainPage.DisplayAlert("ناجح", respons.Message, "موافق");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new ItemTablePage());

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("خطاء", respons.Message, "موافق");
                }
            }
            Application.Current.MainPage.DisplayAlert("خطاء", "ادخل المكونات اولا", "موافق");

        }

        private async void LoadMB()
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

        private async void LoadColors()
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

        private async void LoadMaterial()
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
