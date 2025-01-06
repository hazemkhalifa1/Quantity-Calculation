using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class ColorTablePage : ContentPage
{
    public ColorTablePage()
    {
        InitializeComponent();
        BindingContext = new ColorTableVM();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = BindingContext as ColorTableVM;
        if (viewModel != null && viewModel.Colors.Count == 0)
        {
            viewModel.LoadColors();
        }
    }

}