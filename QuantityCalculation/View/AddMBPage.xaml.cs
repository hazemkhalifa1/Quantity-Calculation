using QuantityCalculation.ViewModel;
namespace QuantityCalculation.View;

public partial class AddMBPage : ContentPage
{
    public AddMBPage()
    {
        InitializeComponent();
        BindingContext = new AddMBVM();
    }
}