using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext dbContext;
        public TodoController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            AddTodoViewModel todoList = new AddTodoViewModel();

            todoList.todos = dbContext.TodoItems.Select(x => x).ToList();

            return View(todoList);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(AddTodoViewModel todo)
        {
            var newTodo = new TodoModel()
            {

                title = todo.title,
                description = todo.description,
                dueDate = todo.dueDate == null ? DateTime.Now : todo.dueDate,
                completed = false,
            };


            await dbContext.TodoItems.AddAsync(newTodo);
            await dbContext.SaveChangesAsync();


            return RedirectToAction("Index", "Todo");
        }

        public async Task<IActionResult> Edit(int id)
        {


            var todos = await dbContext.TodoItems.Where(x => x.id == id).
                Select(x => new AddTodoViewModel
                {
                    title = x.title,
                    description = x.description,
                    dueDate = x.dueDate == null ? DateTime.Now : x.dueDate,
                    completed = x.completed
                }).FirstOrDefaultAsync();

            return View(todos);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddTodoViewModel newTodo)
        {

            Console.WriteLine("New Completed" + newTodo.completed);
            var currentTodo = dbContext.TodoItems.FirstOrDefault(x => x.id == newTodo.id);

            Console.WriteLine("Olde completed " + currentTodo.completed);

            dbContext.Entry(currentTodo).CurrentValues.SetValues(newTodo);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Todo");

        }

        public IActionResult Delete(int id)
        {

            var todo = dbContext.TodoItems.FirstOrDefault(x => x.id == id);
            dbContext.TodoItems.Remove(todo);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Todo");
        }
    }
}
