
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
        public string title { get; set; }
    }
}