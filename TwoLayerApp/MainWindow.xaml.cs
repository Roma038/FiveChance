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

namespace TwoLayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool bWIsActive = true;
        private Button but;
        private BackWindow backWindow;

        public MainWindow()
        {
            
            InitializeComponent();
            
            

        }
        private void Click_Button(object sender, RoutedEventArgs e)
        {
            but = (Button)sender;
            if (but == START)
            {
                backWindow = new BackWindow();
                backWindow.Show();
                backWindow.Owner = this;
                if (backWindow.IsActive == true)
                {
                    this.Hide();
                    bWIsActive = false;
                }
                if (bWIsActive == false)
                {
                    this.Show();
                }
            }
            if (but == options)
            {
                OptionWindow oWindow = new OptionWindow();
                oWindow.Show();
                oWindow.Owner = this;
            }


        }
        
    }
}
