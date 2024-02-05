using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using ToDoList.ViewModels;

namespace ToDoList
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            var name = param.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = $"Not fount {name}", };
            }
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
