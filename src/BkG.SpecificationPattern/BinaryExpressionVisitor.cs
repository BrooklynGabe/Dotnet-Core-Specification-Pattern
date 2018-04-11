using System.Linq.Expressions;

namespace BkG.SpecificationPattern
{
    internal class BinaryExpressionVisitor : ExpressionVisitor
    {
        public BinaryExpressionVisitor(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override Expression Visit(Expression node) => 
            node == _left ? _right : base.Visit(node);

        private readonly Expression _left;
        private readonly Expression _right;
    }
}