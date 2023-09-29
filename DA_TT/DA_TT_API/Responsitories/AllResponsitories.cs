using DA_TT_API.IResponsitories;
using DA_TT_Share.Context;
using Microsoft.EntityFrameworkCore;

namespace DA_TT_API.Responsitories
{
	public class AllResponsitories<T> : IAllResponsitories<T> where T : class
	{
	    private	LapTopDbContext context;
		private DbSet<T> dbset;
        public AllResponsitories()
        {
            
        }
        public AllResponsitories(LapTopDbContext context, DbSet<T> dbset)
        {
            this.context = context;
			this.dbset = dbset;	
        }
        public async Task<bool> CreateItem(T item)
		{
			try
			{
				await dbset.AddAsync(item);
				await context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> DeleteItem(T item)
		{
			try
			{
				dbset.Remove(item);
				await context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<T>> GetAll()
		{
			return await dbset.ToListAsync();
		}

		public async Task<bool> UpdateItem(T item)
		{
			try
			{
				dbset.Update(item);
				await context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
