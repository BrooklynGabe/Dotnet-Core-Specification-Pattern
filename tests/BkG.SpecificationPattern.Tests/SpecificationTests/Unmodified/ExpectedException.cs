using Xunit;
using System;
using System.Linq.Expressions;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Unmodified
{
    public class ExpectedException
    {
        [Fact]
        public void RestrictionIsNullThrowsRequiredArgumentNull()
        {
            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                var specification = new Specification<bool>(null);
            });
        }
    }
}