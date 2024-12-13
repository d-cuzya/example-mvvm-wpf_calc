using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                // через command parameter wpf
                // https://metanit.com/sharp/wpf/22.4.php
                case "0":
                    labelRes.Content += "0";
                    break;
                case "1":
                    labelRes.Content += "1";
                    break;
                case "2":
                    labelRes.Content += "2";
                    break;
                case "3":
                    labelRes.Content += "3";
                    break;
                case "4":
                    labelRes.Content += "4";
                    break;
                case "5":
                    labelRes.Content += "5";
                    break;
                case "6":
                    labelRes.Content += "6";
                    break;
                case "7":
                    labelRes.Content += "7";
                    break;
                case "8":
                    labelRes.Content += "8";
                    break;
                case "9":
                    labelRes.Content += "9";
                    break;
                case "+":
                    plus(labelRes, labelOld);
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
            }
        }
    }
   
}
