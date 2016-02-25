using System;
using Gtk;
using System.Linq;
using BolPatcher;

public partial class MainWindow : Gtk.Window
{
    private Label _tempGameListLabel;
    private MainWindowViewModel _mainViewModel;
    private AddGamesWindow _agWindow;
	private BoolWrapper _addGameWindowOpen = new BoolWrapper(false);


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
        Fixed container = new Fixed();
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
		_agWindow._agwViewModel.ListChanged += delegate {
			_tempGameListLabel.Text = _mainViewModel.GameList.Aggregate(string.Empty, (c, d) => $"{c}{d}\n");
		};

		foreach (var game in _mainViewModel.GameList) {
			Add (new Button{ Label = game.Title });
		}
        _agWindow.ShowAll();
    }
}