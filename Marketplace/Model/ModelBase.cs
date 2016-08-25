using System;
using SQLite;

namespace Marketplace
{
	public class ModelBase
	{

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get;
			set;
		}
	}
}

