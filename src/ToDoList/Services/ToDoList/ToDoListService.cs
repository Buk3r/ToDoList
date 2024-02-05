using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services.ToDoList
{
    public class ToDoListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem { Description = "Buy milk", },
            new ToDoItem { Description = "Do homework", IsChecked = true, },
            new ToDoItem { Description = "Watch stream", },
        };
    }
}
