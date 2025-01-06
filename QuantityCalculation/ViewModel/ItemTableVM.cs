using QuantityCalculation.Models;
using QuantityCalculation.Service;
using QuantityCalculation.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuantityCalculation.ViewModel
{
    public class ItemTableVM : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ICommand AddItemCommand { get; }

        private readonly ApiService _api;

        public ItemTableVM()
        {
            _api = new ApiService();
            AddItemCommand = new Command(OnAddItem);
            Items = new ObservableCollection<Item>();
            //LoadItems();
        }

        private async void OnAddItem()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddItemPage());
        }

        public async void LoadItems()
        {
            var result = await _api.GetAsync<List<Item>>("Item");
            foreach (var item in result)
            {
                Items.Add(item);
            }
        }
    }

}
