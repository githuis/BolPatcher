using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolPatcher
{
    class AddGamesWindowModel
    {
        public void AddGame(string title, string path, string version)
        {
            GameLibrary.Instance.AddGame(title, path, version);
        }
    }
}
