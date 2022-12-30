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
using WPFPlayground.Extension;

namespace WPFPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int x = 2;

            Console.WriteLine(x.DoubleIt());
            Console.WriteLine(x.MultiplyByGivenValue(3));
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello {firstNameText.Text}");
            MessageBox.Show("Hello " + firstNameText.Text);


        }
    }

    
}
