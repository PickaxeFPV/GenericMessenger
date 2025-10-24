using messenger.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace messenger
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!Assets.Pages.Classes.Settings.IsSetupPass)
            {
                NavigationService.Navigate(new Uri("/Assets/Pages/SetupProject.xaml", UriKind.Relative));
            }

            List<ChatItem> All = new List<ChatItem>();
            All.Add(new ChatItem() { Name = "Машина",
                ImageUri = "/Assets/temp/изображениеПрофиля1.jpg",
                LastMessage = "Проверка интерфейса",
                isRead =false,
                isGroup =false,
                isOnline =false });
            All.Add(new ChatItem() { Name = "Крест", ImageUri = "/Assets/temp/ApplicationBar.Cancel.png", LastMessage = "Съешь ещё этих мягких французких булок, да выпей чаю", isRead=false, isGroup=true });
            All.Add(new ChatItem() { Name = "Пользователь, который определённо существует", ImageUri = "/Assets/temp/defaultuser.png", LastMessage = "The quick brown fox jumps over the lazy dog", isRead=true, isGroup=false, isOnline=true});
            All.Add(new ChatItem() { Name = "Телефон", ImageUri = "/Assets/temp/tesno.png", LastMessage = "Проверка интерфейса 2", isRead=false, isGroup=false, isOnline=true });

            AllList.ItemsSource = All;

            Messages.Text = Enumerable.Range(0, AllList.ItemsSource.Count)
                                    .Where(i => (AllList.ItemsSource[i] as ChatItem).isRead == false)
                                    .Count().ToString();

            List<ChatItem> Private = new List<ChatItem>();
            Private.Add(new ChatItem() { Name = "Машина", ImageUri = "/Assets/temp/изображениеПрофиля1.jpg", LastMessage = "Проверка интерфейса" });
            Private.Add(new ChatItem() { Name = "Пользователь, который определённо существует", ImageUri = "/Assets/temp/tesno.png", LastMessage = "Проверка интерфейса 2" });

            PrivateList.ItemsSource = Private;
        }
        #region Actions
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri ("/Assets/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void AllList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChatItem myItem = ((LongListSelector)sender).SelectedItem as ChatItem;
            if (myItem.isGroup == true)
            {
                NavigationService.Navigate(new Uri("/Assets/Pages/GroupChatsPage.xaml?name=" + myItem.Name, UriKind.RelativeOrAbsolute));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Assets/Pages/ChatsPage.xaml?name=" + myItem.Name + "&isOnline=" + myItem.isOnline, UriKind.RelativeOrAbsolute));
            };
        }

        private void Change_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программист ещё не создал страницу на данную кнопку.", "Кнопка не назначена", MessageBoxButton.OK);
        }
        private void Change1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На данную кнопку назначается прямая ссылка на переписку с самим собой. Если в Вашем мессенджере нет данной возможности, можете спокойно удалять данную кнопку.", "Внимание", MessageBoxButton.OK);
        }
        #endregion

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}