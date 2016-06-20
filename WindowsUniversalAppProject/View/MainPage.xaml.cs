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
using WindowsUniversalAppProject.View;
using WindowsUniversalAppProject.ViewModels;
using WindowsUniversalAppsProject.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsUniversalAppProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    { 
        

        public MainPage()
        {
            this.InitializeComponent();
            CheckIfLogged();
        }

        private ApplicationDataContainer localSetting = Windows.Storage.ApplicationData.Current.LocalSettings;
        public ViewModelLocator ViewModelLocator = new ViewModelLocator();

        private void CheckIfLogged()
        {
            Object userName = localSetting.Values["userLogin"];
            Debug.Write(userName);
            if (userName != null)
            {
                Window.Current.Content = new TaskList();
            }
        }

        private void GoToListScreen(object sender, RoutedEventArgs e)
        {
            Object userName = localSetting.Values["userLogin"];
            DataContext = ViewModelLocator.MainViewModel;
            if (userName == null)
            {
                if (LoginBox.Text != "Enter your username here")
                {
                    localSetting.Values["userLogin"] = LoginBox.Text;
                    Window.Current.Content = new TaskList();
                }
                else
                {
                    ErrorBox.Text = "Enter correct login";
                }

            }
        }

        private void GoToAboutPage(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new AboutPage();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

    }
}
