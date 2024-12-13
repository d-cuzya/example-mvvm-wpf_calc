using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WpfApp2
{
    public partial class MainWindow
    {
        private void plus(Label a, Label b)
        {
            if (a.ToString() == "")
            {
                MessageBox.Show("Надо что нить написать!", "Error", MessageBoxButton.OK);
            }
        }
    }
}
