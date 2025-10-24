using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using messenger.Assets.Pages.Classes;

namespace messenger.Assets.Pages.Settings
{
    public partial class EnergyPage : PhoneApplicationPage
    {
        public EnergyPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> settings = new List<SettingsItem>();
            settings.Add(new SettingsItem() { Name = "стикеры", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Destination = "StickersE", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "эмодзи", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Destination = "EmogiE", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "видео", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Destination = "VideoE", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "gif", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Destination = "GIFE", Description = "настроить исключения" });

            SettingsList.ItemsSource = settings;
        }

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            var Selected = SettingsList.SelectedItem as SettingsItem;
            if (Selected != null)
            {
                var Set = Selected.Destination;
                if (Set == "StickersE")
                Classes.Settings.StickersE = true;
            }
        }

        private void ToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}