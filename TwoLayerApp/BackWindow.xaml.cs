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
    /// Interaction logic for BackWindow.xaml
    /// Gameplay logic of the game be in this file
    /// </summary>
    public partial class BackWindow : Window
    {
        private Button button;
        private TextBlock tblock;
        private TextBlock tblockgreen;
        private int click_amount = 0;
        public int Click_amount { get { return click_amount; } }
        private int green_click_amount = 0;
        public int Green_click_amount { get { return green_click_amount; } }
        private int x;
        private bool isClicked = false;
        private static int y;
        public static int Y { set { y = value; } get { return y; } }
        public BackWindow()
        {
            InitializeComponent();
            try
            {
                tblock = new TextBlock()
                {
                    FontWeight = FontWeights.Bold,
                    FontStyle = FontStyles.Normal,
                    Foreground = Brushes.Black,
                    Background = Brushes.DarkRed
                };
                Grid.SetRow(tblock, 12);
                Grid.SetColumn(tblock, 0);
                Grid.SetColumnSpan(tblock, 6);
                Grid.Children.Add(tblock);

                tblockgreen = new TextBlock()
                {
                    FontWeight = FontWeights.Bold,
                    FontStyle = FontStyles.Normal,
                    Foreground = Brushes.Black,
                    Background = Brushes.DarkGreen
                };
                Grid.SetRow(tblockgreen, 12);
                Grid.SetColumn(tblockgreen, 6);
                Grid.SetColumnSpan(tblockgreen, 6);
                Grid.Children.Add(tblockgreen);

                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        //Creating instanse of the button
                        button = new Button() { Margin = new Thickness(1, 1, 1, 1) };
                        Grid.SetRow(button, i); //buttons positioning in a rows 
                        Grid.SetColumn(button, j); //buttons positioning in a columns
                        tblock.TextWrapping = TextWrapping.Wrap;
                        Image image = new Image();
                        image.Stretch = Stretch.Fill; //Image fills the button
                        image.BeginInit();
                        image.Source = new BitmapImage(new Uri(@"C:\Users\rgurbanov\Pictures\Blue_420x420.png"));
                        image.EndInit();
                        button.Content = image; //Imege adding in the button before click
                        button.Background = Brushes.Blue;
                        Grid.Children.Add(button); //Dynamicly adding buttons to the XAML container "Grid"
                        button.Click += Button_Click_;
                        button.Focusable = false;

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"there is Exception{e}");
            }

        }
        private void Button_Click_(Object sender, RoutedEventArgs e)
        {
            button = (Button)sender;

            Random random = new Random();
            x = random.Next(99);
            isClicked = true;

            if (x < y) //Random spawn of red buttons
            {

                button.Background = Brushes.DarkRed;
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.BeginInit();
                image.Source = new BitmapImage(new Uri(@"C:\Users\rgurbanov\Pictures\red_square.png"));
                image.EndInit();
                button.Content = image;

            }
            else //Random spawn of green buttons
            {
                button.Background = Brushes.DarkGreen;
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.BeginInit();
                image.Source = new BitmapImage(new Uri(@"C:\Users\rgurbanov\Pictures\lnasto_green_square.png"));
                image.EndInit();
                button.Content = image;
            }
            if (button.Background == Brushes.DarkRed)
            {

                tblock.Text = click_amount.ToString();
                if (tblock.Text != null)
                {
                    click_amount = 1 + Convert.ToInt32(tblock.Text);
                    tblock.Text = click_amount.ToString();
                }
                if (click_amount >= 6)
                {
                    LosingWin losingWin = new LosingWin();
                    Image image = new Image();
                    MediaElement mediaElement = new MediaElement();
                    image.Stretch = Stretch.Fill;
                    image.BeginInit();
                    image.Source = new BitmapImage(new Uri(@"C:\Users\rgurbanov\Pictures\neon.jpg"));
                    image.EndInit();
                    losingWin.Content = image;
                    losingWin.Show();
                    Close(); 

                }


            }
            if (button.Background == Brushes.DarkGreen)
            {
                tblockgreen.Text = Green_click_amount.ToString();
                if (tblockgreen.Text != null)
                {
                    green_click_amount = 1 + Convert.ToInt32(tblockgreen.Text);
                    tblockgreen.Text = green_click_amount.ToString();
                }
                if (25 < green_click_amount)
                {
                    WinWindow win = new WinWindow();
                    Image image = new Image();
                    image.Stretch = Stretch.Fill;
                    image.BeginInit();
                    image.Source = new BitmapImage(new Uri(@"C:\Users\rgurbanov\Pictures\win_image_png.png"));
                    image.EndInit();
                    win.Content = image;
                    win.Show();
                    backWindow.Close();
                }
            }
            //If button clicked once, IsEnabled set false
            if (isClicked == true)
            {
                button.IsEnabled = false;
            }
        }    
    }
    
}
