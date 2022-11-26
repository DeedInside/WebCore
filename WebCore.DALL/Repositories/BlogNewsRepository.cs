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
        public async Task<bool> Create(BlogNews Entity)
		{
			await _context.BlogNewsSQL.AddAsync(Entity);
			await _context.SaveChangesAsync();

			return true;
        }

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<BlogNews>> GetAll()
		{
            return await _context.BlogNewsSQL.ToListAsync();
        }

		public BlogNews GetRecord(int id)
		{
			throw new NotImplementedException();
		}
	}
}
