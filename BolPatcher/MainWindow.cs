using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private Label _label;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
        //Build ();

        SetWindowStats();
        AddWindowContent();
    }

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

    private void SetWindowStats()
    {
        //Request size change
        SetSizeRequest(300, 150);

        //Change title
        Title = "BolPatcher V 1.0b";
    }



    private void AddWindowContent()
    {
        _label = new Label("Hello World");
		Button btn = new Button ();
		Entry entry = new Entry ();
		Fixed fix = new Fixed ();

		btn.Label = "Add game";
		btn.Clicked += OnAddGame;

		fix.Put (entry, 60, 100);
		fix.Put (_label, 60, 40);
		fix.Put (btn, 60, 0);
		entry.Changed += OnChanged;

		Add (fix);

    }

	private void OnChanged(object s, EventArgs e)
	{
		_label.Text = ((Entry)s).Text;
	}

	private void OnAddGame(object s, EventArgs e)
	{
		((Button)s).Label = "Fuck yes";
	}

}
