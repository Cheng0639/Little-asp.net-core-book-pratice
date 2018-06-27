using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Service;

namespace mvc.Controllers
{
    public class TodoController : Controller
    {
        public TodoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        private readonly ITodoItemService todoItemService;

        public async Task<IActionResult> Index()
        {
            var result = await todoItemService.GetInCompleteItemsAsync();

            var viewModel = new TodoViewModel
            {
                Items = result.ToArray()
            };

            return View(viewModel);
        }
    }
}