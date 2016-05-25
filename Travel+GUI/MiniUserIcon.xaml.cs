using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{
    public delegate void OpenFriendPageDelegate(int userID);

    public partial class MiniUserIcon : UserControl
    {
        int userID;
        public event OpenFriendPageDelegate openFriendPage;

        public MiniUserIcon(DataMini userInformation, Random r)
        {
            InitializeComponent();

            MyStaticData colors = new MyStaticData();
            Grid.SetZIndex(initial, 100);

            this.userID = Convert.ToInt32(userInformation[2]);
            this.iconFill.Fill = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];

            initial.Content = userInformation[0].ToCharArray()[0].ToString() + userInformation[1].ToCharArray()[0].ToString();
            nameLabel.Content = userInformation[0] + " " + userInformation[1];
            startLabel.Content = userInformation[0];
            endLabel.Content = userInformation[0];
        }

        private void friendPage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (var element in ((Grid)((UserControl)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).Parent).Children)
            {
                if (element is FriendPage)
                {
                    ((Grid)((FriendPage)element).Parent).Children.Remove((FriendPage)element);
                }
            }
                if (openFriendPage != null)
            {
                openFriendPage(userID);
            }
        }
    }
}
