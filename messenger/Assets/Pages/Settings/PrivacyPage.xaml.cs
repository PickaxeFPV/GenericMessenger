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
    public partial class PrivacyPage : PhoneApplicationPage
    {
        public PrivacyPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> secure = new List<SettingsItem>();
            secure.Add(new SettingsItem() { Name = "облачный пароль", Destination = "PrivatePage", Description = "выключен" });
            secure.Add(new SettingsItem() { Name = "автоудаление сообщений", Destination = "GroupPage", Description = "выключено" });
            secure.Add(new SettingsItem() { Name = "почта для входа", Destination = "ChannelsPage", Description = "@gmail.com" });
            secure.Add(new SettingsItem() { Name = "чёрный список", Destination = "StoriesPage", Description = "???" });
            secure.Add(new SettingsItem() { Name = "устройства", Destination = "DevicesList", Description = "5", Description1 = "посмотреть список устройств, на которых Ваш аккаунт авторизован в приложении Telegram." });

            SecurityList.ItemsSource = secure;

            List<SettingsItem> privacy = new List<SettingsItem>();
            privacy.Add(new SettingsItem() { Name = "номер телефона", Destination = "NumberPage", Description = "контакты" });
            privacy.Add(new SettingsItem() { Name = "время захода", Destination = "EntrancePage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "фотографии профиля", Destination = "PhotoPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "пересылка сообщений", Destination = "RepostPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "звонки", Destination = "CallsPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "голосовые сообщения", Destination = "VoicePage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "сообщения", Destination = "MessagesPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "дата рождения", Destination = "BirthdayPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "о себе", Destination = "AboutPage", Description = "все" });
            privacy.Add(new SettingsItem() { Name = "приглашения", Destination = "InvitePage", Description = "все", Description1 = "Вы можете выбрать, кому разрешаете приглашать Вас в группы и каналы." });

            PrivacyList.ItemsSource = privacy;

            List<SettingsItem> delete = new List<SettingsItem>();
            delete.Add(new SettingsItem() { Name = "если я не захожу", Description = "18 месяцев", Description1 = "Если вы ни разу не заглянете в Telegram за это время, аккаунт будет удалён со всеми сообщениями и контактами." });

            DeleteList.ItemsSource = delete;

            List<SettingsItem> bots = new List<SettingsItem>();
            bots.Add(new SettingsItem() { Name = "удалить данные о платежах и доставке" });
            bots.Add(new SettingsItem() { Name = "авторизованные сайты", Description = "сайты, где Вы авторизовались через Telegram" });

            BotsList.ItemsSource = bots;

            List<SettingsItem> contacts = new List<SettingsItem>();
            contacts.Add(new SettingsItem() { Name = "синхронизировать" });
            contacts.Add(new SettingsItem() { Name = "подсказка людей при поиске", Description = "показывать людей, которым Вы часто пишете, вверху в разделе поиска." });

            ContactsList.ItemsSource = contacts;

        }

        private void SecurityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (SecurityList.SelectedItem == null)
                return;

            // Get the selected item
            SettingsItem selectedItem = SecurityList.SelectedItem as SettingsItem;

            // Navigate to the next page using the 'dest' property
            switch (selectedItem.Destination)
            {
                case "DevicesList":
                    NavigationService.Navigate(new Uri("/Assets/Pages/Settings/DevicesList.xaml", UriKind.Relative));
                    break;

                default:
                    MessageBox.Show("хоть унажимайся", "не заработает", MessageBoxButton.OK);
                    break;
            }

            // Reset selected item to null
            SecurityList.SelectedItem = null;
        }

        private void PrivacyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (PrivacyList.SelectedItem == null)
                return;

            // Get the selected item
            SettingsItem selectedItem = PrivacyList.SelectedItem as SettingsItem;

            // Navigate to the next page using the 'dest' property
            MessageBox.Show("не ищи секреты", "не заработает", MessageBoxButton.OK);

            // Reset selected item to null
            PrivacyList.SelectedItem = null;
        }
    }
}