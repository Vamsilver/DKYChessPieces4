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
using ChessCore;

namespace DKYChessPieces4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChessPieces chessPieces;
        ChessPiece currentChess;

        public MainWindow()
        {
            chessPieces = new ChessPieces();
            currentChess = null;
            InitializeComponent();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentChess == null)
            {
               // MessageBox.Show((sender as Label).Content.ToString());
            }
            else
            {
                switch (currentChess.GetName())
                {
                    case "Queen":
                        string coords = (sender as Label).Content.ToString();
                        if (currentChess.TryMoveString(coords))
                        {
                            int x = currentChess.GetX();
                            int y = currentChess.GetY();
                            (GetElementInGridPosition(x,10 - y) as Label).Background = (x + y) % 2 == 0 ? Brushes.Black : Brushes.White;
                            currentChess.Move(coords);
                            UpdateImage("Queen", sender);
                            
                        }
                        break;
                }
            }
        }

        private void UpdateImage(string imageName, object sender)
        {
            var image = (Image)this.FindName(imageName);
            Grid.SetColumn(image, GetColumn(sender));
            Grid.SetRow(image, GetRow(sender));
        }

        private void MenuItemQueen_Click(object sender, RoutedEventArgs e)
        {
            chessPieces.Add(ChessFactory.MakeChess("Queen", "51"));
            Grid.SetColumn(Queen, 5);
            Grid.SetRow(Queen, 9);
            Queen.Visibility = Visibility.Visible;
        }

        private int GetRow(object sender)
        {
            return Grid.GetRow(sender as Label);
        }

        private int GetColumn(object sender)
        {
            return Grid.GetColumn(sender as Label);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = GetElementInGridPosition(Grid.GetColumn(sender as Image),
                Grid.GetRow(sender as Image)) as Label;

            currentChess = ChessFactory.MakeChess((sender as Image).Name,label.Content.ToString());

            label.Background = Brushes.LightGreen;

            //MessageBox.Show(currentChess.GetName());
            //Label_MouseLeftButtonDown((GetElementInGridPosition(Grid.GetColumn(sender as Image), 
            //                                                    Grid.GetRow(sender as Image)) as object), e);
        }

        private UIElement GetElementInGridPosition(int column, int row)
        {
            foreach (UIElement element in this.RootGrid.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }

            return null;
        }
    }
}
