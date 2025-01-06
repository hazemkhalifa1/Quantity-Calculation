using QuantityCalculation.Models;
using QuantityCalculation.ViewModel;
namespace QuantityCalculation.View;

public partial class ItemTablePage : ContentPage
{
    public ItemTablePage()
    {
        InitializeComponent();
        BindingContext = new ItemTableVM();
    }
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Item selectedItem)
        {
            // الانتقال إلى صفحة تفاصيل العنصر
            await Navigation.PushAsync(new ShowItemPage(selectedItem));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = BindingContext as ItemTableVM;
        if (viewModel != null && viewModel.Items.Count == 0)
        {
            viewModel.LoadItems();
        }
    }
}