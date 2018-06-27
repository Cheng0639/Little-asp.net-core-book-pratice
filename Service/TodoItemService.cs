using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Service
{
    public class TodoItemService : ITodoItemService
    {
        public TodoItemService(ApplicationDbContext context)
        {
            this.context = context;
        }

        private readonly ApplicationDbContext context;

        public async Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync()
        {
            return await context.Items
                .Where(todo => !todo.IsDone)
                .ToListAsync();
        }
    }
}