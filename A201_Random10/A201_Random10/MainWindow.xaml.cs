﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace A201_Random10
{
  public partial class MainWindow : Window
  {
    Random r = new Random();
    int[] check = new int[10];
    List<int> lstRandom = new List<int>();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnRand_Click(object sender, RoutedEventArgs e)
    {
      for(int i=0; i<10; i++)
      {
        int v = r.Next(10);
        while(RndCheck(v) == false)
          v = r.Next(10);
        lstRandom.Add(v);        
      }

      foreach (var i in lstRandom)
        lstRand.Items.Add(i);

      btnRandom.IsEnabled = false;
    }

    private bool RndCheck(int v)
    {
      if (check[v] == 0)
      {
        check[v] = 1;
        return true;
      }
      else
        return false;
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      lstRand.Items.Clear();
      for (int i = 0; i < 10; i++)
        check[i] = 0;
      lstRandom.Clear();
      btnRandom.IsEnabled = true;
    }
  }
}
