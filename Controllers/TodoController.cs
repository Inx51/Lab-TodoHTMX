using Microsoft.AspNetCore.Mvc;
using TodoHtmx.Models;

namespace TodoHtmx
{
    public class TodoController : Controller
    {
        private static int _maxId = 4;
        public List<TodoItem> Todos { get; set; } = new()
        {
            new()
            {
                Id = 1,
                Title = "Wakeup",
                Description = "Done sleeping.. wake up"
            },
            new()
            {
                Id = 2,
                Title = "Work",
                Description = "Is it any nice?"
            },
            new()
            {
                Id = 3,
                Title = "Eat",
                Description = "Yummy! food!"
            },
            new()
            {
                Id = 4,
                Title = "Die",
                Description = "Ah crap.. now that's just sad.."
            }
        };
        
        public IActionResult Index()
        {
            return View(Todos);
        }

        [HttpPost]
        public IActionResult AddItem([FromForm]string title, [FromForm]string description)
        {
            _maxId++;
            
            var todoItem = new TodoItem
            {
                Id = _maxId,
                Title = title,
                Description = description
            };
            
            return View(todoItem);
        }
        
        [HttpPost]
        [Route("DeleteItem/{id}")]
        public IActionResult DeleteItem([FromRoute]int id)
        {
            var item = Todos.FirstOrDefault(td => td.Id == id);
            Todos.Remove(item!);
            
            return Ok();
        }
    }
}
