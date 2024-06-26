﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces {
    public interface IGenericRepository<T> where T : BasicEntity {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWithSpec(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> specification);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
