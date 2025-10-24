using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using messenger.Resources;

namespace messenger
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> settings = new List<SettingsItem>();
            settings.Add(new SettingsItem() { Name = "Название параметра 1", ImageUri = "/Assets/Icons/chats.png", Destination = "Placeholder", Description="Описание параметра 1"});
            settings.Add(new SettingsItem() { Name = "Название параметра 2", ImageUri = "/Assets/Icons/chats.png", Destination = "Placeholder", Description = "Описание параметра 2" });
            settings.Add(new SettingsItem() { Name = "Название параметра 3", ImageUri = "/Assets/Icons/chats.png", Destination = "Placeholder", Description = "Описание параметра 3" });
            settings.Add(new SettingsItem() { Name = "Название параметра 4", ImageUri = "/Assets/Icons/chats.png", Destination = "Placeholder", Description = "Описание параметра 4" });
            settings.Add(new SettingsItem() { Name = "Название параметра 5", ImageUri = "/Assets/Icons/chats.png", Destination = "Placeholder", Description = "Описание параметра 5" });

            SettingsList.ItemsSource = settings;

            List<SettingsItem> help = new List<SettingsItem>();
            help.Add(new SettingsItem() { Name = "о клиенте", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", Destination = "AboutPage" });

            HelpList.ItemsSource = help;

        }

        private void SettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (SettingsList.SelectedItem == null)
                return;

            // Get the selected item
            SettingsItem selectedItem = SettingsList.SelectedItem as SettingsItem;

            // Navigate to the next page using the 'dest' property
            NavigationService.Navigate(new Uri("/Assets/Pages/Settings/" + selectedItem.Destination + ".xaml", UriKind.Relative));

            // Reset selected item to null
            SettingsList.SelectedItem = null;
        }

        private void ChangeNumber_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программист ещё не назначил действие на данную кнопку.", "Кнопка не назначена", MessageBoxButton.OK);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                    "Клиент отключится от сервера.",
                    "ВНИМАНИЕ",
                    MessageBoxButton.OKCancel
                ) == MessageBoxResult.OK)
            {
                // do the account delete

                // *logs out*
                Assets.Pages.Classes.Settings.IsSetupPass = false;
            }
        }
    }
}