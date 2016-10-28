using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BolPatcher.model;
using BolPatcher.ViewModel;
using Gtk;

namespace BolPatcher.View
{
    public partial class MainWindow : Window
    {
        private Label _tempGameListLabel;
        private MainWindowViewModel _mainViewModel;
        private AddGamesWindow _agWindow;
        private readonly BoolWrapper _addGameWindowOpen = new BoolWrapper(false);

        private Fixed _container;
        private int _height = 100;
        private readonly int _width = 40;

        private List<Button> _btns = new List<Button>();


        public MainWindow() : base(WindowType.Toplevel)
        {
            //Build ();

            SetWindowStats();
            AddWindowContent();
            _mainViewModel = new MainWindowViewModel();
            SetPosition(WindowPosition.Center);
            Destroyed += (s, e) => Environment.Exit(0);
            Console.WriteLine("Hello");
        }

        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }

        private void SetWindowStats()
        {
            //Request size change
            SetSizeRequest(500, 500);

            //Change title
            Title = "BolPatcher";
        }

        private void AddWindowContent()
        {
            _container = new Fixed ();
            Button addGameButton = new Button ();
            addGameButton.Label = "Add Games";
            addGameButton.Clicked += OnAddGameClicked;

            _tempGameListLabel = new Label();
            _tempGameListLabel.Text = "Games will show here once added";


            _container.Put(_tempGameListLabel, 20, 50);
            _container.Put (addGameButton, 20, 20);

            Add(_container);
        }

        private void OnAddGameClicked(object s, EventArgs e)
        {
            if (_addGameWindowOpen.Value)
                return;

            _addGameWindowOpen.Value = true;
            _agWindow = new AddGamesWindow(_addGameWindowOpen);
            _agWindow.AgwViewModel.ListChanged += delegate
            {
                //_tempGameListLabel.Text = _mainViewModel.GameList.Aggregate(string.Empty, (c, d) => $"{c}{d}\n");
                int len = GameLibrary.Instance.Games.Count;
                Game g = GameLibrary.Instance.Games[len-1];
                DatabaseManager.Instance.Insert(g);
                //AddGameToMenu(GameLibrary.Instance.Games[len-1]);
                //Add(new MenuGameWidget(g));

                //btns.Add(new Button(){Label = "Gaem"});

                var gameFix = new MyFixed(g);
                _container.Put(gameFix, _width, _height);
                _height += 40;


                ShowAll ();
            };

            _agWindow.AgwViewModel.AddDownloadCompletedEvent (_agWindow.AddGameButton);
			
            _agWindow.ShowAll();
        }

        public class MyFixed : Fixed{
            private readonly Label _label;
            private readonly Button _button;
            private readonly Game _game;

            public MyFixed (Game game)
            {
                _game = game;

                _label = new Label {Text = _game.Title};
                _button = new Button { Label = "Run" };
                _button.Clicked += (sender, e) =>  {
                    Task.Run (() => _game.Launch());
                };

                Put(_button, 0, 0);
                Put(_label, 50, 0);
			
            }
        }
    }
}