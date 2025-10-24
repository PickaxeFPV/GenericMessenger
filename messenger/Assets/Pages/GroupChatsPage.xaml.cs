using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace messenger.Assets.Pages
{

    public partial class GroupChatsPage : PhoneApplicationPage
    {
        public GroupChatsPage()
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

            if (NavigationContext.QueryString.TryGetValue("name", out userName))
            {
                chatTitle.Text = userName;
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
    }
}