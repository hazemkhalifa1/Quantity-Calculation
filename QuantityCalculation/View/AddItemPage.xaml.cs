using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class AddItemPage : ContentPage
{
    public AddItemPage()
    {
        InitializeComponent();
        BindingContext = new AddItemVM();
    }
}