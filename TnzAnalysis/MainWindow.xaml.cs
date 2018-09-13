using System;
using System.Collections.Generic;
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

namespace TnzAnalysis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileWorker.OpenFile("C:\\Users\\123\\Desktop\\tnz\\data_tnz\\new1_6_10_253_815.tzh");
            short[][] data = FileWorker.AllChannelsData;
        }

        private void openFileMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
