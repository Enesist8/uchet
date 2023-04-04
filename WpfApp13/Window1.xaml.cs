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
using System.Windows.Shapes;
using WpfApp13.DataSet1TableAdapters;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        zapisTableAdapter eee = new zapisTableAdapter();
        public Window1()
        {
            InitializeComponent();
            okoshko.ItemsSource = eee.GetData();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eee.InsertQuery(aaa.Text);
            okoshko.ItemsSource = eee.GetData();
            (Application.Current.MainWindow as MainWindow).re.ItemsSource=eee.GetData();
        }

        private void okoshko_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
