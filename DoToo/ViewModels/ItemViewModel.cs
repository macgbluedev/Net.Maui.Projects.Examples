using CommunityToolkit.Mvvm.ComponentModel;
using DoToo.Repositories;
using DoToo.Models;

using DoToo.Repositories.Contracts;
using CommunityToolkit.Mvvm.Input;

namespace DoToo.ViewModels;

public partial class ItemViewModel : ViewModel
{
    private readonly ITodoItemRepository repository;
    
    [ObservableProperty]
    TodoItem item;

    public ItemViewModel(ITodoItemRepository repository)
    {
        this.repository = repository;
        item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        await repository.AddOrUpdateAsync(item);
        await Navigation.PopAsync();
    }
}
