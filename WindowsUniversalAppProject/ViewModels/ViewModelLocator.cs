using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUniversalAppProject.ViewModels;

namespace WindowsUniversalAppsProject.ViewModels
{
    public class ViewModelLocator
    {
        public TaskViewModel MainViewModel { get; private set; }
        public ViewModelLocator()
        {
            MainViewModel = new TaskViewModel();
            Debug.Write("PRZECHODZI PRZEZ LOCATORA");
        }
    }
}
