namespace BkG.SpecificationPattern
{
    using System;
    using System.Linq.Expressions;

    public sealed class Specification<T>
    {
        public Specification(Expression<Func<T, bool>> restriction)
        {
            _restriction = restriction 
                            ?? throw new RequiredArgumentNullException(nameof(restriction), "The specification requires knowing what condition is to be met.");
        }

        public bool IsSatisfiedBy(T current) => _restriction.Compile()(current);
        
        private readonly Expression<Func<T, bool>> _restriction;
    }
}