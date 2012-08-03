namespace TodoWeb.Views
{
    // {"id":"0","todo":"","todos":[{"todo":"Kevin","isDone":true}]}:
    // {"id":"0","todo":"","todos":[{"todo":"Kevin","isDone":true}]}
    public class ToDoViewModel
    {
        public int id { get; set; }
        public string todo { get; set; }
        public TodoItem[] todos { get; set; }
    }

    public class TodoItem
    {
        public bool isDone { get; set; }
        public string todo { get; set; }
    }
}