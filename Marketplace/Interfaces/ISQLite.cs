using System;
using SQLite;

namespace Marketplace
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

