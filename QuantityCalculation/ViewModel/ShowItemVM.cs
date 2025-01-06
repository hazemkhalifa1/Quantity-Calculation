using QuantityCalculation.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class ShowItemVM : BaseViewModel
    {
        private string inputValue;
        public ObservableCollection<ItemComponent> Materials { get; set; } = new ObservableCollection<ItemComponent>();

        public string InputValue
        {
            get => inputValue;
            set => SetProperty(ref inputValue, value);
        }
        public ICommand ShowDetalis { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Item CurrentItem { get; set; }
        public ShowItemVM()
        {

        }
        public ShowItemVM(Item item) : base()
        {
            CurrentItem = item;
            ShowDetalis = new Command(OnShowDetalis);
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            Materials.Clear();
            foreach (var m in CurrentItem.Components)
            {
                m.Weight /= 1000;
                Materials.Add(m);
            }
        }

        private void OnShowDetalis()
        {
            Materials.Clear();
            double x = 0;
            if (Double.TryParse(inputValue, out x))
            {
                foreach (var m in CurrentItem.Components)
                {
                    ItemComponent material = new ItemComponent
                    {
                        Name = m.Name,
                        Weight = (m.Weight * x) / 1000,
                        Id = m.Id
                    };
                    Materials.Add(material);
                }
            }
            else
                Application.Current.MainPage.DisplayAlert("خطأ", "من فضلك أدخل قيمة صحيحة", "موافق");
        }
    }
}
