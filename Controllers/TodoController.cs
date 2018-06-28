using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Service;

namespace mvc.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
        {
            this.todoItemService = todoItemService;
            this.userManager = userManager;
        }

        private readonly ITodoItemService todoItemService;
        private readonly UserManager<IdentityUser> userManager;

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var result = await todoItemService.GetInCompleteItemsAsync(currentUser);
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

            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var addItemReseult = await todoItemService.AddItemAsync(newItem, currentUser);

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

            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var sucessful = await todoItemService.MarkDoneAsync(Id, currentUser);

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