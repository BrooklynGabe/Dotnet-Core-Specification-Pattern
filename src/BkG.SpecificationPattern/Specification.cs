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

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification) => specification._restriction;

        public Specification<T> Not() =>
            new Specification<T>(
                Expression.Lambda<Func<T, bool>>(Expression.Not(_restriction.Body), _restriction.Parameters));

        public static Specification<T> operator !(Specification<T> specification) => 
            specification?.Not() ?? throw new RequiredArgumentNullException(nameof(specification), "Negating specification requires non-null reference");
        
        private readonly Expression<Func<T, bool>> _restriction;
    }
}