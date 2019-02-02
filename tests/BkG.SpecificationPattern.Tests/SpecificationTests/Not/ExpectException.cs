using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Not
{
    public class ExpectException
    {
        protected readonly Specification<bool> specification;

        public ExpectException()
        {
            specification = null;
        }

        [Fact]
        public void SpecificationIsNullUsingOverloadThrowsRequiredArgumentNull()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                var vNegatedSpecification = !specification;
            });
        }
    }
}