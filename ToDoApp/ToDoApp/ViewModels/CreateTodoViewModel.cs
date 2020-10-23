using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.Views
{
    public class CreateTodoViewModel : ContentPage
    {
        public CreateTodoViewModel()
        {
            Title = "Todo Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var descriptionEntry = new Entry();
            descriptionEntry.SetBinding(Entry.TextProperty, "Description");

            var statusEntry = new Entry();
            statusEntry.SetBinding(Entry.TextProperty, "Status");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var todoItem = (TodoModel)BindingContext;
                await App.Database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var todoItem = (TodoModel)BindingContext;
                await App.Database.DeleteItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Название" },
                    nameEntry,
                    new Label { Text = "Описание" },
                    descriptionEntry,
                    new Label { Text = "Статус" },
                    statusEntry,
                    saveButton,
                    deleteButton
                }
            };
        }
    }
}