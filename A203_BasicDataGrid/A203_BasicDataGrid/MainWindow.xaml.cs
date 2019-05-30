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

namespace A203_BasicDataGrid
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      List<Customer> customers = new List<Customer>();
      customers.Add(new Customer { UserID = 190001, UserName = "홍길동", UserSex = "남", UserPhone = "010-1236-5678" });
      customers.Add(new Customer { UserID = 190002, UserName = "성춘향", UserSex = "여", UserPhone = "010-2145-4512" });
      dataGrid.ItemsSource = customers;
    }
  }
}
