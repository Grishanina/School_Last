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

namespace School
{
    /// <summary>
    /// Логика взаимодействия для PageService.xaml
    /// </summary>
    public partial class PageService : Page
    {
        public PageService()
        {
            InitializeComponent();
            ClassBase.BD = new Entities2();
            listProduct.ItemsSource = ClassBase.BD.Service.ToList();
        }

        // Сумма со скидкой и проверка на наличие скидки
        private void PricePT_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);

            List<Service> TP = ClassBase.BD.Service.Where(x => x.ID == index).ToList();

            double sum = 0;

            foreach (Service prd in TP)
            {
                if (prd.Discount != 0)
                {
                    sum += Convert.ToDouble(prd.Cost - ((prd.Cost) * (prd.Discount)));
                    tb.Text = sum.ToString("F0") + " рублей за 30 минут";
                }
                else if (prd.Discount == 0)
                {
                    sum += Convert.ToDouble(prd.Cost);
                    tb.Text = sum.ToString("F0");
                }
            }
        }

        // Сумма без скидки (зачеркнутая цена) и проверка на наличие скидки
        private void PriseDiscount_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);

            List<Service> TP = ClassBase.BD.Service.Where(x => x.ID == index).ToList();

            double pr = 0;

            foreach (Service prd in TP)
            {
                if (prd.Discount != 0)
                {
                    pr += Convert.ToDouble(prd.Cost);
                    tb.Text = pr.ToString("F0");
                }
                else if (prd.Discount == 0)
                {
                    tb.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
