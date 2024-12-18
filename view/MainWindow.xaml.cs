using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            //https://github.com/Pluser761/Countries/blob/master/Views/MainWindow.xaml DataContext & Locator
            InitializeComponent();
            AddNumberCommand = new RelayCommand(AddNumber, CanAddNumber);
            AddActionCommand = new RelayCommand(Action, CanAction);
            this.DataContext = this;
        }
    }
}
