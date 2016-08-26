using System;
using SQLite.Net;
using SQLite.Net.Async;

namespace Marketplace
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void CloseConnection();
        void DeleteDatabase();
	}
}

