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

            query = spec.Includes.Aggregate(query, (current, include)=> current.Include(include));

            return query;
        }
    }
}
