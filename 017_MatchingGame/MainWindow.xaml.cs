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
using System.Windows.Threading;

namespace _025_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    Button first;
    Button second;
    DispatcherTimer myTimer = new DispatcherTimer();
    int matched = 0;
    int[] rnd = new int[16];  // 랜덤 숫자가 중복되는지 체크

    public MainWindow()
    {
      InitializeComponent();
      boardSet();
      myTimer.Interval = new TimeSpan(0, 0, 0, 0, 750);
      myTimer.Tick += MyTimer_Tick;
    }

    private void MyTimer_Tick(object sender, EventArgs e)
    {
      myTimer.Stop();

      first.Content = MakeImage("../../Images/check.png");
      second.Content = MakeImage("../../Images/check.png");
      first = null;
      second = null;

    }

    private void boardSet()
    {
      for(int i=0;i<16;i++)
      {
        Button c = new Button();
        c.Background = Brushes.White;
        c.Margin = new Thickness(10);
        c.Content = MakeImage("../../Images/check.png");       
        c.Tag = TagSet();   // 이 문장이 중요, 그림의 인덱스
        c.Click += C_Click;
        board.Children.Add(c);
      }
    }
    
    // 16개 버튼 각각을 인식하는 Tag를 만들어 주는 함수
    private int TagSet()
    {
      int i;
      Random r = new Random();
      while(true)
      {
        i = r.Next(16); // 0~15까지
        if(rnd[i] == 0)
        {
          rnd[i] = 1;
          break;
        }
      }
      return i % 8; // 태그는 0~7까지, 8개의 그림을 표시
    }

    // 버튼의 클릭
    private void C_Click(object sender, RoutedEventArgs e)
    {
      Button btn = sender as Button;

      string[] icon = { "android", "evernote", "Facebook",
        "Google","Instagram","Pinterest","Skype","Twitter" };
      
      btn.Content = MakeImage("../../Images/" + icon[(int)btn.Tag] + ".png");
      
      // 두개의 버튼을 순서대로 눌렀을 때 처리
      // Button first, second
      if(first == null) // 내가 누른 버튼이 첫번째 버튼
      {
        first = btn;
        return;        
      }
      second = btn;

      // 매치가 되었을 때
      if((int)first.Tag == (int)second.Tag)
      {
        first = null;
        second = null;
        matched += 2;
        if (matched >= 16) {
          MessageBoxResult res = MessageBox.Show(
            "성공! 다시?", "Success", MessageBoxButton.YesNo);
          if(res == MessageBoxResult.Yes)
          {
            resetRnd();
            boardReset();
            boardSet();
            matched = 0;
          }
        }
      }
      // 매치가 안되었을 때는 다시 덮어주어야 한다
      else
      {
        myTimer.Start();
      }
    }

    private void boardReset()
    {
      board.Children.Clear();
    }

    // rnd[] 배열 초기화
    private void resetRnd()
    {
      for (int i = 0; i < 16; i++)
        rnd[i] = 0;
    }

    private Image MakeImage(string v)
    {
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      bi.UriSource = new Uri(v, UriKind.Relative);
      bi.EndInit();

      Image myImage = new Image();
      myImage.Margin = new Thickness(10);
      myImage.Stretch = Stretch.Fill;
      myImage.Source = bi;

      return myImage;
    }
  }
}
