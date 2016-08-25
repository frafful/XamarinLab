using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Marketplace
{
	public class Repository<T> where T : ModelBase, new()
	{
		static object locker = new object(); 
		SQLiteConnection database;

		public Repository()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			//db.CreateTable<TodoItem>();
		}

		public IEnumerable<T> GetItems()
		{
			lock (locker)
			{
				return (from i in database.Table<T>() select i).ToList();
			}
		}

		/*public IEnumerable<T> GetItemsNotDone()
		{
			lock (locker)
			{
				return database.Query<T>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
			}
		}*/

		public T GetItem(int id)
		{
			lock (locker)
			{
				return database.Table<T>().FirstOrDefault(x => x.Id == id);
			}
		}

		public int SaveItem(T item)
		{
			lock (locker)
			{
				if (item.Id != 0)
				{
					database.Update(item);
					return item.Id;
				}
				else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker)
			{
				return database.Delete<T>(id);
			}
		}
	}
}

