using System.IO;
using System.Linq;
using BolPatcher.model;

namespace BolPatcher
{
	public sealed class DatabaseManager
	{
		private static DatabaseManager _instance;
		private readonly SqLiteConnection _database;
		public static DatabaseManager Instance => _instance ?? (_instance = new DatabaseManager());

		private DatabaseManager ()
		{
			string fileName = Path.Combine(PathController.Instance.Path, "settigs.db");
			_database = new SqLiteConnection(fileName);
			//_database.DropTable<Game>();
			_database.CreateTable<Game>();

			var count = _database.Table<Game>().ToList();

		}

	

		public void Insert(Game localGame)
		{
            if(!Exists(localGame))
			    _database.Insert(localGame);
		}

		public bool Exists(Game game)
		{
			return _database.Table<Game> ().Any (g => g.GetHashCode() == game.GetHashCode());
		}
			
	}
}

