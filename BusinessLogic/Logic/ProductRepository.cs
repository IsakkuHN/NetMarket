using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Logic {
    public class ProductRepository : IProductRepository {

        private readonly MarketDbContext _context;

        public ProductRepository(MarketDbContext context) {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync() {
            return await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id) {
            return await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
