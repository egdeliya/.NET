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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Size = 8;
        private const int MineCount = 8;
        private bool[,] map;

        private int trueSelectCount;
        private int selectCount;
        
        public MainWindow()
        {
            InitializeComponent(); 
            
            Reset();    

        }

        private void Reset()
        {
            trueSelectCount = 0;
            selectCount = 0;
            
            ClearCell();
            CreateCell();
        }

        private void CreateMine()
        {
            var rand= new Random();

            map = new bool[Size,Size];

            var count = 0;
            while (count != MineCount)
            {
                var x = rand.Next(Size);
                var y = rand.Next(Size);

                if (map[x, y] == false)
                {
                    map[x, y] = true;
                    count ++;
                }

            }
        }

        private void CheckWin()
        {
            if (selectCount == MineCount && selectCount == trueSelectCount)
            {
                MessageBox.Show("Eee!");
                Reset();
            }
        }

        private void CreateCell()
        {
            for (int i = 0; i < Size; i++)
            {
                gameMap.RowDefinitions.Add(new RowDefinition());
                gameMap.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var btn = new CellControl(i, j);
                    btn.OnOpenCell += OnOpenCell;
                    btn.OnSelectCell += OnSelectCell;
                    btn.OnUnSelectCell += OnUnSelectCell;

                    gameMap.Children.Add(btn);

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }

            CreateMine();
        }

        private void OnUnSelectCell(CellControl sender)
        {
            if (map[sender.X, sender.Y])
                trueSelectCount--;

            selectCount--;
            CheckWin();
        }

        private void OnSelectCell(CellControl sender)
        {
            if (map[sender.X, sender.Y])
                trueSelectCount++;

            selectCount++;

            CheckWin();
        }

        private void OnOpenCell(CellControl sender)
        {
            if (map[sender.X, sender.Y])
            {
                MessageBox.Show("mine");
                Reset();
                return;
            }

            int count = 0;

            ForeachCell(sender, (x, y) =>
            {
                if (map[x, y])
                    count++;
            });


            if (count == 0)
            {
                ForeachCell(sender, (x, y) => Find(x, y).OpenCell());
            }
            sender.SetMineCount(count);
        }

        private CellControl Find(int x, int y)
        {
            foreach (CellControl cell in gameMap.Children)
            {
                if (cell.X == x && cell.Y == y)
                    return cell;
            }

            return null;
        }

        private void ForeachCell(CellControl centerCell, Action<int, int> Action)
        {
            for (int x = centerCell.X - 1; x <= centerCell.X + 1; x++)
            {
                for (int y = centerCell.Y - 1; y <= centerCell.Y + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= Size || y >= Size)
                        continue;

                    Action.Invoke(x, y);

                }
            }
        }
        private void ClearCell()
        {
            gameMap.RowDefinitions.Clear();
            gameMap.ColumnDefinitions.Clear();

            gameMap.Children.Clear();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClearCell();
            CreateCell();
        }

    }
}
