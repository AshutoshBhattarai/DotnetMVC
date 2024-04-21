namespace MVC.Models
{
    public class AddTodoViewModel
    {
        public int id { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public DateTime dueDate { get; set; }

        public bool completed { get; set; }

        public List<TodoModel> todos { get; set; }
    }
}
