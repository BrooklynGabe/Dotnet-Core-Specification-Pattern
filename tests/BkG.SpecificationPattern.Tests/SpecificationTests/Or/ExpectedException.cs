using Xunit;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Or
{
    public class ExpectedException
    {
        [Fact]
        public void OtherIsNullThrowsRequiredArgumentNullUsingMethod()
        {
            var thisSpec = new Specification<bool>(testValue => testValue);

            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                Specification<bool> otherSpec = null;

                var andSpecs = thisSpec.Or(otherSpec);
            });
        }

        [Fact]
        public void ThisIsNullThrowsRequiredArgumentNullUsingOverloadOperator()
        {
            Specification<bool> thisSpec = null;

            Assert.Throws<RequiredArgumentNullException>(() =>
            {
                var otherSpec = new Specification<bool>(testValue => testValue);

                var andSpecs = thisSpec | otherSpec;
            });
        }
    }
}