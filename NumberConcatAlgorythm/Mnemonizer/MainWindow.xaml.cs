using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coder;
<<<<<<< HEAD
using DataWorker;
using DataWorker.XmlDataWorker;
=======
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

namespace Mnemonizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        private MnemonicCoder coder;// = new MnemonicCoder();
=======
        private MnemonicCoder coder = new MnemonicCoder();
>>>>>>> 550a2d7cd26c001b8e893ffad0908709ce35aa03

        public MainWindow()
        {
            InitializeComponent();
            coder = new MnemonicCoder();
            //coder.DataWorker = new XmlDataWorker();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (rbCode.IsChecked == true)
                textBox2.Text = coder.GetMnemonicString(textBox1.Text);
            else 
                if(rbDecode.IsChecked == true)
                    textBox2.Text = coder.GetOriginalString(textBox1.Text);
        }
    }
}
