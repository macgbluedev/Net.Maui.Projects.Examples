using DoToo.ViewModels;

namespace DoToo.Views;

public partial class ItemView : ContentPage
{
	public ItemView(ItemViewModel itemViewModel)
	{
        InitializeComponent();
        itemViewModel.Navigation = Navigation;
		BindingContext = itemViewModel;
	}
}