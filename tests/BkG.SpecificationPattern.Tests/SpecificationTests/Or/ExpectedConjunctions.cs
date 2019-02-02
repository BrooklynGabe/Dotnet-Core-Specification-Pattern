using System.Collections.Generic;
using Xunit;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.Or
{
    public class ExpectedDisjunction
    {
        protected readonly Specification<bool> falseAlways;
        protected const bool PlaceHolder = true;

        public ExpectedDisjunction()
        {
            falseAlways = new Specification<bool>(val => false);
        }

        public static IEnumerable<object[]> OrSpecs =>
            new List<object[]>
            {
                new object[] { new Specification<bool>(val => true), new Specification<bool>(val => false) },
                new object[] { new Specification<bool>(val => false), new Specification<bool>(val => true)},
                new object[] { new Specification<bool>(val => true), new Specification<bool>(val => true) }
            };

        public class UsingMethod : ExpectedDisjunction
        {
            [Theory]
            [MemberData(nameof(OrSpecs))]
            public void EitherOrBothTrueReturnTrue(Specification<bool> left, Specification<bool> right)
            {
                var actual = left.Or(right);

                Assert.True(actual.IsSatisfiedBy(PlaceHolder));
            }

            [Fact]
            public void BothFalseReturnsFalse()
            {
                var actual = falseAlways.Or(falseAlways);

                Assert.False(actual.IsSatisfiedBy(PlaceHolder));
            }
        }

        public class UsingOverload : ExpectedDisjunction
        {
            [Theory]
            [MemberData(nameof(OrSpecs))]
            public void EitherOrBothTrueReturnTrue(Specification<bool> left, Specification<bool> right)
            {
                var actual = left | right;

                Assert.True(actual.IsSatisfiedBy(PlaceHolder));
            }

            [Fact]
            public void BothFalseReturnsFalse()
            {
                var actual = falseAlways | falseAlways;

                Assert.False(actual.IsSatisfiedBy(PlaceHolder));
            }
        }
    }
}