﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.Models;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class TodoListPage : ContentPage
    {
        ListView listView;
        public TodoListPage()
        {
            Title = "Todo";
            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                IconImageSource = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };

            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new CreateTodoViewModel
                {
                    BindingContext = new TodoModel()
                });
            };
            ToolbarItems.Add(toolbarItem);


            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    var status = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };

                    label.SetBinding(Label.TextProperty, "Name");
                    status.SetBinding(Label.TextProperty, "Status");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, status }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };

            listView.ItemSelected += async (sender, e) =>
            {

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new CreateTodoViewModel
                    {
                        BindingContext = e.SelectedItem as TodoModel
                    });
                }
            };
            Content = listView;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}