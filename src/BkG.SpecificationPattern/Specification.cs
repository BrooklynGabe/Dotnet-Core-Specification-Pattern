namespace BkG.SpecificationPattern
{
    using System;
    using System.Linq.Expressions;

    public sealed class Specification<T>
    {
        public Specification(Expression<Func<T, bool>> restriction)
        {
            _restriction = restriction
                            ?? throw new RequiredArgumentNullException(
                                nameof(restriction), 
                                "The specification requires knowing what condition is to be met.");
        }

        public bool IsSatisfiedBy(T current) => _restriction.Compile()(current);

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification) => specification._restriction;

        public Specification<T> Not() =>
            new Specification<T>(
                Expression.Lambda<Func<T, bool>>(Expression.Not(_restriction.Body), _restriction.Parameters));

        public static Specification<T> operator !(Specification<T> specification) =>
            specification?.Not() 
            ?? throw new RequiredArgumentNullException(
                nameof(specification), 
                "Negating specification requires non-null reference");

        public Specification<T> And(Specification<T> other) => DoBinaryOperation(Expression.AndAlso, this, other, "and");

        public static Specification<T> operator &(Specification<T> specification, Specification<T> other) =>
            specification?.And(other) 
            ?? throw new RequiredArgumentNullException(
                nameof(specification), 
                "The first operand for an And statement cannot be null");

        public Specification<T> Or(Specification<T> other) => DoBinaryOperation(Expression.OrElse, this, other, "or");

        public static Specification<T> operator |(Specification<T> specification, Specification<T> other) =>
            specification?.Or(other) 
            ?? throw new RequiredArgumentNullException(
                nameof(specification), 
                "The first operand for an Or statement cannot be null");

        private Specification<T> DoBinaryOperation(
                Func<Expression, Expression, BinaryExpression> operation,
                Specification<T> left,
                Specification<T> right,
                string operationType
            )
        {
            if(right == null)
            {
                throw new RequiredArgumentNullException(
                    nameof(right), 
                    $"The other operand for an '{operationType}' statement cannot be null");
            }

            var vExpression = Expression.Lambda<Func<T, bool>>(
                operation(
                    new BinaryExpressionVisitor(
                            left._restriction.Parameters[0], right._restriction.Parameters[0]).Visit(left._restriction.Body),
                            right._restriction.Body
                        ),
                    right._restriction.Parameters
                );

            return new Specification<T>(vExpression);
        }

        private readonly Expression<Func<T, bool>> _restriction;
    }
}