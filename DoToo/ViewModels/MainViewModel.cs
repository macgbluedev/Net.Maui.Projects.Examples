﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoToo.Repositories.Contracts;
using DoToo.Views;
using System.Collections.ObjectModel;
using DoToo.Models;

namespace DoToo.ViewModels;
public partial class MainViewModel : ViewModel
{
    private readonly ITodoItemRepository repository;
    private readonly IServiceProvider services;

    [ObservableProperty]
    ObservableCollection<TodoItemViewModel> items;

    public MainViewModel(ITodoItemRepository repository, IServiceProvider services)
    {
        repository.OnItemAdded += (sender, item) => items.Add(CreateTodoItemViewModel(item));
        repository.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadDataAsync());

        this.repository = repository;
        this.services = services;
        Task.Run(LoadDataAsync);
    }

    private async Task LoadDataAsync()
    {
        var items = await repository.GetItemsAsync();
        var itemViewModels = items.Select(i => CreateTodoItemViewModel(i));
        Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);
    }

    private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
    {
        var itemViewModel = new TodoItemViewModel(item);

        itemViewModel.ItemStatusChanged += ItemStatusChanged;

        return itemViewModel;
    }
    private void ItemStatusChanged(object sender, EventArgs e)
    {
    }

    [RelayCommand]
    public async Task AddItemAsync()
        => await Navigation.PushAsync(services.GetRequiredService<ItemView>());

}