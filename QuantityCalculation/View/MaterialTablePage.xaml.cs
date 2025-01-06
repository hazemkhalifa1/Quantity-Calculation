using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class MaterialTablePage : ContentPage
{
    public MaterialTablePage()
    {
        InitializeComponent();
        BindingContext = new MaterialTableVM();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = BindingContext as MaterialTableVM;
        if (viewModel != null && viewModel.Materials.Count == 0)
        {
            viewModel.LoadMaterial();
        }
    }

}