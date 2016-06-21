using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsUniversalAppProject.Model;
using WindowsUniversalAppProject.ViewModels;
using WindowsUniversalAppsProject.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsUniversalAppProject.View
{

    public sealed partial class TaskList : Page
    {
        public ViewModelLocator ViewModelLocator = new ViewModelLocator();
        private ApplicationDataContainer localSetting = Windows.Storage.ApplicationData.Current.LocalSettings;
        private int selectedTask;

        public TaskList()
        {
            Object userName = localSetting.Values["userLogin"];

            this.InitializeComponent();
            DataContext = ViewModelLocator.MainViewModel;
            WhoIsLogged.Text = userName.ToString();
        }

        public TaskViewModel ViewModel
        {
            get
            {
                return DataContext as TaskViewModel;
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            localSetting.Values["userLogin"] = null;
            Window.Current.Content = new MainPage();
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new AddNewTask();
        }

        private async void DeleteTask(object sender, RoutedEventArgs e)
        {
            this.ViewModel.TasksCollection.RemoveAt(MainList.SelectedIndex);
            string apiUrl = "http://windowsphoneuam.azurewebsites.net/api/todotasks";
            var objClint = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage respon = await objClint.DeleteAsync(apiUrl + "/" + selectedTask);
            string responJsonText = await respon.Content.ReadAsStringAsync();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskModel select = (sender as ListBox).SelectedItem as TaskModel;
            if (select != null)
            {
                selectedTask = select.Id;
            }
        }
    }
}
