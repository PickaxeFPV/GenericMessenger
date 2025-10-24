using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using messenger.Resources;

namespace messenger.Assets.Pages
{
    public class MessageContentPresenter : ContentControl
    {
        /// <summary>
        /// The DataTemplate to use when the message comes from the current user
        /// </summary>
        public DataTemplate MeTemplate { get; set; }

        /// <summary>
        /// The opposite of MeTemplate
        /// </summary>
        public DataTemplate YouTemplate { get; set; }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (MeTemplate != null)
                ContentTemplate = (newContent as UserMessage).IsFromSelf ? MeTemplate : YouTemplate;
        }
    }

    public partial class ChatsPage : PhoneApplicationPage
    {
        public ChatsPage()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PaddingRectangle.Visibility = Visibility.Visible;
            PaddingRectangleShowAnim.Begin();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PaddingRectangle.Visibility = Visibility.Collapsed;
            PaddingRectangleHideAnim.Begin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string userName;
            string OnlineState;

            if (NavigationContext.QueryString.TryGetValue("name", out userName))
            {
                chatTitle.Text = userName;
            }
            if (NavigationContext.QueryString.TryGetValue("isOnline", out OnlineState))
            {
                if (OnlineState == "True")
                {
                    Online.Text = "в сети";
                }
                else
                {
                    Online.Text = "не в сети";
                }
            }
        }

        private void SendMenuItem_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "")
            {
                ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                btn.IsEnabled = false;
                ((this.Resources["MessagesPresenter"] as MessageContentPresenter).Content as MessageCollection).Add(
                    new UserMessage()
                    {
                        Text = messageBox.Text,
                        TimeStamp = DateTime.Now,
                        IsFromSelf = true
                    }
                );
                ConversationScrollViewer.Focus();
                messageBox.Text = "";

            }
        }
        private void messageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn != null)
                btn.IsEnabled = (messageBox != null) && (messageBox.Text != "");

        }

        private void Grid_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Static context menu
            var contextMenu = new ContextMenu()
            {
                DataContext = (sender as Grid).DataContext,
                IsOpen = true,
                VerticalOffset = e.GetPosition(sender as Grid).Y + 20.0 // FIXME
            };

            var shareBtn = new MenuItem()
            {
                Header = "поделиться"
            };
            contextMenu.Items.Add(shareBtn);

            var deleteBtn = new MenuItem()
            {
                Header = "удалить"
            };
            deleteBtn.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteBtn);

            var copyBtn = new MenuItem()
            {
                Header = "копировать"
            };
            copyBtn.Click += CopyBtn_Click;
            contextMenu.Items.Add(copyBtn);
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(
                (((sender as MenuItem).Parent as ContextMenu).DataContext as UserMessage).Text
            );
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ((this.Resources["MessagesPresenter"] as MessageContentPresenter).Content as MessageCollection).Remove(
                ((sender as MenuItem).Parent as ContextMenu).DataContext as UserMessage
            );
        }

        private void DebugMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("пользователь онлайн? " + Online.Text, "кнопка отображения неотображаемой информации", MessageBoxButton.OK);
        }

        private void Exception_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программист ещё не создал виджет, который должен использоваться здесь.", "Кнопка не назначена", MessageBoxButton.OK);
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программист ещё не создал страницу на данную кнопку.", "Кнопка не назначена", MessageBoxButton.OK);
        }
    }
}