using System;
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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var addItemReseult = await todoItemService.AddItemAsync(newItem);

            if (!addItemReseult)
            {
                return BadRequest("Could not add item");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var sucessful = await todoItemService.MarkDoneAsync(Id);

            if (sucessful)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest("Could not mark item as done");
            }
        }
    }
}