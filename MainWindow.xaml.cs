using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Kuzmich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string CT;
        public MainWindow()
        {
            
            InitializeComponent();
            Head.Background = new SolidColorBrush(Color.FromRgb(255, 204, 153));
            EnterBtn.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            GuestBtn.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            Captcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
            CT = Captcha.CaptchaText;
        }

        bool CheckCap = false;

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new TradeEntities();
            var User = context.User.Where(u=>u.UserLogin == ULogin.Text && u.UserPassword == UPwd.Password).FirstOrDefault();
            
            if (User != null)
            {
                if (!CheckCap)
                {
                    var W = new ShopWindow(User);
                    this.Close();
                    W.Show();
                }
                else if (CheckCap && CT == CaptchaAnsw.Text)
                {
                    var W = new ShopWindow(User);
                    this.Close();
                    W.Show();
                }
                else
                {
                    Captcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
                    CT = Captcha.CaptchaText;
                    timerfunc();
                }
                

            }
            else
            {
                CheckCap = true;
                Captcha.Visibility = Visibility;
                CaptchaAnsw.Visibility = Visibility;
                Error.Text = "Ошибка !";
                timerfunc();


            }
        }

         async void timerfunc()
        {
            window.IsEnabled = false;
            await Task.Delay(10000);
            window.IsEnabled = true;
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            User usr = new User()
            {
                UserRole = 1,
            };

            var W = new ShopWindow(usr);
            this.Close();
            W.Show();
        }
    }
}
