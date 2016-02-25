using System;
using Gtk;

namespace BolPatcher
{
    public partial class AddGamesWindow : Gtk.Window
    {
		private Entry _hostPathBox;
        private Entry _pathBox;
		public AddGamesWindowViewModel _agwViewModel;
		private BoolWrapper winOpen;


		public AddGamesWindow(BoolWrapper windowOpen) : base(Gtk.WindowType.Toplevel)
        {
            _agwViewModel = new AddGamesWindowViewModel();
            SetWindowStats();
            AddWindowContent();            
			winOpen = windowOpen;
        }

		protected override void OnDestroyed ()
		{
			winOpen.Value = false;
		}

        private void SetWindowStats()
        {
            //Request size change
            SetSizeRequest(200, 250);

            //Change title
            Title = "Add Game - BolPatcher";

			//Try to set window position
			SetPosition(WindowPosition.Center);
        }

        private void AddWindowContent()
        {
            Label label = new Label("Add game"), titleLabel = new Label("Host address"), saveLabel = new Label("Save path");
            Button btn = new Button();
            _hostPathBox = new Entry();
            _pathBox = new Entry();
            Fixed fix = new Fixed();

            btn.Label = "Add game";
            btn.Clicked += OnAddGame;

            fix.Put(label, 5, 10);
            fix.Put(titleLabel, 5, 30);
            fix.Put(_hostPathBox, 5, 50);
            fix.Put(saveLabel, 5, 80);
            fix.Put(_pathBox, 5, 100);
            fix.Put(btn, 5, 140);

            Add(fix);
        }

        private void OnAddGame(object s, EventArgs e)
        {
			_agwViewModel.AddGame (_pathBox.Text, _hostPathBox.Text);
        }
    }
}
