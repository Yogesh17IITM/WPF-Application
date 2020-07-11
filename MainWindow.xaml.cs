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
        
        private string DomainType;

        public MainWindow()
        {
            InitializeComponent();                     

            #region Setting default variables
            RectangleRB.IsChecked = true;   // Default selection - Rectangle            
            #endregion
        }

        private void CreateGeometryButton_Click(object sender, RoutedEventArgs e)
        {
            // Display Input Details
            #region Displaying Input details 
            textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + "[INPUT]";
            textBox1.Text += System.Environment.NewLine + "Geometrical Params:";
            textBox1.Text += System.Environment.NewLine + "\tBottom-Left Point = (" + BLXTextBox.Text + ","+ BLYTextBox.Text + ")";
            textBox1.Text += System.Environment.NewLine + "\tTop-Right Point = (" + TRXTextBox.Text + "," + TRYTextBox.Text + ")";            
            textBox1.Text += System.Environment.NewLine + "\tNX = " + NXTextBox.Text;
            textBox1.Text += System.Environment.NewLine + "\tNY = " + NYTextBox.Text;
            #endregion

            // Writing Inputs to a File   
            #region Writing Inputs to File
            textBox1.Text += System.Environment.NewLine;
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);                        
            string strDomainType = DomainType + Environment.NewLine;
            File.WriteAllText(Path.Combine(docPath, "Input/CreateGeometryInput.txt"), strDomainType);
            string[] lines = { BLXTextBox.Text, BLYTextBox.Text, TRXTextBox.Text, TRYTextBox.Text, NXTextBox.Text, NYTextBox.Text };
            File.AppendAllLines(Path.Combine(docPath, "Input/CreateGeometryInput.txt"), lines);
            textBox1.Text += System.Environment.NewLine + "[SUCCESS] File created successfully !!!";
            #endregion

            // Start Command Process
            #region Starting Command Process
            //private ProcessStartInfo psi = new ProcessStartInfo("cmd");   // To launch cmd.exe
            //psi.UseShellExecute = false;
            //psi.RedirectStandardOutput = true;
            //psi.RedirectStandardInput = true;
            //psi.CreateNoWindow = true;
            //private Process Proc;
            //Proc = Process.Start(psi);
            //Proc.StandardInput.WriteLine(@"f:");
            //Proc.StandardInput.WriteLine(@"dir");
            //Proc.StandardInput.WriteLine(@"exit");
            //textBox1.Text += System.Environment.NewLine + System.Environment.NewLine + Proc.StandardOutput.ReadToEnd();
            #endregion

            // Launch Create Geometry .exe
            #region Launching application
            textBox1.Text += System.Environment.NewLine;
            textBox1.Text += System.Environment.NewLine + "Creating Geometry...";
            Process Proc = Process.Start(@"E:\GitHub\FluidSimulation\CreatingInterfaceGitHub\GeometryCreation\Geometry\Debug\Geometry.exe");
            textBox1.Text += System.Environment.NewLine;
            textBox1.Text += System.Environment.NewLine + "[SUCCESS] Geometry Created Successfully!!!";
            textBox1.Text += System.Environment.NewLine;
            textBox1.Text += System.Environment.NewLine + "Please check the following directory:";
            textBox1.Text += System.Environment.NewLine + "Path: Documents\\Output\\";
            #endregion
        }

        private void RectangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DomainType = "Rectangle";
            textBox1.Text = "[MESSAGE] " + System.Environment.NewLine;
            textBox1.Text += DomainType + " has been selected !";            
        }       

        private void TriangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DomainType = "Triangle";
            textBox1.Text = "[MESSAGE] " + System.Environment.NewLine;
            textBox1.Text += DomainType + " has been selected !";
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

        private void LaunchParaviewButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += System.Environment.NewLine;
            textBox1.Text += System.Environment.NewLine + "Launching Paraview...";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\ParaView 5.3.0-Qt5-OpenGL2-Windows-64bit\bin\paraview.exe";            
            startInfo.Arguments = @"C:\Users\YOGESH\Documents\Output\InitialStateOfParticles.csv";
            Process.Start(startInfo);   // Do not wait for the user to exit application.
                                        // Since it enables to work parallely. 

            #region Error Handling
            //try
            //{                
            //    // Start the process with the info we specified.
            //    // Call WaitForExit and then the using statement will close.
            //    using (Process exeProcess = Process.Start(startInfo))
            //    {
            //        exeProcess.WaitForExit();
            //    }
            //}
            //catch
            //{
            //    // Log error.
            //}

            // Display this message once paraview is closed
            //textBox1.Text += System.Environment.NewLine;
            //textBox1.Text += System.Environment.NewLine + "Closing Paraview successful !!!";
            #endregion

        }
    }
}