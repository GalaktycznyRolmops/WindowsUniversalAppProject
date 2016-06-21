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
    public sealed partial class EditTaskPage : Page
    {
        App thisApp = Application.Current as App;
        public EditTaskPage()
        {
            this.InitializeComponent();
        }

        private async void SubmitChanges(object sender, RoutedEventArgs e)
        {
            WindowsUniversalAppProject.Model.TaskModel AfterEdit = new Model.TaskModel();

            DateTimeOffset time = DateTimeOffset.Now;
            string formattedDate = String.Format("{0:d/M/yyyy HH:mm:ss}", time);
            AfterEdit.Id = thisApp.selectedTask.Id;
            AfterEdit.OwnerId = thisApp.selectedTask.OwnerId;
            AfterEdit.CreatedAt = formattedDate;
            AfterEdit.Title = TitleBox.Text;
            AfterEdit.Value = DescBox.Text;

            string apiUrl = "http://windowsphoneuam.azurewebsites.net/api/todotasks" + "/" + AfterEdit.Id;
            string taskInJson = JsonConvert.SerializeObject(AfterEdit);

            var objClint = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage respon = await objClint.PutAsync(apiUrl, new StringContent(taskInJson, System.Text.Encoding.UTF8, "application/json"));
            string responJsonText = await respon.Content.ReadAsStringAsync();

            Window.Current.Content = new TaskList();
        }

        private void ReturnToList(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new TaskList();
        }
    }
}
