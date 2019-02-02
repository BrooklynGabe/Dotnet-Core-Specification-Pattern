using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Not
{
    public class ExpectedCompliments
    {
        protected readonly Specification<bool> specification;

        public ExpectedCompliments()
        {
            specification = new Specification<bool>(val => val);
        }

        public class UsingNotMethod : ExpectedCompliments
        {
            [Theory]
            [InlineData(true, false)]
            [InlineData(false, true)]
            public void ReturnsLogicalCompliment(bool input, bool expected)
            {
                var actual = specification.Not();

                Assert.Equal(expected, actual.IsSatisfiedBy(input));
            }
        }

        public class UsingOverloadedOperator : ExpectedCompliments
        {
            [Theory]
            [InlineData(true, false)]
            [InlineData(false, true)]
            public void ReturnsLogicalCompliment(bool input, bool expected)
            {
                var actual = !specification;

                Assert.Equal(expected, actual.IsSatisfiedBy(input));
            }
        }
    }
}