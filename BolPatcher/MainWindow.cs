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

	private Label _label;

    private void AddWindowContent()
    {
        _label = new Label("Hello World");
		Entry entry = new Entry ();
		Fixed fix = new Fixed ();

		fix.Put (entry, 60, 100);
		fix.Put (_label, 60, 40);
		entry.Changed += OnChanged;

		Add (fix);

    }

	private void OnChanged(object s, EventArgs e)
	{
		_label.Text = ((Entry)s).Text;
	}

}
