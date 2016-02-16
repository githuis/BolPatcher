using System;
using Gtk;

namespace BolPatcher
{
    public partial class AddGamesWindow : Gtk.Window
    {
        private Entry _titleBox;
        private Entry _pathBox;
        private AddGamesWindowModel _agwModel;

        public AddGamesWindow() : base(Gtk.WindowType.Toplevel)
        {
            _agwModel = new AddGamesWindowModel();
            SetWindowStats();
            AddWindowContent();
            //SetPosition(WindowPosition.Center);
        }

        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            
        }

        private void SetWindowStats()
        {
            //Request size change
            SetSizeRequest(200, 250);

            //Change title
            Title = "Add Game - BolPatcher";
        }

        private void AddWindowContent()
        {
            Label label = new Label("Add games"), titleLabel = new Label("Game Title"), saveLabel = new Label("Save path");
            Button btn = new Button();
            _titleBox = new Entry();
            _pathBox = new Entry();
            Fixed fix = new Fixed();

            btn.Label = "Add game";
            btn.Clicked += OnAddGame;

            fix.Put(label, 5, 10);
            fix.Put(titleLabel, 5, 30);
            fix.Put(_titleBox, 5, 50);
            fix.Put(saveLabel, 5, 80);
            fix.Put(_pathBox, 5, 100);
            fix.Put(btn, 5, 140);

            Add(fix);
        }

        private void OnAddGame(object s, EventArgs e)
        {
            _agwModel.AddGame(_titleBox.Text, "g", "1");
        }
    }
}
