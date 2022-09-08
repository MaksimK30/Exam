using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kuzmich
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        string RoleName;
        public ShopWindow(User usr)
        {
            InitializeComponent();

            BinBtn.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            ChangeBtn.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            ExitBtn.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            Head.Background = new SolidColorBrush(Color.FromRgb(255, 204, 153));


            switch (usr.UserRole)
            {
                case 1:
                    RoleName = RoleName = " (Гость)";
                    break;

                case 2:
                    RoleName = " (Клиент)";
                    break;

                case 3:
                    RoleName = " (Менеджер)";
                    ChangeBtn.Visibility = Visibility.Visible;
                    break;

                case 4:
                    RoleName = " (Администратор)";
                    ChangeBtn.Visibility = Visibility.Visible;
                    break;


            }
            UName.Text = usr.UserName + " " + usr.UserSurname + RoleName;
        }

    

    private void ExitBtn_Click(object sender, RoutedEventArgs e)
    {
            var W = new MainWindow();
            this.Close();
            W.Show();
    }

    private void ChangeBtn_Click(object sender, RoutedEventArgs e)
    {
            var W = new ChangeWindow();
            this.Close();
            W.Show();
        }

    private void BinBtn_Click(object sender, RoutedEventArgs e)
    {
            var W = new BinWindow();
            this.Close();
            W.Show();
        }
}
}
