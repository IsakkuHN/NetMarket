using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic {
    public class ProductRepository : IProductRepository {
        public Task<IReadOnlyList<Product>> GetAllProductsAsync() {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
