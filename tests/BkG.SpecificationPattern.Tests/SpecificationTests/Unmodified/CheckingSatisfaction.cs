using Xunit;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Unmodified
{
    public class CheckingSatisfaction
    {
        protected readonly Specification<bool> specification;

        public CheckingSatisfaction()
        {
            specification = new Specification<bool>(val => val);
        }

        [Fact]
        public void SatisfiedReturnsTrue()
        {
            Assert.True(specification.IsSatisfiedBy(true));
        }

        [Fact]
        public void UnsatisfiedReturnsFalse()
        {
            Assert.False(specification.IsSatisfiedBy(false));
        }
    }
}