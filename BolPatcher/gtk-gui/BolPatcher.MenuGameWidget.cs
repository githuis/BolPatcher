
// This file has been generated by the GUI designer. Do not modify.

using Gtk;
using Mono.Unix;

namespace BolPatcher
{
	public class MenuGameWidget : Bin
	{
		private Frame _frame1;
		
		private Alignment _gtkAlignment;
		
		private Button _button2;
		
		private Label _gtkLabel1;

		protected virtual void Build ()
		{
			Gui.Initialize (this);
			// Widget BolPatcher.MenuGameWidget
			BinContainer.Attach (this);
			Name = "BolPatcher.MenuGameWidget";
			// Container child BolPatcher.MenuGameWidget.Gtk.Container+ContainerChild
			_frame1 = new Frame ();
			_frame1.Name = "frame1";
			_frame1.ShadowType = 0;
			// Container child frame1.Gtk.Container+ContainerChild
			_gtkAlignment = new Alignment (0F, 0F, 1F, 1F);
			_gtkAlignment.Name = "GtkAlignment";
			_gtkAlignment.LeftPadding = 12;
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			_button2 = new Button ();
			_button2.CanFocus = true;
			_button2.Name = "button2";
			_button2.UseUnderline = true;
			_button2.Label = Catalog.GetString ("GtkButton");
			_gtkAlignment.Add (_button2);
			_frame1.Add (_gtkAlignment);
			_gtkLabel1 = new Label ();
			_gtkLabel1.Name = "GtkLabel1";
			_gtkLabel1.LabelProp = Catalog.GetString ("<b>GtkFrame</b>");
			_gtkLabel1.UseMarkup = true;
			_frame1.LabelWidget = _gtkLabel1;
			Add (_frame1);
			if ((Child != null)) {
				Child.ShowAll ();
			}
			Hide ();
		}
	}
}
