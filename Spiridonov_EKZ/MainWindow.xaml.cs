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

namespace Spiridonov_EKZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

        }
        Date date = new Date();

        public class Date
        {
            private int editYear;
            public int EditYear
            {
                set
                {
                    if (value > 0)
                    {
                        editYear = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода года");
                    }
                }
                get
                {
                    return editYear;
                }
            }
            private int editMonth;
            public int EditMonth
            {

                set
                {
                    if (value > 0 && value <= 12)
                    {
                        editMonth = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода месяца");
                    }
                }
                get
                {
                    return editMonth;
                }
            }

            private int editDay;
            public int EditDay
            {
                set
                {
                    if ((editMonth == 1 || editMonth == 3 || editMonth == 5 || editMonth == 7 || editMonth == 8 || editMonth == 10 || editMonth == 12) && value <= 31)
                    {
                        editDay = value;
                    }
                    else if ((editMonth == 4 || editMonth == 6 || editMonth == 9 || editMonth == 11) && value <= 30)
                    {
                        editDay = value;
                    }
                    else if ((editYear % 4 == 0 && editMonth == 2 && value <= 29) || (editMonth == 2 && value <= 28))
                    {
                        editDay = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода дня");
                    }
                }
                get
                {
                    return editDay;
                }
            }

            public Date()
            {

            }

            public Date(int day)
            {
                editDay = day;
            }

            public Date(int day, int month)
            {
                editDay = day;
                editMonth = month;
            }

            public Date(int day, int month, int year)
            {
                editDay = day;
                editMonth = month;
                editYear = year;
            }

            public void plusDate(int addDay, int addMonth, int addYear, bool editmode)
            {
                if (editmode == true)
                {

                    if ((EditMonth == 1 || EditMonth == 3 || EditMonth == 5 || EditMonth == 7 || EditMonth == 8 || EditMonth == 10 || EditMonth == 12) && (EditDay + addDay) <= 31)
                    {
                        editDay += addDay;
                    }
                    else if ((EditMonth == 4 || EditMonth == 6 || EditMonth == 9 || EditMonth == 11) && (EditDay + addDay) <= 30)
                    {
                        editDay += addDay;
                    }
                    else if ((EditYear % 4 == 0 && EditMonth == 2 && (EditDay + addDay) <= 29) || (EditMonth == 2 && (EditDay + addDay) <= 28))
                    {
                        editDay += addDay;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода дня");
                    }
                    if (((EditMonth + addMonth) <= 12) || ((EditMonth + addMonth) >= -12))
                    {
                        editMonth += addMonth;

                    }
                    else
                    {
                        throw new Exception("Ошибка ввода месяца");
                    }
                    if ((EditYear + addYear) > 0)
                    {
                        editYear += addYear;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода года");
                    }

                }
            }
        }

        private void btnEditDate_Click(object sender, RoutedEventArgs e)
        {
            date.EditMonth = Convert.ToInt32(tbxMonth.Text);
            date.EditYear = Convert.ToInt32(tbxYear.Text);
            date.EditDay = Convert.ToInt32(tbxDay.Text);
            lblOutputDay.Content = date.EditDay;
            lblOutputMonth.Content = date.EditMonth;
            lblOutputYear.Content = date.EditYear;
        }

        private void btnEditDatePlus_Click(object sender, RoutedEventArgs e)
        {
            bool editMode = true;
            date.plusDate(int.Parse(tbxDayPlus.Text), int.Parse(tbxMonthPlus.Text), int.Parse(tbxYearPlus.Text), editMode);
            lblOutputDay.Content = date.EditDay;
            lblOutputMonth.Content = date.EditMonth;
            lblOutputYear.Content = date.EditYear;
        }
    }
}
