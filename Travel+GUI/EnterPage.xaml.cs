using System;
using System.Collections.Generic;
using System.Drawing;
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
    public delegate void RegistrationDelegate(RegistrationData data);
    public delegate void EnterDelegate(String[] data);

    class EnterPageEngine
    {

        public StringBuilder select;

        public EnterPageEngine()
        {
            this.select = new StringBuilder("00000000");
        }

        public RegistrationData RegistrationDeal(TextBox passwordTB1, TextBox passwordTB2, TextBox nameTB, TextBox surnameTB,
                                                    TextBox dayTB, TextBox monthTB, TextBox yearTB, TextBox contactTB, TextBox cityTB, TextBox e_mailTB)
        {
            RegistrationData data = new RegistrationData();
            try
            {
                if (passwordTB1.Text.Equals(passwordTB2.Text) || nameTB.Text.Equals("") || surnameTB.Text.Equals("")
                     || dayTB.Text.Equals("") || monthTB.Text.Equals("") || yearTB.Text.Equals("")
                      || contactTB.Text.Equals("") || cityTB.Text.Equals("") || passwordTB1.Text.Equals("")
                       || e_mailTB.Text.Equals(""))
                {
                    throw new Exception();
                }
                else
                {
                    data.Name = nameTB.Text;
                    data.Surname = surnameTB.Text;
                    data.Date = (new DateTime(Convert.ToInt32(dayTB.Text.ToString()),
                                                Convert.ToInt32(dayTB.Text.ToString()),
                                                Convert.ToInt32(dayTB.Text.ToString()))).ToOADate();
                    data.Contacts = contactTB.Text;
                    data.City = cityTB.Text;
                    data.Categories = Convert.ToInt32(select);
                    data.Password = passwordTB1.Text;
                    data.E_mail = e_mailTB.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Щось не так :( /n Перевірте чи всі поля заповненні правильно!");
            }
            return data;
        }

        public String[] EnterDeal(TextBox enterE_mailTB, TextBox enterPasswordTB)
        {
            String[] enterData = new String[2];
            try
            {
                if (enterE_mailTB.Text.Equals("") || enterPasswordTB.Text.Equals(""))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    enterData[0] = enterE_mailTB.Text;
                    enterData[1] = enterPasswordTB.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Щось не так :( /n Перевірте чи всі поля заповненні правильно!");
            }
            return enterData;
        }

        public void GridDown(Grid grid)
        {
            Thickness from = new Thickness();
            from.Bottom = 520;
            from.Left = 99;
            Thickness to = new Thickness();
            to.Bottom = 34;
            to.Left = 99;
            ThicknessAnimation downAnimation = new ThicknessAnimation();
            downAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            downAnimation.From = from;
            downAnimation.To = to;
            grid.BeginAnimation(Grid.MarginProperty, downAnimation);
        }

        public void GridUp(Grid grid)
        {
            Thickness from = new Thickness();
            from.Bottom = 520;
            from.Left = 99;
            Thickness to = new Thickness();
            to.Bottom = 34;
            to.Left = 99;
            ThicknessAnimation upAnimation = new ThicknessAnimation();
            upAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            upAnimation.From = to;
            upAnimation.To = from;
            grid.BeginAnimation(Grid.MarginProperty, upAnimation);
        }

        public String CategorySelect(object sender)
        {
            String lbName = ((Label)sender).Name;
            Char[] cArray = lbName.ToCharArray();
            int i = Convert.ToInt16(cArray[1]);
            select.Insert(i - 49, 1);

            return "[" + (String)((Label)sender).Content + "]" + " ";
        }
    }

    public partial class EnterPage : UserControl
    {
        EnterPageEngine engine;

        private bool regIsDown = false;
        private Random r;

        public event RegistrationDelegate Registration;
        public event EnterDelegate Enter;

        public EnterPage()
        {
            InitializeComponent();
            engine = new EnterPageEngine();
            r = new Random();

            //this.arrow.Visibility = System.Windows.Visibility.Hidden;
            this.labelForm.Foreground = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];
            
        }

        private void labelReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (regIsDown)
            {
                if (Registration != null)
                {
                    Registration(engine.RegistrationDeal(passwordTB1, passwordTB2, nameTB, surnameTB, 
                                                            dayTB, monthTB, yearTB, contactTB, cityTB, e_mailTB));
                }
            }
            else
            {
                engine.GridDown(upGrid);
                regIsDown = true;
                //arrow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void enterButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Enter != null)
            {
                Enter(engine.EnterDeal(enterE_mailTB, enterPasswordTB));
            }
        }

        private void upButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (regIsDown)
            {
                engine.GridUp(upGrid);
                regIsDown = false;
                //arrow.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void c_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];
        }

        private void c_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 60, 60, 60));
        }

        private void c_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryTB.Text += engine.CategorySelect(sender);
        }

        private void clear_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!categoryTB.Text.Equals(""))
            {
                categoryTB.Text = categoryTB.Text.Replace(categoryTB.Text.Substring(categoryTB.Text.LastIndexOf("[")), "");
            }
        }

    }
}
