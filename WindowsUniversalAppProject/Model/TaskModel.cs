using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUniversalAppProject.Model
{
    public class TaskModel
    {
 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; }
        public string CreatedAt { get; set; }

        public TaskModel() { }

        public TaskModel(int id, string title, string value, string ownerId, string createdAt)
        {
            this.Id = id;
            this.Title = title;
            this.Value = value;
            this.OwnerId = ownerId;
            this.CreatedAt = createdAt;
        }

    }
}
