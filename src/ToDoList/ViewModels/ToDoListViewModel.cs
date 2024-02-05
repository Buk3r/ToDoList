using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ToDoListViewModel(IEnumerable<ToDoItem> toDoItems)
        {
            ToDoItems = new ObservableCollection<ToDoItem>(toDoItems);
        }

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }   
    }
}
