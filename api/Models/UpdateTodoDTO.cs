
namespace todo
{
    public class UpdateTodoDTO
    {
        public string name { get; set; }
        public bool done { get; set; }
    }

    public class CreateTodoDTO
    {
        public string name { get; set; }
    }
}