using System.Collections.Generic;
using Xunit;

namespace BkG.SpecificationPattern.Tests.SpecificationTests.And
{
    public class ExpectedConjunctions
    {
        protected readonly Specification<bool> trueAlways;
        protected const bool PlaceHolder = true;

        public ExpectedConjunctions()
        {
            trueAlways = new Specification<bool>(val => true);
        }

        public static IEnumerable<object[]> AndSpecs =>
            new List<object[]>
            {
                new object[] { new Specification<bool>(val => true), new Specification<bool>(val => false) },
                new object[] { new Specification<bool>(val => false), new Specification<bool>(val => true)},
                new object[] { new Specification<bool>(val => false), new Specification<bool>(val => false) }
            };

        public class UsingMethod : ExpectedConjunctions
        {
            [Fact]
            public void BothTrueReturnTrue()
            {
                var actual = trueAlways.And(trueAlways);

                Assert.True(actual.IsSatisfiedBy(PlaceHolder));
            }

            [Theory]
            [MemberData(nameof(AndSpecs))]
            public void EitherOrBothFalseReturnFalse(Specification<bool> left, Specification<bool> right)
            {
                var actual = left.And(right);

                Assert.False(actual.IsSatisfiedBy(PlaceHolder));
            }
        }

        public class UsingOverload : ExpectedConjunctions
        {
            [Fact]
            public void BothTrueReturnTrue()
            {
                var actual = trueAlways & trueAlways;

                Assert.True(actual.IsSatisfiedBy(PlaceHolder));
            }

            [Theory]
            [MemberData(nameof(AndSpecs))]
            public void EitherOrBothFalseReturnFalse(Specification<bool> left, Specification<bool> right)
            {
                var actual = left & right;

                Assert.False(actual.IsSatisfiedBy(PlaceHolder));
            }
        }
    }
}