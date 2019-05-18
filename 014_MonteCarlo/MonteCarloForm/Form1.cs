using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonteCarloForm
{
    public partial class Form1 : Form
    {
        Timer t1 = new Timer();
        Random r = new Random();
        Graphics g;
        Pen redPen = new Pen(Brushes.Red);
        Pen bluePen = new Pen(Brushes.Blue);
        Pen p;
        private int iCnt = 0;
        private int oCnt = 0;
        private int xCount = 200;
        List<Double> pi = new List<Double>();

        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(10+400+10+400+10, 420+toolStripStatusLabel1.Height);            

            ChartSetting();

            this.Text = "Monte Carlo ... Finding PI";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            g = CreateGraphics();
            p = new Pen(Brushes.SlateBlue);

            //g.FillRectangle(Brushes.White, new Rectangle(10, 10, 400, 400));
            //Invalidate();

            t1.Interval = 1;
            t1.Start();
            t1.Tick += T1_Tick;          
                        
        }

        private void ChartSetting()
        {
            chart1.Location = new Point(420, 10);
            chart1.Size = new Size(400, 400);
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("draw");
            chart1.ChartAreas["draw"].AxisX.Minimum = 0;
            chart1.ChartAreas["draw"].AxisX.Maximum = xCount;   // 최초에 차트 폭은 200으로 함
            chart1.ChartAreas["draw"].AxisX.Interval = xCount / 4;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Black;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].AxisY.Minimum = 2.9;
            chart1.ChartAreas["draw"].AxisY.Maximum = 3.4;
            chart1.ChartAreas["draw"].AxisY.Interval = 0.1;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].CursorX.AutoScroll = true;

            chart1.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            chart1.Series.Clear();
            chart1.Series.Add("PI");
            chart1.Series["PI"].ChartType = SeriesChartType.Line;
            chart1.Series["PI"].Color = Color.SlateBlue;
            chart1.Series["PI"].BorderWidth = 3;
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);

        }
        private int Count = 0;
        private void T1_Tick(object sender, EventArgs e)
        {
            int x = r.Next(400);
            int y = r.Next(400);

            Rectangle rect = new Rectangle(x+10, y+10, 1, 1);

            if ((x - 200) * (x - 200) + (y - 200) * (y - 200) <= 40000)
            {
                iCnt++;
                g.DrawRectangle(redPen, rect);
            }
            else
            {
                g.DrawRectangle(bluePen, rect);
                oCnt++;
            }
            int count = iCnt + oCnt;
            double v = (double)iCnt / count * 4;
            if (count % 100 == 1)
            {
                Count++;
                chart1.Series["PI"].Points.Add(v);
                pi.Add(v);
                // zoom을 위해 100개까지는 기본, 데이터 갯수가 많아지면 100개만 보이지만, 스크롤 나타남
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Maximum = (Count >= xCount) ? Count : xCount;

                if (Count > xCount)
                {
                    chart1.ChartAreas["draw"].AxisX.ScaleView.Zoom(Count - xCount, Count);
                }
                else
                {
                    chart1.ChartAreas["draw"].AxisX.ScaleView.Zoom(0, xCount);
                }
            }
            
            toolStripStatusLabel1.Text = "n = " + count +", In: " + iCnt + ", Out: " + oCnt + ", PI = " + v;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g.FillRectangle(Brushes.White, new Rectangle(10, 10, 400, 400));
            g.DrawRectangle(p, new Rectangle(10, 10, 400, 400));
            g.DrawEllipse(p, new Rectangle(10, 10, 400, 400));
        }

        bool stopOrStart = false;

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (stopOrStart == false)
            {
                t1.Stop();                
                stopOrStart = true;
            }
            else
            {
                t1.Start();
                stopOrStart = false;
            }
        }
    }
}
