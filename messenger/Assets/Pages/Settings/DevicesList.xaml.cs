using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace messenger.Assets.Pages.Settings
{
    public partial class DevicesList : PhoneApplicationPage
    {
        public DevicesList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> thisdev = new List<SettingsItem>();
            thisdev.Add(new SettingsItem() { Name = "Windows Phone 8.1", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Description = "messenger client" });

            ThisList.ItemsSource = thisdev;

            List<SettingsItem> help = new List<SettingsItem>();
            help.Add(new SettingsItem() { Name = "iPhone 17 Ultra", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Description="Telegram client" });
            help.Add(new SettingsItem() { Name = "Android 16", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Description="Telegram client"});
            help.Add(new SettingsItem() { Name = "Windows 12", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Description = "Unigram client" });
            help.Add(new SettingsItem() { Name = "Linux Madness Machine", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Description = "Telegram client" });

            AllList.ItemsSource = help;

        }
    }
}