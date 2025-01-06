using QuantityCalculation.ViewModel;

namespace QuantityCalculation.View;

public partial class MBTablePage : ContentPage
{
    public MBTablePage()
    {
        InitializeComponent();
        BindingContext = new MBTableVM();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = BindingContext as MBTableVM;
        if (viewModel != null && viewModel.MBs.Count == 0)
        {
            viewModel.LoadMB();
        }
    }
}