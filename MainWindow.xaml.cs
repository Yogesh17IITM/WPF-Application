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
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: Launch My Application instead of cmd (May be through .bat)
        private ProcessStartInfo psi = new ProcessStartInfo("cmd");
        private Process Proc;

        public MainWindow()
        {
            InitializeComponent();
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.CreateNoWindow = true;
        }

        private void CreateGeometryButton_Click(object sender, RoutedEventArgs e)
        {   
            Proc = Process.Start(psi);
            Proc.StandardInput.WriteLine(@"f:");
            Proc.StandardInput.WriteLine(@"dir");
            Proc.StandardInput.WriteLine(@"exit");
            textBox1.Text += Proc.StandardOutput.ReadToEnd();
        }
        
        private void RunButton_Click(object sender, RoutedEventArgs e)
        { 
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }       
    }
}
