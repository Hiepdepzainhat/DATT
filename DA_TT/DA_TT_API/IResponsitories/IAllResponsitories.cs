using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DA_TT_API.IResponsitories
{
	public interface IAllResponsitories<T>
	{
		Task<List<T>> GetAll();
		Task<bool> CreateItem(T item);
		Task<bool> DeleteItem(T item);
		Task<bool> UpdateItem(T item);
	}
}
