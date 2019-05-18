using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MonteCarlo
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    int iCnt = 0;
    int oCnt = 0;
    string s = "";
    
    public MainWindow()
    {
      InitializeComponent();

      Random r = new Random();

      iCnt = 0; oCnt = 0;
      int n = 100000;
      for (int i = 0; i < n; i++)
      {
        Rectangle rect = new Rectangle();
        rect.Width = 1;
        rect.Height = 1;
        rect.Stroke = Brushes.Blue;

        int x = r.Next() % 400;
        int y = r.Next() % 400;

        if ((x - 200) * (x - 200) + (y - 200) * (y - 200) <= 40000)
        {
          rect.Stroke = Brushes.Red;
          iCnt++;
        }
        else
        {
          rect.Stroke = Brushes.Blue;
          oCnt++;
        }
        Canvas.SetLeft(rect, x);
        Canvas.SetTop(rect, y);
        Canvas1.Children.Add(rect);
      }
      s += "N = " + n + ", In : " + iCnt + ", Out : " + oCnt + ", PI = " + (double)iCnt / n * 4 + "\n";
      txtInfo.Text = s;
    }
  }

  //private void StopRestart(object sender, System.Windows.Input.MouseButtonEventArgs e)
  //{
  //  //MessageBox.Show("Clicked");      
  //}
}
