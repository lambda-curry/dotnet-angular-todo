
using System;
using System.ComponentModel.DataAnnotations;

namespace todo
{
    public class UpdateTodoDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool done { get; set; }
    }

    public class CreateTodoDTO
    {

        [Required]
        public string title { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;

        public bool done { get; set; } = false;
    }
}