using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormCalc
{
    public partial class Form1 : Form
    {
        private double lValue;
        private char op = '\0';
        private bool opFlag = false;
        private double memory;
        private bool memFlag;

        public Form1()
        {
            InitializeComponent();

            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        // 1을 눌렀을 때 처리되는 함수
        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true || memFlag == true)
            {
                txtResult.Text = "1";
                opFlag = false;
                memFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "1";  // txtResult.Text += "1";

            // 3자리마다 쉼표 삽입            
            //double v = Double.Parse(txtResult.Text);
            //txtResult.Text = commaProcedure(v, txtResult.Text);
        }

        // 3자리마다 쉼표 삽입   
        private static string commaProcedure(double v, string s)
        {
            int pos = 0;
            if (s.Contains("."))
            {
                pos = s.Length - s.IndexOf('.');
                if (pos == 1)   // 맨 뒤에 소수점이 있으면
                    return s;
                string formatStr = "{0:N" + (pos - 1) + "}";
                s = string.Format(formatStr, v);
            }
            else
                s = string.Format("{0:N0}", v);
            return s;
        }

        // 소수점 처리
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Contains("."))
                return;
            else
                txtResult.Text += ".";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "2";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "3";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "4";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "5";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "6";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "7";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "8";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "9";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = "0";
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + "0";
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = (-v).ToString();
        }

        // + 버튼
        private void btnPlus_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " + ";
            op = '+';
            opFlag = true;
        }

        // =버튼, 계산 수행하게 됨
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Double rVlaue = Double.Parse(txtResult.Text);
            switch(op)
            {
                case '+':
                    txtResult.Text = (lValue + rVlaue).ToString();
                    break;
                case '-':
                    txtResult.Text = (lValue - rVlaue).ToString();
                    break;
                case '*':
                    txtResult.Text = (lValue * rVlaue).ToString();
                    break;
                case '/':
                    txtResult.Text = (lValue / rVlaue).ToString();
                    break;
            }
            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);

            txtExp.Text = "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " - ";
            op = '-';
            opFlag = true;
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " × ";
            op = '*';
            opFlag = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " ÷ ";
            op = '/';
            opFlag = true;
        }

        // 제곱근 처리
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            txtExp.Text = "√(" + txtResult.Text + ") ";
            txtResult.Text = Math.Sqrt(Double.Parse(txtResult.Text)).ToString();

            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);
        }

        // 제곱 처리
        private void btnSqr_Click(object sender, EventArgs e)
        {
            txtExp.Text = "sqr(" + txtResult.Text + ") ";
            txtResult.Text = (Double.Parse(txtResult.Text) *Double.Parse(txtResult.Text)).ToString();
            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);
        }

        private void btnRecip_Click(object sender, EventArgs e)
        {
            txtExp.Text = "1 / (" + txtResult.Text + ") ";
            txtResult.Text = (1/Double.Parse(txtResult.Text)).ToString();
            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);
        }

        // 지금 txtResult에 있는 값을 0으로
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        // 초기화
        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            txtExp.Text = "";
            lValue = 0;
            op = '\0';
            opFlag = false;
        }

        // 맨 뒤의 한 글자를 지우기
        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
            if (txtResult.Text.Length == 0)
                txtResult.Text = "0";
        }

        // Memory Save
        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(txtResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memFlag = true;
        }

        // Memory Read
        private void btnMR_Click(object sender, EventArgs e)
        {
            txtResult.Text = memory.ToString();
            memFlag = true;
            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);
        }

        // Memory Clear
        private void btnMC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            memory = 0;
            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }

        // M+
        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(txtResult.Text);
        }

        // M-
        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(txtResult.Text);
        }

        // 모든 숫자버튼을 하나로 처리하는 메소드
        private void btn_Click(object sender, EventArgs e)
        {
            // 많이 사용하는 기법이니까 알아야 합니다.
            Button btn = sender as Button;
            string s = btn.Name.Remove(0, 3);   // s = 1, 2, 3, ..., 0

            if (txtResult.Text == "0" || opFlag == true || memFlag == true)
            {
                txtResult.Text = s;
                opFlag = false;
                memFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + s;  // txtResult.Text += "1";

            // 3자리마다 쉼표 삽입            
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = commaProcedure(v, txtResult.Text);
        }
    }
}
