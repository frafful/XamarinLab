using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Threading;
using Marketplace.Helpers;

namespace Marketplace
{
	public class Repositorio<T> where T : ModelBase, new()
	{
		static object locker = new object();
        private static readonly AsyncLock lockerAsync = new AsyncLock();

		public Repositorio()
		{
            CriarTodasTabelas();
		}

        public void ExcluirTodasTabelas()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.DropTable<UsuarioModel>();
        }

        public void CriarTodasTabelas()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<UsuarioModel>();
        }

        public async Task CriarTodasTabelasAsync()
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            await db.CreateTableAsync<UsuarioModel>().ConfigureAwait(false);
        }

        public IEnumerable<T> Listar()
		{
            var db = DependencyService.Get<ISQLite>().GetConnection();

            lock (locker)
			{
				return (from i in db.Table<T>() select i).ToList();
			}
		}

        public async Task<IEnumerable<T>> ListarAsync()
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            using (await lockerAsync.LockAsync())
            {
                return await db.Table<T>().ToListAsync();
            }
        }
                
        public T Obter(int id)
		{
            var db = DependencyService.Get<ISQLite>().GetConnection();

            lock (locker)
			{
				return db.Table<T>().FirstOrDefault(x => x.Id == id);
			}
		}

        public async Task<T> ObterAsync(int id)
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            using (await lockerAsync.LockAsync())
            {
                return await db.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public int Salvar(T item)
		{
            var db = DependencyService.Get<ISQLite>().GetConnection();

            lock (locker)
			{
				if (item.Id != 0)
				{
					db.Update(item);
					return item.Id;
				}
				else {
					return db.Insert(item);
				}
			}
		}

        public async Task<int> SalvarAsync(T item)
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            using (await lockerAsync.LockAsync())
            {
                return await db.InsertAsync(item);
            }
        }

        public int Excluir(int id)
		{
            var db = DependencyService.Get<ISQLite>().GetConnection();

            lock (locker)
			{
				return db.Delete<T>(id);
			}
		}

        public async Task<int> ExcluirAsync(int id)
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            using (await lockerAsync.LockAsync())
            {
                return await db.DeleteAsync<T>(id);
            }
        }
    }
}

