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
using GameCore;
using GameCore.Managers;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для ViewPort.xaml
    /// </summary>
    public partial class ViewPort : UserControl
    {
        public World World { get; set; }

        private const string saveFile = "gameData\\save.json";

        public ViewPort()
        {
            InitializeComponent();
            Loaded += ViewPort_Loaded;
            
        }
        
        private void ViewPort_Loaded(object sender, RoutedEventArgs e)
        {
            World = new World();
            World.RenderManager = new WPFRenderManager(MainCanvas);

            World.CreateDefaultWorld();
            
            World.BeginSimulation();

            // только объекты, на которых фокусируются, могут перехватывать клавиши
            Focusable = true;
            Keyboard.Focus(this);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            World.InputManager.KeyDown((GameCore.Key)e.Key);
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            World.InputManager.KeyUp((GameCore.Key)e.Key);
            base.OnKeyUp(e);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            World.SaveWorld(saveFile);
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            World.LoadWorld(saveFile);
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            World.CreateDefaultWorld();
        }

        public void Close()
        {
            World.EndSimulation();
        }
    }
}
