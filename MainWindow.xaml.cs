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
            // Display Input Details
            textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + "[INPUT] Geometrical Params: ";
            textBox1.Text += System.Environment.NewLine + "Length = " + LengthTextBox.Text;
            textBox1.Text += System.Environment.NewLine + "Height = " + HeightTextBox.Text;
            textBox1.Text += System.Environment.NewLine + "NX = " + NXTextBox.Text;
            textBox1.Text += System.Environment.NewLine + "NY = " + NYTextBox.Text;

            // Start Process
            Proc = Process.Start(psi);
            Proc.StandardInput.WriteLine(@"f:");
            Proc.StandardInput.WriteLine(@"dir");
            Proc.StandardInput.WriteLine(@"exit");
            textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + Proc.StandardOutput.ReadToEnd();

            // TODO: after displaying WRITE INPUTS to a file
            // In C++ side, read inputs and execute
        }
               
        private void RectangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "[MESSAGE] Rectangle has been selected !";
        }       

        private void TriangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "[MESSAGE] Triangle has been selected !";
        }

        private void textBox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Currently in READ-ONLY mode
        }
                
        public void LengthTextBox_GotFocus(object sender, RoutedEventArgs e)
        {            
            LengthTextBox.Text = string.Empty;
            LengthTextBox.GotFocus -= LengthTextBox_GotFocus;
        }

        public void HeightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HeightTextBox.Text = string.Empty;
            HeightTextBox.GotFocus -= HeightTextBox_GotFocus;
        }

        public void NXTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NXTextBox.Text = string.Empty;
            NXTextBox.GotFocus -= NXTextBox_GotFocus;
        }

        public void NYTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NYTextBox.Text = string.Empty;
            NYTextBox.GotFocus -= NYTextBox_GotFocus;
        }
    }
}