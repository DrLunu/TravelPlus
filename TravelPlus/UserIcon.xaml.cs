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

    public partial class UserIcon : UserControl
    {
        public UserIcon(String name, String surname, Random r)
        {
            InitializeComponent();
            Grid.SetZIndex(magicButton, 100);
            Grid.SetZIndex(exitLabel, 101);

            this.icon.Fill = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];

            initial.Content = name.ToCharArray()[0].ToString() + surname.ToCharArray()[0].ToString();
            startLabel.Content = name;
            endLabel.Content = name;
        }

        private void magicButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var p1 = (Grid)this.Parent;
            var p2 = (HomePage)p1.Parent;
            var p3 = (Grid)p2.Parent;
            p3.Children.Remove(p2);
        }
    }
}
