using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data {
    public class SpecificationEvaluator<T> where T : BasicEntity {

        public static IQueryable<T> GetQuery (IQueryable<T> query, ISpecification<T> spec) {
        
            if (spec.Criteria != null) {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null) {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescendent != null) {
                query = query.OrderByDescending(spec.OrderByDescendent);
            }

            if(spec.IsPagingEnabled) {
                query = query.Skip(spec.Skip).Take(spec.Take); ;
            }

            query = spec.Includes.Aggregate(query, (current, include)=> current.Include(include));

            return query;
        }
    }
}
