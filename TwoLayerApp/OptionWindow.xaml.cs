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
using System.Windows.Shapes;

namespace TwoLayerApp
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// Logic of the difficulty mode locate in this file
    /// </summary>
    public partial class OptionWindow : Window
    {
       private Button optionBut;
       
        public OptionWindow()
        {
            InitializeComponent();
            
        }

        private void option_Click(object sender, RoutedEventArgs e)
        {
            optionBut = (Button)sender;
            if (optionBut == easy)
            {
                BackWindow.Y = 30;
                
            }
            else if (optionBut == normal)
            {
                BackWindow.Y = 40;
                
            }
            else if (optionBut == hard)
            {
                BackWindow.Y = 50;
                
            }
        }
    }
}
