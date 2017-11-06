﻿using System;
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
    /// Логика взаимодействия для CellControl.xaml
    /// </summary>
    public partial class CellControl : UserControl
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private CellState state;

        public delegate void CellEventDelegate(CellControl sender);

        public event CellEventDelegate OnOpenCell;
        public event CellEventDelegate OnSelectCell;
        public event CellEventDelegate OnUnSelectCell;

        public CellControl()
        {
            InitializeComponent();
        }

        public CellState State
        {
            get { return state; }
            private set
            {
                state = value;
                switch (state)
                {
                      case CellState.Flag:
                        CellButton.Content = "F";
                        break;
                    case CellState.Note:
                        CellButton.Content = "?";
                        break;
                    default:
                        CellButton.Content = "";
                        break;
                }
            }
        }
        public CellControl(int x, int y)
        {
            InitializeComponent();

            X = x;
            Y = y;

            CellButton.PreviewMouseUp += Cell_MouseUp;
        }

        private void Cell_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {
                OpenCell();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                switch (State)
                {
                    case  CellState.Flag:
                        State = CellState.Note;
                        OnSelectCell.Invoke(this);
                        break;
                    case CellState.None:
                        State = CellState.Flag;
                        break;
                    case CellState.Note:
                        State = CellState.None;
                        OnUnSelectCell.Invoke(this);
                        break;
                }
            }
        }

        public void SetMineCount(int Count)
        {
            CellButton.Content = Count.ToString();
        }

        public void OpenCell()
        {
            if (State != CellState.None)
                return;

            State = CellState.Open;
            CellButton.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));

            OnOpenCell.Invoke(this);
        }
    }
}
