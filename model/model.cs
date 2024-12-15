using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace WpfApp2
{
    public partial class MainWindow
    {
        public int numbers = 0;
        public static readonly RoutedCommand AddNumberCommand = new RoutedCommand();

        public void AddNumber(object sender, ExecutedRoutedEventArgs e)
        {
            numbers = numbers * 10 + (int)e.Parameter;
        }
        private void plus(Label a, Label b)
        {
            if (a.ToString() == "")
            {
                MessageBox.Show("Надо что нить написать!", "Error", MessageBoxButton.OK);
            }
        }
    }
}
