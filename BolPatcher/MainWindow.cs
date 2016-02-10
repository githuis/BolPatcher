using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
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
        Label label = new Label("Hello World");

        Add(label);
    }
}
