using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateTodo());
        }

        private async void OnListButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTodo());
        }
    }
}
