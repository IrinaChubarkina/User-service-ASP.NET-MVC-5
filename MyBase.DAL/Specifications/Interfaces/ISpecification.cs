using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBase.DAL.Specifications.Interfaces
{
    //public interface ISpecification<T>
    //{
    //    Expression<Func<T, bool>> Criteria { get; }
    //    List<Expression<Func<T, object>>> Includes { get; }
    //}

    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> IsSatisfiedBy();
    }
}
