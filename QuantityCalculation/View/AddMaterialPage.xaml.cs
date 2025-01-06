using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class AddMaterialPage : ContentPage
{
    public AddMaterialPage()
    {
        InitializeComponent();
        BindingContext = new AddMaterialVM();
    }
}