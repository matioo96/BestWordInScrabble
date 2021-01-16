using BestWordInScrabble.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace BestWordInScrabble.Views
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private Point startPoint;
        private void btnToggle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(btnToggle);
        }
        private void btnToggle_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var currentPoint = e.GetPosition(btnToggle);
            if (e.LeftButton == MouseButtonState.Pressed && btnToggle.IsMouseCaptured && (Math.Abs(currentPoint.X - startPoint.X) >
                SystemParameters.MinimumHorizontalDragDistance || Math.Abs(currentPoint.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                btnToggle.ReleaseMouseCapture();
                DragMove();
            }
        }
    }
}
