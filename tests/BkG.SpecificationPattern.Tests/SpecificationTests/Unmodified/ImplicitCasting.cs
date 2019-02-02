using System;
using System.Linq.Expressions;
using Xunit;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Unmodified
{
    public class ImplicitCasting
    {
        protected readonly Specification<bool> specification;

        public ImplicitCasting()
        {
            specification = new Specification<bool>(val => val);
        }

        [Fact]
        public void ToExpressionFuncT_ReturnsBool()
        {
            Expression<Func<bool, bool>> actual = specification;
            
            Assert.NotNull(actual);
        }
    }
}