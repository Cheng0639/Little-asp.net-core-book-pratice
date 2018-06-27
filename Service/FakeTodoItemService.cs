using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using mvc.Models;

namespace mvc.Service
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync()
        {
            var result = new[]{
                new TodoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                },
            };

            return Task.FromResult(result.AsEnumerable());
        }
    }
}