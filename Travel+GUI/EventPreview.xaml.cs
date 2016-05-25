using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Travel_GUI
{
    public delegate void OpenEventPageDelegate(int eventID);

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