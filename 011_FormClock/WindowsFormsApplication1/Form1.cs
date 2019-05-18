using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    Graphics g;   // Graphics 객체
    private bool aClock_Flag = false; // 아날로그와 디지털 선택
    private Point Center;   // 중심점
    private double radius;  // 반지름
    private int hourHand;   // 시침의 길이
    private int minHand;    // 분침의 길이
    private int secHand;    // 초침의 길이

    private bool milliSec;
    DoubleBufferedPanel panel1 = new DoubleBufferedPanel();
    //Panel panel1 = new Panel();

    public Form1()
    {
      InitializeComponent();
      this.Text = "FormClock";
      this.DoubleBuffered = true;

      //panel1 = new DoubleBufferedPanel();
      panel1.Location = new Point(30, 30);
      panel1.Size = new Size(200, 200);
      this.Controls.Add(panel1);

      //g = panel1.CreateGraphics();
      g = panel1.CreateGraphics();

      //panel1.Width = 200;
      //panel1.Height = 200;

      //panel1.BackColor = Color.White;
      //this.BackColor = Color.White;

      aClockSetting();
      TimerSetting();
    }

    private void TimerSetting()
    {
      if (milliSec == true)
        timer1.Interval = 100; // 0.1초에 한번
      else
        timer1.Interval = 1000;     // 1초에 한번씩

      timer1.Tick += Timer1_Tick;
      timer1.Start();
    }



    private void Timer1_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;
      Font font = new Font("맑은고딕", 12, FontStyle.Bold);
      Font font1 = new Font("맑은고딕", 32, FontStyle.Bold | FontStyle.Italic);
      Brush brush = Brushes.SkyBlue;
      Brush brush1 = Brushes.SteelBlue;

      //panel1.Refresh();
      panel1.Refresh();

      if (aClock_Flag == false)
      {
        string date = DateTime.Today.ToString("D");
        string time = string.Format("{0:D2}:{1:D2}:{2:D2}", c.Hour, c.Minute, c.Second);
        g.DrawString(date, font, brush, new Point(2, 50));
        g.DrawString(time, font1, brush1, new Point(0, 84));
      }
      else
      {
        DrawClockFace(); //시계판 그리기
        double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
        double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
        double radSec;
        if (milliSec == false)
          radSec = (c.Second) * 6 * Math.PI / 180;
        else
          radSec = (c.Second + c.Millisecond / 1000.0) * 6 * Math.PI / 180;

        DrawHands(radHr, radMin, radSec); // 바늘 그리기
      }
    }

    private void DrawHands(double radHr, double radMin, double radSec)
    {
      // 시침
      DrawLine((int)(hourHand * Math.Sin(radHr)), (int)(-hourHand * Math.Cos(radHr)),
          0, 0, Brushes.RoyalBlue, 8, Center.X, Center.Y);
      // 분침
      DrawLine((int)(minHand * Math.Sin(radMin)), (int)(-minHand * Math.Cos(radMin)),
          0, 0, Brushes.SkyBlue, 6, Center.X, Center.Y);
      // 초침
      DrawLine((int)(secHand * Math.Sin(radSec)), (int)(-secHand * Math.Cos(radSec)),
          0, 0, Brushes.OrangeRed, 3, Center.X, Center.Y);

      // 배꼽
      int coreSize = 16;
      Rectangle r = new Rectangle(Center.X - coreSize / 2, Center.Y - coreSize / 2, coreSize, coreSize);
      g.FillEllipse(Brushes.Gold, r);
      Pen p = new Pen(Brushes.DarkRed, 3);
      g.DrawEllipse(p, r);
    }
    private void DrawLine(int x1, int y1, int x2, int y2, Brush color, int thick, int Cx, int Cy)
    {
      Pen pen = new Pen(color, thick);
      pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
      g.DrawLine(pen, x1 + Cx, y1 + Cy, x2 + Cx, y2 + Cy);
    }
    private void DrawClockFace()
    {
      Pen pen = new Pen(Brushes.LightSteelBlue, 30);
      g.DrawEllipse(pen, Center.X - 85, Center.Y - 85, 170, 170);
    }

    // 아날로그 클럭을 그리기 위한 기본 수치 설정
    private void aClockSetting()
    {
      Center = new Point(panel1.Width / 2, panel1.Height / 2);
      radius = panel1.Height / 2;

      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }
    private void 기지털ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      aClock_Flag = false;
    }

    private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      aClock_Flag = true;
    }

    private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void 밀리초단위ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      milliSec = true;
      timer1.Stop();
      TimerSetting();
    }

    private void 초단위ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      milliSec = false;
      timer1.Stop();
      TimerSetting();
    }
  }


  public class DoubleBufferedPanel : Panel
  {
    public DoubleBufferedPanel()
    {
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.UpdateStyles();
      this.DoubleBuffered = true;
    }
  }
}
