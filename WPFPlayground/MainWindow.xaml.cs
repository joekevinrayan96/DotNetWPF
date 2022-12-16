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

    interface IAnimal
    {
        void animalSound(); // interface method (does not have a body)
    }

    class Pig : IAnimal
    {
        public void animalSound()
        {
            // The body of animalSound() is provided here
            Console.WriteLine("The pig says: wee wee");
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Pig myPig = new Pig();  // Create a Pig object
            myPig.animalSound();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello {firstNameText.Text}");
            MessageBox.Show("Hello " + firstNameText.Text);

            
        }
    }

    
}
