using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUniversalAppProject.Model
{
    public class TaskModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; }
        public string CreatedAt { get; set; }

        public TaskModel(string Id, string Title, string Value, string OwnerId, string CreatedAt)
        {
            this.Id = Id;
            this.Title = Title;
            this.Value = Value;
            this.OwnerId = OwnerId;
            this.CreatedAt = CreatedAt;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
