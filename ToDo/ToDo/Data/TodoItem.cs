namespace ToDo.Data
{
    public class TodoItem
    {
        public TodoItem(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public bool IsComplete { get; set; } = false;
    }