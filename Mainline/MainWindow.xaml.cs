﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Squirrel;

namespace Mainline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;

        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var updateManager = new UpdateManager(@"D:\Code\Mainline\Releases"))
            {
                CurrentVersion.Text = $"Current version: {updateManager.CurrentlyInstalledVersion()}";
                var releaseEntry = await updateManager.UpdateApp();
                NewVersion.Text = $"Update Version: {releaseEntry?.Version.ToString() ?? "No update"}";
            }
        }

        //private async void OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    using (var updateManager = await UpdateManager.GitHubUpdateManager("https://github.com/IUsername/Mainline"))
        //    {
        //        CurrentVersion.Text = $"Current version: {updateManager.CurrentlyInstalledVersion()}";
        //        var releaseEntry = await updateManager.UpdateApp();
        //        NewVersion.Text = $"Update Version: {releaseEntry?.Version.ToString() ?? "No update"}";
        //    }
        //}
    }
}
