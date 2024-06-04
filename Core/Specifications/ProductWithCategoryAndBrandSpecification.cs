using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications {
    public class ProductWithCategoryAndBrandSpecification : BaseSpecification<Product> {

        public ProductWithCategoryAndBrandSpecification(ProductSpecificationParams productParams)
            : base (x => (!productParams.Brand.HasValue || x.BrandId == productParams.Brand) && 
                         (!productParams.Category.HasValue || x.CategoryId == productParams.Category) ){
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);

            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort)) {
                switch (productParams.Sort) {
                    case "precioAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "precioDesc":
                        AddOrderByDescendent(p => p.Price);
                        break;
                    case "descriptionAsc":
                        AddOrderBy(p => p.Description);
                        break;
                    case "descriptionDesc":
                        AddOrderByDescendent( p => p.Description);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }

            }
        }

        public ProductWithCategoryAndBrandSpecification(int id) : base(x => x.Id == id) {

            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);
        }
    }
}
