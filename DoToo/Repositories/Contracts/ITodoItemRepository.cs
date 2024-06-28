﻿using DoToo.Models;
namespace DoToo.Repositories.Contracts;

public interface ITodoItemRepository
{
    event EventHandler<TodoItem> OnItemAdded;
    event EventHandler<TodoItem> OnItemUpdated;
    Task<List<TodoItem>> GetItemsAsync();
    Task AddItemAsync(TodoItem item);
    Task UpdateItemAsync(TodoItem item);
    Task AddOrUpdateAsync(TodoItem item);
}
