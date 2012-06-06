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
using DeCodeString;
using CodeString;


namespace mnemonic_string
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private deCodeString decoder;
        private codeString coder;

        public MainWindow()
        {
            InitializeComponent();
            decoder = new deCodeString();
            coder = new codeString();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String enterString = DeCodeEnterString_TB.Text;
            DeCodeRsult_TB.Text = decoder.mnemogetdecode(enterString);            
        }          
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            String enterString = CodeEnterString_TB.Text;
            CodeRsult_TB.Text = coder.mnemoCode(enterString);
        }
               
    }
}
