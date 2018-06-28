using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mvc.Models;

namespace mvc.Service
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync(ApplicationUser user);

        Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user);

        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}