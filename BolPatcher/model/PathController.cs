using System;
using System.IO;
using BolPatcher.Internals;

namespace BolPatcher
{
    public sealed class PathController
    {
        public static PathController Instance
        {
            get { return _instance ?? (_instance = new PathController()); }
        }

        private static PathController _instance;

        public string Path { get; private set; }
        public string GamesPath { get { return System.IO.Path.Combine(Path, "games"); } }

        public PathController()
        {
            Path = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(GamesPath);
        }

        /// <summary>
        /// Creates the game directory
        /// </summary>
        /// <returns>The path of the directory.</returns>
        /// <param name="title">Game title</param>
        public string CreateGameDir(string title)
        {
            string path = GamesPath + "/" + title;
            Directory.CreateDirectory(path);

            return path;

        }

        public void UnzipAndDelete(string title)
        {
            using (var unzip = new Unzip(System.IO.Path.Combine(GamesPath, title, "gamedata.zip")))
            {
                unzip.ExtractToDirectory(System.IO.Path.Combine(GamesPath, title));
            }

            File.Delete(System.IO.Path.Combine(GamesPath, title, "gamedata.zip"));
        }
    }
}