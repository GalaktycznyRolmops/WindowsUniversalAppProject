using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsUniversalAppProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewTask : Page
    {
        private ApplicationDataContainer localSetting = Windows.Storage.ApplicationData.Current.LocalSettings;

        public AddNewTask()
        {
            this.InitializeComponent();
        }

        public int GenerateNewID()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, 6);
            return ticks;
        }

        private async void AddTask(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text != "" && DescBox.Text != "")
            {
                WindowsUniversalAppProject.Model.TaskModel newTask = new Model.TaskModel();

                DateTimeOffset time = DateTimeOffset.Now;
                string formattedDate = String.Format("{0:d/M/yyyy HH:mm:ss}", time);

                newTask.Id = GenerateNewID();
                newTask.Title = TitleBox.Text;
                newTask.Value = DescBox.Text;
                newTask.OwnerId = (String)localSetting.Values["userLogin"];
                newTask.CreatedAt = formattedDate;

                string apiUrl = "http://windowsphoneuam.azurewebsites.net/api/todotasks";
                string taskInJson = JsonConvert.SerializeObject(newTask);

                var objClint = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(apiUrl, new StringContent(taskInJson, System.Text.Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();
                Debug.Write(responJsonText);
                Window.Current.Content = new TaskList();
            }
        }

        private void ReturnToList(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new TaskList();
        }
    }
}
