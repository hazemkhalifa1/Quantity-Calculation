using QuantityCalculation.Models;
using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class ShowItemPage : ContentPage
{
    public ShowItemPage(Item _item)
    {
        InitializeComponent();
        BindingContext = new ShowItemVM(_item);
    }
}