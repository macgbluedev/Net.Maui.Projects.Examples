using DoToo.Repositories.Contracts;

namespace DoToo.ViewModels;
public class MainViewModel : ViewModel
{
    private readonly ITodoItemRepository repository;
    public MainViewModel(ITodoItemRepository repository)
    {
        this.repository = repository;
        Task.Run(LoadDataAsync);
    }
    private async Task LoadDataAsync()
    {
    }
}
