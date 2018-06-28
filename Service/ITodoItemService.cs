using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mvc.Models;

namespace mvc.Service
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync();

        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}