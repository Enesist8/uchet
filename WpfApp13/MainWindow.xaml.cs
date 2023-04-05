using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
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
using WpfApp13.DataSet1TableAdapters;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        zpTableAdapter ggg = new zpTableAdapter();
        zapisTableAdapter eee = new zapisTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            Griddds.ItemsSource = ggg.GetData();
            re.ItemsSource = eee.GetData();
            re.DisplayMemberPath = "tip_zapisi";
            re.SelectedValuePath = "id_zapis";
            kalendarik.SelectedDate = DateTime.Today;
            var money = ggg.GetData();
            int sum = 0;
            for (int i = 0; i < money.Count; i++)
            {
                if (Convert.ToBoolean(money[i][4]))
                {
                    sum += Convert.ToInt32(money[i][3]);
                }
                else
                {
                    sum -= Convert.ToInt32(money[i][3]);
                }
            }
            adada.Text = Convert.ToString(sum);

            Griddds.ItemsSource = ggg.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)re.SelectedValue;
            int a;
            if (Convert.ToInt32(Summa.Text) < 0)
            {
                int b = Convert.ToInt32(Summa.Text) * (-1);
                Summa.Text = Convert.ToString(b);
                ggg.InsertQuery(Name.Text, id, Summa.Text, false);
            }
            else
            {
                ggg.InsertQuery(Name.Text, id, Summa.Text, true);
            }
            var money = ggg.GetData();
            int sum = 0;
            for (int i = 0; i < money.Count; i++)
            {
                if (Convert.ToBoolean(money[i][4]))
                {
                    sum += Convert.ToInt32(money[i][3]);
                }
                else
                {
                    sum -= Convert.ToInt32(money[i][3]);
                }
            }
            adada.Text = Convert.ToString(sum);

            Griddds.ItemsSource = ggg.GetData();
        }
    
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var id = Griddds.SelectedItem as DataRowView;
            if (Convert.ToInt32(Summa.Text) < 0)
            {
                int b = Convert.ToInt32(Summa.Text) * (-1);
                Summa.Text = Convert.ToString(b);
                ggg.UpdateQuery(Name.Text, (int)re.SelectedValue, Summa.Text, false, (int)id.Row[0]);
            }
            else
            {
                ggg.UpdateQuery(Name.Text, (int)re.SelectedValue, Summa.Text, true, (int)id.Row[0]);
            }
            var money = ggg.GetData();
            int sum = 0;
            for (int i = 0; i < money.Count; i++)
            {
                if (Convert.ToBoolean(money[i][4]))
                {
                    sum += Convert.ToInt32(money[i][3]);
                }
                else
                {
                    sum -= Convert.ToInt32(money[i][3]);
                }
            }
            adada.Text = Convert.ToString(sum);

            Griddds.ItemsSource = ggg.GetData();
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = (int)(Griddds.SelectedItem as DataRowView).Row[0];
            ggg.DeleteQuery(id);
            Griddds.ItemsSource = ggg.GetData(); 
            var money = ggg.GetData();
            int sum = 0;
            for (int i = 0; i < money.Count; i++)
            {
                sum += Convert.ToInt32(money[i][3]);
                adada.Text = Convert.ToString(sum);
            }
            Griddds.ItemsSource = ggg.GetData();
        }
    

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            
        }

        private void Griddds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Griddds.SelectedItem != null)
            {
                var grida = Griddds.SelectedItem as DataRowView;
                Name.Text = Convert.ToString(grida.Row[1]);
                Summa.Text = Convert.ToString(grida.Row[3]);
                re.SelectedValue = Convert.ToInt32(grida.Row[2]);   
            }
        }
         private void kalendarik_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
