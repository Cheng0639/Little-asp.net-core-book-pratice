using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using mvc.Models;

namespace mvc.Service
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync(IdentityUser user);

        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user);

        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}