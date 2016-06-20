using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUniversalAppProject.Model;

namespace WindowsUniversalAppProject
{
    static class TaskCollection
    {
        public static ObservableCollection<TaskModel> tasksCollection { get; set; }
    }
}
