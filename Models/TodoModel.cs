using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class TodoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id  { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public DateTime dueDate { get; set; }

        public Boolean completed { get; set; }
    }
}
