using DoToo.Repositories;
using DoToo.Repositories.Contracts;

namespace DoToo.ViewModels;

public class ItemViewModel : ViewModel
{
    private readonly ITodoItemRepository repository;
    public ItemViewModel(ITodoItemRepository repository) 
        => this.repository = repository;
}
