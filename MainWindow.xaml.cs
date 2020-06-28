using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Navigation;


namespace HonorBuddyLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) e.Source;
            try
            {
                switch (btn.Uid)
                {
                    case "0":
                        Process.Start(Environment.CurrentDirectory + "\\Auth\\HBCD_Auth.exe");
                        break;
                    case "1":
                        Process.Start(Environment.CurrentDirectory + "\\HBRelog\\HBRelog.exe");
                        break;
                    case "2":
                        Process.Start(Environment.CurrentDirectory + "\\Honorbuddy.exe");
                        break;
                    case "3":
                        MessageBoxResult mbr = MessageBox.Show(
                            "Copy this text?:\n 127.0.0.1 auth3.buddyauth.com \n 127.0.0.1 auth2.buddyauth.com \n 127.0.0.1 www.buddyauth.com",
                            "Hosts File", MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.OK);
                        
                        if (mbr == MessageBoxResult.Yes)
                        {
                            Clipboard.SetText("127.0.0.1 auth3.buddyauth.com 127.0.0.1 auth2.buddyauth.com 127.0.0.1 www.buddyauth.com");
                        }

                        Process.Start(@"C:\Windows\System32\drivers\etc");

                        break;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
