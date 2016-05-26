using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{ 
    public delegate void WindowCreateDelegate();

    public partial class MainWindow : Window
    {
        List<EventPreview> news;
        EnterPage enterPage;
        HomePage homePage;
        FriendPage friendPage;
        EventPage eventPage;
        bool isReg;

        public EnterPage EnterPage
        {
            get
            {
                return enterPage;
            }

            set
            {
                enterPage = value;
            }
        }

        public List<EventPreview> News
        {
            get
            {
                return news;
            }

            set
            {
                news = value;
            }
        }

        public event WindowCreateDelegate WindowCreate;

        public MainWindow()
        {
            InitializeComponent();

            AddBackground();
            EnterPage = new EnterPage();
            Head.Children.Add(EnterPage);
        }

        public List<EventPreview> CreateStartWindow(List<DataEventPreview> data)
        {
            EventPreview preview;
            news = new List<EventPreview>();
            for (int i = 0; i < data.Count; i++)
            {
                preview = new EventPreview(data[i]);
                news.Add(preview);
                elementPanel.Children.Add(preview);
            }
            return news;
        }

        public HomePage CreateHomePage(DataUserPage data)
        {
            Head.Children.Remove(enterPage);
            BannerAnimation(true);
            homePage = new HomePage(data, this);
            isReg = true;
            Head.Children.Add(homePage);
            homePage.engine.icon.ExitEvent += ExitFromHomePage;
            return (homePage);
        }

        public void CreateHomePage()
        {
            MessageBox.Show("Щось не так! Перевірте правильність даних, чи зареєструйтеся.");
        }

        private void ExitFromHomePage()
        {
            BannerAnimation(false);
            Head.Children.Add(EnterPage);
        }

        public void CreateFriendPage(DataUserPage data)
        {
            friendPage = new FriendPage(data, this);
            Head.Children.Add(friendPage);
        }

        public EventPage CreateEventPage(List<DataMini> subscribers, List<Bitmap> photos, int eventID)
        {
            eventPage = null;
            foreach(EventPreview p in news)
            {
                if(p.data.EventID == eventID)
                {
                    eventPage = new EventPage(p, this, photos, subscribers, isReg);
                    break;
                }
            }
            grid.Children.Add(eventPage);
            return eventPage;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.GetPosition(this).X >= 1363 && e.GetPosition(this).Y <= 3)
            {
                this.exitButton.Visibility = System.Windows.Visibility.Visible;
            }
            if (e.GetPosition(this).X <= 3 && e.GetPosition(this).Y <= 3)
            {
                this.minimizedButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void exitButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
                exitButton.Visibility = System.Windows.Visibility.Hidden;
                minimizedButton.Visibility = System.Windows.Visibility.Hidden;
        }

        private void minimizedButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void upButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.ScrollToHome();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (WindowCreate != null)
            {
                WindowCreate();
            }

        }

        // My methods

        private void AddBackground()
        {
            Bitmap picture = new Bitmap(@"D:\Bamboleioooo\...пережила\ППЗ\банер.png");
            Bitmap title = new Bitmap(@"D:\Bamboleioooo\...пережила\ППЗ\банер5.png");
            banner.Source = MainWindow.CreateBitmapSourceFromGdiBitmap(picture);
        }

        private void BannerAnimation(bool toTheRight)
        {
            Thickness from = new Thickness();
            from.Left = -284;
            Thickness to = new Thickness();
            to.Left = 700;
            to.Right = -984;
            Thickness toTitle = new Thickness();
            toTitle.Left = 1200;
            toTitle.Right = -1184;
            ThicknessAnimation bannerRightAnimation = new ThicknessAnimation();
            ThicknessAnimation titleRightAnimation = new ThicknessAnimation();
            titleRightAnimation.DecelerationRatio = 0;

            titleRightAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            bannerRightAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            if (toTheRight)
            {
                bannerRightAnimation.From = from;
                bannerRightAnimation.To = to;
                titleRightAnimation.From = from;
                titleRightAnimation.To = toTitle;
                banner.BeginAnimation(MarginProperty, bannerRightAnimation);
            }
            else
            {
                bannerRightAnimation.From = to;
                bannerRightAnimation.To = from;
                titleRightAnimation.From = toTitle;
                titleRightAnimation.To = from;
                banner.BeginAnimation(MarginProperty, bannerRightAnimation);
            }
        }
        
        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}
