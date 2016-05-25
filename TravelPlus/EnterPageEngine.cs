using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Travel_GUI
{
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
                else
                {
                    throw new Exception();
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
                    enterData[0] = enterE_mailTB.Text;
                    enterData[1] = enterPasswordTB.Text;
                }
                else
                {
                    throw new NullReferenceException();
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
}
