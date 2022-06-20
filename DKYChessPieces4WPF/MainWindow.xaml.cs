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
                string coords = (sender as Label).Content.ToString();
                int pastX = currentChess.GetX();
                int pastY = currentChess.GetY();

                switch (currentChess.GetName())
                {
                    case "Queen":
                        if (currentChess.TryMoveString(coords))
                        {
                            MoveChessWithImage("Queen", coords, sender);
                        }
                        break;

                    case "Rook":

                        if (currentChess.TryMoveString(coords))
                        {
                            MoveChessWithImage("Rook", coords, sender);
                        }
                        break;

                    case "Horse":
                        if (currentChess.TryMoveString(coords))
                        {
                            MoveChessWithImage("Horse", coords, sender);
                        }
                        break;

                    case "King":
                        if (currentChess.TryMoveString(coords))
                        {
                            MoveChessWithImage("King", coords, sender);
                        }
                        break;

                    default: 
                        break;
                }

                (GetElementInGridPosition(pastX, 10 - pastY) as Label).Background = (pastX + pastY) % 2 == 0 ? Brushes.Black : Brushes.White;
                currentChess = null;
            }
        }

        private void MoveChessWithImage(string imageName, string coords, object sender)
        {
            currentChess.Move(coords);
            chessPieces.Replace(currentChess);
            UpdateImage(imageName, sender);
        }

        private void UpdateImage(string imageName, object sender)
        {
            var image = (Image)this.FindName(imageName);
            Grid.SetColumn(image, GetColumn(sender));
            Grid.SetRow(image, GetRow(sender));
        }

        private void MenuItemQueen_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click("Queen", 4, 1);
        }

        private void MenuItemRook_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click("Rook", 1, 1);
        }

        private void MenuItemHorse_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click("Horse", 2, 1);
        }

        private void MenuItemKing_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click("King", 5, 1);
        }

        private void MenuItem_Click(string chessName, int x, int y)
        {
            var image = (Image)this.FindName(chessName);

            chessPieces.Add(ChessFactory.MakeChess(chessName, x, y));
            Grid.SetColumn(image, x);
            Grid.SetRow(image, 10 - y);
            image.Visibility = Visibility.Visible;
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
            if (currentChess == null)
            {
                var label = GetElementInGridPosition(Grid.GetColumn(sender as Image),
                    Grid.GetRow(sender as Image)) as Label;

                currentChess = ChessFactory.MakeChess((sender as Image).Name, label.Content.ToString());

                label.Background = Brushes.LightGreen;
            }
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
