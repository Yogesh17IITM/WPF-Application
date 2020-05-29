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
using System.IO;
using Path = System.IO.Path;

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
        private string DomainType;

        public MainWindow()
        {
            InitializeComponent();
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.CreateNoWindow = true;
            RectangleRB.IsChecked = true;   // Default selection - Rectangle
            DomainType = "Rectangle";
        }

        private void CreateGeometryButton_Click(object sender, RoutedEventArgs e)
        {
            // Display Input Details
            #region Displaying Input details 
            textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + "[INPUT] Geometrical Params: ";
            textBox1.Text += System.Environment.NewLine + "Bottom-Left Point = (" + BLXTextBox.Text + ","+ BLYTextBox.Text + ")";
            textBox1.Text += System.Environment.NewLine + "Top-Right Point = (" + TRXTextBox.Text + "," + TRYTextBox.Text + ")";            
            textBox1.Text += System.Environment.NewLine + "NX = " + NXTextBox.Text;
            textBox1.Text += System.Environment.NewLine + "NY = " + NYTextBox.Text;
            #endregion

            // Start Process
            #region Starting Command Process
            Proc = Process.Start(psi);
            Proc.StandardInput.WriteLine(@"f:");
            Proc.StandardInput.WriteLine(@"dir");
            Proc.StandardInput.WriteLine(@"exit");
            textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + Proc.StandardOutput.ReadToEnd();
            #endregion

            // Writing Inputs to a File   
            #region Writing Inputs to File
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);                        
            string strDomainType = DomainType + Environment.NewLine;
            File.WriteAllText(Path.Combine(docPath, "Input/CreateGeometryInput.txt"), strDomainType);
            string[] lines = { BLXTextBox.Text, BLYTextBox.Text, TRXTextBox.Text, TRYTextBox.Text, NXTextBox.Text, NYTextBox.Text };
            File.AppendAllLines(Path.Combine(docPath, "Input/CreateGeometryInput.txt"), lines);
            #endregion

            // Start Create Geometry .exe
        }

        private void RectangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "[MESSAGE] "+ DomainType + " has been selected !";            
        }       

        private void TriangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DomainType = "Triangle";
            textBox1.Text = "[MESSAGE] " + DomainType + " has been selected !";
        }

        private void textBox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Currently in READ-ONLY mode
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

        private void BLXTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BLXTextBox.Text = string.Empty;
            BLXTextBox.GotFocus -= BLXTextBox_GotFocus;
        }

        private void BLYTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BLYTextBox.Text = string.Empty;
            BLYTextBox.GotFocus -= BLYTextBox_GotFocus;
        }

        private void TRXTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TRXTextBox.Text = string.Empty;
            TRXTextBox.GotFocus -= TRXTextBox_GotFocus;
        }

        private void TRYTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TRYTextBox.Text = string.Empty;
            TRYTextBox.GotFocus -= TRYTextBox_GotFocus;
        }
    }
}