using System;
using Gtk;
using BolPatcher;

public partial class MainWindow : Gtk.Window
{
    private Button _addGameWindowButton;
    private Label _tempGameListLabel;
    private MainViewModel _mainViewModel;
    private AddGamesWindow _agWindow;

	private bool _addGameWindowOpen = false;


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        //Build ();

        SetWindowStats();
        AddWindowContent();
        _mainViewModel = new MainViewModel();
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
        _addGameWindowButton = new Button();
        _addGameWindowButton.Clicked += OnAddGame;

        _tempGameListLabel = new Label();
        _tempGameListLabel.Text = "Games will show here once added";

		container.Put (_addGameWindowButton, 20, 20);
        container.Put(_tempGameListLabel, 20, 50);

        Add(container);
    }

    private void OnAddGame(object s, EventArgs e)
    {
		if (_addGameWindowOpen)
			return;
		
        _agWindow = new AddGamesWindow();
        _agWindow.ShowAll();
		_addGameWindowOpen = true;
		((Button)s).Label = "Add Game";
    }


}
