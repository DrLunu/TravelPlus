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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{
    public delegate void SomethingDelegate(int userID);

    public partial class FriendIcon : UserControl
    {

        public event SomethingDelegate Something;

        private int userID;

        public FriendIcon(String name, String surname, int userID, Random r)
        {
            InitializeComponent();
            this.userID = userID;
            Grid.SetZIndex(magicButton, 100);

            this.icon.Fill = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];

            initial.Content = name.ToCharArray()[0].ToString() + surname.ToCharArray()[0].ToString();
            startLabel.Content = name;
            endLabel.Content = name;
        }

        private void magicButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Something != null)
            {
                Something(userID);
            }
        }
    }
}
