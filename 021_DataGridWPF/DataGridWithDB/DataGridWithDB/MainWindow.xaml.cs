using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace DataGridWithDB
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\강병익\Documents\GitHub\CS\021_DataGridWPF\DataGridWithDB\DataGridWithDB\Students.mdf;Integrated Security=True";
    public MainWindow()
    {
      InitializeComponent();
            
      txtId.IsEnabled = false;
      FillDataGrid();
    }

    private void FillDataGrid()
    {
      string sql = string.Empty;
      using (SqlConnection conn = new SqlConnection(connString))
      {
        sql = "SELECT * FROM StudentTable";
        SqlCommand cmd = new SqlCommand(sql, conn);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable("StudentTable");
        sda.Fill(dt);
        dataGrid.ItemsSource = dt.DefaultView;
      }
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      string sql = string.Empty;
      if (txtSId.Text != "")
        sql = string.Format("SELECT * FROM StudentTable WHERE SID={0}", txtSId.Text);
      else if (txtSName.Text != "")
        sql = string.Format("SELECT * FROM StudentTable WHERE SName=N'{0}'", txtSName.Text);
      else if (txtPhone.Text != "")
        sql = string.Format("SELECT * FROM StudentTable WHERE SPhone=N'{0}'", txtPhone.Text);
      else
        return;

      using (SqlConnection conn = new SqlConnection(connString))
      {
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable("StudentTable");
        sda.Fill(dt);
        dataGrid.ItemsSource = dt.DefaultView;
      }
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
      string sql = string.Empty;
      using (SqlConnection conn = new SqlConnection(connString))
      {
        conn.Open();
        sql = string.Format("INSERT INTO StudentTable(SId, SName, SPhone) VALUES({0}, N'{1}', '{2}')",
          txtSId.Text, txtSName.Text, txtPhone.Text);
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
      }
      FillDataGrid();
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      string sql = string.Empty;
      using (SqlConnection conn = new SqlConnection(connString))
      {
        conn.Open();
        sql = string.Format("UPDATE StudentTable SET SId={0}, SName=N'{1}', SPhone='{2}' WHERE ID={3}",          
          txtSId.Text, txtSName.Text, txtPhone.Text, txtId.Text);
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
      }
      FillDataGrid();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      string sql = string.Empty;
      using (SqlConnection conn = new SqlConnection(connString))
      {
        conn.Open();
        sql = string.Format("DELETE FROM StudentTable WHERE ID={0}", txtId.Text);
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
      }
      FillDataGrid();
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DataGrid dg = sender as DataGrid;
      if (dg.SelectedItem == null)
        return;

      DataRowView drv = dg.SelectedItem as DataRowView;
      txtId.Text = drv.Row[0].ToString();
      txtSId.Text = drv.Row[1].ToString();
      txtSName.Text = drv.Row[2].ToString();
      txtPhone.Text = drv.Row[3].ToString();
    }

    private void btnReadAll_Click(object sender, RoutedEventArgs e)
    {
      FillDataGrid();
    }
  }
}
