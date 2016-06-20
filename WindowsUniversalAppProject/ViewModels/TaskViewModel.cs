using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUniversalAppProject.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using Windows.Storage;
using WindowsUniversalAppProject.ViewModels;
using System.Diagnostics;
using System.Net.Http;

namespace WindowsUniversalAppProject.ViewModels
{
    public class TaskViewModel : ViewModel
    {
        public TaskViewModel()
        {
            DownloadTasksFromRest();
        }

        private ApplicationDataContainer localSetting = Windows.Storage.ApplicationData.Current.LocalSettings;

        public string GenerateNewID()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private ObservableCollection<TaskModel> tasksCollection;
        public ObservableCollection<TaskModel> TasksCollection
        {
            get { return tasksCollection; }
            set {
                tasksCollection = value;
                NotifyPropertyChanged();
            }
        }

        public async void DownloadTasksFromRest()
        {
            tasksCollection = new ObservableCollection<TaskModel>();
            tasksCollection.Clear();
            string apiUrl = "http://windowsphoneuam.azurewebsites.net/api/todotasks?OwnerId=" + localSetting.Values["userLogin"];
            HttpClient client = new HttpClient();
            string jsonString = await client.GetStringAsync(new Uri(apiUrl));
            List<TaskModel> tasks = JsonConvert.DeserializeObject<List<TaskModel>>(jsonString);

            foreach (TaskModel task in tasks)
            {
                tasksCollection.Add(task);
            }
        }




    }
}
