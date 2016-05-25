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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{

    public partial class FriendPage : UserControl
    {
        private FriendPageEngine engine;
        private Boolean regIsDown;

        public FriendPage(DataUserPage data)
        {
            InitializeComponent();

            engine = new FriendPageEngine(data);

            engine.UserIconSet(grid, new Control());
            engine.CreateEventlist(eventPanel);
            engine.FillByData(nameLabel, surnameLabel, contentDate, contentCity, contentCategorys);

            List<Control> labels = new List<Control>();
            labels.Add(nameLabel);
            labels.Add(surnameLabel);
            labels.Add(dateLabel);
            labels.Add(cityLabel);
            labels.Add(categoryLabel);
            labels.Add(eventLabel);
            MyStaticData.ColoredLabels(labels, new Random());
        }
        
        private void eventLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (regIsDown)
            {
                engine.GridDown(upGrid, scrollViewer, border);
                regIsDown = false;
            }
            else
            {
                engine.GridUp(upGrid, scrollViewer, border);
                regIsDown = true;
            }
        }

        private void grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((Grid)this.Parent).Children.Remove(this);
        }
    }
    
}
