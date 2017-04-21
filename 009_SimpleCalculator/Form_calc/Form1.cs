using System;
using System.Windows.Forms;

namespace _007_Calculator
{
  public partial class Form1 : Form
  {
    private double savedValue;  // 4칙 연산자를 누르면 txtResult에 있는 값을 저장
    private bool newButton;   // 새로 숫자가 시작되어야 하는 것을 말하는 flag
    private char myOperator;  // 현재 계산할 Operator

    public Form1()
    {
      InitializeComponent();
      txtResult.Text = "0";
    }

    // 숫자 버튼 클릭 이벤트 처리함수
    private void btn_Click(object sender, EventArgs e)
    {
      Button btn = sender as Button;
      string number = btn.Text;
      if (txtResult.Text == "0" || newButton == true)
      {
        txtResult.Text = number;
        newButton = false;
      }
      else
        txtResult.Text = txtResult.Text + number;
    }

    // 소수점 처리
    private void btnDot_Click(object sender, EventArgs e)
    {
      if(txtResult.Text.Contains(".") == false)
        txtResult.Text += ".";
    }

    // operator 4개에 대한 함수를 하나로 쓸 수 있다
    private void btnOp_Click(object sender, EventArgs e)
    {
      Button btn = sender as Button;
      
      savedValue = double.Parse(txtResult.Text);// string의 첫번째 요소 값
      myOperator = btn.Text[0];
      newButton = true;
    }

    private void btnEqual_Click(object sender, EventArgs e)
    {
      // 저장했던 값과 지금 txtResult에 있는 값을 계산해 준다
      if (myOperator == '+')
        txtResult.Text = (savedValue + double.Parse(txtResult.Text)).ToString();
      else if (myOperator == '-')
        txtResult.Text = (savedValue - double.Parse(txtResult.Text)).ToString();
      else if (myOperator == '×')
        txtResult.Text = (savedValue * double.Parse(txtResult.Text)).ToString();
      else if (myOperator == '÷')
        txtResult.Text = (savedValue / double.Parse(txtResult.Text)).ToString();
    }
  }
}

/* 
    // + 버튼
    private void btnPlus_Click(object sender, EventArgs e)
    {
      // 지금 TextResult 값을 저장하고
      // 다음 숫자 버튼이 눌릴때 새로 써지게 해야함
      savedValue = double.Parse(txtResult.Text);
      newButton = true;
      myOperator = '+';
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
      savedValue = double.Parse(txtResult.Text);
      newButton = true;
      myOperator = '-';
    }

    private void btnMulti_Click(object sender, EventArgs e)
    {
      savedValue = double.Parse(txtResult.Text);
      newButton = true;
      myOperator = '*';
    }

    private void btnDivide_Click(object sender, EventArgs e)
    {
      savedValue = double.Parse(txtResult.Text);
      newButton = true;
      myOperator = '/';
    }
*/