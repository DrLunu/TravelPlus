using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Travel_GUI
{
    class FriendPageEngine : UserPageEngine
    {
        private DataUserPage data;
        private Random r;

        public FriendPageEngine(DataUserPage data) : base(data) { }

        public void UserIconSet(Grid grid, Control icon, int userID)
        {
            icon = new FriendIcon(data.Name, data.Surname, userID, r);
            base.UserIconSet(grid, icon);
            icon.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
        }

        public void FillByData(Label nameLabel, Label surnameLabel, Label contentDate, Label contentCity, TextBlock contentCategorys)
        {
            base.FillByData(nameLabel, contentDate, contentCity, contentCategorys);
            surnameLabel.Content = data.Surname;
        }

        public void GridDown(Grid grid, ScrollViewer scrollViewer, Rectangle border)
        {
            Thickness from = new Thickness();
            from.Bottom = 314;
            from.Right = 28;
            Thickness to = new Thickness();
            to.Bottom = 19;
            to.Right = 28;
            ThicknessAnimation downAnimation = new ThicknessAnimation();

            downAnimation.Completed += new EventHandler((o, ex) =>
            {
                scrollViewer.Visibility = Visibility.Hidden;
                border.Visibility = Visibility.Hidden;
            });

            downAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            downAnimation.From = to;
            downAnimation.To = from;
            grid.BeginAnimation(Grid.MarginProperty, downAnimation);
            Thickness from2 = new Thickness();
            from2.Bottom = 100;
            Thickness to2 = new Thickness();
            to2.Bottom = 11;
            downAnimation.From = to2;
            downAnimation.To = from2;
            scrollViewer.BeginAnimation(ScrollViewer.MarginProperty, downAnimation);
            border.BeginAnimation(Border.MarginProperty, downAnimation);
        }

        public void GridUp(Grid grid, ScrollViewer scrollViewer, Rectangle border)
        {
            Thickness from = new Thickness();
            from.Bottom = 314;
            from.Right = 28;
            Thickness to = new Thickness();
            to.Bottom = 19;
            to.Right = 28;
            ThicknessAnimation downAnimation = new ThicknessAnimation();
            downAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            downAnimation.From = from;
            downAnimation.To = to;
            grid.BeginAnimation(Grid.MarginProperty, downAnimation);
            Thickness from2 = new Thickness();
            from2.Bottom = 100;
            Thickness to2 = new Thickness();
            to2.Bottom = 11;
            downAnimation.From = from2;
            downAnimation.To = to2;
            scrollViewer.BeginAnimation(ScrollViewer.MarginProperty, downAnimation);
            border.BeginAnimation(Border.MarginProperty, downAnimation);

            scrollViewer.Visibility = Visibility.Visible;
            border.Visibility = Visibility.Visible;
        }
    }
}
