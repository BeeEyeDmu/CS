using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading; // 타이머용

namespace _2015_clock
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool aClock_Flag = false;
        private Point Center;
        private double radius;
        private int hourHand;
        private int minHand;
        private int secHand;

        public MainWindow()
        {
            InitializeComponent();
            aClock_Setting();
            TimerSetting();
        }

        private void aClock_Setting()
        {
            Center = new Point(Canvas1.Width / 2, Canvas1.Height / 2);
            radius = Canvas1.Width / 2;
            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }

        private void TimerSetting()
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // 1초에 한번씩
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now;

            if (aClock_Flag == false)
            {
                Canvas1.Children.Clear();
                string x = "";

                txtDate.Text = DateTime.Today.ToString("D");
                x = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 
                  c.Hour, c.Minute, c.Second, c.Millisecond);
                dClock.Text = x;
            }
            else
            {
                Canvas1.Children.Clear();
                DrawClockFace(); //시계판 그리기
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
                double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
                double radSec = (c.Second + c.Millisecond/1000.0) * 6 * Math.PI / 180;
                DrawHands(radHr, radMin, radSec); // 바늘 그리기
            }
        }

        // 시계 바늘 그리기
        private void DrawHands(double radHr, double radMin, double radSec)
        {
            // 시침
            DrawLine(hourHand * Math.Sin(radHr), -hourHand * Math.Cos(radHr),
                0, 0, Brushes.RoyalBlue, 8, new Thickness(Center.X, Center.Y, 0, 0));
            //분침
            DrawLine(minHand * Math.Sin(radMin), -minHand * Math.Cos(radMin),
                0, 0, Brushes.SkyBlue, 6, new Thickness(Center.X, Center.Y, 0, 0));
            // 초침
            DrawLine(secHand * Math.Sin(radSec), -secHand * Math.Cos(radSec),
                0, 0, Brushes.OrangeRed, 3, new Thickness(Center.X, Center.Y, 0, 0));

            Ellipse core = new Ellipse();
            core.Margin = new Thickness(Canvas1.Width / 2 - 10, 
                Canvas1.Height / 2 - 10, 0, 0);
            core.Stroke = Brushes.SteelBlue;
            core.Fill = Brushes.LightSteelBlue;
            core.Width = 20;
            core.Height = 20;
            Canvas1.Children.Add(core);
        }

        private void DrawLine(double x1, double y1, int x2, int y2, 
            SolidColorBrush color, int thick, Thickness margin)
        {
            Line line = new Line();
            line.X1 = x1; line.Y1 = y1; line.X2 = x2; line.Y2 = y2;
            line.Stroke = color;
            line.StrokeThickness = thick;
            line.Margin = margin;
            line.StrokeStartLineCap = PenLineCap.Round;
            Canvas1.Children.Add(line);
        }

        // 시계 판 그리기
        private void DrawClockFace()
        {
            aClock.Stroke = Brushes.LightSteelBlue;
            aClock.StrokeThickness = 30;
            Canvas1.Children.Add(aClock);
        }

        private void aClock_Click(object sender, RoutedEventArgs e)
        {
            txtDate.Text = "";
            dClock.Text = "";
            aClock_Flag = true;
        }

        private void dClock_Click(object sender, RoutedEventArgs e)
        {
            aClock_Flag = false;
        }
    }
}
