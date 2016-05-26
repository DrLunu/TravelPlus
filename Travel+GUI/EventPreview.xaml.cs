using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Travel_GUI
{
    public delegate void OpenEventPageDelegate(int eventID);

    public class EventPreviewEngine
    {
        private DataEventPreview data;
        private Random r;
        public int eventID;

        public EventPreviewEngine(DataEventPreview data)
        {
            this.data = data;
            r = new Random();
            this.eventID = data.EventID;
        }

        public void FillByData(Label LabelEventName, Label contentCategory, Label contentPlace,
                                TextBlock contentDescription, Label number, Label dateLabel)
        {
            //try
            //{
            LabelEventName.Content = data.EventName;
            contentCategory.Content = MyStaticData.IntToCategories(data.Category);
            contentPlace.Content = data.Place;
            contentDescription.Text = data.Description;
            number.Content = data.SubscribersCount;
            dateLabel.Content = DateTime.FromOADate(data.Date).ToString();
            //}
            //catch (Exception)
            //{
            //}
        }

        public void FillByColor(Ellipse PhotoPlace)
        {
            PhotoPlace.Fill = new LinearGradientBrush((MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)]).Color, Colors.White, 90);
        }

        public void FillByPhotos(Ellipse FullSizePhotoPlace, Ellipse MiniPhoto1, Ellipse MiniPhoto2,
                                    Ellipse MiniPhoto3, Ellipse MiniPhoto4)
        {
            try
            {
                FullSizePhotoPlace.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[0]));
                MiniPhoto1.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[1]));
                MiniPhoto2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[2]));
                MiniPhoto3.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[3]));
                MiniPhoto4.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[4]));

                ((ImageBrush)FullSizePhotoPlace.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto1.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto2.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto3.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto4.Fill).Stretch = Stretch.UniformToFill;
            }
            catch (Exception)
            {
            }
        }

        public void PhotoShift(Object sender, Ellipse FullSizePhotoPlace)
        {
            if (((Ellipse)sender).Fill is ImageBrush)
            {
                System.Windows.Media.Brush photoBrush = FullSizePhotoPlace.Fill;
                FullSizePhotoPlace.Fill = ((Ellipse)sender).Fill;
                ((Ellipse)sender).Fill = photoBrush;
            }
        }
    }

    public partial class EventPreview : UserControl
    {
        public event OpenEventPageDelegate openEventPage;

        private EventPreviewEngine engine;
        public DataEventPreview data;

        public EventPreview(DataEventPreview data)
        {
            InitializeComponent();

            this.engine = new EventPreviewEngine(data);
            this.data = data;

            Random r = new Random();

            engine.FillByColor(FullSizePhotoPlace);
            engine.FillByColor(MiniPhoto1);
            engine.FillByColor(MiniPhoto2);
            engine.FillByColor(MiniPhoto3);
            engine.FillByColor(MiniPhoto4);

            List<Control> labels = new List<Control>();
            labels.Add(LabelEventName);
            labels.Add(LabelCategory);
            labels.Add(LabelDescription);
            labels.Add(LabelPlace);
            labels.Add(number);
            MyStaticData.ColoredLabels(labels, new Random());

            engine.FillByPhotos(FullSizePhotoPlace, MiniPhoto1, MiniPhoto2, MiniPhoto3, MiniPhoto4);
            engine.FillByData(LabelEventName, contentCategory, contentPlace, contentDescription, number, dateLabel);
        }

        private void MiniPhoto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            engine.PhotoShift(sender, this.FullSizePhotoPlace);
        }

        private void EventName_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Event_MouseLeftButtonUp();
        }

        public void Event_MouseLeftButtonUp()
        {
            if (openEventPage != null)
            {
                openEventPage(engine.eventID);
            }
        }

        private void MiniPhoto_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Ellipse)sender).Fill is ImageBrush) { ((Ellipse)sender).Cursor = Cursors.Hand; }
        }
    }
}