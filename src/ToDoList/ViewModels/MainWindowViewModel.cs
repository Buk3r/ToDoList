using ReactiveUI;
using System;
using System.Reactive.Linq;
using ToDoList.Models;
using ToDoList.Services.ToDoList;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        public MainWindowViewModel()
        {
            var service = new ToDoListService();
            ToDoListViewModel = new ToDoListViewModel(service.GetItems());
            _contentViewModel = ToDoListViewModel;
        }

        public ToDoListViewModel ToDoListViewModel { get; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        ToDoListViewModel.ToDoItems.Add(newItem);
                    }

                    ContentViewModel = ToDoListViewModel;
                });

            ContentViewModel = addItemViewModel;
        }

    }
}
