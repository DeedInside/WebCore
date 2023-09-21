using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.DALL.Interfaces;
using WebCore.Domain.Models;

namespace WebCore.DALL.Repositories
{
	public class BlogNewsRepository : IBlogNewsRepository
	{
        private readonly ApplicationContext _context;

        public BlogNewsRepository(ApplicationContext context)
        {
            _context = context;
        }
		/// <summary>
		/// adds an entry to DB
		/// </summary>
		/// <param name="Entity">record blog</param>
		/// <returns></returns>
        public async Task<bool> Create(BlogNews Entity)
		{
			await _context.BlogNewsSQL.AddAsync(Entity);
			await _context.SaveChangesAsync();

			return true;
        }
		/// <summary>
		/// removeat record by id
		/// </summary>
		/// <param name="id">id record</param>
		/// <returns></returns>
		public async Task<bool> Delete(int id)
		{
			var user = await _context.BlogNewsSQL.FirstOrDefaultAsync(u => u.Id == id);
			if(user != null)
			{ 
				_context.BlogNewsSQL.Remove(user);
				await _context.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// return all db BlogNewsSQL
		/// </summary>
		/// <returns></returns>
		public async Task<List<BlogNews>> GetAll()
		{
            return await _context.BlogNewsSQL.ToListAsync();
        }
        /// <summary>
        /// todo: return record in BlogNewsSQL by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public BlogNews GetRecord(int id)
		{
			throw new NotImplementedException();
		}
	}
}
