using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class AddColorPage : ContentPage
{
    public AddColorPage()
    {
        InitializeComponent();
        BindingContext = new AddColorVM();
    }
}