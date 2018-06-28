using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace mvc.Service
{
    public class FakeTodoItemService : ITodoItemService
    {

        public Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}