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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GrowUIElementHorizontally(MyButton, 0, 200, 5);
        }

        public void GrowUIElementHorizontally(UIElement element, int startWidth, int endWidth, int durationSeconds)
        {
            var animation = new DoubleAnimation()
            {
                From = startWidth,
                To = endWidth,
                Duration = new Duration(TimeSpan.FromSeconds(durationSeconds)),
                RepeatBehavior = RepeatBehavior.Forever,
            };
            
            var storyboard = new Storyboard();

            Storyboard.SetTargetProperty(animation, new PropertyPath(WidthProperty));
            Storyboard.SetTarget(animation, element);

            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Hello {NameTextBox.Text}");
        }
    }
}
