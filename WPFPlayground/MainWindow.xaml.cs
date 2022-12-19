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

namespace WPFPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class BaseClass
    {
        public virtual void SomeMethod()
        {
            Console.WriteLine("In BaseClass.SomeMethod");
        }
    }

    public class DerivedClass : BaseClass
    {
        public override void SomeMethod()
        {
            base.SomeMethod();
            Console.WriteLine("In DerivedClass.SomeMethod");
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DerivedClass d = new DerivedClass();
            d.SomeMethod();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello {firstNameText.Text}");
            MessageBox.Show("Hello " + firstNameText.Text);

            
        }
    }

    
}
