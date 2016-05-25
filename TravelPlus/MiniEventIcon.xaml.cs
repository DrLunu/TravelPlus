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

    public partial class MiniEventIcon : UserControl
    {
        private int eventID;

        public event OpenEventPageDelegate openEventPage;

        public MiniEventIcon(DataMini eventInformation, Bitmap imade)
        {
            InitializeComponent();

            this.eventID = Convert.ToInt32(eventInformation[2]);

            MyStaticData colors = new MyStaticData();

            this.iconFill.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(imade));

            nameLabel.Content = eventInformation[0];
        }

        private void iconStroke_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (openEventPage != null)
            {
                openEventPage(eventID);
            }
        }
    }
}
