using System;
using Gtk;
using System.Linq;
using System.Collections.Generic;
using BolPatcher;

public partial class MainWindow : Gtk.Window
{
    private Label _tempGameListLabel;
    private MainWindowViewModel _mainViewModel;
    private AddGamesWindow _agWindow;
	private BoolWrapper _addGameWindowOpen = new BoolWrapper(false);

	private Fixed container;
	private int height = 100, width = 40;

	private List<Button> btns = new List<Button>();


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        //Build ();

        SetWindowStats();
        AddWindowContent();
        _mainViewModel = new MainWindowViewModel();
        SetPosition(WindowPosition.Center);

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
		container = new Fixed ();
		Button addGameButton = new Button ();
		addGameButton.Label = "Add Games";
		addGameButton.Clicked += OnAddGameClicked;

        _tempGameListLabel = new Label();
        _tempGameListLabel.Text = "Games will show here once added";


        container.Put(_tempGameListLabel, 20, 50);
		container.Put (addGameButton, 20, 20);

        Add(container);
    }

    private void OnAddGameClicked(object s, EventArgs e)
    {
		if (_addGameWindowOpen.Value)
			return;

		_addGameWindowOpen.Value = true;
		_agWindow = new AddGamesWindow(_addGameWindowOpen);
		_agWindow._agwViewModel.ListChanged += delegate
		{
			//_tempGameListLabel.Text = _mainViewModel.GameList.Aggregate(string.Empty, (c, d) => $"{c}{d}\n");
			int len = GameLibrary.Instance.Games.Count;
			Game g = GameLibrary.Instance.Games[len-1];
			//AddGameToMenu(GameLibrary.Instance.Games[len-1]);
			//Add(new MenuGameWidget(g));

			//btns.Add(new Button(){Label = "Gaem"});

			var gameFix = new MyFixed(g);
			container.Put(gameFix, width, height);
			height += 40;


			ShowAll ();
		};

		_agWindow._agwViewModel.AddDownloadCompletedEvent (_agWindow.addGameButton);
			
        _agWindow.ShowAll();
    }

	public class MyFixed : Fixed{
		private Label _label;
		private Button _button;
		private readonly Game _game;

		public MyFixed (Game game)
		{
			_game = game;

			_label = new Label {Text = _game.Title};
			_button = new Button { Label = "Run" };
			_button.Clicked += (sender, e) =>  {
				_game.Launch();
			};

			Put(_button, 0, 0);
			Put(_label, 50, 0);
			
		}
	}
}