using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUniversalAppProject.Model;


namespace WindowsUniversalAppProject.ViewModel
{
    class TaskViewModel
    {
        public ObservableCollection<TaskModel> tasksCollection { get; set; }


        public string GenerateNewID()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void GetDefaultAccomplishments()
        {
            ObservableCollection<TaskModel> a = new ObservableCollection<TaskModel>();

            a.Add(new TaskModel("asdfghjk", "clean", "like everything", "1", "date here"));
            a.Add(new TaskModel("asdf23fw", "example title", "dunno", "1", "date here"));
            a.Add(new TaskModel("qwertyuu", "title", "whatever", "1", "date here"));

            tasksCollection = a;
        }






    }
}
