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
    public partial class NotificationPage : PhoneApplicationPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> settings = new List<SettingsItem>();
            settings.Add(new SettingsItem() { Name = "личные", ImageUri = "/Assets/Icons/PrivateNoty.png", Destination = "PrivatePage", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "группы", ImageUri = "/Assets/Icons/GroupNoty.png", Destination = "GroupPage", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "каналы", ImageUri = "/Assets/Icons/ChannelNoty.png", Destination = "ChannelsPage", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "истории", ImageUri = "/Assets/Icons/StoryNoty.png", Destination = "StoriesPage", Description = "настроить исключения" });
            settings.Add(new SettingsItem() { Name = "реакции", ImageUri = "/Assets/Icons/ReactsNoty.png", Destination = "ReactsPage", Description = "сообщения+истории" });

            NotifyList.ItemsSource = settings;

            List<SettingsItem> notifications = new List<SettingsItem>();
            notifications.Add(new SettingsItem() { Name = "вибросигнал", Destination = "PrivatePage", Description = "по умолчанию" });
            notifications.Add(new SettingsItem() { Name = "рингтон", Destination = "GroupPage", Description = "по умолчанию" });

            CallsList.ItemsSource = notifications;

            List<SettingsItem> inapp = new List<SettingsItem>();
            inapp.Add(new SettingsItem() { Name = "звук"});
            inapp.Add(new SettingsItem() { Name = "вибросигнал"});
            inapp.Add(new SettingsItem() { Name = "показывать текст"});
            inapp.Add(new SettingsItem() { Name = "звук в чате"});
            inapp.Add(new SettingsItem() { Name = "всплывающие окна", Description = "показывать всплывающие окна, когда приложение открыто" });

            InAppList.ItemsSource = inapp;

            List<SettingsItem> events = new List<SettingsItem>();
            events.Add(new SettingsItem() { Name = "контакт присоединился к telegram"});
            events.Add(new SettingsItem() { Name = "закреплённые сообщения"});

            EventsList.ItemsSource = events;

            List<SettingsItem> wipe = new List<SettingsItem>();
            wipe.Add(new SettingsItem() { Name = "сбросить настройки уведомлений", Destination = "PrivatePage", Description="сбросить все особые настройки уведомлений для отдельных контактов, групп и каналов" });

            WipeList.ItemsSource = wipe;

        }
    }
}